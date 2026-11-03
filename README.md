# LeetCode

This repository contains my LeetCode problem solutions.

## Generate a File for the Daily Question

To simplify the process of creating a new file for solving a LeetCode Daily Question, I created the `DQ_FileGen.ps1` PowerShell script.

The script works correctly for most common problems but does not yet support problems with more complex starter code, such as [LRU Cache](https://leetcode.com/problems/lru-cache/description/).

### Usage

Run the script from the repository's root directory:

```powershell
PS C:\path\to\LeetCode> .\Problems\DQ_FileGen.ps1
```

When prompted, paste the URL of the LeetCode problem you want to solve:

```text
Paste the LeetCode problem URL: https://leetcode.com/problems/minimum-moves-to-equal-array-elements-ii/description/
```