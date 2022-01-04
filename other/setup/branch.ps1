cls
$dir1 = $pwd
$dir2 = "C:\temp\2022-01-02"
$repoName = "newRepo1"
$repoUrl = "https://github.com/WyckoffCo/${repoName}"
$branchName = Get-Random

cd $dir2
git clone $repoUrl
cd $repoName

#git checkout main
git branch $branchName
git checkout $branchName
echo "# newRepo1asdf" >> README.md
git add README.md
git commit -m "commit asdf"
git push --set-upstream origin $branchName

cd ..
rd $repoName -Recurse -Force  
cd $dir1
