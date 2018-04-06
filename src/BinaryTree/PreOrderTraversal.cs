using System;
using System.Collections.Generic;

namespace BinaryTree
{
    public class PreOrderTraversal<T> : ITraversalStrategy<T> where T : IComparable<T>
    {
        public IEnumerator<T> Traversal(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                yield break;
            }

            var stack = new Stack<BinaryTreeNode<T>>();
            stack.Push(node);

            while (stack.Count > 0)
            {
                node = stack.Pop();

                yield return node.Value;

                if (node.Right != null)
                {
                    stack.Push(node.Right);
                }
                if (node.Left != null)
                {
                    stack.Push(node.Left);
                }
            }
        }
    }
}
