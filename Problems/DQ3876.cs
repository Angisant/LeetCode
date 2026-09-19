/*
LeetCode daily question #3876 https://leetcode.com/problems/construct-uniform-parity-array-ii/description/
*/

namespace Problems.DQ3876;

public class Solution
{
    /*
        Option 1: nums2[i] = nums1[i]​​​​​​​
        Option 2: nums2[i] = nums1[i] - nums1[j], for an index j != i, such that nums1[i] - nums1[j] >= 1 => nums1[i] > nums1[j]

        Case 1: All numbers in num1 are even => num2 = num1 => true
        Case 2: All numbers in num1 are odd => num2 = num1 => true
        Case 3: There's atleast one odd and one even in num1. One odd can make all evens odd (Even - Odd) => 
            num2 is odd => true
    */
    public bool UniformArray(int[] nums1)
    {
        int oddNumsCount = 0, smallestOdd = 0;
        foreach (int n in nums1)
        {
            if (n % 2 != 0)
            {
                if (smallestOdd == 0 || n < smallestOdd)
                {
                    smallestOdd = n;
                }
                oddNumsCount++;
            }
        }

        // Check if its all evens or all odds
        if (oddNumsCount == 0 || oddNumsCount == nums1.Length) return true;

        // There's atleast one odd and one even => one odd turns all evens into odds.
        foreach (int n in nums1)
        {
            // If the number is even we have to look for a smaller odd number to be able to turn it odd
            if (n % 2 == 0 && n < smallestOdd) return false;
        }
        return true;
    }
}