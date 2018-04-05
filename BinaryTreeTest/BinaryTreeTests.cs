using System.Linq;
using BinaryTree;
using Xunit;

namespace BinaryTreeTest
{
    public class BinaryTreeTests
    {
        private readonly BinaryTree<int> _sut;

        public BinaryTreeTests()
        {
            _sut = new BinaryTree<int> { 8, 5, 12, 3, 7, 10, 15 };
        }

        [Fact]
        public void InOrderTraversal()
        {
            // Arrange
            var expected = new [] { 3, 5, 7, 8, 10, 12, 15 };

            // Act
            _sut.TraversalStrategy = new InOrderTraversal<int>();

            // Assert
            Assert.True(expected.SequenceEqual(_sut));
        }

        [Fact]
        public void PreOrderTraversal()
        {
            // Arrange
            var expected = new [] { 8, 5, 3, 7, 12, 10, 15 };

            // Act
            _sut.TraversalStrategy = new PreOrderTraversal<int>();

            // Assert
            Assert.True(expected.SequenceEqual(_sut));
        }

        [Fact]
        public void PostOrderTraversal()
        {
            // Arrange
            var expected = new [] { 3, 7, 5, 10, 15, 12, 8 };

            // Act
            _sut.TraversalStrategy = new PostOrderTraversal<int>();

            // Assert
            Assert.True(expected.SequenceEqual(_sut));
        }

        [Fact]
        public void Should_be_cleared()
        {
            // Arrange
            // Act
            _sut.Clear();

            // Assert
            Assert.Empty(_sut);
        }

        [Fact]
        public void Should_be_copy_to_array()
        {
            // Arrange
            var arr = new int[_sut.Count];

            // Act
            _sut.CopyTo(arr, 0);

            // Assert
            Assert.Equal(_sut.Count, arr.Length);
        }

        [Fact]
        public void Remove_should_return_true_and_remove_element_from_tree_when_tree_contains_element_to_remove()
        {
            // Arrange
            var initialCount = _sut.Count;
            const int remove = 10;

            // Act
            var isRemoved = _sut.Remove(remove);

            // Assert
            Assert.True(isRemoved);
            Assert.True(_sut.Count < initialCount);
        }

        [Fact]
        public void Remove_should_return_false_and_make_no_changes_to_tree_when_tree_does_not_contain_element_to_remove()
        {
            // Arrange
            var initialCount = _sut.Count;
            const int remove = 404;

            // Act            
            var isRemoved = _sut.Remove(remove);

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
            var exists = _sut.Contains(element);

            // Assert
            Assert.Equal(isSuccess, exists);
        }
    }
}
