/*
LeetCode daily question #238 https://leetcode.com/problems/product-of-array-except-self/description/
*/

namespace Problems.DQ238;

public class Solution
{
    // Normal Approach: Calculate total product and then divide it by current   O(n)
    // Problem: [-1,1,0,-3,3]=>[0,0,9,0,0] zeros screw up everything
    public int[] ProductExceptSelf_TotalProduct(int[] nums)
    {
        int totalProd = 1;
        foreach (int n in nums)
        {
            totalProd *= n;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != 0)
            {
                nums[i] = totalProd / nums[i];
            }
        }
        return nums;
    }

    // Brute Force Approach: For each n[i], calculate the product of the array without n[i]   O(n^2)
    // Problem: [-1,-1,-1,-1,...]   We can have a lot of repeated values that make us revisit the whole array
    public int[] ProductExceptSelf_BruteForce(int[] nums)
    {
        int[] answer = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            int prod = 1;
            for (int j = 0; j < nums.Length; j++)
            {
                if (i != j)
                {
                    prod *= nums[j];
                }
            }
            answer[i] = prod;
        }
        return answer;
    }

    //  Hashing Approach: For each distinct m[i], calculate the product of the array without n[i]  O(n*m)
    public int[] ProductExceptSelf_Hashing(int[] nums)
    {
        Dictionary<int, int> prods = new Dictionary<int, int>();
        int[] answer = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            if (prods.TryGetValue(nums[i], out int p))
            {
                answer[i] = p;
            }
            else
            {
                int prod = 1;
                for (int j = 0; j < nums.Length; j++)
                {
                    if (i != j)
                    {
                        prod *= nums[j];
                    }
                }
                answer[i] = prod;
                prods.Add(nums[i], prod);
            }
        }
        return answer;
    }

    //  Prefix/Suffix Approach: For each n[i], calculate the products of [0,n-1] and [n+1,Length]  O(n)
    public int[] ProductExceptSelf_PrefixSuffix(int[] nums)
    {
        int[] preProds = new int[nums.Length];
        int[] sufProds = new int[nums.Length];
        int[] answer = new int[nums.Length];    // We can also just modify nums

        int preProd = 1, sufProd = 1;
        for (int i = 0; i < nums.Length; i++)
        {
            preProds[i] = preProd;
            preProd *= nums[i];

            sufProds[nums.Length - 1 - i] = sufProd;
            sufProd *= nums[nums.Length - 1 - i];
        }

        for (int i = 0; i < nums.Length; i++)
        {
            answer[i] = preProds[i] * sufProds[i];
        }
        return answer;
    }
}
