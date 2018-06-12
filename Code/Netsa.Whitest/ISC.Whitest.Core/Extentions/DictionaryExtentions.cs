using System.Collections.Generic;

namespace ISC.Whitest.Core.Extentions
{
    public static class DictionaryExtentions
    {
        public static void AddOrUpdate<TKey, TValue>(this Dictionary<TKey, TValue> targetDictionary, KeyValuePair<TKey, TValue> itemToAdd)
        {
            targetDictionary.AddOrUpdate(itemToAdd.Key,itemToAdd.Value);
        }

        public static void AddOrUpdate<TKey, TValue>(this Dictionary<TKey, TValue> targetDictionary, TKey key, TValue value)
        {
            if (!targetDictionary.ContainsKey(key))
                targetDictionary.Add(key, value);
            else
                targetDictionary[key] = value;
        }
    }
}
