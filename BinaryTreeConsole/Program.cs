using System;
using BinaryTree;

namespace BinaryTreeConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var binaryTree = new BinaryTree<int>() { 8, 5, 12, 3, 7, 10, 15 };

            var inOrder = new InOrderTraversal();
            var preOrder = new PreOrderTraversal();
            var postOrder = new PostOrderTraversal();

            Console.Write("Pre-order : ");
            binaryTree.SetTraversalStrategy(preOrder);
            foreach (var item in binaryTree)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine(Environment.NewLine);
            Console.Write("Post-order : ");
            binaryTree.SetTraversalStrategy(postOrder);
            foreach (var item in binaryTree)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine(Environment.NewLine);
            Console.Write("In-order : ");
            binaryTree.SetTraversalStrategy(inOrder);
            foreach (var item in binaryTree)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Count : {0}", binaryTree.Count);

            const int remove = 10;
            var result = binaryTree.Remove(remove);
            if (result)
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Node {0} was removed, count after remove : {1}", remove, binaryTree.Count);

                Console.Write("Values: ");
                foreach (var item in binaryTree)
                {
                    Console.Write(item + " ");
                }
            }

            var arr = new int[binaryTree.Count];
            binaryTree.CopyTo(arr, 0);

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Copy to array: ");

            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }

            binaryTree.Clear();

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Count after clear: {0}", binaryTree.Count);
            Console.Write("Values after clar: ");

            foreach (var item in binaryTree)
            {
                Console.Write(item + " ");
            }

            Console.ReadKey();
        }
    }
}
