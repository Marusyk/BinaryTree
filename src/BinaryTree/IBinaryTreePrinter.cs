using System;
using System.Collections.Generic;

namespace BinaryTree
{
    public interface IBinaryTreePrinter<T> where T : IComparable<T>
    {
        void Print(BinaryTreeNode<T> node);
    }
}
