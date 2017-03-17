namespace ADLibrary.Collections
{
    public class BucketHash<T>
    {
        const int SIZE = 101;
        Arraylist<T>[] buckets;

        public BucketHash()
        {
            buckets = new Arraylist<T>[SIZE];
            for(int i = 0; i < SIZE; i++)
            {
                buckets[i] = new Arraylist<T>(1, 2);        // The buckets are lists of size 1 that double in size when full
            }
        }

        public int hash(T key)
        {
            var i = key.GetHashCode();
            i = i % buckets.Length;
            if(i < 0)
            {
                i += buckets.Length;
            }
            return i;
        }

        public void insert(T item)
        {
            var hashValue = hash(item);
            if(!buckets[hashValue].contains(item))
            {
                buckets[hashValue].add(item);
            }
        }

        public void remove(T item)
        {
            var hashValue = hash(item);
            buckets[hashValue].remove(item);
        }
    }
}
