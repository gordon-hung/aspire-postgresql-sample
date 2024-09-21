using MediatR;

namespace Aspire.PostgreSQLSample.Core.ApplicationServices;
internal class UserAddService(
	IUserIdGenerator generator,
	IPasswordHasher hasher,
	IUserRepository repository) : IRequestHandler<UserAddRequest, string>
{
	public async Task<string> Handle(UserAddRequest request, CancellationToken cancellationToken)
	{
		var id = generator.NewId();
		var hashedPassword = hasher.HashPassword(request.Password);

		await repository.AddAsync(
			id: id,
			username: request.Username.ToLower(),
			hashedPassword: hashedPassword,
			cancellationToken: cancellationToken)
			.ConfigureAwait(false);

		return id;
	}
}
