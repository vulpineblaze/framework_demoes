# framework_demoes
##### Description
This repo is for our initial efforts programming the game 'Fusion Bombs Derp' in Unity 2D. The idea behind using this repo is that we may have to prototype other Unity projects in order to investigate different code examples / features before implementing them into our main body of code. 
____
## Installation
##### User
 * Go to link "here"   // this section needs pretty-fying
 * Extract all
 * Execute /path/to/binary
##### Development
 * Fork repo
 * Make your changes
   *  git clone
   *  Unity 5.1.1a   //double check revision
   *  do's and dont's
 * Submit pull request
   * Provide what issue you fixed ( pound sign, then the issue number, eg #42 )
   * detail your change (aka what you did exactly)
   * whatever else for QA purposes
____
## Contributing
##### Overview
The best way to contribute is to play our game and give us feedback! The best way to give feedback is to create issues for the bugs you find.
##### Issues
* Title
  *  A short, simple snippet about your problem. 
  *  Please use proper nouns
  *  Please avoid saying "broken", "fix", etc..  If it wasn't broken and needing fixing, it wouldn't be an issue. 
  *  Eg. "Player shoots multiple bullets each mouse click"
* Description
  * Provide a description somewhat like the following:
    * What were you doing when the issue occured?
    * What is the exact effect of the issue?
    * What exactly was supposed to happen instead?
  * This format allows to rapid digestion of your issue, and make its easier to reproduce, debug, and correct.
  * Eg. "I clicked twice on the second stage, and got 400 bullets instead of 4."
* Labels, Milestones, Assignment, etc..
  * These are for the devs to help sort and deal with issues effeciently, and we do not except or want help with this. 
  * Please don't mess with them.
 
##### Development

____
____
## Dev Info
### Git
This section will include various git command combonations, too help prevent any **Ooops'** happening to the repo or anyones personal code. 
Some sweet links:

[git command cheat sheet](https://training.github.com/kit/downloads/github-git-cheat-sheet.pdf)

[git markdown guide](https://help.github.com/articles/markdown-basics/)
#### Git command "variables"
Some of these command will have a spot with a vairable, like this: \<variablename\>. 

These will be described here:
* \<branchname\>  The name of the branch you are working on. We are currently *mis*using "master"
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
To change between branches, simply run the command:
* 'git checkout <branchname>'

##### Merging your branch with master, or some other branch.
coming soon(TM)

##### Address an Issue, then create a Pull request
This workflow has the user take a fresh issue, make a branch, complete the issue, and merge the branch back into master.

* `git checkout -b <branchname> `
  * Use the issue+number as the name, plus some descriptive text (Eg. For issue#53 use "**iss53-fix-the-bug-we-found**")
  * If you already have the branch, leave out the **-b** flag

Do work as per the typical workflow. Once you have you last commit pushed, do this:
* Goto github.com and create a pull request.
  * [github tut](https://help.github.com/articles/creating-a-pull-request/)
* Assuming the auto-merge feature is working, fill in the details secion and create the merge.
  * If not, github give you that helper list of commands. Do those.
  * Then try to `git pull`
  * If there are still merge errors, try using the GitGUI
    * I did this and was able to fix the merge super fast.
* At the bottom, there will be a button to merge: Press it.
* Once that is complete, github will say that you can delete the branch. Do that too.
  * Your commits aren't deleted, they are moved to be under 'master', and so your branch contains no useful info now.
* On the command line, run the following commands
  * `git pull origin master`
    * This will inform you your branch is gone.
    * This step may not be needed. I did it and everything worked in the end.
  * `git checkout master`
  * `git pull origin master`
* At this point you should be in master, and have all your changes from the branch. You're done!


____
### Development Schedule
This section is to help coordinate any sort of timeline building, as well as help us to coordinate our schedules. Real life supercedes all schedules directives, except where specifically stated & agreed upon.

##### Weekly
* We will separately made code changes, when we find time. Shoot for at least 1 per week. 
* We will make our best attempt at meeting every Friday for 2-4+ hours to coordinate our changes and make some progress on existing issues & features.
 * If not, we can *make it up* by doing more solo work the week before.

##### Monthly
* We will both coordinate our scheudles and attempt to declare a "*Coding Weekend!* " 1-2 times monthly to make 'sprint' and make serious headway on the larger|new|outstanding issues & features. 
