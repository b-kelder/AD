using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLibrary.Collections
{
    public class LinearHash<T>
    {
        const int BUCKET_SIZE = 2;

        const int START_BUCKET_COUNT = 10;
        const int TABLE_SIZE = 101;
        int level;
        int bucketPointer;

        Arraylist<T[]> buckets;

        // TODO: Cache result of startBucketCount * (int)Math.Pow(2, level) ?
        public LinearHash()
        {
            buckets = new Arraylist<T[]>(START_BUCKET_COUNT, BUCKET_SIZE);
        }

        public int hash(T key)
        {
            var hashValue = key.GetHashCode();
            hashValue = hashValue % buckets.count();

            if(hashValue < 0)
            {
                hashValue += buckets.count();
            }
            return hashValue;
        }

        private int index(T key)
        {
            var hashed = hash(key);
            int temp = hashed % (START_BUCKET_COUNT * (int)Math.Pow(2, level));       // 2^x is always an integer anyway
            if(temp < bucketPointer)
            {
                return hashed % (START_BUCKET_COUNT * (int)Math.Pow(2, level + 1));
            }
            else
            {
                return temp;
            }
        }

        private void addBucket()
        {
            buckets.add(new T[BUCKET_SIZE]);
            if(bucketPointer == START_BUCKET_COUNT * (int)Math.Pow(2, level))
            {
                bucketPointer = 0;
                level++;
            }
            else
            {
                bucketPointer++;
            }
        }

        public void insert(T item)
        {
            var bucketIndex = index(item);
            throw new DataMisalignedException();
        }
    }
}
