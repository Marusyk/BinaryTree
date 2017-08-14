using System;
using System.Collections.Generic;

namespace BinaryTree
{
    public class InOrderTraversal : ITraversalStrategy
    {
        public IEnumerator<T> Traversal<T>(BinaryTreeNode<T> node) where T : IComparable<T>
        {
            var stack = new Stack<BinaryTreeNode<T>>();

            while (stack.Count > 0 || node != null)
            {
                if (node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }
                else
                {
                    node = stack.Pop();
                    yield return node.Value;
                    node = node.Right;
                }
            }
        }
    }
}
