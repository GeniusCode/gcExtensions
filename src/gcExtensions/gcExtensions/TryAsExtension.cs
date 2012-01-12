using System;
using System.Linq;

namespace gcExtensions
{
    public static class TryAsExtension
    {
        public static bool TryAs<T>(this object input, Action<T> toTry)
            where T : class
        {
            var caster = input as T;
            
            if (caster == null)
                return false;

            toTry(caster);
            return true;
        }

    }
}
