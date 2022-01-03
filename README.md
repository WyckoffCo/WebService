# Foobar

Webservice listens for organization events to know when a repository has been created. When the repository is created:

1. automate the protection of the master branch. 
2. Notify yourself with an @mention in an issue within the repository that outlines the protections that were added

The following rules are enforced:

##### Repository
* Allow merge commits
* Squash commits are not allowed

##### Master Branch
* Pull requests are required to merge to master
* Do not allow re-writting history
* Restrictions are applied to administrators