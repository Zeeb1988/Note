1.GitHub远程仓库同步到本地:

git clone URL
git init

2.远程添加/删除源

git remote add origin URL
git remote rm  origin

3.查看仓库状态

git status

4.提交更改到暂存区

git add readme.txt
git add --all

5.提交到本地仓库

git commit -m"更新的版本或者内容"

6.将本地仓库覆盖同步远程仓库

git push origin main
git push --all

7.将远程仓库覆盖同步本地仓库

git pull --all

8.分支

git checkout main     切换到main分支
git merge master      将master分支内容与当前分支内容合并
git branch -d master  删除master分支
git branch master     创建master分支
git branch -a         查看所有本地分支和远程分支

