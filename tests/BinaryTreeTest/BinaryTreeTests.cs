using System;
using System.Collections.Generic;
using System.Linq;
using BinaryTree;
using Xunit;

namespace BinaryTreeTest
{
    public class BinaryTreeTests
    {
        private readonly BinaryTree<int> _sut;
        private readonly List<int> _testData = new() { 8, 5, 12, 3, 7, 10, 15 };

        public BinaryTreeTests()
        {
            _sut = new BinaryTree<int>(_testData);
        }

        [Fact]
        public void InOrderTraversal()
        {
            // Arrange
            int[] expected = new [] { 3, 5, 7, 8, 10, 12, 15 };

            // Act
            var sut = new BinaryTree<int>(new InOrderTraversal<int>());
            sut.AddRange(_testData);

            // Assert
            Assert.True(expected.SequenceEqual(sut));
        }

        [Fact]
        public void PreOrderTraversal()
        {
            // Arrange
            int[] expected = new [] { 8, 5, 3, 7, 12, 10, 15 };

            // Act
            _sut.TraversalStrategy = new PreOrderTraversal<int>();

            // Assert
            Assert.True(expected.SequenceEqual(_sut));
        }

        [Fact]
        public void PostOrderTraversal()
        {
            // Arrange
            var sut = new BinaryTree<int>();
            sut.AddRange(_testData);
            int[] expected = new [] { 3, 7, 5, 10, 15, 12, 8 };

            // Act
            sut.TraversalStrategy = new PostOrderTraversal<int>();

            // Assert
            Assert.True(expected.SequenceEqual(sut));
        }

        [Fact]
        public void Should_be_cleared()
        {
            // Arrange
            // Act
            _sut.Clear();

            // Assert
            Assert.Null(_sut.Head);
            Assert.Empty(_sut);
        }

        [Fact]
        public void Should_be_copy_to_array()
        {
            // Arrange
            int[] arr = new int[_sut.Count];

            // Act
            _sut.CopyTo(arr, 0);

            // Assert
            Assert.Equal(_sut.Count, arr.Length);
        }

        [Theory]
        [InlineData(new int[] { 8, 5, 10, 3, 7, 12, 15, 4, 6, 55, 89, 99, 69 })]
        [InlineData(new int[] { 8, 155, 10, 3, 7, 12, 15, 4, 6, 55, 89, 99, 69 })]
        [InlineData(new int[] { 8, 5, 12, 3, 7, 10, 15 })]
        [InlineData(new int[] { 10, 5, 15, 12, 11, 8, 99 })]
        [InlineData(new int[] { 15, 10, 19, 14, 12 })]
        [InlineData(new int[] { 7, 5, 10, 9, 15, 12 })]
        [InlineData(new int[] { 10, 5, 12, 3, 7 })]
        [InlineData(new int[] { 8, 10 })]
        [InlineData(new int[] { 10, 8 })]
        public void Remove_should_return_true_and_remove_element_from_tree_when_tree_contains_element_to_remove(int[] testData)
        {
            // Arrange
            const int remove = 10;
            var sut = new BinaryTree<int>(testData);
            int initialCount = sut.Count;

            // Act
            bool isRemoved = sut.Remove(remove);

            // Assert
            Assert.True(isRemoved);
            Assert.True(sut.Count < initialCount);
        }

        [Fact]
        public void Remove_should_return_false_and_make_no_changes_to_tree_when_tree_does_not_contain_element_to_remove()
        {
            // Arrange
            int initialCount = _sut.Count;
            const int remove = 404;

            // Act
            bool isRemoved = _sut.Remove(remove);

            // Assert
            Assert.False(isRemoved);
            Assert.Equal(initialCount, _sut.Count);
        }

        [Theory]
        [InlineData(true, 10)]
        [InlineData(false, 20)]
        public void Check_contains_element(bool isSuccess, int element)
        {
            // Arrange
            // Act
            bool exists = _sut.Contains(element);

            // Assert
            Assert.Equal(isSuccess, exists);
        }

        [Fact]
        public void ShouldThrowException_OnReceivingNullData()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                _sut.AddRange(null);
            });
        }

        [Fact]
        public void ShouldThrowException_OnInvalidCapacity()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var sut = new BinaryTree<int>(-1);
            });
        }

        [Fact]
        public void ShouldThrowException_OnInvalidTraversalStrategy()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                _sut.TraversalStrategy = null;
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                _sut.TraversalStrategy = null;
            });
        }

        [Fact]
        public void ShouldThrowException_OnInvalidTraversalStrategy_WhileInitializing()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new BinaryTree<int>(traversalStrategy: null);
            });
        }

        [Fact]
        public void ShouldThrowException_OnTryingToCopyToNullArray()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                _sut.CopyTo(null, 0);
            });
        }

        [Fact]
        public void ShouldThrowException_OnTryingToCopyWithNegativeIndex()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                _sut.CopyTo(new int[] { 1 }, -1);
            });
        }

        [Fact]
        public void ShouldThrowException_OnTryingToCopyToArrayWithInsufficientSpace()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                _sut.CopyTo(new int[_testData.Count], _testData.Count - 1);
            });
        }

        [Fact]
        public void ShouldThrowException_OnAddingToFixedCapacityTree()
        {
            int maxCapacity = 1;
            var sut = new BinaryTree<int>(maxCapacity)
            {
                1
            };

            Assert.True(sut.IsFixedSize);
            Assert.False(sut.IsReadOnly);
            Assert.Equal(maxCapacity, sut.Capacity);
            Assert.Single(sut);
            Assert.Throws<NotSupportedException>(() =>
            {
                sut.Add(1);
            });
        }

        [Fact]
        public void PreOrderTraversal_NullNode()
        {
            IEnumerator<int> results = new PreOrderTraversal<int>().Traversal(null);
            Assert.False(results.MoveNext());
        }
    }
}
