using System;
using System.Runtime.InteropServices;
using System.Security;

internal static class Class7
{
	public static byte[] byte_0;

	internal static string smethod_0(SecureString secureString_0)
	{
		IntPtr intPtr = IntPtr.Zero;
		try
		{
			intPtr = Marshal.SecureStringToGlobalAllocUnicode(secureString_0);
			return Marshal.PtrToStringUni(intPtr);
		}
		finally
		{
			Marshal.ZeroFreeGlobalAllocUnicode(intPtr);
		}
	}
}
