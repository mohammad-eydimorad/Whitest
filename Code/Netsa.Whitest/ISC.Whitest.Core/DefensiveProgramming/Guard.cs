using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISC.Whitest.Core.DefensiveProgramming
{
    public static class Guard
    {
        public static class Against
        {
            public static void NullArgument(object argValue, string argName = "")
            {
                if (argValue == null)
                    throw new ArgumentNullException(argName);
            }
            public static void NullOrEmptyEnumerable(IEnumerable argValue, string argName = "Enumerable")
            {
                NullArgument(argValue, argName);

                if (!argValue.GetEnumerator().MoveNext())
                    throw new ArgumentException("Argument was empty", argName);
            }
            public static void NullOrWhiteSpaceString(string argument, string argumentName = "string")
            {
                if (string.IsNullOrWhiteSpace(argument))
                {
                    throw new ArgumentException($"{argumentName} is null or whitespace", argumentName);
                }
            }
        }
    }
}
