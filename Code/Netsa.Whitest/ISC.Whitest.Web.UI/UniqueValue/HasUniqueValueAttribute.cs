using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISC.Whitest.Web.UI.UniqueValue
{
    public class HasUniqueValueAttribute : Attribute
    {
        public string Key { get; private set; }
        public HasUniqueValueAttribute(string key)
        {
            this.Key = key;
        }
    }
}
