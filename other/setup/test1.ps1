
cls
$github_key = "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"
$orgName = "WyckoffCo"
$repoName = "newRepo1"
$branchName = "main"


# set protection

# $url = "https://api.github.com/repos/${orgName}/${repoName}/branches/${branchName}/protection/enforce_admins"

# get repo
$url = "https://api.github.com/repos/${orgName}/${repoName}"
$method = "GET"
$url = "https://api.github.com/orgs/${orgName}/repos"
echo $url

curl -X $method -H "Authorization: token ${github_key}" $url
