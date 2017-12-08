using System;
using System.Collections.Generic;
using System.Linq;

namespace ISC.Whitest.Web.Core.ValueTransformation
{
    public class ValueTransformationHandler
    {
        private readonly List<Tuple<string, string, string>> _values = new List<Tuple<string, string, string>>();
        public void Add(string key, string realValue, string changedValue)
        {
            if (_values.Any(a=>a.Item1 == key)) throw new Exception($"Duplicate key detected : {key}");
            _values.Add(new Tuple<string, string, string>(key,realValue,changedValue));
        }
        public string GetRealValueOf(string key)
        {
            var target = _values.FirstOrDefault(a => a.Item1 == key);
            if (target == null) throw new KeyNotFoundException();
            return target.Item2;
        }
    }
}
