# framework_demoes
## Description
This repo is for our initial efforts programming the game 'Fusion Bombs Derp' in Unity 2D. The idea behind using this repo is that we may have to prototype other Unity projects in order to investigate different code examples / features before implementing them into our main body of code. 


# Dev Info
## Git
This section will include various git command combonations, tpo help prevent any **Ooops'** happening to the repo or anyones personal code. 
Some sweet links:

[git command cheat sheet](https://training.github.com/kit/downloads/github-git-cheat-sheet.pdf)

[git markdown guide](https://help.github.com/articles/markdown-basics/)
### Git command "variables"
Some of these command will have a spot with a vairable, like this: \<variablename\>. 

These will be described here:
* \<branchname\>  The name of the branch you are working on. We are cureent (mis)using "master"
* \<variablename\>  from the example, not used.
 

### Typical dev workflow

Before opening the project in Unity, pull changes from the repo:
* `git pull`

Then do some work. Once you are done, close Unity and push the changes into github:
* `git add .`   -   You may have to use the flag "-A"
* `git commit -m "I did this, that, and the other!"`
* `git pull`
* `git push origin <branchname>`


### To Wipe All Local Changes

##### This will destroy any work you have done!
##### Make a copy of your work manually! Run this at your own risk!

* `git fetch origin`
* `git reset --hard origin/master`

### Issues, Branches, etc..
Heres a few links to warm-up:
[Using pull requests](https://help.github.com/articles/using-pull-requests/)
#### Making a branch
coming soon(TM)

#### Working in your branch, and not master
coming soon(TM)

#### Merging your branch with master, or some other branch.
coming soon(TM)


## Development Schedule
This section is to help coordinate any sort of timeline building, as well as help us to coordinate our schedules. Real life supercedes all schedules directives, except where specifically stated & agreed upon.

#### Weekly
* We will separately made code changes, when we find time. Shoot for at least 1 per week. 
* We will make our best attempt at meeting every Friday for 2-4+ hours to coordinate our changes and make some progress on existing issues & features.
** If not, we can *make it up* by doing more solo work the week before.

#### Monthly
* We will both coordinate our scheudles and attempt to declare a "*Coding Weekend!* " 1-2 times monthly to make 'sprint' and make serious headway on the larger|new|outstanding issues & features. 
