<p align="center">
  <img src="https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcS_N3p8bFpmy0AyoBl_3n3XwSVlnjfnPzLduqRlCI-sS19C810kSQ" alt="HttpPatch" width="100"/>
</p>

# BinaryTree
C# Binary tree 

This little project contains a cross platform Binary Tree implementation

![Windows Build](https://github.com/Marusyk/BinaryTree/workflows/Windows%20Build/badge.svg)
![MacOs Build](https://github.com/Marusyk/BinaryTree/workflows/MacOs%20Build/badge.svg)
![Linux Build](https://github.com/Marusyk/BinaryTree/workflows/Linux%20Build/badge.svg)

 [![AppVeyor](https://ci.appveyor.com/api/projects/status/l3kmfu18f4fbmuvu?svg=true)](https://ci.appveyor.com/project/Marusyk/binarytree) 
 [![GitHub release](https://badge.fury.io/gh/Marusyk%2FBinaryTree.svg)](https://github.com/Marusyk/BinaryTree/releases/tag/v5.2.0)
 [![NuGet package](https://badge.fury.io/nu/BinaryTree.svg)](https://www.nuget.org/packages/BinaryTree/)
 [![NuGet](https://img.shields.io/nuget/dt/BinaryTree.svg)](https://www.nuget.org/packages/BinaryTree/)
 [![License](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/Marusyk/BinaryTree/blob/master/LICENSE) 
 [![contributions welcome](https://img.shields.io/badge/contributions-welcome-brightgreen.svg?style=flat)](https://github.com/Marusyk/BinaryTree/blob/master/CONTRIBUTING.md)

# How to Install

You can directly install this library from [Nuget][6]. There is package:

**[BinaryTree][7]**

    PM> Install-Package BinaryTree
[6]: http://nuget.org
[7]: https://www.nuget.org/packages/BinaryTree

# How to use

Create a new instanse:
`var binaryTree = new BinaryTree<int>();`
and add elements: 

```csharp
binaryTree.Add(8);
binaryTree.Add(5);
binaryTree.Add(12)
```
or use collection initializer like : `var binaryTree = new BinaryTree<int>() { 8, 5, 12, 3, 7, 10, 15 };`

Another way is constructs a BinaryTree, copying the contents of the given collection

```csharp
IList<int> numbers = new List<int>();
var binaryTree = new BinaryTree<int>(numbers);
```

Also you can initialize a new instance of the BinaryTree class that is empty and has the specified initial capacity:
`var binaryTree = new BinaryTree<int>(10);`

By default traversal is set to [**In-order**](https://en.wikipedia.org/wiki/Tree_traversal#In-order) <br>
You can set the type of traversal in constructor `var binaryTree = new BinaryTree<int>(new PostOrderTraversal<int>());`
or use property `TraversalStrategy`:

```csharp
var inOrder = new InOrderTraversal<int>();
var preOrder = new PreOrderTraversal<int>();
var postOrder = new PostOrderTraversal<int>();

binaryTree.TraversalStrategy = preOrder;
```

Available operations:

 - `void Add(T value)` - adds a new element to the tree
 - `void AddRange(IEnumerable<T> collection)` - copying the contents of the given collection to the tree
 - `ITraversalStrategy<T> TraversalStrategy` -gets or sets type of traversal(Pre-order, In-order, Post-order)
 - `int Count` - returns count of elements in tree
 - `int Capacity` - gets the number of elements that the BinaryTree can contain
 - `bool IsReadOnly` - always return `false`
 - `bool IsFixedSize` - gets a value indicating whether the BinaryTree has a fixed size
 - `bool Contains(T value)` - checks if the tree contains the element 
 - `bool Remove(T value)` - remove element from the tree. Returns `true` if element was removed.
 - `void Clear()` - clears tree
 - `void CopyTo(T[] array, int arrayIndex)` - copies all the elements of the tree to the specified one-dimensional array starting at the specified destination array index. 
 - `IEnumerator<T> GetEnumerator()` - returns numerator of tree

To display all elements of tree, use:

```csharp
foreach (var item in binaryTree)
{
   Console.Write(item + " ");
}
```
or use extension method:

```csharp
binaryTree.PrintToConsole();
```

 ## Contributing

Please read [CONTRIBUTING.md](https://github.com/Marusyk/BinaryTree/blob/master/CONTRIBUTING.md) for details on our code of conduct, and the process for submitting pull requests to us.

## License

This project is licensed under the MIT License - see the [LICENSE.md](https://github.com/Marusyk/BinaryTree/blob/master/LICENSE) file for details
