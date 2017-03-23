namespace ADLibrary.Collections
{
    public interface IList<T> : IList<T>
    {
        void add(T item);
        T get(int index);
        int indexOf(T item);
        T removeAt(int index);
        void remove(T item);
        void insert(T item, int index);
    }
}
