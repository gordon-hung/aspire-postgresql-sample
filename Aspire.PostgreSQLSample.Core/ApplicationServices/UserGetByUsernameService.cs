using MediatR;

namespace Aspire.PostgreSQLSample.Core.ApplicationServices;
internal class UserGetByUsernameService(
	IUserRepository repository) : IRequestHandler<UserGetByUsernameRequest, UserInfoResponse?>
{
	public async Task<UserInfoResponse?> Handle(UserGetByUsernameRequest request, CancellationToken cancellationToken)
	{
		var info = await repository.GetByUsernameAsync(request.Username.ToLower(), cancellationToken).ConfigureAwait(false);

		return info is null
			? null
			: new UserInfoResponse(
				info.Id,
				info.Username,
				info.State,
				info.CreatedAt,
				info.UpdateAt);
	}
}
