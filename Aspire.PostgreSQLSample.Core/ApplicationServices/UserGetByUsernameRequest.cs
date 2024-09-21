using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Aspire.PostgreSQLSample.Core.ApplicationServices;
public record UserGetByUsernameRequest(
	string Username) : IRequest<UserInfoResponse?>;