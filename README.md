# JobCandidateHub

**One API Project To Accept Candidates**

## I will divide the improvements into 2 sections, technical and business:

### Technical:
 - Add background jobs with Hangfire or Quartz on some candidates' logic, for example, after a certain amount of time, we could send a mail to a candidate with a preferable action.
 - Add Caching either by Redis or .NET memory cache, for a lot faster querying, also this could happen without changing the current repositories.
 - Add a Validation pipeline with the mediator that holds all validation of the candidate like if the name exists or if the number exists before.
 - Add Global Exception Handling Middleware that represents a friendly and easy-to-understand message with my already created Error class that helps implement such a thing.
 - Add More Configuration to the Database like indexes on the possible columns that will be used on the search, and create a view to hold any server-side (database) calculation, like Name split to First and Last Name.
 - Could Create a More Powerful Repository that holds all the needed database access, after that we could remove the application layer queries to be aligned with clean architecture.
 - Add Specification pattern if only we gonna have a lot of DTOs for the same types that have wide tables in the database.
 - Create a hub with SignalR that keeps everything in real-time updated, for example, once a certain candidate is updated anyone has that candidate on a list or alone will get updated.
 - Add sorting to the candidate's list query and make the user choose the preferable option, also with the selected columns that are needed, maybe with a static extension method or dynamic expression builder.

### Business:
 - made the HR life easier by providing some functionalities obviously as bulk actions, or for example, setting certain criteria to be filtered and automatically taking action with the rest of the candidates.
 - integrating with system APIs from the provided LinkedIn profiles or GitHub to get the available information that could help narrow the possible candidates' numbers with ATS.
 - export some repeated and common reports to be shown or used in other places.

## Assumption
 - I assumed that you need a get API to get the data, cause I've got a little confused, about how you'll get the data after creating or updating a candidate.
 - I assumed you want to test the get API immediately, so I've created a seeder that increases the candidates with each build by 20.
 - I assumed that this API will get published so, I've created a scaffold workflow that works with every pull-request or push on the master branch

## Time spent on the task is 11 hours separated.
