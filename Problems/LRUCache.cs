/*
LeetCode LRU Cache https://leetcode.com/problems/lru-cache/
*/

// Suggestion to achieve O(1) => Instead of Array/Linked List, combine Hash Table and Doubly Linked List \\


using System.Diagnostics;

//public class LRUCache
//{
//    private int _capacity;
//
//    private List<KeyValuePair<int, int>> cache;
//
//    public LRUCache(int capacity)
//    {
//        if (capacity >= 1 && capacity <= 3000)
//        {
//            _capacity = capacity;
//            cache = new List<KeyValuePair<int, int>>(capacity);
//        }
//        else
//        {
//            Debug.WriteLine($"Capacity {capacity} out of range");
//        }
//    }
//
//    // Return the value of the key if the key exists, otherwise return -1.
//    public int Get(int key)
//    {
//        int value = -1;
//        try
//        {
//            if (key < 0 || key > 10000)
//            {
//                Debug.WriteLine($"Key {key} out of range");
//            }
//            else
//            {
//                int index = cache.FindIndex(c => c.Key == key);
//                if (index >= 0)
//                {
//                    KeyValuePair<int, int> kvp = cache[index];
//                    Debug.WriteLine($"Obtaining kvp with key {key}...");
//                    cache.RemoveAt(index);  // Remove old kvp
//                    cache.Add(kvp);         // Add old kvp to top
//                    value = kvp.Value;
//                }
//            }
//        }
//        catch (Exception e)
//        {
//            Debug.WriteLine($"Key {key} doesn't exist");
//        }
//        return value;
//    }
//
//    /*
//    Update the value of the key if the key exists. Otherwise, add the key-value pair to the cache. 
//    If the number of keys exceeds the capacity from this operation, evict the least recently used key .
//    */
//    public void Put(int key, int value)
//    {
//        try
//        {
//            if (key < 0 || key > 10000)
//            {
//                Debug.WriteLine($"Key {key} out of range");
//            }
//            else if (value < 0 || value > 100000)
//            {
//                Debug.WriteLine($"Value {value} out of range");
//            }
//            else
//            {
//                KeyValuePair<int, int> kvp = new KeyValuePair<int, int>(key, value);
//                int index = cache.FindIndex(c => c.Key == key);
//                if (index >= 0)
//                {
//                    Debug.WriteLine($"Updating old key-value pair: [{cache[index].Key},{cache[index].Value}] to [{key},{value}]...");
//                    cache.RemoveAt(index);
//                }
//                else
//                {
//                    // Cache is full => remove least used key
//                    if (cache.Count >= _capacity)
//                    {
//                        Debug.WriteLine($"Evicting least recently used key [{cache[0].Key},{cache[0].Value}]...");
//                        cache.RemoveAt(0);
//                    }
//                }
//                Debug.WriteLine($"Adding key-value pair: [{key},{value}]...");
//                cache.Add(kvp);         // Add kvp to top
//            }
//        }
//        catch (Exception e)
//        {
//            Debug.WriteLine($"Unsucessfull insertion of kvp [{key},{value}]...");
//        }
//    }
//}

public class LRUCache
{
    private int _capacity;

    private Dictionary<int, LinkedListNode<KeyValuePair<int, int>>> cacheKeyMapping;

    private LinkedList<KeyValuePair<int, int>> cache;

    public LRUCache(int capacity)
    {
        if (capacity >= 1 && capacity <= 3000)
        {
            _capacity = capacity;
            cache = new LinkedList<KeyValuePair<int, int>>();
            cacheKeyMapping = new Dictionary<int, LinkedListNode<KeyValuePair<int, int>>>();
        }
        else
        {
            Debug.WriteLine($"Capacity {capacity} out of range");
        }
    }

    // Return the value of the key if the key exists, otherwise return -1.
    public int Get(int key)
    {
        int value = -1;
        try
        {
            if (key < 0 || key > 10000)
            {
                Debug.WriteLine($"Key {key} out of range");
            }
            else
            {
                if (cacheKeyMapping.TryGetValue(key, out LinkedListNode<KeyValuePair<int, int>> node))
                {
                    KeyValuePair<int, int> kvp = node.Value;
                    Debug.WriteLine($"Obtaining kvp with key {key}...");
                    cache.Remove(node);  // Remove old kvp
                    cacheKeyMapping[key] = cache.AddLast(kvp);         // Add old kvp to top
                    value = kvp.Value;
                }
            }
        }
        catch (Exception e)
        {
            Debug.WriteLine($"Key {key} doesn't exist");
        }
        return value;
    }

    /*
    Update the value of the key if the key exists. Otherwise, add the key-value pair to the cache. 
    If the number of keys exceeds the capacity from this operation, evict the least recently used key .
    */
    public void Put(int key, int value)
    {
        try
        {
            if (key < 0 || key > 10000)
            {
                Debug.WriteLine($"Key {key} out of range");
            }
            else if (value < 0 || value > 100000)
            {
                Debug.WriteLine($"Value {value} out of range");
            }
            else
            {
                bool hasKey = cacheKeyMapping.TryGetValue(key, out LinkedListNode<KeyValuePair<int, int>> node);
                if (hasKey)
                {
                    Debug.WriteLine($"Updating old key-value pair: [{node.Value.Key},{node.Value.Value}] to [{key},{value}]...");
                    cache.Remove(node);
                }
                else
                {
                    // Cache is full => remove least used key
                    if (cache.Count >= _capacity)
                    {
                        Debug.WriteLine($"Evicting least recently used key [{cache.First.Value.Key},{cache.First.Value.Value}]...");
                        cacheKeyMapping.Remove(cache.First.Value.Key);
                        cache.RemoveFirst();
                    }
                }
                Debug.WriteLine($"Adding key-value pair: [{key},{value}]...");
                KeyValuePair<int, int> kvp = new KeyValuePair<int, int>(key, value);
                LinkedListNode<KeyValuePair<int, int>> newNode = cache.AddLast(kvp);         // Add kvp to top

                if (!hasKey)
                {
                    cacheKeyMapping.Add(key, newNode);
                }
                else
                {
                    cacheKeyMapping[key] = newNode;
                }
            }
        }
        catch (Exception e)
        {
            Debug.WriteLine($"Unsucessfull insertion of kvp [{key},{value}]...");
        }
    }
}


