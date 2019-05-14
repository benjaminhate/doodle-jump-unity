using UnityEngine;
using System.Collections.Generic;

namespace Tools
{
    public static class CommonHelper
    {
        public static T GetRandom<T>(this T[] list)
        {
            return list[Random.Range(0, list.Length)];
        }
        public static T GetRandom<T>(this IList<T> list)
        {
            return list[Random.Range(0, list.Count)];
        }
    }
}
