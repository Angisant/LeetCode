/*
LeetCode daily question #347 https://leetcode.com/problems/top-k-frequent-elements/description/
*/

namespace Problems.DQ347;

public class Solution
{
    // Dictionary approach => Time: O(nlogn) Space: O(n)
    public int[] TopKFrequent_DefaultSort(int[] nums, int k)
    {
        Dictionary<int, int> freqs = new Dictionary<int, int>();
        foreach (int n in nums)     // O(n)
        {
            if (freqs.ContainsKey(n))
            {
                freqs[n]++;
            }
            else
            {
                freqs.Add(n, 1);
            }
        }
        var entries = freqs.ToArray();
        Array.Sort(entries, (a, b) => b.Value - a.Value);  // Garanteed O(nlogn) complexity
        return entries.Take(k).Select(f => f.Key).ToArray();      // O(k)
    }

    // Bucket sort approach => Time: O(n) Space: O(n)
    public int[] TopKFrequent_BucketSort(int[] nums, int k)
    {
        List<List<int>> buckets = Enumerable.Range(0, nums.Length).Select(_ => new List<int>()).ToList();   // O(n)

        Dictionary<int, int> freqs = new Dictionary<int, int>();
        foreach (int n in nums)     // O(n)
        {
            if (freqs.ContainsKey(n))
            {
                freqs[n]++;
            }
            else
            {
                freqs.Add(n, 1);
            }
        }

        foreach (var (n, freq) in freqs)    // O(n)
        {
            buckets[freq - 1].Add(n);
        }

        int[] topKFreq = new int[k];
        int count = 0;
        for (int b = buckets.Count - 1; b >= 0; b--)    // O(n)
        {
            if (count == k) break;
            foreach (int n in buckets[b])
            {
                topKFreq[count] = n;
                count++;
                if (count == k) break;
            }
        }
        return topKFreq;
    }
}
