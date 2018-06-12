using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISC.Whitest.Core.Extentions
{
    public static class DataRowExtentions
    {
        public static T ValueOfCell<T>(this DataRow row, string columnName)
        {
            var value = row[columnName];
            var typeOfT = typeof(T);
            return (T)Convert.ChangeType(value, typeOfT);
        }
    }
}
