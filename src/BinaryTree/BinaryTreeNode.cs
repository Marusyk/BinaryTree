using System;

namespace BinaryTree
{
    public class BinaryTreeNode<TNode> : IComparable<TNode> where TNode : IComparable<TNode>
    {
        public BinaryTreeNode(TNode value)
        {
            Value = value;
        }

        public BinaryTreeNode<TNode> Left { get; set; }

        public BinaryTreeNode<TNode> Right { get; set; }

        public TNode Value { get; }

        public int CompareNode(BinaryTreeNode<TNode> node)
        {
            return Value.CompareTo(node.Value);
        }

        public int CompareTo(TNode node)
        {
            return Value.CompareTo(node);
        }
    }
}
