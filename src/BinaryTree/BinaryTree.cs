using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTree
{
    public class BinaryTree<T> : ICollection<T> where T : IComparable<T>
    {
        private ITraversalStrategy<T> _traversalStrategy;
        private BinaryTreeNode<T> _head;

        public BinaryTree(ITraversalStrategy<T> traversalStrategy)
        {
            _traversalStrategy = traversalStrategy ?? throw new ArgumentNullException(nameof(traversalStrategy));
        }

        public BinaryTree(IEnumerable<T> collection)
        {
            AddRange(collection);
        }

        public BinaryTree(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity should be more then zero.");
            }

            IsFixedSize = true;
            Capacity = capacity;
        }

        public BinaryTree()
        {
        }

        public BinaryTreeNode<T> Head => _head;

        public ITraversalStrategy<T> TraversalStrategy
        {
            get => _traversalStrategy ?? (_traversalStrategy = new InOrderTraversal<T>());
            set => _traversalStrategy = value ?? throw new ArgumentNullException(nameof(value));
        }

        public int Count { get; private set; }

        public int Capacity { get; }

        public bool IsReadOnly => false;

        public bool IsFixedSize { get; }

        public void Add(T value)
        {
            if (IsFixedSize && Count >= Capacity)
            {
                throw new NotSupportedException($"The BinaryTree has a fixed size. Can not add more than {Capacity} items");
            }

            if (_head == null)
            {
                _head = new BinaryTreeNode<T>(value);
            }
            else
            {
                AddTo(_head, value);
            }
            Count++;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            using (IEnumerator<T> enumerator = collection.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Add(enumerator.Current);
                }
            }
        }

        public bool Contains(T value)
        {
            return FindWithParent(value, out BinaryTreeNode<T> _) != null;
        }

        public bool Remove(T value)
        {
            BinaryTreeNode<T> current = FindWithParent(value, out BinaryTreeNode<T> parent);

            if (current == null)
            {
                return false;
            }

            Count--;

            if (current.Right == null)
            {
                if (parent == null)
                {
                    _head = current.Left;
                }
                else
                {
                    int result = parent.CompareTo(current.Value);
                    if (result > 0)
                    {
                        parent.Left = current.Left;
                    }
                    else if (result < 0)
                    {
                        parent.Right = current.Left;
                    }
                }
            }
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;

                if (parent == null)
                {
                    _head = current.Right;
                }
                else
                {
                    int result = parent.CompareTo(current.Value);
                    if (result > 0)
                    {
                        parent.Left = current.Right;
                    }
                    else if (result < 0)
                    {
                        parent.Right = current.Right;
                    }
                }
            }
            else
            {
                BinaryTreeNode<T> leftMost = current.Right.Left;
                BinaryTreeNode<T> leftMostParent = current.Right;

                while (leftMost.Left != null)
                {
                    leftMostParent = leftMost;
                    leftMost = leftMost.Left;
                }

                leftMostParent.Left = leftMost.Right;
                leftMost.Left = current.Left;
                leftMost.Right = current.Right;

                if (parent == null)
                {
                    _head = leftMost;
                }
                else
                {
                    int result = parent.CompareTo(current.Value);

                    if (result > 0)
                    {
                        parent.Left = leftMost;
                    }
                    else if (result < 0)
                    {
                        parent.Right = leftMost;
                    }
                }
            }
            return true;
        }

        public void Clear()
        {
            _head = null;
            Count = 0;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.GetLowerBound(0) != 0)
            {
                throw new ArgumentException("Non zero lower bound");
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (array.Length - arrayIndex < Count)
            {
                throw new ArgumentException();
            }

            IEnumerator<T> items = TraversalStrategy.Traversal(_head);
            while (items.MoveNext())
            {
                array[arrayIndex++] = items.Current;
            }
        }

        private static void AddTo(BinaryTreeNode<T> node, T value)
        {
            if (value.CompareTo(node.Value) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new BinaryTreeNode<T>(value);
                }
                else
                {
                    AddTo(node.Left, value);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new BinaryTreeNode<T>(value);
                }
                else
                {
                    AddTo(node.Right, value);
                }
            }
        }

        private BinaryTreeNode<T> FindWithParent(T value, out BinaryTreeNode<T> parent)
        {
            BinaryTreeNode<T> current = _head;
            parent = null;

            while (current != null)
            {
                int result = current.CompareTo(value);
                if (result > 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (result < 0)
                {
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }
            return current;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return TraversalStrategy.Traversal(_head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
