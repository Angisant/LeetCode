/*
LeetCode daily question #1401 https://leetcode.com/problems/circle-and-rectangle-overlapping/description/
*/

namespace Problems.DQ1401;

public class Solution
{
    public bool CheckOverlap(int radius, int xCenter, int yCenter, int x1, int y1, int x2, int y2)
    {
        // Inequation for any P(x,y) that belongs to rectangle: x1<=x<=x2 & y1<=y<=y2
        // Check if main circle points belongs to rectangle
        int x1Circle = xCenter - radius;
        int x2Circle = xCenter + radius;
        int y1Circle = yCenter - radius;
        int y2Circle = yCenter + radius;
        if ((x1Circle >= x1 && x1Circle <= x2 && yCenter >= y1 && yCenter <= y2) ||
        (x2Circle >= x1 && x2Circle <= x2 && yCenter >= y1 && yCenter <= y2) ||
        (xCenter >= x1 && xCenter <= x2 && y1Circle >= y1 && y1Circle <= y2) ||
        (xCenter >= x1 && xCenter <= x2 && y2Circle >= y1 && y2Circle <= y2)) return true;

        // Inequation for any P(x,y) that belongs to circle: (x-xCenter)^2 + (y-yCenter)^2 <= radius^2
        // For each point in rectangles borders, we will check if it belongs to circle
        double d1 = Math.Sqrt(Math.Pow(x1 - xCenter, 2) + Math.Pow(y1 - yCenter, 2));   // bottom left corner
        double d2 = Math.Sqrt(Math.Pow(x2 - xCenter, 2) + Math.Pow(y2 - yCenter, 2));   // top right corner
        double d3 = Math.Sqrt(Math.Pow(x1 - xCenter, 2) + Math.Pow(y2 - yCenter, 2));   // top left corner
        double d4 = Math.Sqrt(Math.Pow(x2 - xCenter, 2) + Math.Pow(y1 - yCenter, 2));   // bottom right corner

        // Check if rectangle corners belong to circle
        if (d1 <= radius || d2 <= radius || d3 <= radius || d4 <= radius) return true;

        if (d1 <= d2 && d1 <= d3 && d1 <= d4)
        {
            double dx = Math.Sqrt(Math.Pow(x1 + 1 - xCenter, 2) + Math.Pow(y1 - yCenter, 2));
            double dy = Math.Sqrt(Math.Pow(x1 - xCenter, 2) + Math.Pow(y1 + 1 - yCenter, 2));
            // Check which edge is closer to circle
            if (dx <= dy)
            {
                // Travel along (x1y1)(x2y1) edge
                for (int x = x1 + 1; x < x2; x++)
                {
                    if (Math.Sqrt(Math.Pow(x - xCenter, 2) + Math.Pow(y1 - yCenter, 2)) <= radius) return true;
                }
            }
            else
            {
                // Travel along (x1y1)(x1y2) edge
                for (int y = y1 + 1; y < y2; y++)
                {
                    if (Math.Sqrt(Math.Pow(x1 - xCenter, 2) + Math.Pow(y - yCenter, 2)) <= radius) return true;
                }
            }
        }
        else if (d2 <= d1 && d2 <= d3 && d2 <= d4)
        {
            double dx = Math.Sqrt(Math.Pow(x2 - 1 - xCenter, 2) + Math.Pow(y2 - yCenter, 2));
            double dy = Math.Sqrt(Math.Pow(x2 - xCenter, 2) + Math.Pow(y2 - 1 - yCenter, 2));
            // Check which edge is closer to circle
            if (dx <= dy)
            {
                // Travel along (x2y2)(x1y2) edge
                for (int x = x2 - 1; x > x1; x--)
                {
                    if (Math.Sqrt(Math.Pow(x - xCenter, 2) + Math.Pow(y2 - yCenter, 2)) <= radius) return true;
                }
            }
            else
            {
                // Travel along (x2y2)(x2y1) edge
                for (int y = y2 - 1; y > y1; y--)
                {
                    if (Math.Sqrt(Math.Pow(x2 - xCenter, 2) + Math.Pow(y - yCenter, 2)) <= radius) return true;
                }
            }
        }
        else if (d3 <= d1 && d3 <= d2 && d3 <= d4)
        {
            double dx = Math.Sqrt(Math.Pow(x1 + 1 - xCenter, 2) + Math.Pow(y2 - yCenter, 2));
            double dy = Math.Sqrt(Math.Pow(x1 - xCenter, 2) + Math.Pow(y2 - 1 - yCenter, 2));
            // Check which edge is closer to circle
            if (dx <= dy)
            {
                // Travel along (x1y2)(x2y2) edge
                for (int x = x1 + 1; x < x2; x++)
                {
                    if (Math.Sqrt(Math.Pow(x - xCenter, 2) + Math.Pow(y2 - yCenter, 2)) <= radius) return true;
                }
            }
            else
            {
                // Travel along (x1y2)(x1y1) edge
                for (int y = y2 - 1; y > y1; y--)
                {
                    if (Math.Sqrt(Math.Pow(x1 - xCenter, 2) + Math.Pow(y - yCenter, 2)) <= radius) return true;
                }
            }
        }
        else
        {
            double dx = Math.Sqrt(Math.Pow(x2 - 1 - xCenter, 2) + Math.Pow(y1 - yCenter, 2));
            double dy = Math.Sqrt(Math.Pow(x2 - xCenter, 2) + Math.Pow(y1 - yCenter, 2));
            // Check which edge is closer to circle
            if (dx <= dy)
            {
                // Travel along (x2y1)(x1y1) edge
                for (int x = x2 - 1; x > x1; x--)
                {
                    if (Math.Sqrt(Math.Pow(x - xCenter, 2) + Math.Pow(y1 - yCenter, 2)) <= radius) return true;
                }
            }
            else
            {
                // Travel along (x2y1)(x2y2) edge
                for (int y = y1 + 1; y < y2; y++)
                {
                    if (Math.Pow(x2 - xCenter, 2) + Math.Pow(y - yCenter, 2) <= radius) return true;
                }
            }
        }
        return false;
    }
}