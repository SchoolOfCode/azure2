# Dapper Npgsql Asp

A simple API for a books table.

## Building the application

To build the application, run the command `dotnet build`

## Running the application

To run the application, run the command `dotnet run ./LibraryApi/LibraryApi.csproj`. To run the project with rebuild on code change, run the command `dotnet watch run ./LibraryApi/LibraryApi.csproj`

## Testing the application

To run the tests included, run the command `dotnet test ./LibraryApi.Test/LibraryApi.Tests.csproj`

## Adding Secrets

To safely store connection strings locally you will need to store them in your local secrets manager. Information about this can be found at https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-3.1&tabs=windows.

### Instructions

- Open a command prompt/terminal within the LibraryApi project and run `dotnet user-secrets init`
- Set your secret. Run the command `dotnet user-secrets set "ConnectionStrings:DefaultConnect" "{connectionString}"` replacing {connectionString} with the provided connection string

At this point your secret has been saved to the system and is unique to this project.