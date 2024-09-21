using Aspire.PostgreSQLSample.Core.Enums;

namespace Aspire.PostgreSQLSample.Core.Models;
public record UserInfo(
	string Id,
	string Username,
	string Password,
	UserState State,
	DateTimeOffset CreatedAt,
	DateTimeOffset UpdateAt);
