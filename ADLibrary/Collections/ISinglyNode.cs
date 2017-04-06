namespace ADLibrary.Collections
{
    /// <summary>
    /// Interface for all our singly nodes. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISinglyNode<T>
    {
        Node<T> next { get; set; }
        T data { get; set; }
    }
}
