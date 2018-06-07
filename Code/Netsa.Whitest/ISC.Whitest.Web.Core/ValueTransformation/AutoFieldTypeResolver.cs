using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISC.Whitest.Core.Extentions;

namespace ISC.Whitest.Web.Core.ValueTransformation
{
    public static class AutoFieldTypeResolver
    {
        public static FieldType GetProperFieldType(Type typeOfProperty)
        {
            if (typeOfProperty.IsNumeric()) return FieldType.Number;
            if (typeOfProperty.IsGuid()) return FieldType.Guid;
            return FieldType.UnformattedString;
        }
    }
}
