using Aspire.PostgreSQLSample.Core;
using Aspire.PostgreSQLSample.Core.ApplicationServices;
using Aspire.PostgreSQLSample.RESTful.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aspire.PostgreSQLSample.RESTful.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
	/// <summary>
	/// Creates new id.
	/// </summary>
	/// <param name="userIdGenerator">The user identifier generator.</param>
	/// <returns></returns>
	[HttpGet("new-id")]
	public ValueTask<string> NewId(
		[FromServices] IUserIdGenerator userIdGenerator)
	{
		return ValueTask.FromResult(userIdGenerator.NewId());
	}
	/// <summary>
	/// Users the add asynchronous.
	/// </summary>
	/// <param name="mediator">The mediator.</param>
	/// <param name="source">The source.</param>
	/// <returns></returns>
	[HttpPost]
	public async ValueTask<string> UserAddAsync(
		[FromServices] IMediator mediator,
		[FromBody] UserAddViewModel source)
		=> await mediator.Send(
			request: new UserAddRequest(
				Username: source.UserName,
				Password: source.Password),
		cancellationToken: HttpContext.RequestAborted)
		.ConfigureAwait(false);

	/// <summary>
	/// Users the get by identifier asynchronous.
	/// </summary>
	/// <param name="mediator">The mediator.</param>
	/// <param name="id">The identifier.</param>
	/// <returns></returns>
	[HttpGet("{id}/id")]
	public async ValueTask<UserInfoViewModel?> UserGetByIdAsync(
		[FromServices] IMediator mediator,
		string id)
	{
		var response = await mediator.Send(
			request: new UserGetByIdRequest(Id: id),
			cancellationToken: HttpContext.RequestAborted)
			.ConfigureAwait(false);

		return response is null
			? null
			: new UserInfoViewModel(
				response.Id,
				response.Username,
				response.State,
				response.CreatedAt,
				response.UpdateAt);
	}

	[HttpGet("{username}/username")]
	public async ValueTask<UserInfoViewModel?> UserGetByUsernameAsync(
		[FromServices] IMediator mediator,
		string username = "Gordon_Hung")
	{
		var response = await mediator.Send(
			request: new UserGetByUsernameRequest(Username: username),
			cancellationToken: HttpContext.RequestAborted)
			.ConfigureAwait(false);

		return response is null
			? null
			: new UserInfoViewModel(
				response.Id,
				response.Username,
				response.State,
				response.CreatedAt,
				response.UpdateAt);
	}
}
