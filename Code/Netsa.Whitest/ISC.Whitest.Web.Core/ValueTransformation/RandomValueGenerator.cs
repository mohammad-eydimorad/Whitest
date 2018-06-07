using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISC.Whitest.Web.Core.ValueTransformation
{
    public static class RandomValueGenerator
    {
        public static object Generate(FieldType type)
        {
            if (type == FieldType.Auto) throw new Exception();

            switch (type)
            {
                case FieldType.Email: return Faker.Internet.Email();
                case FieldType.Username: return Faker.Internet.UserName();
                case FieldType.UnformattedString: return Guid.NewGuid().ToString();
                case FieldType.Number: return Faker.RandomNumber.Next(1, 2147483640);
                case FieldType.Firstname: return Faker.Name.First();
                case FieldType.Lastname: return Faker.Name.Last();
                case FieldType.Guid: return Guid.NewGuid();
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}
