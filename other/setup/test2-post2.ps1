
cls
# $github_key = "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"
$github_key = "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"

$orgName = "WyckoffCo"
$repoName = "newRepo1"
$branchName = "main"


# set protection
# https://docs.github.com/en/rest/reference/branches#set-admin-branch-protection

$url = "https://api.github.com/repos/${orgName}/${repoName}/branches/${branchName}/protection/enforce_admins"
$method = "POST"
echo $url


curl -X $method -H "Authorization: token ${github_key}" $url 

# curl -X POST -H "Authorization: token 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" https://api.github.com/repos/WyckoffCo/newRepo1/branches/main/protection/enforce_admins
# curl -X POST -H "Accept: application/vnd.github.v3+json" https://api.github.com/repos/WyckoffCo/newRepo1/branches/main/protection/enforce_admins
