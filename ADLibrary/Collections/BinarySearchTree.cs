using System;

namespace ADLibrary.Collections
{
    class BinarySearchTree<T> : ICollection<T>
    {
        private TreeNode<T> root;

        public BinarySearchTree() { }

        public void add(T item)
        {

        }

        public void remove(T item)
        {
            throw new NotImplementedException();
        }

        public void clear()
        {
            throw new NotImplementedException();
        }

        public bool contains(T item)
        {
            throw new NotImplementedException();
        }

        public int count()
        {
            throw new NotImplementedException();
        }

        public T[] toArray()
        {
            throw new NotImplementedException();
        }
    }

    internal class TreeNode<T>
    {
        public T data { get; set; }
        public TreeNode<T> left { get; set; }   //Kleiner
        public TreeNode<T> right { get; set; }  //Groter

        public TreeNode(T data)
        {
            this.data = data;
        }
    }
}
