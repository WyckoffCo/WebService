
cls
$github_key = "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"
#$github_key_secured = ConvertTo-SecureString -String "${github_key}" -AsPlainText -Force
$listenerUrl = "https://wyckoff-jason-github.azurewebsites.net/api/HttpTrigger-Anon?"
$orgName = "WyckoffCo"
$repoName = "newRepo1"
$branchName = "main"
$webhookName = "newWebHook"
#"Authorization: token ${github_key}" 

# -----------------------------------------------------------------------------------------------------------------
##  Get Hooks
# curl -H "Authorization: token ${github_key}" https://api.github.com/orgs/${orgName}/hooks

$url = "https://api.github.com/orgs/${orgName}/hooks"
$stuff = Invoke-RestMethod -Uri $url -Method Get  -Token "${github_key_secured}" -Authentication "Bearer"

$headers = @{
    Authorization='token ' + $github_key
    }

$body = @{
    org=$orgName
    name="test"
    config={
        url: 'url'
        }
    }

$stuff = Invoke-RestMethod -Uri $url -Method Get -Headers $Headers -Verbose

# -----------------------------------------------------------------------------------------------------------------

$url = "https://api.github.com/repos/${orgName}/${repoName}/branches/${branchName}/protection/enforce_admins"

curl -X POST -H "Authorization: token ${github_key}" $url

# -----------------------------------------------------------------------------------------------------------------
##  Create Hooks

$url = "https://api.github.com/orgs/${orgName}/hooks"
$method = "Post"

$headers = @{
    Authorization='token ' + $github_key
    }

$body = @{
    org=$orgName
    name="test"
    config={
        url: 'url'
        }
    }

$stuff = Invoke-RestMethod -Uri $url -Method $method -Headers $headers -Body $body

# -----------------------------------------------------------------------------------------------------------------
# curl \
#   -X POST \
#   -H "Accept: application/vnd.github.v3+json" \
#   https://api.github.com/orgs/ORG/hooks \
#   -d '{"name":"${webhookName}","config":{"url":"${listenerUrl}","content_type":"json","secret":"secret","insecure_ssl":"insecure_ssl","username":"username","password":"password"}}'

curl -X POST -H "Authorization: token ${github_key}" https://api.github.com/orgs/${orgName}/hooks -d '{"name":"${webhookName}","config":{"url":"${listenerUrl}","content_type":"json"}}'




