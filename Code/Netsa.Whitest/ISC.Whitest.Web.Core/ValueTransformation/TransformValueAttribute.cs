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
        public FieldType FieldType { get; }
        public TransformValueAttribute(FieldType fieldType = FieldType.Auto)
        {
            this.FieldType = fieldType;
        }
    }
}
