using System;
using System.Collections.Generic;

namespace BinaryTree
{
    public class InOrderTraversal : TraversalStrategy
    {
        public override IEnumerator<T> Traversal<T>(BinaryTreeNode<T> head)
        {
            if (head == null)
                yield break;

            var stack = new Stack<BinaryTreeNode<T>>();
            var current = head;
            var goLeftNext = true;

            stack.Push(current);

            while (stack.Count > 0)
            {
                if (goLeftNext)
                {
                    while (current.Left != null)
                    {
                        stack.Push(current);
                        current = current.Left;
                    }
                }

                yield return current.Value;

                if (current.Right != null)
                {
                    current = current.Right;
                    goLeftNext = true;
                }
                else
                {
                    current = stack.Pop();
                    goLeftNext = false;
                }
            }
        }
    }
}
