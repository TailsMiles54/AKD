using System;
using System.Collections.Generic;
using System.Linq;

namespace Utils
{
    public static class Utils
    {
        public static T ThrowIfArgumentNull<T>(this T argument) where T : class
        {
            if (argument == null)
            {
                throw new ArgumentNullException($"Name of type - {typeof(T).Name}");
            }

            return argument;
        }
    
        public static T GetRandomElement<T>(this IList<T> list)
        {
            return list[UnityEngine.Random.Range(0, list.Count-1)];
        }
    
        public static List<T> GetRandomElements<T>(this IList<T> list, int count)
        {
            var shuffledList = list.OrderBy(x => UnityEngine.Random.Range(0, 1f)).ToList();
            return shuffledList.Take(count).ToList();
        }
    }
}