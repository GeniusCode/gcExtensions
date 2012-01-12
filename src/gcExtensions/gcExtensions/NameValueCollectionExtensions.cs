using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace gcExtensions
{
    public static class NameValueCollectionExtensions
    {
        public static string GetOrDefaultValue(this NameValueCollection collection, string key, string otherValue)
        {
            return collection.AllKeys.Contains(key) ? collection[key] : otherValue;
        }

    }
}
