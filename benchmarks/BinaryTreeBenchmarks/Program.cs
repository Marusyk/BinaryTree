using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using BinaryTree;

namespace BinaryTreeBenchmarks
{
    public class Program
    {
        private static readonly IList<int> Numbers = RandomNumbers();
        private static readonly IList<char> Chars = RandomChars();
        private static readonly IList<string> Strings = RandomStrings();

        static void Main(string[] args)
        {
            BenchmarkRunner.Run(typeof(Program));
            Console.WriteLine("Done");
            Console.ReadKey();
        }

        private static IList<int> RandomNumbers()
        {
            var rnd = new Random();
            return Enumerable.Range(0, 500)
                .Select(r => rnd.Next(100))
                .ToList();
        }

        private static IList<char> RandomChars()
        {
            var rnd = new Random();
            return Enumerable.Range(0, 500)
                .Select(r => (char)('a' + rnd.Next(26)))
                .ToList();
        }

        private static IList<string> RandomStrings()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var strings = new List<string>();
            var rnd = new Random();
            for (int i = 0; i < 500; i++)
            {
                var startIndex = rnd.Next(0, chars.Length - 1);
                var lenght = rnd.Next(chars.Length - startIndex);
                strings.Add(chars.Substring(startIndex, lenght));
            }
            return strings;
        }

        [Benchmark]
        public static void NumbersInOrderTraversal()
        {
            _ = new BinaryTree<int>(Numbers);
        }

        [Benchmark]
        public static void NumbersPreOrderTraversal()
        {
            var preOrder = new PreOrderTraversal<int>();
            var binaryTree = new BinaryTree<int>(preOrder);
            binaryTree.AddRange(Numbers);
        }

        [Benchmark]
        public static void NumbersPostOrderTraversal()
        {
            var postOrder = new PostOrderTraversal<int>();
            var binaryTree = new BinaryTree<int>(postOrder);
            binaryTree.AddRange(Numbers);
        }

        [Benchmark]
        public static void CharsInOrderTraversal()
        {
            _ = new BinaryTree<char>(Chars);
        }

        [Benchmark]
        public static void CharsPreOrderTraversal()
        {
            var preOrder = new PreOrderTraversal<char>();
            var binaryTree = new BinaryTree<char>(preOrder);
            binaryTree.AddRange(Chars);
        }

        [Benchmark]
        public static void CharsPostOrderTraversal()
        {
            var postOrder = new PostOrderTraversal<char>();
            var binaryTree = new BinaryTree<char>(postOrder);
            binaryTree.AddRange(Chars);
        }

        [Benchmark]
        public static void StringsInOrderTraversal()
        {
            _ = new BinaryTree<string>(Strings);
        }

        [Benchmark]
        public static void StringsPreOrderTraversal()
        {
            var preOrder = new PreOrderTraversal<string>();
            var binaryTree = new BinaryTree<string>(preOrder);
            binaryTree.AddRange(Strings);
        }

        [Benchmark]
        public static void StringsPostOrderTraversal()
        {
            var postOrder = new PostOrderTraversal<string>();
            var binaryTree = new BinaryTree<string>(postOrder);
            binaryTree.AddRange(Strings);
        }
    }
}
