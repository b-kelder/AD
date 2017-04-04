using System;

namespace ADLibrary.Collections
{
    class BinarySearchTree<T> : ICollection<T> where T : IComparable
    {
        private TreeNode<T> root;
        private int nodeCount;

        public BinarySearchTree() { }

        public void add(T item)
        {
            TreeNode<T> toAdd = new TreeNode<T>(item);
            if (root == null)
            {
                root = toAdd;
            } else
            {
                TreeNode<T> current = root;
                TreeNode<T> parent;
                while (true)
                {
                    parent = current;
                    if (item.CompareTo(current.data) < 0)
                    {
                        current = current.left;
                        if (current == null)
                        {
                            parent.left = toAdd;
                            return;
                        }
                    }
                    else
                    {
                        current = current.right;
                        if (current != null)
                        {
                            parent.right = toAdd;
                            return;
                        }
                    }
                }
            }

            nodeCount++;
        }

        public void inOrder(TreeNode<T> root)
        {
            if (root != null)
            {
                inOrder(root.left);
                //root.DisplayNode();
                inOrder(root.right);
            }
        }

        public void preOrder(TreeNode<T> root)
        {
            if (root != null)
            {
                //theRoot.displayNode();
                preOrder(root.left);
                preOrder(root.right);
            }
        }

        public void postOrder(TreeNode<T> root)
        {
            if (root != null)
            {
                postOrder(root.left);
                postOrder(root.right);
                //root.DisplayNode();
            }
        }

        public T findMin()
        {
            TreeNode<T> current = root;
            while (current.left != null)
            {
                current = current.left;
            }
            return current.data;
        }

        public T findMax()
        {
            TreeNode<T> current = root;
            while (current.right != null)
            {
                current = current.right;
            }
            return current.data;
        }

        public void clear()
        {
            root = null;
        }

        public bool contains(T item)
        {
            TreeNode<T> current = root;

            while (current.data.CompareTo(item) != 0)
            {
                if (item.CompareTo(current.data) < 0)
                {
                    current = current.left;
                }
                else
                {
                    current = current.right;
                }

                if (current == null)
                {
                    return false;
                }
            }
            return true;
        }

        public void remove(T item)
        {
            TreeNode<T> current = root;
            TreeNode<T> parent = root;
            bool isLeftChild = true;

            while (current.data.CompareTo(item) != 0)
            {
                parent = current;
                if (item.CompareTo(current.data) < 0)
                {
                    isLeftChild = true;
                    current = current.left;
                } else
                {
                    isLeftChild = false;
                    current = current.right;
                }
                if (current == null)
                {
                    return;
                }
            }

            if ((current.left == null) && (current.right == null))
            {
                if (current == root)
                {
                    root = null;
                }
                else if (isLeftChild)
                {
                    parent.left = null;
                }
                else
                {
                    parent.right = null;
                }
            }
            else if (current.right == null)
            {
                if (current == root)
                {
                    root = current.left;
                }
                else if (isLeftChild)
                {
                    parent.left = current.left;
                }
                else
                {
                    parent.right = current.right;
                }
            }
            else if (current.left == null)
            {
                if (current == root)
                {
                    root = current.right;
                }
                else if (isLeftChild)
                {
                    parent.left = parent.right;
                }
                else
                {
                    parent.right = current.right;
                }
            }
            else
            {
                TreeNode<T> successor = getSuccessor(current);
                if (current == root)
                {
                    root = successor;
                }
                else if (isLeftChild)
                {
                    parent.left = successor;
                }
                else
                {
                    parent.right = successor;
                }
                successor.left = current.left;
            }
        }

        public TreeNode<T> getSuccessor(TreeNode<T> delNode)
        {
            TreeNode<T> successorParent = delNode;
            TreeNode<T> successor = delNode;
            TreeNode<T> current = delNode.right;
            while (!(current == null))
            {
                successorParent = current;
                successor = current;
                current = current.left;
            }
            if (!(successor == delNode.right))
            {
                successorParent.left = successor.right;
                successor.right = delNode.right;
            }
            return successor;
        }

        public int count()
        {
            return nodeCount;
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
