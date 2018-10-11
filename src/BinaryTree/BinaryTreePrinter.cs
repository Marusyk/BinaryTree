using System;

namespace BinaryTree
{
    public class BinaryTreePrinter<T> where T : IComparable<T>
    {
        const int maxValueLength = 5;
        public void PrettyPrint(BinaryTreeNode<T> root)
        {
            PrettyPrintRec(root, 0);
        }

        private void PrettyPrintRec(BinaryTreeNode<T> node, int spaces)
        {
            if (node != null)
            {
                PrettyPrintRec(node.Left, spaces + 1);
                Console.WriteLine(new String(' ', spaces * maxValueLength) + node.Value);
                PrettyPrintRec(node.Right, spaces + 1);
            }
        }
    }
}
