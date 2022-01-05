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

## Known issues / feature backlog
The following are a list of known issues or desired features, and should prioritized for future work:

1. Assumption is new repo includes a "main" branch.  Need to check if branch exists; if not, create one.
2. Using a PAT for authentication / authorization.  Improve authentication / authorization.
3. Hardcoded org name of 'WyckoffCo'
4. Webhook was manually created.  Build script to create webhook for org.
5. Current deployment to Azure is via VisualStudio publish.  Add GitHub Actions for CI/CD deployment
