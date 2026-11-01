/*
LeetCode daily question #2409 https://leetcode.com/problems/count-days-spent-together/description/
*/

namespace Problems.DQ2409;

public class Solution
{
    // Approach: Convert everything to dates, check the latest arrival and earliest departure to determine the meeting
    public int CountDaysTogether(string arriveAlice, string leaveAlice, string arriveBob, string leaveBob)
    {
        DateTime arriveA = DateTime.ParseExact(arriveAlice, "MM-dd", null);
        DateTime leaveA = DateTime.ParseExact(leaveAlice, "MM-dd", null);
        DateTime arriveB = DateTime.ParseExact(arriveBob, "MM-dd", null);
        DateTime leaveB = DateTime.ParseExact(leaveBob, "MM-dd", null);

        if (leaveA < arriveB || leaveB < arriveA) return 0;

        DateTime start = (arriveA > arriveB) ? arriveA : arriveB;
        DateTime end = (leaveA < leaveB) ? leaveA : leaveB;

        return (int)(end - start).TotalDays + 1;
    }

    // Approach: Since this all happens within a year, convert everything to the day of the year (e.g.231), check 
    // the latest arrival (bigger arrival value) and earliest departure (smaller departure value) to determine the meeting
    public int CountDaysTogether_Days(string arriveAlice, string leaveAlice, string arriveBob, string leaveBob)
    {
        int arriveA = DateTime.ParseExact(arriveAlice, "MM-dd", null).DayOfYear;
        int leaveA = DateTime.ParseExact(leaveAlice, "MM-dd", null).DayOfYear;
        int arriveB = DateTime.ParseExact(arriveBob, "MM-dd", null).DayOfYear;
        int leaveB = DateTime.ParseExact(leaveBob, "MM-dd", null).DayOfYear;

        if (leaveA < arriveB || leaveB < arriveA) return 0;

        int start = (arriveA > arriveB) ? arriveA : arriveB;
        int end = (leaveA < leaveB) ? leaveA : leaveB;

        return end - start + 1;
    }
}
