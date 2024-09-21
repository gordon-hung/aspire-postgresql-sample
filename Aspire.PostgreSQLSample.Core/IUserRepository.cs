using Aspire.PostgreSQLSample.Core.Models;

namespace Aspire.PostgreSQLSample.Core;

public interface IUserRepository
{
	public ValueTask AddAsync(string id, string username, string hashedPassword, CancellationToken cancellationToken = default);
	public ValueTask<UserInfo?> GetByUsernameAsync(string username, CancellationToken cancellationToken = default);
	public ValueTask<UserInfo?> GetByIdAsync(string id, CancellationToken cancellationToken = default);
	public ValueTask UpdatePasswordAsync(string id, string hashedPassword, CancellationToken cancellationToken = default);
}
