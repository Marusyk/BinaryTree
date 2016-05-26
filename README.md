# BinaryTree
C# Binary tree 

This little project contains a Binary Tree implementation

 [![AppVeyor](https://ci.appveyor.com/api/projects/status/l3kmfu18f4fbmuvu?svg=true)](https://ci.appveyor.com/project/Marusyk/binarytree) 
 [![NuGet package](https://badge.fury.io/nu/BinaryTree.svg)](https://www.nuget.org/packages/BinaryTree/)
 [![GitHub release](https://badge.fury.io/gh/Marusyk%2FBinaryTree.svg)](https://github.com/Marusyk/BinaryTree/releases/tag/v2.0.0)

# How to Install

You can directly install this library from [Nuget][6]. There are two packages:

**[BinaryTree][7]**

    PM> Install-Package BinaryTree
[6]: http://nuget.org
[7]: https://www.nuget.org/packages/BinaryTree/1.0.0

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
<br>
By default traversal is set to **In-order** <br>
Yoi can set traversal in consructor `var binaryTree = new BinaryTree<int>(new PostOrderTraversal());`
or use method `SetTraversalStrategy()`
```
var inOrder = new InOrderTraversal();
var preOrder = new PreOrderTraversal();
var postOrder = new PostOrderTraversal();

binaryTree.SetTraversalStrategy(preOrder);
```

Available opeations:

 - `void Add(T value)` - add a new element to the tree
 - `int Count` - return count of elements in tree
 - `bool IsReadOnly` - always return `false`
 - `bool Contains(T value)` - check if element contains in the tree
 - `bool Remove(T value)` - remove element from the tree. Return `true` if element was removed.
 - `void Clear()` - clear tree
 - `void CopyTo(T[] array, int arrayIndex)` - copies all the elements of the tree to the specified one-dimensional array starting at the specified destination array index. 
 - `void SetTraversalStrategy(TraversalStrategy traversalStrategy)` - set stratefy of traversal(Pre-order, In-order, Post-order)
 - `IEnumerator<T> GetEnumerator()` - return numerator of tree

To display all elements of tree use:
```
foreach (var item in binaryTree)
{
   Console.Write(item + " ");
}
```
