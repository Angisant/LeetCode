
param(
    [Parameter(Position = 0)]
    [string]$Url
)

$ErrorActionPreference = "Stop"

# Ask for a URL if one wasn't supplied as an argument.
if ([string]::IsNullOrWhiteSpace($Url)) {
    $Url = Read-Host "Paste the LeetCode problem URL"
}

# Extract the problem slug from the URL.
if ($Url -notmatch 'leetcode\.com/problems/([^/?#]+)') {
    throw "Invalid LeetCode problem URL."
}

$slug = $Matches[1]
$apiUrl = "https://leetcode.com/graphql"

# Request the problem title, number, and C# starter code.
$query = @'
query questionData($titleSlug: String!) {
    question(titleSlug: $titleSlug) {
        questionFrontendId
        title
        titleSlug
        codeSnippets {
            lang
            langSlug
            code
        }
    }
}
'@

$body = @{
    operationName = "questionData"
    query         = $query
    variables     = @{ titleSlug = $slug }
} | ConvertTo-Json -Depth 5

try {
    $response = Invoke-RestMethod `
        -Uri $apiUrl `
        -Method Post `
        -ContentType "application/json" `
        -Headers @{ "Referer" = "https://leetcode.com/problems/$slug/" } `
        -Body $body

    $problem = $response.data.question

    if ($null -eq $problem) {
        throw "LeetCode did not return problem data."
    }
}
catch {
    throw "Could not retrieve problem data from LeetCode. $($_.Exception.Message)"
}

$number = $problem.questionFrontendId
$title = $problem.title
$canonicalSlug = $problem.titleSlug

# Find the C# starter code.
$snippet = $problem.codeSnippets |
    Where-Object { $_.lang -eq "C#" -or $_.langSlug -eq "csharp" } |
    Select-Object -First 1

$signature = $null

if ($snippet) {
    # Extract the public method declaration from the starter code.
    $pattern = '(?m)^\s*public\s+(?:(?:static|virtual|override|async|sealed|new)\s+)*(?:[\w.<>,?\[\]\s]+?)\s+\w+\s*\([^;{}\r\n]*\)\s*(?=\{|=>|$)'

    $match = [regex]::Match($snippet.code, $pattern)

    if ($match.Success) {
        $signature = $match.Value.Trim()
    }
}

# Ask for the signature only if LeetCode's starter code
# doesn't contain one we can recognize.
if (-not $signature) {
    Write-Host "Couldn't detect the C# method signature."
    $signature = Read-Host "Enter the method declaration (e.g. public int Solve(int[] nums))"

    if ([string]::IsNullOrWhiteSpace($signature)) {
        throw "A method declaration is required."
    }
}

$fileName = "DQ$number.cs"
$filePath = Join-Path $PSScriptRoot $fileName
$namespace = "Problems.DQ$number"
$problemUrl = "https://leetcode.com/problems/$canonicalSlug/description/"

# Never overwrite an existing solution.
if (Test-Path $filePath) {
    throw "$fileName already exists. Nothing was overwritten."
}

$content = @"
/*
LeetCode daily question #$number $problemUrl
*/

namespace $namespace;

public class Solution
{
    $signature
    {
        // TODO: Implement solution
    }
}
"@

Set-Content -LiteralPath $filePath -Value $content -Encoding utf8

Write-Host "Created $fileName : $title" -ForegroundColor Green

# Open the generated file in VS Code if its CLI is available.
if (Get-Command code -ErrorAction SilentlyContinue) {
    code --reuse-window $filePath
}
else {
    Write-Host "VS Code CLI 'code' wasn't found. Open $filePath manually."
}
