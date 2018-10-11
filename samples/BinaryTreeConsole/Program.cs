using BinaryTree;
using System;

namespace BinaryTreeConsole
{
    internal class Program
    {
        private static void Main()
        {
            var binaryTree = new BinaryTree<int> { 8, 5, 12, 3, 7, 10, 15 };

            Console.Write("Pre-order : ");
            binaryTree.TraversalStrategy = new PreOrderTraversal<int>();
            binaryTree.PrintToConsole();

            Console.WriteLine(Environment.NewLine);
            Console.Write("Post-order : ");
            binaryTree.TraversalStrategy = new PostOrderTraversal<int>();
            binaryTree.PrintToConsole();

            Console.WriteLine(Environment.NewLine);
            Console.Write("In-order : ");
            binaryTree.TraversalStrategy = new InOrderTraversal<int>();
            binaryTree.PrintToConsole();

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Pretty print: ");
            Console.WriteLine(Environment.NewLine);
            binaryTree.Print();

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine($"Count : {binaryTree.Count}");

            const int remove = 10;
            var isRemoved = binaryTree.Remove(remove);
            if (isRemoved)
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine($"Node {remove} was removed, count after remove : {binaryTree.Count}");

                Console.Write("Values: ");
                binaryTree.PrintToConsole();
            }

            var arr = new int[binaryTree.Count];
            binaryTree.CopyTo(arr, 0);

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Copy to array: ");
            arr.PrintToConsole();

            binaryTree.Clear();

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine($"Count after clear: {binaryTree.Count}");
            Console.Write("Values after clear: ");
            binaryTree.PrintToConsole();

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
    }
}
