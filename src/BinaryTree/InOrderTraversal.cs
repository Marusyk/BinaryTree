using System;
using System.Collections.Generic;

namespace BinaryTree
{
    public class InOrderTraversal<T> : ITraversalStrategy<T> where T : IComparable<T>
    {
        public IEnumerator<T> Traversal(BinaryTreeNode<T> node)
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
