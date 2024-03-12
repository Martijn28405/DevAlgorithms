using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Solution;

public class HashTable<K, V> : IHashTable<K, V>
{
    Entry<K, V>[]? buckets { get; set;}

    public ReadOnlyCollection<Entry<K, V>> data => buckets == null? null : buckets.AsReadOnly();

    public HashTable() { buckets = null; }

    public HashTable(Entry<K, V>[]? input) { importData(input);}

    public HashTable(int capacity)
    {
        buckets = new Entry<K, V>[capacity];
    }

    protected int getIndex(K key)
    {
        int hashCode = Math.Abs(key.GetHashCode());
        return hashCode % buckets.Length;
    }
    protected int getNextIndex(int index)
    {
        return (index + 1) % buckets.Length;
    }

    public bool Add(K key, V value)
    {
        int index = getIndex(key);
        if (buckets[index] != null && buckets[index].Key.Equals(key)) return false;
        if (buckets[index] == null)
        {
            buckets[index] = new Entry<K, V>(key, value);
            return true;
        }

        return default;
    }

    public V? Find(K key)
    {
        int index = getIndex(key);
        if (buckets != null && buckets[index] != null && buckets[index].Key.Equals(key)) return buckets[index].Value;
        int potentialindex = index++ % buckets.Length;
        while (potentialindex != index)
        {
            if (buckets != null && buckets[potentialindex] != null && buckets[potentialindex].Key.Equals(key))
            {
                return buckets[potentialindex].Value;
            }
            potentialindex = getNextIndex(potentialindex);
            
        }
        return default;
        
    }

    public bool Delete(K key)
    {      
        int index = getIndex(key);
        if (buckets[index] != null && buckets[index].Key.Equals(key))
        {
            buckets[index] = null;
            return true;
        }
        int potentialindex = index++ % buckets.Length;
        while (potentialindex != index)
        {
            if (buckets[potentialindex].Key.Equals(key))
            {
                buckets[potentialindex] = null;
                return true;
            }
            potentialindex = getNextIndex(potentialindex);
        }

        return false;                        
    }


    //DO NOT REMOVE the following method:
    private void importData(Entry<K, V>[]? inputData){
        if(inputData != null) {
            buckets = new Entry<K, V>[inputData.Length];
            for (int i = 0; i < inputData.Length; ++i) 
                buckets[i] = inputData[i];
        }
    }
}