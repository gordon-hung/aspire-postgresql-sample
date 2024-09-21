using Aspire.PostgreSQLSample.Core.Enums;

namespace Aspire.PostgreSQLSample.Core.ApplicationServices;
public record UserInfoResponse(
	string Id,
	string Username,
	UserState State,
	DateTimeOffset CreatedAt,
	DateTimeOffset UpdateAt);
