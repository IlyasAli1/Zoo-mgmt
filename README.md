# Zoo Management

This is an API using Swagger to manage a zoo. In this new animals, enclosures and zookeepers can be added, removed and updated. Each with their own properties and relationships, where animals can be added to enclosures for example.

## Prerequisites

You will need to have docker installed.

## Setup

This has been updated to use SQL Server rather than SQLite.

Go to the project directory and execulte the commands in an admin powershell:

- `docker-compose up`

This will create a SQL Server container in docker.

Now run:
- `dotnet tool install --global dotnet-ef`
- `dotnet ef migrations add zoo-mgmt`
- `dotnet ef database update`

You can now open the solution file (.sln) and run the program.

## Using MSSQL Management Studio

Using SQL Server Authentication.

- Login: `SA`
- Password: `Password123`

There will already be data present as the code in this runs SQL queries to check if the database "zoo-mgmt" exists and if the tables are empty. The code fills the tables with sample data if they are empty.
