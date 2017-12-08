using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISC.Whitest.Web.Core.ValueTransformation
{
    public static class RandomValueGenerator
    {
        public static string Generate(FieldType type)
        {
            switch (type)
            {
                case FieldType.Email: return Faker.Internet.Email();
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

        }
    }
}
