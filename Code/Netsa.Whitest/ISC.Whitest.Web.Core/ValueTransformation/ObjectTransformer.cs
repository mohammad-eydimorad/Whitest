using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ISC.Whitest.Web.Core.Context;

namespace ISC.Whitest.Web.Core.ValueTransformation
{
    public static class ObjectTransformer
    {
        public static void Transform<T>(T objectToTransform, string key, IScenarioContext context)
        {
            if (!context.ScenarioContainer.IsRegistered<TransformValueManager>()) return;
            var transformValueManager = context.ScenarioContainer.Resolve<TransformValueManager>();
            Transform(objectToTransform, key, transformValueManager);
        }

        public static void Transform<T>(T objectToTransform, IScenarioContext context)
        {
            Transform(objectToTransform, null, context);
        }

        private static void Transform<T>(T objectToTransform, string key, TransformValueManager valueManager)
        {
            var typeOfTClass = typeof(T);
            if (key == null)
                key = typeOfTClass.Name;

            var properties = typeOfTClass.GetProperties();
            foreach (var propertyInfo in properties)
            {
                var transformationAttribute = propertyInfo.GetCustomAttributes(true).OfType<TransformValueAttribute>().FirstOrDefault();
                if (transformationAttribute == null) continue;

                var fieldType = ResolveFieldType(transformationAttribute.FieldType, propertyInfo.PropertyType);
                var newValue = RandomValueGenerator.Generate(fieldType);

                var propertyKey = GeneratePropertyKey(key, propertyInfo.Name);
                var property = new TransformedProperty(propertyKey, propertyInfo.GetValue(objectToTransform), newValue);
                valueManager.Add(property);
                propertyInfo.SetValue(objectToTransform, newValue);
            }
        }

        private static FieldType ResolveFieldType(FieldType fieldType, Type propertyType)
        {
            if (fieldType != FieldType.Auto) return fieldType;
            return AutoFieldTypeResolver.GetProperFieldType(propertyType);
        }

        public static string GeneratePropertyKey(string key, string propertyName)
        {
            return $"{key}_{propertyName}";
        }

       
    }
}
