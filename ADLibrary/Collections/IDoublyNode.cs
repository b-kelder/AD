namespace ADLibrary.Collections
{
    /// <summary>
    /// Interface for all our doubly nodes. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDoublyNode<T>
    {
        Node<T> next { get; set; }
        Node<T> previous { get; set; }
        T data { get; set; }
    }
}