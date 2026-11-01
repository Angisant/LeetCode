/*
LeetCode daily question #43 https://leetcode.com/problems/multiply-strings/description/
*/

namespace Problems.DQ43;

public class Solution
{
    // Approach: Save number digits in arrays. Calculate, save and join partial products
    // Time: O(l1*l2)    Space: O(l1*l2)
    public string Multiply_PartialProducts(string num1, string num2)
    {
        if (num1 == "0" || num2 == "0") return "0";

        int l1 = num1.Length, l2 = num2.Length;
        int[][] partialProds = new int[l1][];
        int[] n1 = new int[l1];
        int[] n2 = new int[l2];
        int[] res = new int[l1 + l2];

        for (int i = 0; i < l1; i++)
        {
            n1[i] = num1[i] - '0';
        }

        for (int i = 0; i < l2; i++)
        {
            n2[i] = num2[i] - '0';
        }

        for (int i = 0; i < l1; i++)    // Bottom number
        {
            int carry = 0;
            partialProds[i] = new int[l2 + 1];
            for (int j = 0; j < l2; j++)    // Top number
            {
                int num = n1[l1 - 1 - i] * n2[l2 - 1 - j] + carry;

                carry = num / 10;
                if (num > 9)
                {
                    num %= 10;
                }
                partialProds[i][l2 - j] = num;
            }
            if (carry > 0) partialProds[i][0] = carry;
        }


        for (int i = 0; i < partialProds.Length; i++)
        {
            int carry = 0;
            for (int j = partialProds[i].Length - 1; j >= 0; j--)
            {
                int pos = res.Length - 1 - i - (partialProds[i].Length - 1 - j);

                int sum = res[pos] + partialProds[i][j] + carry;
                res[pos] = sum % 10;
                carry = sum / 10;
            }
        }

        if (res[0] == 0) res = res[1..];

        return new string(res.Select(r => (char)(r + '0')).ToArray());
    }

    // Approach: Calculate and only save on final number array
    // Time: O(l1*l2)    Space: O(l1+l2)
    public string Multiply_Simplified(string num1, string num2)
    {
        if (num1 == "0" || num2 == "0") return "0";

        int l1 = num1.Length, l2 = num2.Length;
        int[] res = new int[l1 + l2];

        // Go through digits from right to left
        for (int i = l1 - 1; i >= 0; i--)
        {
            for (int j = l2 - 1; j >= 0; j--)
            {
                int pos = i + j + 1;
                int n1 = num1[i] - '0', n2 = num2[j] - '0';     // Convert digits to int    
                int sum = n1 * n2 + res[pos];   // Do multiplication and add any value that may have been carried over

                res[pos] = sum % 10;
                res[pos - 1] += sum / 10;     // Carry value to left operation
            }
        }

        if (res[0] == 0) res = res[1..];

        return new string(res.Select(r => (char)(r + '0')).ToArray());
    }
}
