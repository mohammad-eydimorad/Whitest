using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISC.Whitest.Core.Extentions
{
    public static class TypeExtentions
    {
        public static bool IsNumeric(this Type type)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                case TypeCode.Object:
                    if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        return Nullable.GetUnderlyingType(type).IsNumeric();
                    }
                    return false;
                default:
                    return false;
            }
        }

        public static bool IsString(this Type type)
        {
            return type == typeof(string);
        }

        public static bool IsGuid(this Type type)
        {
            return typeof(Guid) == type ||
                   typeof(Guid?) == type;
        }
    }
}
