using Aspire.PostgreSQLSample.Core.Enums;

namespace Aspire.PostgreSQLSample.RESTful.ViewModels;

public record UserInfoViewModel(
	string Id,
	string Username,
	UserState State,
	DateTimeOffset CreatedAt,
	DateTimeOffset UpdateAt);
