using MediatR;

namespace Aspire.PostgreSQLSample.Core.ApplicationServices;
public record UserAddRequest(
	string Username,
	string Password) : IRequest<string>;
