cls

$temp = Get-Random
$repoName = "newRepo${temp}"
#$repoUrl = "https://github.com/WyckoffCo/${repoName}"

gh repo create WyckoffCo/$repoName -d "another repo"

# gh auth refresh -h github.com -s delete_repo
# gh repo delete WyckoffCo/$repoName --confirm

