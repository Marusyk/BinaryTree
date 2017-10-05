using System.Linq;
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
            // arrange
            var nodeOrigin = new BinaryTreeNode<int>(1);
            var nodeToCompare = new BinaryTreeNode<int>(1);
            // act
            var isEqual = nodeOrigin.CompareNode(nodeToCompare);
            // assert
            Assert.AreEqual(0, isEqual);
        }

        [TestMethod]
        public void TestNodeCompareShouldBeHigher()
        {
            // arrange
            var nodeOrigin = new BinaryTreeNode<int>(2);
            var nodeToCompare = new BinaryTreeNode<int>(1);
            // act
            var isHigher = nodeOrigin.CompareNode(nodeToCompare);
            // assert
            Assert.AreEqual(1, isHigher);
        }

        [TestMethod]
        public void TestNodeCompareShouldBeLower()
        {
            // arrange
            var nodeOrigin = new BinaryTreeNode<int>(1);
            var nodeToCompare = new BinaryTreeNode<int>(2);
            // act
            var isLower = nodeOrigin.CompareNode(nodeToCompare);
            // assert
            Assert.AreEqual(-1, isLower);
        }
    }
}
