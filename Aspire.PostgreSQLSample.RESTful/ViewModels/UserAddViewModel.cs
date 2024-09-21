using System.ComponentModel.DataAnnotations;

namespace Aspire.PostgreSQLSample.RESTful.ViewModels;

public record UserAddViewModel
{
	[RegularExpression(@"^[a-zA-Z][a-zA-Z0-9_]{3,19}$", ErrorMessage = "Input must start with a letter and can contain letters, numbers, and underscores, with a length of 4 to 20 characters.")]
	public string UserName { get; init; } = default!;

	[Required]
	[StringLength(maximumLength: 64, MinimumLength = 8)]
	public string Password { get; init; } = default!;
}
