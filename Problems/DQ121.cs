/*
LeetCode daily question #121 https://leetcode.com/problems/best-time-to-buy-and-sell-stock/description/
*/

namespace Problems.DQ121;

public class Solution
{
    public int MaxProfit(int[] prices)
    {
        int maxP = 0, min = prices[0];
        foreach (int p in prices)
        {
            if (p < min)
            {
                min = p;
            }

            if (maxP < p - min)
            {
                maxP = p - min;
            }
        }
        return maxP;
    }
}