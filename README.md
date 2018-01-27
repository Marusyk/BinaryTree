# BinaryTree
C# Binary tree 

This little project contains a cross platform Binary Tree implementation

 [![AppVeyor](https://ci.appveyor.com/api/projects/status/l3kmfu18f4fbmuvu?svg=true)](https://ci.appveyor.com/project/Marusyk/binarytree) 
 [![Travis build status](https://img.shields.io/travis/Marusyk/BinaryTree.svg?label=travis-ci&branch=master&style=flat-square)](https://travis-ci.org/Marusyk/BinaryTree)
 [![NuGet package](https://badge.fury.io/nu/BinaryTree.svg)](https://www.nuget.org/packages/BinaryTree/)
 [![GitHub release](https://badge.fury.io/gh/Marusyk%2FBinaryTree.svg)](https://github.com/Marusyk/BinaryTree/releases/tag/v4.0.0.1)
 [![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE.md) ![contributions welcome](https://img.shields.io/badge/contributions-welcome-brightgreen.svg?style=flat)

# How to Install

You can directly install this library from [Nuget][6]. There are two packages:

**[BinaryTree][7]**

    PM> Install-Package BinaryTree
[6]: http://nuget.org
[7]: https://www.nuget.org/packages/BinaryTree

# How to use

Create a new instanse:
`var binaryTree = new BinaryTree<int>();`
and add elements: 
```
binaryTree.Add(8);
binaryTree.Add(5);
binaryTree.Add(12)
```
or use collection initializer like : `var binaryTree = new BinaryTree<int>() { 8, 5, 12, 3, 7, 10, 15 };`


By default traversal is set to **In-order** <br>
You can set the type of traversal in constructor `var binaryTree = new BinaryTree<int>(new PostOrderTraversal<int>());`
or use method `SetTraversalStrategy()`:
```
var inOrder = new InOrderTraversal<int>();
var preOrder = new PreOrderTraversal<int>();
var postOrder = new PostOrderTraversal<int>();

binaryTree.SetTraversalStrategy(preOrder);
```

Available operations:

 - `void Add(T value)` - adds a new element to the tree
 - `int Count` - returns count of elements in tree
 - `bool IsReadOnly` - always return `false`
 - `bool Contains(T value)` - checks if the tree contains the element 
 - `bool Remove(T value)` - remove element from the tree. Returns `true` if element was removed.
 - `void Clear()` - clears tree
 - `void CopyTo(T[] array, int arrayIndex)` - copies all the elements of the tree to the specified one-dimensional array starting at the specified destination array index. 
 - `void SetTraversalStrategy(ITraversalStrategy<T> traversalStrategy)` - sets type of traversal(Pre-order, In-order, Post-order)
 - `IEnumerator<T> GetEnumerator()` - returns numerator of tree

To display all elements of tree, use:
```
foreach (var item in binaryTree)
{
   Console.Write(item + " ");
}
```

 ## Contributing

Please read [CONTRIBUTING.md](https://github.com/Marusyk/BinaryTree/blob/master/CONTRIBUTING.md) for details on our code of conduct, and the process for submitting pull requests to us.

## License

This project is licensed under the MIT License - see the [LICENSE.md](https://github.com/Marusyk/BinaryTree/blob/master/LICENSE) file for details
