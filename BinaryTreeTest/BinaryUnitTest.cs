using System.Linq;
using BinaryTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BinaryTreeTest
{
    [TestClass]
    public class BinaryUnitTest
    {
        [TestMethod]
        public void TestInOrderTraversal()
        {
            // arrange
            var expected = new int[] { 3, 5, 7, 8, 10, 12, 15 };
            var binaryTree = new BinaryTree<int> { 8, 5, 12, 3, 7, 10, 15 };
            var inOrder = new InOrderTraversal<int>();
            // act
            binaryTree.SetTraversalStrategy(inOrder);
            // assert
            Assert.IsTrue(expected.SequenceEqual(binaryTree));
        }

        [TestMethod]
        public void TestPreOrderTraversal()
        {
            {
                // arrange
                var expected = new int[] { 8, 5, 3, 7, 12, 10, 15 };
                var binaryTree = new BinaryTree<int> { 8, 5, 12, 3, 7, 10, 15 };
                var preOrder = new PreOrderTraversal<int>();
                // act
                binaryTree.SetTraversalStrategy(preOrder);
                // assert
                Assert.IsTrue(expected.SequenceEqual(binaryTree));
            }
        }

        [TestMethod]
        public void TestPostOrderTraversal()
        {
            {
                // arrange
                var expected = new int[] { 3, 7, 5, 10, 15, 12, 8 };
                var binaryTree = new BinaryTree<int> { 8, 5, 12, 3, 7, 10, 15 };
                var postOrder = new PostOrderTraversal<int>();
                // act
                binaryTree.SetTraversalStrategy(postOrder);
                // assert
                Assert.IsTrue(expected.SequenceEqual(binaryTree));
            }
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
        public void TestBinaryTreeRemove_ShouldReturnTrueAndRemoveElementFromTree_WhenTreeContainsElementToRemove()
        {
            // arrange
            var binaryTree = new BinaryTree<int> { 8, 5, 12, 3, 7, 10, 15 };
            var initialCount = binaryTree.Count;
            // act
            const int remove = 10;
            var isRemoved = binaryTree.Remove(remove);
            // assert
            Assert.IsTrue(isRemoved);
            Assert.IsTrue(binaryTree.Count < initialCount);
        }
        [TestMethod]
        public void TestBinaryTreeRemove_ShouldReturnFalseAndMakeNoChangesToTree_WhenTreeDoesNotContainElementToRemove()
        {
            // arrange
            var binaryTree = new BinaryTree<int> { 8, 5, 12, 3, 7, 10, 15 };
            var initialCount = binaryTree.Count;
            // act
            const int remove = 404;
            var isRemoved = binaryTree.Remove(remove);
            // assert
            Assert.IsFalse(isRemoved);
            Assert.AreEqual(initialCount, binaryTree.Count);
        }
    }
}
