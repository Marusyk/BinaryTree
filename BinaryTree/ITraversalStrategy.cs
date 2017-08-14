using System;
using System.Collections.Generic;

namespace BinaryTree
{
    public interface ITraversalStrategy
    {
        IEnumerator<T> Traversal<T>(BinaryTreeNode<T> node) where T : IComparable<T>;
    }
}
