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
            // Arrange
            var expected = new [] { 3, 5, 7, 8, 10, 12, 15 };
            var binaryTree = new BinaryTree<int> { 8, 5, 12, 3, 7, 10, 15 };
            var inOrderTraversalStrategy = new InOrderTraversal<int>();

            // Act
            binaryTree.SetTraversalStrategy(inOrderTraversalStrategy);

            // Assert
            Assert.IsTrue(expected.SequenceEqual(binaryTree));
        }

        [TestMethod]
        public void TestPreOrderTraversal()
        {
            // Arrange
            var expected = new [] { 8, 5, 3, 7, 12, 10, 15 };
            var binaryTree = new BinaryTree<int> { 8, 5, 12, 3, 7, 10, 15 };
            var preOrder = new PreOrderTraversal<int>();

            // Act
            binaryTree.SetTraversalStrategy(preOrder);

            // Assert
            Assert.IsTrue(expected.SequenceEqual(binaryTree));
        }

        [TestMethod]
        public void TestPostOrderTraversal()
        {
            // Arrange
            var expected = new [] { 3, 7, 5, 10, 15, 12, 8 };
            var binaryTree = new BinaryTree<int> { 8, 5, 12, 3, 7, 10, 15 };
            var postOrder = new PostOrderTraversal<int>();

            // Act
            binaryTree.SetTraversalStrategy(postOrder);

            // Assert
            Assert.IsTrue(expected.SequenceEqual(binaryTree));
        }

        [TestMethod]
        public void TestBinaryTreeClear()
        {
            // Arrange
            var binaryTree = new BinaryTree<int> { 8, 5, 12, 3, 7, 10, 15 };

            // Act
            binaryTree.Clear();

            // Assert
            Assert.AreEqual(binaryTree.Count, 0);
        }

        [TestMethod]
        public void TestBinaryTreeCopy()
        {
            // Arrange
            var binaryTree = new BinaryTree<int> { 8, 5, 12, 3, 7, 10, 15 };

            // Act
            var arr = new int[binaryTree.Count];
            binaryTree.CopyTo(arr, 0);

            // Assert
            Assert.AreEqual(binaryTree.Count, arr.Length);
        }

        [TestMethod]
        public void TestBinaryTreeRemove_ShouldReturnTrueAndRemoveElementFromTree_WhenTreeContainsElementToRemove()
        {
            // Arrange
            var binaryTree = new BinaryTree<int> { 8, 5, 12, 3, 7, 10, 15 };
            var initialCount = binaryTree.Count;

            // Act
            const int remove = 10;
            var isRemoved = binaryTree.Remove(remove);

            // Assert
            Assert.IsTrue(isRemoved);
            Assert.IsTrue(binaryTree.Count < initialCount);
        }
        [TestMethod]
        public void TestBinaryTreeRemove_ShouldReturnFalseAndMakeNoChangesToTree_WhenTreeDoesNotContainElementToRemove()
        {
            // Arrange
            var binaryTree = new BinaryTree<int> { 8, 5, 12, 3, 7, 10, 15 };
            var initialCount = binaryTree.Count;

            // Act
            const int remove = 404;
            var isRemoved = binaryTree.Remove(remove);

            // Assert
            Assert.IsFalse(isRemoved);
            Assert.AreEqual(initialCount, binaryTree.Count);
        }

        [TestMethod]
        public void TestBinaryTree_Contains()
        {
            // Arrange
            var binaryTree = new BinaryTree<int> { 8, 5, 12, 3, 7, 10, 15 };

            // Act
            var exists = binaryTree.Contains(10);
            var doesntExist = binaryTree.Contains(20);

            // Assert
            Assert.IsTrue(exists);
            Assert.IsFalse(doesntExist);
        }
    }
}
