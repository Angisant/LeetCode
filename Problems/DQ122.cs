/*
LeetCode daily question #122 https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/description/
*/

namespace Problems.DQ122;

public class Solution
{
    public int MaxProfit(int[] prices)
    {
        int maxP = 0, currMaxP = 0, min = prices[0];
        for (int i = 0; i < prices.Length; i++)
        {
            int p = prices[i];
            if (p < min || currMaxP > p - min)
            {
                maxP += currMaxP;
                currMaxP = 0;
                min = p;
            }
            else if (currMaxP < p - min)     // Is there a new current max profit?
            {
                currMaxP = p - min;
            }
        }
        return maxP + currMaxP;
    }
}