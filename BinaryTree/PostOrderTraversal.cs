using System;
using System.Collections.Generic;

namespace BinaryTree
{
    public class PostOrderTraversal : ITraversalStrategy
    {
        public IEnumerator<T> Traversal<T>(BinaryTreeNode<T> node) where T : IComparable<T>
        {
            var stack = new Stack<BinaryTreeNode<T>>();
            BinaryTreeNode<T> lastNodeVisited = null;

            while (stack.Count > 0 || node != null)
            {
                if (node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }
                else
                {
                    var peekNode = stack.Peek();
                    if (peekNode.Right != null && lastNodeVisited != peekNode.Right)
                    {
                        node = peekNode.Right;
                    }
                    else
                    {
                        yield return peekNode.Value;
                        lastNodeVisited = stack.Pop();
                    }
                }
            }
        }
    }
}
