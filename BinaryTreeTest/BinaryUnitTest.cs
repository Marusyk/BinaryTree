using System.Linq;
using BinaryTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryTreeTest
{
    [TestClass]
    public class BinaryUnitTest
    {
        [TestMethod]
        public void TestInOrderTraversal()
        {
            // arrange
            var orderedTree = new BinaryTree<int> { 3, 5, 7, 8, 10, 12, 15 };
            var binaryTree = new BinaryTree<int> { 8, 5, 12, 3, 7, 10, 15 };
            var inOrder = new InOrderTraversal<int>();
            // act
            binaryTree.SetTraversalStrategy(inOrder);
            // assert
            Assert.IsTrue(orderedTree.SequenceEqual(binaryTree));
        }

        [TestMethod]
        public void TestBinaryTreeClear()
        {
            // arrange
            var binaryTree = new BinaryTree<int> { 8, 5, 12, 3, 7, 10, 15 };
            // act
            binaryTree.Clear();
            // assert
            Assert.AreEqual(binaryTree.Count, 0);
        }

        [TestMethod]
        public void TestBinaryTreeCopy()
        {
            // arrange
            var binaryTree = new BinaryTree<int> { 8, 5, 12, 3, 7, 10, 15 };
            // act
            var arr = new int[binaryTree.Count];
            binaryTree.CopyTo(arr, 0);
            // assert
            Assert.AreEqual(binaryTree.Count, arr.Length);
        }

        [TestMethod]
        public void TestBinaryTreeRemove()
        {
            // arrange
            var binaryTree = new BinaryTree<int> { 8, 5, 12, 3, 7, 10, 15 };
            var initCnt = binaryTree.Count;
            // act
            const int remove = 10;
            var isRemoved = binaryTree.Remove(remove);
            // assert
            Assert.IsTrue(isRemoved);
            Assert.IsTrue(binaryTree.Count < initCnt);
        }
    }
}
