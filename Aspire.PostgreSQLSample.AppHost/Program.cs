using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var username = builder.AddParameter("username", secret: true);
var password = builder.AddParameter("password", secret: true);

var postgres = builder.AddPostgres("postgresdb", username, password).WithPgAdmin();
var postgresdb = postgres.AddDatabase("NpgsqlConnection");

builder.AddProject<Projects.Aspire_PostgreSQLSample_RESTful>("aspire-postgresqlsample-restful")
     .WithReference(postgresdb);

builder.Build().Run();
