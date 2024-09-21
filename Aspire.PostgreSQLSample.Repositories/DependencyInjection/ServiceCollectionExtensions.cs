using Aspire.PostgreSQLSample.Core;
using Aspire.PostgreSQLSample.Repositories;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddPostgreSQLSampleRepository(
		this IServiceCollection services)
		=> services
		.AddSingleton(TimeProvider.System)
		.AddScoped<IUserIdGenerator, UserIdGenerator>()
		.AddScoped<IPasswordHasher, PasswordHasher>()
		.AddTransient<IUserRepository, UserRepository>();
}
