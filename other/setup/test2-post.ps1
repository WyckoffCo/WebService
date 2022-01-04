
cls
# $github_key = "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"
$github_key = "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"

$orgName = "WyckoffCo"
$repoName = "newRepo3"
$branchName = "main"


# set protection

# $url = "https://api.github.com/repos/${orgName}/${repoName}/branches/${branchName}/protection/enforce_admins"

# /orgs/{org}/repos
$method = "POST"
$url = "https://api.github.com/orgs/${orgName}/repos"
echo $url

$body = @{
    org=$orgName
    name="${repoName}"
    visibility="public"
    auto_init="true"
    }

curl -X $method -H "Authorization: token ${github_key}" $url -d '{"name":"${repoName}","org":"${orgName}","visibility":"public"}'
