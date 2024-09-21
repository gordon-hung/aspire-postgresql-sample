# aspire-postgresql-sample
ASP.NET Core 8.0 Aspire PostgreSQL

In this article, you learn how to use the .NET Aspire PostgreSQL Entity Framework Core integration. The Aspire.Npgsql.EntityFrameworkCore.PostgreSQL library is used to register a DbContext service for connecting to a PostgreSQL database. It also enables corresponding health checks, logging and telemetry.

PostgreSQL is a powerful, open source, object-relational database system. The .NET Aspire PostgreSQL Entity Framework integration streamlines essential database context and connection configurations for you by handling the following concerns:

* Registers EntityFrameworkCore in the DI container for connecting to PostgreSQL database.
* Automatically configures the following:
    Connection pooling to efficiently managed HTTP requests and database connections"
    Automatic retries to increase app resiliency
    Health checks, logging and telemetry to improve app monitoring and diagnostics
## Get started
To get started with the .NET Aspire PostgreSQL Entity Framework Core integration, install the Aspire.Npgsql.EntityFrameworkCore.PostgreSQL NuGet package in the client-consuming project, i.e., the project for the application that uses the PostgreSQL Entity Framework Core client.
```sh
dotnet add package Aspire.Npgsql.EntityFrameworkCore.PostgreSQL
```

## App host usage
To model the PostgreSQL server resource in the app host, install the Aspire.Hosting.PostgreSQL NuGet package in the app host project.
```sh
dotnet add package Aspire.Hosting.PostgreSQL
```

## Migrations Overview

Create your first migration
```sh
dotnet ef migrations add InitialCreate
```

Create your database and schema
```sh
dotnet ef database update
```
