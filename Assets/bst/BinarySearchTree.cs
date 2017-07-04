using System;
using System.Collections.Generic;

namespace BinaryTreeVisualizer
{
    public sealed class BinarySearchTree<T> where T : IComparable
    {
        public Node<T> Root { get; set; }

        public BinarySearchTree(List<T> initData)
        {
            foreach (var data in initData)
            {
                // This is probably naive, but it will work for now
                Root = Insert(Root, data);
            }
        }

        public Node<T> Insert(Node<T> node, T data)
        {
            if (node == null)
            {
                return new Node<T>(data);
            }
            else if (data.CompareTo(node.Data) < 0)
            {
                // Data is smaller than this node's data
                node.Left = Insert(node.Left, data);
            }
            else
            {
                // Data is bigger than or equal to this node's data
                node.Right = Insert(node.Right, data);
            }

            return node;
        }

        public void Delete(T data)
        {
        }

        public IEnumerable<T> GetPreOrderTraversal()
        {
            return DoPreOrderTraversal(Root);
        }

        public IEnumerable<T> GetInOrderTraversal()
        {
            return DoInOrderTraversal(Root);
        }

        public T GetMin()
        {
            if (Root == null)
            {
                return default(T);
            }

            Node<T> node = Root;
            while (node.Left != null)
            {
                node = node.Left;
            }

            return node.Data;
        }

        public T GetMax()
        {
            if (Root == null)
            {
                return default(T);
            }

            Node<T> node = Root;
            while (node.Right != null)
            {
                node = node.Right;
            }

            return node.Data;
        }

        private IEnumerable<T> DoPreOrderTraversal(Node<T> root)
        {
            List<T> nodes = new List<T>();

            nodes.Add(root.Data);

            if (root.Left != null)
            {
                nodes.AddRange(DoInOrderTraversal(root.Left));
            }

            if (root.Right != null)
            {
                nodes.AddRange(DoInOrderTraversal(root.Right));
            }

            return nodes;
        }

        private IEnumerable<T> DoInOrderTraversal(Node<T> root)
        {
            List<T> nodes = new List<T>();

            if (root.Left != null)
            {
                nodes.AddRange(DoInOrderTraversal(root.Left));
            }

            nodes.Add(root.Data);

            if (root.Right != null)
            {
                nodes.AddRange(DoInOrderTraversal(root.Right));
            }

            return nodes;
        }
    }
}
