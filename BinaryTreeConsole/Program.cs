using System;
using BinaryTree;

namespace BinaryTreeConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /* 
            var binaryTree = new BinaryTree<int>();

            binaryTree.Add(8);
            binaryTree.Add(5);
            binaryTree.Add(12);
            binaryTree.Add(3);
            binaryTree.Add(7);
            binaryTree.Add(10);
            binaryTree.Add(15);
            */

            /*
            var binaryTree = new BinaryTree<int> { 8, 5, 12, 3, 7, 10, 15 };
            */

            TraversalStrategy traversalStrategy = new InOrderTraversal();
            var binaryTree = new BinaryTree<int>(traversalStrategy) { 8, 5, 12, 3, 7, 10, 15 };

            Console.WriteLine("Count : {0}", binaryTree.Count);

            foreach (var item in binaryTree)
            {
                Console.Write(item + " ");
            }

            binaryTree.Remove(7);

            Console.WriteLine();
            Console.WriteLine("Count after remove: {0}", binaryTree.Count);

            foreach (var item in binaryTree)
            {
                Console.Write(item + " ");
            }

            Console.ReadKey();
        }
    }
}
