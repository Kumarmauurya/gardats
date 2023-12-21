using System;
using System.Runtime.InteropServices;

internal static class Class63
{
	[DllImport("kernel32.dll")]
	private static extern IntPtr LoadLibrary(string string_0);

	[DllImport("kernel32.dll")]
	private static extern IntPtr GetProcAddress(IntPtr intptr_0, string string_0);

	public static Delegate smethod_0<T>(string string_0, string string_1)
	{
		try
		{
			return Marshal.GetDelegateForFunctionPointer(GetProcAddress(LoadLibrary(string_0), string_1), typeof(T));
		}
		catch (Exception)
		{
			return null;
		}
	}
}
