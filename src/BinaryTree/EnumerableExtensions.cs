using System;
using System.Collections.Generic;

namespace BinaryTree
{
    public static class EnumerableExtensions
    {
        public static void PrintToConsole<T>(this IEnumerable<T> source)
        {
            foreach (var item in source)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
