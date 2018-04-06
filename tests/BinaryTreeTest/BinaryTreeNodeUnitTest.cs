using BinaryTree;
using Xunit;

namespace BinaryTreeTest
{
    public class BinaryTreeNodeUnitTest
    {
        [Fact]
        public void TestNodeCompareShouldBeEqual()
        {
            // Arrange
            var nodeOrigin = new BinaryTreeNode<int>(1);
            var nodeToCompare = new BinaryTreeNode<int>(1);

            // Act
            var isEqual = nodeOrigin.CompareNode(nodeToCompare);

            // Assert
            Assert.Equal(0, isEqual);
        }

        [Fact]
        public void TestNodeCompareShouldBeHigher()
        {
            // Arrange
            var nodeOrigin = new BinaryTreeNode<int>(2);
            var nodeToCompare = new BinaryTreeNode<int>(1);

            // Act
            var isHigher = nodeOrigin.CompareNode(nodeToCompare);

            // Assert
            Assert.Equal(1, isHigher);
        }

        [Fact]
        public void TestNodeCompareShouldBeLower()
        {
            // Arrange
            var nodeOrigin = new BinaryTreeNode<int>(1);
            var nodeToCompare = new BinaryTreeNode<int>(2);

            // Act
            var isLower = nodeOrigin.CompareNode(nodeToCompare);

            // Assert
            Assert.Equal(-1, isLower);
        }
    }
}
