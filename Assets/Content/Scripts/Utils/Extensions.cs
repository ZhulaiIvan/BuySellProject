using System;
using System.Collections.Generic;

namespace Content.Scripts.Utils
{
    public static class Extensions
    {
        public static void Each<T>(this IEnumerable<T> array, Action<T> action)
        {
            foreach (T item in array) 
                action?.Invoke(item);
        }
    }
}