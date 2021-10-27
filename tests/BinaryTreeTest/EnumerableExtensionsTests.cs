using BinaryTree;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace BinaryTreeTest
{
    public class EnumerableExtensionsTests
    {
        private readonly TextWriter _mockConsoleWriter;
        private readonly TextWriter _consoleTextWriter;

        private readonly List<string> _testData;

        public EnumerableExtensionsTests()
        {
            _consoleTextWriter = Console.Out;
            _mockConsoleWriter = new StringWriter();
            Console.SetOut(_mockConsoleWriter);

            _testData = new List<string> { "elements", "of", "list" };
        }

        ~EnumerableExtensionsTests()
        {
            Console.SetOut(_consoleTextWriter);
            _consoleTextWriter.Dispose();
            _mockConsoleWriter.Dispose();
        }

        [Fact]
        public void ShouldThrowException_OnTryingToPrintUnsupportedArrayAsTree()
        {
            Assert.Throws<NotSupportedException>(() =>
            {
                _testData.PrintAsTree();
            });
        }

        [Fact]
        public void ShouldWriteSpecifiedDataToConsole()
        {
            // Arrange
            // Act
            _testData.PrintToConsole();

            // Assert
            Assert.Equal("elements of list ", _mockConsoleWriter.ToString());
        }
    }
}
