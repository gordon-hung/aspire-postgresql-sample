using Aspire.PostgreSQLSample.Core.ApplicationServices;
using Aspire.PostgreSQLSample.MigrationEntry.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.AddNpgsqlDbContext<PostgresContext>("NpgsqlConnection");

builder.Services
	.AddPostgreSQLSampleCore()
	.AddPostgreSQLSampleRepository();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
	var context = scope.ServiceProvider.GetRequiredService<PostgresContext>();
	context.Database.Migrate();
}

using (var scope = app.Services.CreateScope())
{
	var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
	var username = "Gordon_Hung";
	var password = "1qaz2wsx";

	using var cts = new CancellationTokenSource();
	await mediator.Send(new UserAddRequest(username, password), cts.Token).ConfigureAwait(false);
}

app.Run();
