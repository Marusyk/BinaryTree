using System;
using System.Collections.Generic;

namespace BinaryTree
{
    public abstract class TraversalStrategy
    {
        public abstract IEnumerator<T> Traversal<T>(BinaryTreeNode<T> node) where T : IComparable<T>;
    }
}
