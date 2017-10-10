using BinaryTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryTreeTest
{
    [TestClass]
    public class BinaryTreeNodeUnitTest
    {
        [TestMethod]
        public void TestNodeCompareShouldBeEqual()
        {
            // Arrange
            var nodeOrigin = new BinaryTreeNode<int>(1);
            var nodeToCompare = new BinaryTreeNode<int>(1);

            // Act
            var isEqual = nodeOrigin.CompareNode(nodeToCompare);

            // Assert
            Assert.AreEqual(0, isEqual);
        }

        [TestMethod]
        public void TestNodeCompareShouldBeHigher()
        {
            // Arrange
            var nodeOrigin = new BinaryTreeNode<int>(2);
            var nodeToCompare = new BinaryTreeNode<int>(1);

            // Act
            var isHigher = nodeOrigin.CompareNode(nodeToCompare);

            // Assert
            Assert.AreEqual(1, isHigher);
        }

        [TestMethod]
        public void TestNodeCompareShouldBeLower()
        {
            // Arrange
            var nodeOrigin = new BinaryTreeNode<int>(1);
            var nodeToCompare = new BinaryTreeNode<int>(2);

            // Act
            var isLower = nodeOrigin.CompareNode(nodeToCompare);

            // Assert
            Assert.AreEqual(-1, isLower);
        }
    }
}
