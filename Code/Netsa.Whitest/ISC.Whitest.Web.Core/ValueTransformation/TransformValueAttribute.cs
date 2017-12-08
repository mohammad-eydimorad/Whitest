using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISC.Whitest.Web.Core.ValueTransformation
{
    [AttributeUsage(AttributeTargets.Property)]
    public class TransformValueAttribute : Attribute
    {
        public string Key { get; }
        public FieldType Type { get; }

        public TransformValueAttribute(string key, FieldType type)
        {
            Key = key;
            Type = type;
        }
    }
}
