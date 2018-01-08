using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISC.Whitest.Core.DefensiveProgramming
{
    public static class Ensure
    {
        public static class That
        {
            public static void CollectionHasBeenInitialized<T>(ref List<T> enumerable)
            {
                if (enumerable == null) enumerable = new List<T>();
            }

            public static void CollectionHasBeenInitialized<T>(ref T[] array)
            {
                if (array == null) array = new T[] {};
            }
        }
    }
}
