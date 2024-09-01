# CapitalRecruit

This web API project was developed with .NET 8. It aimed to bridge the interaction between an Employer or recruiter and a Candidate or applicant.
The employer creates a form (with question templates as he chooses) for the applicant (Candidate) to fill out later and save to the database.

In this project, I demonstrated;
- The use of the SOLID principle for my code modularity, reusability, and flexibility.
- The use of dependency injection.
- Abstraction of some configurations out of the program.cs class for code cleanness.
- Use of NoSql CosmosDb
- Use of a Generic repository to avoid repetition of common CRUD operations
- Unit test to ensure application features reliability.
- Security in not exposing sensitive information within the code base.
- Clean architecture implementation.
- Tactical comments to explain my reasoning and why I implemented certain logic in a certain way.

# Tools used
- Azure Cosmos DB emulator.
- X Unit test
- .NET 8
- Entity Framework core
- Postman

# Project limitation
There are other good stuff I didn't cover in this project due to time constrain such as;
- Loggings
- Global exception handling
- Authentication and Authorization to mention but few.
  
# What I learned
My main takeaway from this project is having frontend developers in mind every step of my designing and implementations, it made me think on both ends not only on the backend.
