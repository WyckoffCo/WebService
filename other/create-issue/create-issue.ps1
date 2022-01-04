

cls
# $github_key = "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"
$github_key = "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"

$orgName = "WyckoffCo"
$repoName = "newRepo1"



# set protection
# https://docs.github.com/en/rest/reference/branches#update-branch-protection

# /repos/{owner}/{repo}/issues


$url = "https://api.github.com/repos/${orgName}/${repoName}/issues"
$method = "POST"
echo $url


#$body = Get-Content .\test2-post3.json -Raw

#echo $body

curl -X $method -H "Authorization: token ${github_key}" $url -d "{'title':'MY ISSUE'}"