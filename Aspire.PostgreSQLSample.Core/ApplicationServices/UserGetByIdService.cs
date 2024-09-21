using MediatR;

namespace Aspire.PostgreSQLSample.Core.ApplicationServices;
internal class UserGetByIdService(
	IUserRepository repository) : IRequestHandler<UserGetByIdRequest, UserInfoResponse?>
{
	public async Task<UserInfoResponse?> Handle(UserGetByIdRequest request, CancellationToken cancellationToken)
	{
		var info = await repository.GetByIdAsync(request.Id.ToLower(), cancellationToken).ConfigureAwait(false);

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
