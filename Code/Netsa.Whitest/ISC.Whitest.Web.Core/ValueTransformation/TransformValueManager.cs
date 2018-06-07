using System;
using System.Collections.Generic;
using System.Linq;

namespace ISC.Whitest.Web.Core.ValueTransformation
{
    public class TransformValueManager
    {
        private readonly List<TransformedProperty> _entities = new List<TransformedProperty>();
        public void Add(TransformedProperty property)
        {
            GuardAgainstDuplicatedEntity(property);
            _entities.Add(property);
        }
        private void GuardAgainstDuplicatedEntity(TransformedProperty property)
        {
            if (EntityWithKeyHasBeenAddedBefore(property))
                throw new Exception($"Duplicate key detected : {property.Key}");
        }
        private bool EntityWithKeyHasBeenAddedBefore(TransformedProperty property)
        {
            return _entities.Any(a => a.SameKeyAs(property));
        }

        public object GetOriginalValueOf(string key)
        {
            var target = _entities.FirstOrDefault(a => a.Key == key);
            if (target == null)
                throw new KeyNotFoundException();
            return target.OriginalValue;
        }

        public List<TransformedProperty> GetTransformedProperties()
        {
            return this._entities.ToList();
        }
    }
}
