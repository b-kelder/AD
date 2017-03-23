namespace ADLibrary.Collections
{
    /// <summary>
    /// Interface for all our collections. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IList<T>
    {
        bool contains(T item);
        void clear();
        int count();
        T[] toArray();
    }
}
