using System;
using System.Collections.Generic;

namespace BinaryTree
{
    public interface IBinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        int Count { get; }
        void Add(T value);
        bool Contains(T value);
        bool Remove(T value);
    }
}
