using System;

namespace ADLibrary.Collections
{
    /// <summary>
    /// A generic Binary Search Tree list.
    /// </summary>
    /// <typeparam name="T">The type to store in this tree</typeparam>
    public class BinarySearchTree<T> : ICollection<T> where T : IComparable
    {
        /// <summary>
        /// The root node of the tree
        /// </summary>
        private TreeNode<T> root;
        /// <summary>
        /// The amount of items in our list.
        /// </summary>
        private int nodeCount;

        /// <summary>
        /// Default constructor for the BinarySearchTree
        /// </summary>
        public BinarySearchTree() { }

        /// <summary>
        /// Method to add an item to the tree
        /// </summary>
        /// <param name="item"></param>
        public void add(T item)
        {
            //Create a new node to add with the item as data
            TreeNode<T> toAdd = new TreeNode<T>(item);
            //Add to root if root is empty
            if (root == null)
            {
                root = toAdd;
                nodeCount++;
            }
            else
            {
                //Create nodes to keep track of where we are in the tree and who the parent is
                TreeNode<T> current = root;
                TreeNode<T> parent;
                //Keep looping until we are done
                while (true)
                {
                    parent = current;
                    //Check if we need to go to the left or right
                    if (item.CompareTo(current.data) < 0)
                    {
                        current = current.left;
                        //If the correct spot has been found
                        if (current == null)
                        {
                            //Add the node
                            parent.left = toAdd;
                            //Increase node count
                            nodeCount++;
                            return;
                        }
                    }
                    else
                    {
                        current = current.right;
                        //If the correct spot has been found
                        if (current == null)
                        {
                            parent.right = toAdd;
                            //Increase node count
                            nodeCount++;
                            //Add the node
                            return;
                        }
                    }
                }
            }
        }

        private void inOrder(TreeNode<T> root)
        {
            if (root != null)
            {
                inOrder(root.left);
                //root.DisplayNode();
                inOrder(root.right);
            }
        }

        private void preOrder(TreeNode<T> root)
        {
            if (root != null)
            {
                //theRoot.displayNode();
                preOrder(root.left);
                preOrder(root.right);
            }
        }

        private void postOrder(TreeNode<T> root)
        {
            if (root != null)
            {
                postOrder(root.left);
                postOrder(root.right);
                //root.DisplayNode();
            }
        }

        /// <summary>
        /// Method to find the smallest item in the tree
        /// </summary>
        /// <returns>The smallest item</returns>
        public T findMin()
        {
            //Create node to keep track of where we are
            TreeNode<T> current = root;
            //Keep looping until we find the smallest one
            while (current.left != null)
            {
                current = current.left;
            }
            return current.data;
        }

        /// <summary>
        /// Method to find the largest item in the tree
        /// </summary>
        /// <returns>The largest item</returns>
        public T findMax()
        {
            //Create node to keep track of where we are
            TreeNode<T> current = root;
            //Keep looping until we find the largest one
            while (current.right != null)
            {
                current = current.right;
            }
            return current.data;
        }

        /// <summary>
        /// Method to clear the tree
        /// </summary>
        public void clear()
        {
            //Remove any linkt to existing nodes
            root = null;
            nodeCount = 0;
        }

        /// <summary>
        /// Method to check if the tree contains an item
        /// </summary>
        /// <param name="item">The item to check for</param>
        /// <returns>true if found, false if not</returns>
        public bool contains(T item)
        {
            //Create node to keep track of where we are
            TreeNode<T> current = root;
            //Keep looping until we find the item
            while (current.data.CompareTo(item) != 0)
            {
                //Check if we need to go left or right
                if (item.CompareTo(current.data) < 0)
                {
                    current = current.left;
                }
                else
                {
                    current = current.right;
                }

                //If we are at the end of the tree
                if (current == null)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Method to remove an item from the tree
        /// </summary>
        /// <param name="item">The removed item</param>
        public void remove(T item)
        {
            //Create node to keep track of where we are
            TreeNode<T> current = root;
            TreeNode<T> parent = root;
            //Keep track if its a left node or not
            bool isLeftChild = true;

            //Loop until data is not equal
            while (current.data.CompareTo(item) != 0)
            {
                parent = current;
                //if data is smaller traverse the left side else traverse the right side
                if (item.CompareTo(current.data) < 0)
                {
                    isLeftChild = true;
                    current = current.left;
                } else
                {
                    isLeftChild = false;
                    current = current.right;
                }
                //current equals null than the item was not found
                if (current == null)
                {
                    return;
                }
            }

            //If its left and right are null
            if ((current.left == null) && (current.right == null))
            {
                //Check if item is root
                if (current == root)
                {
                    root = null;
                }
                //Set the correct child of its parent to null
                else if (isLeftChild)
                {
                    parent.left = null;
                }
                else
                {
                    parent.right = null;
                }
            }
            //if only right is null
            else if (current.right == null)
            {
                //Check if item is root
                if (current == root)
                {
                    root = current.left;
                }
                //Set the correct child of its parent to null
                else if (isLeftChild)
                {
                    parent.left = current.left;
                }
                else
                {
                    parent.right = current.right;
                }
            }
            //if only left is null
            else if (current.left == null)
            {
                //Check if item is root
                if (current == root)
                {
                    root = current.right;
                }
                //Set the correct child of its parent to null
                else if (isLeftChild)
                {
                    parent.left = parent.right;
                }
                else
                {
                    parent.right = current.right;
                }
            }
            //If both childs are not null
            else
            {
                //Get the successor
                TreeNode<T> successor = getSuccessor(current);
                //Check if item is root
                if (current == root)
                {
                    root = successor;
                }
                //Set the correct child of its parent to the successor
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
            //Decrease the node count
            nodeCount--;
        }

        /// <summary>
        /// Method used to get the successor
        /// </summary>
        /// <param name="delNode">node to delete</param>
        /// <returns>the successor node</returns>
        private TreeNode<T> getSuccessor(TreeNode<T> delNode)
        {
            //Keep track of nodes
            TreeNode<T> successorParent = delNode;
            TreeNode<T> successor = delNode;
            TreeNode<T> current = delNode.right;
            //Loop until current equals null
            while (current != null)
            {
                successorParent = current;
                successor = current;
                current = current.left;
            }
            if (successor != delNode.right)
            {
                successorParent.left = successor.right;
                successor.right = delNode.right;
            }
            return successor;
        }

        /// <summary>
        /// Method to get the total items in the tree
        /// </summary>
        /// <returns>The total items in the tree</returns>
        public int count()
        {
            return nodeCount;
        }

        public T[] toArray()
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// A node to be used in the BST
    /// </summary>
    /// <typeparam name="T">The type to store in this node</typeparam>
    internal class TreeNode<T>
    {
        /// <summary>
        /// The data to store
        /// </summary>
        public T data { get; set; }
        /// <summary>
        /// The left child node
        /// </summary>
        public TreeNode<T> left { get; set; }
        /// <summary>
        /// The right child node
        /// </summary>
        public TreeNode<T> right { get; set; }

        /// <summary>
        /// Default constructor for the node
        /// </summary>
        /// <param name="data">The data to store</param>
        public TreeNode(T data)
        {
            this.data = data;
        }
    }
}
