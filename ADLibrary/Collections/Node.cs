namespace ADLibrary.Collections
{
    /// <summary>
    /// Interface for all our nodes. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T> : ISinglyNode<T>, IDoublyNode<T>
    {
        public Node<T> next { get; set; }
        public Node<T> previous { get; set; }
        public T data { get; set; }

        public Node(T element)
        {
            this.data = element;
        }
    }
}
