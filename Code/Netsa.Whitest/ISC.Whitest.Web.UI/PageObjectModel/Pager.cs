using System;
using System.Collections.Generic;
using System.Linq;

namespace ISC.Whitest.Web.UI.PageObjectModel
{
    public class Pager
    {
        private readonly IPageFactory _factory;
        private readonly Dictionary<Type, object> _cacheDictionary;
        public Pager(IPageFactory factory)
        {
            _factory = factory;
            _cacheDictionary = new Dictionary<Type, object>();
        }
        public T Page<T>() where T : BasePage<T>, new()
        {
            if (HasCreatedPageBefore<T>())
            {
                return GetFromCache<T>();
            }

            var instance = _factory.Create<T>();
            AddToCache<T>(instance);
            return instance;
        }
        private bool HasCreatedPageBefore<T>()
        {
            return _cacheDictionary.ContainsKey(typeof(T));
        }
        private T GetFromCache<T>()
        {
            return (T)_cacheDictionary[typeof(T)];
        }

        private void AddToCache<T>(T instance)
        {
            _cacheDictionary.Add(typeof(T), instance);
        }
    }
}