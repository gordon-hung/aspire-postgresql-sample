using Aspire.PostgreSQLSample.Core;

namespace Aspire.PostgreSQLSample.Repositories;
internal class UserIdGenerator(
	TimeProvider timeProvider) : IUserIdGenerator
{
	private static object instance = new object();
	public string NewId()
	{
		lock (instance)
		{
			Thread.Sleep(1);
			long ticks = timeProvider.GetUtcNow().Ticks;
			return ConvertToBase(ticks, 36);
		}
	}

	private static String ConvertToBase(long num, int nbase)
	{
		String chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

		// check if we can convert to another base
		if (nbase < 2 || nbase > chars.Length)
			return "";

		long r;
		String newNumber = "";

		// in r we have the offset of the char that was converted to the new base
		while (num >= nbase)
		{
			r = num % nbase;
			newNumber = chars[(int)r] + newNumber;
			num = num / nbase;
		}
		// the last number to convert
		newNumber = chars[(int)num] + newNumber;

		return newNumber.ToLower();
	}
}
