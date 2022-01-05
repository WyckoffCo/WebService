# WebService

Webservice listens for organization events to know when a repository has been created. When the repository is created:

1. automate the protection of the master branch. 
2. Notify yourself with an @mention in an issue within the repository that outlines the protections that were added

## Repository Structure
All updates should be made in the following directories.

### src
All source code required to build the application.

### utils
Helpful scripts