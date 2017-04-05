namespace ADLibrary.Collections
{
    public interface IDoublyNode<T>
    {
        Node<T> next { get; set; }
        Node<T> previous { get; set; }
        T data { get; set; }
    }
}