using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISC.Whitest.Web.Core.ValueTransformation
{
    public class TransformedProperty
    {
        public string Key { get; private set; }
        public object OriginalValue { get; private set; }
        public object TransformedValue { get; private set; }
        public TransformedProperty(string key, object originalValue, object transformedValue)
        {
            Key = key;
            OriginalValue = originalValue;
            TransformedValue = transformedValue;
        }

        public bool SameKeyAs(TransformedProperty property)
        {
            return this.Key == property.Key;
        }
    }
}
