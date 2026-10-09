/*
LeetCode LRU Cache https://leetcode.com/problems/lfu-cache/
*/

using System.Diagnostics;

public class LFUCache
{
    private int _capacity;

    private Dictionary<int, LinkedListNode<KeyValuePair<int, int>>> cacheKeyMapping;

    private Dictionary<int, int> cacheKeyFrequency;

    private LinkedList<KeyValuePair<int, int>> cache;

    public LFUCache(int capacity)
    {
        if (capacity >= 1 && capacity <= 10000)
        {
            _capacity = capacity;
            cache = new LinkedList<KeyValuePair<int, int>>();
            cacheKeyMapping = new Dictionary<int, LinkedListNode<KeyValuePair<int, int>>>();
            cacheKeyFrequency = new Dictionary<int, int>();
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
            if (key < 0 || key > 100000)
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

                    cacheKeyFrequency[key]++;   // Update key frequency
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
    If the number of keys exceeds the capacity from this operation, evict the least frequently used key .
    */
    public void Put(int key, int value)
    {
        try
        {
            if (key < 0 || key > 100000)
            {
                Debug.WriteLine($"Key {key} out of range");
            }
            else if (value < 0 || value > 1000000000)
            {
                Debug.WriteLine($"Value {value} out of range");
            }
            else
            {
                if (cacheKeyMapping.TryGetValue(key, out LinkedListNode<KeyValuePair<int, int>> node))
                {
                    Debug.WriteLine($"Updating old key-value pair: [{node.Value.Key},{node.Value.Value}] to [{key},{value}]...");
                    cache.Remove(node);
                }
                else
                {
                    // Cache is full => remove least frequently used key
                    if (cache.Count >= _capacity)
                    {
                        List<int> lfuKeys = GetLeastFrequentlyUsedKeys();
                        if (lfuKeys.Count > 1)  // Remove least recently used key
                        {
                            Debug.WriteLine($"Obtaining least recently used key...");
                            int lru = GetLeastRecentlyUsedKey(lfuKeys);
                            RemoveKey(lru);
                        }
                        else    // Remove least frequently used key
                        {
                            Debug.WriteLine($"Obtaining least frequently used key...");
                            int lfu = lfuKeys.First();
                            RemoveKey(lfu);
                        }
                    }
                }
                Debug.WriteLine($"Adding key-value pair: [{key},{value}]...");
                AddOrUpdateKeyValuePair(key, value);
            }
        }
        catch (Exception e)
        {
            Debug.WriteLine($"Unsucessfull insertion of kvp [{key},{value}]...");
        }
    }

    private List<int> GetLeastFrequentlyUsedKeys()
    {
        int minFreq = -1;
        List<int> lfuKeys = new List<int>();
        foreach (var kvp in cacheKeyFrequency)
        {
            if (minFreq < 0 || kvp.Value < minFreq)
            {
                minFreq = kvp.Value;
                lfuKeys.Clear();
                lfuKeys.Add(kvp.Key);
            }
            else if (kvp.Value == minFreq)
            {
                lfuKeys.Add(kvp.Key);
            }
        }
        return lfuKeys;
    }

    private int GetLeastRecentlyUsedKey(List<int> keys)
    {
        HashSet<int> set = new HashSet<int>(keys);
        LinkedListNode<KeyValuePair<int, int>> node = cache.First;
        while (node != null)
        {
            int key = node.Value.Key;
            if (set.Contains(key))
            {
                return key;
            }
            node = node.Next;
        }
        return -1;
    }

    private bool RemoveKey(int key)
    {
        if (cacheKeyMapping.TryGetValue(key, out LinkedListNode<KeyValuePair<int, int>> node))
        {
            Debug.WriteLine($"Evicting key [{key},{node.Value.Value}]...");
            cacheKeyMapping.Remove(key);
            cacheKeyFrequency.Remove(key);
            cache.Remove(node);
            return true;
        }
        return false;
    }

    private void AddOrUpdateKeyValuePair(int key, int value)
    {
        KeyValuePair<int, int> kvp = new KeyValuePair<int, int>(key, value);
        LinkedListNode<KeyValuePair<int, int>> newNode = cache.AddLast(kvp);         // Add kvp to top
        if (cacheKeyMapping.ContainsKey(key))
        {
            cacheKeyMapping[key] = newNode;
            cacheKeyFrequency[key]++;   // Update key frequency
        }
        else
        {
            cacheKeyMapping.Add(key, newNode);
            cacheKeyFrequency.Add(key, 1);
        }
    }

    public void PrintCache()
    {
        string str = "END:";
        foreach (var node in cache)
        {
            str += $"({node.Key}, {node.Value})";
        }
        str += ":START";
        Console.WriteLine(str);
    }
}