using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ISC.Whitest.Web.Core.Context;
using ISC.Whitest.Web.Core.ValueTransformation;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ISC.Whitest.Web.Core.SpecflowExtentions
{
    public static class TableExtentions
    {
        public static T CreateInstance<T>(this Table table, string key, IScenarioContext context)
        {
            var output = table.CreateInstance<T>();
            ObjectTransformer.Transform(output, key, context);
            return output;
        }

       

        public static List<T> ConvertTableToList<T>(this Table table) where T : new()
        {
            var convertedItems = new List<T>();
            var typeOfOutputObject = typeof(T);

            foreach (var row in table.Rows)
            {
                var obj = new T();
                foreach (var colName in row.Keys)
                {
                    if (string.IsNullOrWhiteSpace(row[colName])) continue;
                    var propertyInfo = typeOfOutputObject.GetProperty(colName.Replace(" ", string.Empty));
                    if (propertyInfo == null) continue;

                    var valueOfField = row[colName];
                    SetValueOnProperty(propertyInfo, obj, valueOfField);
                }
                convertedItems.Add(obj);
            }
            return convertedItems;
        }
        private static void SetValueOnProperty<T>(PropertyInfo propertyInfo, T obj, string valueOfField) where T : new()
        {

            if (propertyInfo.PropertyType == typeof(int) || propertyInfo.PropertyType == typeof(int?))
                propertyInfo.SetValue(obj, int.Parse(valueOfField));
            else
                propertyInfo.SetValue(obj, valueOfField);
        }

       
    }
}
