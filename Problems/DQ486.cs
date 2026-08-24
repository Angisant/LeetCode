/*
LeetCode daily question #486 https://leetcode.com/problems/predict-the-winner/description/
*/

// DOOVER. RECURSION

namespace Problems.DQ486;

public class Solution
{
    public bool PredictTheWinner(int[] nums)
    {
        int player1Score = 0, player2Score = 0;
        int startIndex = 0, endIndex = nums.Length - 1;
        bool isPlayer1Turn = true;

        while (true)
        {
            if (startIndex > endIndex) // End case
            {
                // Player 1 wins if score is higher or equal
                return player1Score >= player2Score;
            }
            else
            {
                int turnScore = 0;

                // Get highest score
                if (nums[startIndex] >= nums[endIndex])
                {
                    turnScore = nums[startIndex];
                    startIndex++;
                }
                else
                {
                    turnScore = nums[endIndex];
                    endIndex--;
                }

                // Add score
                if (isPlayer1Turn)
                {
                    player1Score += turnScore;
                }
                else
                {
                    player2Score += turnScore;
                }
                isPlayer1Turn = !isPlayer1Turn; // switch player turn
            }
        }
    }
}