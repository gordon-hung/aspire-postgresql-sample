using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspire.PostgreSQLSample.Core;
public interface IUserIdGenerator
{
	string NewId();
}
