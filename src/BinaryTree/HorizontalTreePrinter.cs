using System;

namespace BinaryTree
{
    public class HorizontalTreePrinter<T> : IBinaryTreePrinter<T> where T : IComparable<T>
    {
        const int maxValueLength = 5;
        public void Print(BinaryTreeNode<T> root)
        {
            PrintRec(root, 0);
        }

        private void PrintRec(BinaryTreeNode<T> node, int spaces)
        {
            if (node != null)
            {
                PrintRec(node.Left, spaces + 1);
                Console.WriteLine(new String(' ', spaces * maxValueLength) + node.Value);
                PrintRec(node.Right, spaces + 1);
            }
        }
    }
}
