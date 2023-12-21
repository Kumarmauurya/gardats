using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

internal class Class19
{
	[CompilerGenerated]
	private sealed class Class20
	{
		public Random random_0;

		internal char method_0(string string_0)
		{
			return string_0[random_0.Next(string_0.Length)];
		}
	}

	public bool bool_0;

	public string string_0 = "";

	public string access_token = "";

	public string string_1 = "";

	public string string_2 = "";

	public string string_3 = "";

	public string string_4 = "";

	public string string_5 = "";

	public CngKey cngKey_0;

	public Class19()
	{
		smethod_0(15, "0123456789");
		smethod_0(20, "0123456789");
		smethod_0(16, "abcdefghijklmnopqrstuvwxyz0123456789");
	}

	private static string smethod_0(int int_0, string string_6)
	{
		Random random_0 = new Random();
		return new string((from string_0 in Enumerable.Repeat(string_6, int_0)
			select string_0[random_0.Next(string_0.Length)]).ToArray());
	}
}
