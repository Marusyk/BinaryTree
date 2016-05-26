using System.Collections.Generic;

namespace BinaryTree
{
    public class PreOrderTraversal : TraversalStrategy
    {
        public override IEnumerator<T> Traversal<T>(BinaryTreeNode<T> node)
        {
            if (node == null)
                yield break;

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
