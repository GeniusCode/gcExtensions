using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gcExtensions
{
    public static class DictionaryExtensions
    {
        public static TValue GetOrCreateValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue> createDelegate)
        {
            bool wasCreated;
            return GetOrCreateValue(dictionary, key, createDelegate, out wasCreated);
        }

        public static TValue GetOrCreateValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue> createDelegate, out bool wasCreated)
        {
            TValue output;
            if (dictionary.TryGetValue(key, out output))
            {
                wasCreated = false;
                return output;
            }

            var result = createDelegate();
            dictionary.Add(key, result);
            wasCreated = true;
            return result;
        }

        public static bool AddIfUniqueOrReplace<TInput, TKey>(this IDictionary<TKey, TInput> dictionary, TInput input, TKey key, Func<bool> replacePredicate = null)
        {
            if (AddIfUnique(dictionary, input, key))
                return true;

            if(replacePredicate == null || replacePredicate())
            {
                dictionary[key] = input;
                return true;
            }

            return false;
        }

        public static bool AddIfUnique<TInput, TKey>(this IDictionary<TKey, TInput> dictionary, TInput input, TKey key)
        {
            if (!dictionary.ContainsKey(key))
            {
                dictionary.Add(key, input);
                return true;
            }
            return false;
        }



    }
}
