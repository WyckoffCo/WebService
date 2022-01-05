cls

$temp = Get-Random
$repoName = "newRepo${temp}"

gh repo create WyckoffCo/$repoName -d "test repo" --public


# Delete repo when done.

# gh auth refresh -h github.com -s delete_repo
# gh repo delete WyckoffCo/$repoName --confirm

