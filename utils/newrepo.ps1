cls

# $temp = Get-Random
$temp = "-2022-01-07-v2"
$orgName = "WyckoffCo"
$repoName = "newRepo${temp}"

gh repo create $orgName/$repoName -d "test repo" --public --template $orgName/"repoTemplate"

# Delete repo when done.

# gh auth refresh -h github.com -s delete_repo
# gh repo delete WyckoffCo/$repoName --confirm



