using MediatR;

namespace Aspire.PostgreSQLSample.Core.ApplicationServices;
public record UserGetByIdRequest(
	string Id):IRequest<UserInfoResponse?>;
