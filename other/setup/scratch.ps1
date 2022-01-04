$repoName = "newRepo2"


gh repo create WyckoffCo/$repoName  --private --disable-wiki --disable-issues -d "another repo"

gh auth refresh -h github.com -s delete_repo
gh repo delete WyckoffCo/$repoName --confirm





httprepl http://localhost:7071/api/Function1
post -h Content-Type=application/json

connect <ROOT URI> --verbose
