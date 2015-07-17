# framework_demoes
##### Description
This repo is for our initial efforts programming the game 'Fusion Bombs Derp' in Unity 2D. The idea behind using this repo is that we may have to prototype other Unity projects in order to investigate different code examples / features before implementing them into our main body of code. 

____
____
## Dev Info
### Git
This section will include various git command combonations, tpo help prevent any **Ooops'** happening to the repo or anyones personal code. 
Some sweet links:

[git command cheat sheet](https://training.github.com/kit/downloads/github-git-cheat-sheet.pdf)

[git markdown guide](https://help.github.com/articles/markdown-basics/)
#### Git command "variables"
Some of these command will have a spot with a vairable, like this: \<variablename\>. 

These will be described here:
* \<branchname\>  The name of the branch you are working on. We are cureent (mis)using "master"
* \<variablename\>  from the example, not used.
 

____
#### Typical dev workflow

Before opening the project in Unity, pull changes from the repo:
* `git pull`

Then do some work. Once you are done, close Unity and push the changes into github:
* `git add .`   -   You may have to use the flag "-A"
* `git commit -m "I did this, that, and the other!"`
* `git pull`
* `git push origin <branchname>`


____
#### To Wipe All Local Changes

##### This will destroy any work you have done!
##### Make a copy of your work manually! Run this at your own risk!

* `git fetch origin`
* `git reset --hard origin/master`

____
#### Issues, Branches, etc..
Heres a few links to warm-up:
[Using pull requests](https://help.github.com/articles/using-pull-requests/)
[Basic Branching & Merging](https://git-scm.com/book/en/v2/Git-Branching-Basic-Branching-and-Merging)

##### View all branches branch
* `git branch`

##### Making a branch
* `git checkout -b <branchname> `
  *  This is shorthand for these two commands:
  *  `git branch <branchname>`
  *  `git checkout <branchname>`
* `git push origin <branchname> ` 
  * Now github knows about your branch

##### Setting remote for a branch
* `git remote add <remote_server>`
  * OPTIONAL: probably gonna wanna keep this origin
* `git push origin <branchname> ` 
  
##### Deleting a branch locally
* `git branch -D <branchname> `

##### Working in your branch, and not master
coming soon(TM)

##### Merging your branch with master, or some other branch.
coming soon(TM)

##### Address an Issue, then create a Pull request
This workflow has the user take a fresh issue, make a branch, complete the issue, and merge the branch back into master.

* `git checkout -b <branchname> `
  * Use the issue+number as the name (Eg. For issue#53 use "**iss53**")
  * If you already have the branch, leave out the **-b** flag

Do work as per the typical workflow. Once you have you last commit pushed, do this:
* Goto github.com and create a pull request.
  * [github tut](https://help.github.com/articles/creating-a-pull-request/)
* I have no clue whats next. Never got this far...


____
### Development Schedule
This section is to help coordinate any sort of timeline building, as well as help us to coordinate our schedules. Real life supercedes all schedules directives, except where specifically stated & agreed upon.

##### Weekly
* We will separately made code changes, when we find time. Shoot for at least 1 per week. 
* We will make our best attempt at meeting every Friday for 2-4+ hours to coordinate our changes and make some progress on existing issues & features.
 * If not, we can *make it up* by doing more solo work the week before.

##### Monthly
* We will both coordinate our scheudles and attempt to declare a "*Coding Weekend!* " 1-2 times monthly to make 'sprint' and make serious headway on the larger|new|outstanding issues & features. 
