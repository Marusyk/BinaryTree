using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTree
{
    public class BinaryTree<T> : ICollection<T> where T : IComparable<T>
    {
        #region private fields

        private TraversalStrategy _traversalStrategy;
        private BinaryTreeNode<T> _head;

        #endregion

        #region public constructors

        public BinaryTree(TraversalStrategy traversalStrategy)
        {
            SetTraversalStrategy(traversalStrategy);
        }

        public BinaryTree()
        {
            _traversalStrategy = new InOrderTraversal();
        }

        #endregion

        #region private methods

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
            var current = _head;
            parent = null;

            while (current != null)
            {
                var result = current.CompareTo(value);
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

        #endregion

        #region public 

        public void Add(T value)
        {
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

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public bool Contains(T value)
        {
            BinaryTreeNode<T> parent;
            return FindWithParent(value, out parent) != null;
        }

        public bool Remove(T value)
        {
            BinaryTreeNode<T> parent;

            var current = FindWithParent(value, out parent);

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
                    var result = parent.CompareTo(current.Value);
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
                    var result = parent.CompareTo(current.Value);
                    if(result > 0)
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
                var leftMost = current.Right.Left;
                var leftMostParent = current.Right;

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
                    var result = parent.CompareTo(current.Value);

                    if (result > 0)
                    {
                        parent.Left = leftMost;
                    }
                    else if(result < 0)
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
            var items = _traversalStrategy.Traversal(_head);
            while(items.MoveNext())
            {
                array[arrayIndex++] = items.Current;
            }
        }

        public void SetTraversalStrategy(TraversalStrategy traversalStrategy)
        {
            _traversalStrategy = traversalStrategy;
        }

        #endregion

        #region IEnumerable implementation

        public IEnumerator<T> GetEnumerator()
        {
            return _traversalStrategy.Traversal(_head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        } 
        #endregion
    }
}
