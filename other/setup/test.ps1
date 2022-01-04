
cls
# https://docs.microsoft.com/en-us/aspnet/core/web-api/http-repl/?view=aspnetcore-6.0&tabs=windows#test-http-post-requests
$url = "http://localhost:7071/api/NewRepo"
#$rootUrl = "http://localhost:7071"
# $dir2 = "C:\temp\2022-01-02"
# $repoName = "newRepo1"
# $repoUrl = "https://github.com/WyckoffCo/${repoName}"
# $branchName = Get-Random

httprepl $url
#pref set editor.command.default "C:\Users\JasonWyckoff\AppData\Local\Programs\Microsoft VS Code\Code.exe"
# pref set editor.command.default "C:\Program Files\Notepad++\notepad++.exe"
post -h Content-Type=application/json -f "test-body-newrepo.json"

#httprepl connect --base $url --verbose
# post <PARAMETER> [-c|--content] [-f|--file] [-h|--header] [--no-body] [-F|--no-formatting] [--response] [--response:body] [--response:headers] [-s|--streaming]


