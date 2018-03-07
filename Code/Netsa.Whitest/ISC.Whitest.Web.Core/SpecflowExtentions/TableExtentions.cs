using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISC.Whitest.Web.Core.ValueTransformation;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ISC.Whitest.Web.Core.SpecflowExtentions
{
    public static class TableExtentions
    {
        public static T CreateInstance<T>(this Table table, ScenarioContext context)
        {
            var output = table.CreateInstance<T>();
            HandleValueTransformation(output, context);
            return output;
        }

        public static List<T> ConvertTableToList<T>(this Table table) where T : new()
        {
            var convertTableToList = new List<T>();
            var objType = typeof(T);
            foreach (var row in table.Rows)
            {
                var obj = new T();
                foreach (var colName in row.Keys)
                {
                    if (string.IsNullOrWhiteSpace(row[colName])) continue;
                    var propertyInfo = objType.GetProperty(colName.Replace(" ", string.Empty));
                    if (propertyInfo == null) continue;
                    //TODO: get parse method from type with reflection
                    if (propertyInfo.PropertyType == typeof(int) || propertyInfo.PropertyType == typeof(int?))
                        propertyInfo.SetValue(obj, int.Parse(row[colName]));
                    else
                        propertyInfo.SetValue(obj, row[colName]);
                }
                convertTableToList.Add(obj);
            }
            return convertTableToList;
        }

        private static void HandleValueTransformation<T>(T output, ScenarioContext context)
        {
            if (!context.ScenarioContainer.IsRegistered<ValueTransformationHandler>()) return;

            var handler = context.ScenarioContainer.Resolve<ValueTransformationHandler>();
            var properties = typeof(T).GetProperties();
            foreach (var propertyInfo in properties)
            {
                var transformationAttribute = propertyInfo.GetCustomAttributes(true).OfType<TransformValueAttribute>().FirstOrDefault();
                if (transformationAttribute != null)
                {
                    var newValue = RandomValueGenerator.Generate(transformationAttribute.Type);

                    handler.Add(transformationAttribute.Key, propertyInfo.GetValue(output).ToString(), newValue);
                    propertyInfo.SetValue(output, newValue);
                }
            }
        }


    }
}
