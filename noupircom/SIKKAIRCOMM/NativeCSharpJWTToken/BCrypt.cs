using System;
using System.Runtime.InteropServices;

namespace NativeCSharpJWTToken
{
	public static class BCrypt
	{
		public struct BCRYPT_PSS_PADDING_INFO
		{
			[MarshalAs(UnmanagedType.LPWStr)]
			public string pszAlgId;

			public int cbSalt;

			public BCRYPT_PSS_PADDING_INFO(string pszAlgId, int cbSalt)
			{
				this.pszAlgId = pszAlgId;
				this.cbSalt = cbSalt;
			}
		}

		internal struct BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO : IDisposable
		{
			internal readonly int cbSize;

			internal readonly int dwInfoVersion;

			internal readonly IntPtr pbNonce;

			internal readonly int cbNonce;

			internal readonly IntPtr pbAuthData;

			internal readonly int cbAuthData;

			internal readonly IntPtr pbTag;

			internal readonly int cbTag;

			internal readonly IntPtr pbMacContext;

			internal readonly int cbMacContext;

			internal readonly int cbAAD;

			internal readonly long cbData;

			internal readonly int dwFlags;

			internal BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO(byte[] iv, byte[] aad, byte[] tag)
			{
				this = default(BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO);
				dwInfoVersion = BCRYPT_INIT_AUTH_MODE_INFO_VERSION;
				cbSize = Marshal.SizeOf(typeof(BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO));
				if (iv != null)
				{
					cbNonce = iv.Length;
					pbNonce = Marshal.AllocHGlobal(cbNonce);
					Marshal.Copy(iv, 0, pbNonce, cbNonce);
				}
				if (aad != null)
				{
					cbAuthData = aad.Length;
					pbAuthData = Marshal.AllocHGlobal(cbAuthData);
					Marshal.Copy(aad, 0, pbAuthData, cbAuthData);
				}
				if (tag != null)
				{
					cbTag = tag.Length;
					pbTag = Marshal.AllocHGlobal(cbTag);
					Marshal.Copy(tag, 0, pbTag, cbTag);
					cbMacContext = tag.Length;
					pbMacContext = Marshal.AllocHGlobal(cbMacContext);
				}
			}

			public void Dispose()
			{
				if (pbNonce != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(pbNonce);
				}
				if (pbTag != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(pbTag);
				}
				if (pbAuthData != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(pbAuthData);
				}
				if (pbMacContext != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(pbMacContext);
				}
			}
		}

		internal struct BCRYPT_KEY_LENGTHS_STRUCT
		{
			public int dwMinLength;

			public int dwMaxLength;

			public int dwIncrement;
		}

		internal struct BCRYPT_OAEP_PADDING_INFO
		{
			[MarshalAs(UnmanagedType.LPWStr)]
			public string pszAlgId;

			public IntPtr pbLabel;

			public int cbLabel;

			public BCRYPT_OAEP_PADDING_INFO(string alg)
			{
				pszAlgId = alg;
				pbLabel = IntPtr.Zero;
				cbLabel = 0;
			}
		}

		public const uint ERROR_SUCCESS = 0u;

		public const uint BCRYPT_PAD_PSS = 8u;

		public const uint BCRYPT_PAD_OAEP = 4u;

		public static readonly byte[] BCRYPT_KEY_DATA_BLOB_MAGIC = BitConverter.GetBytes(1296188491);

		public static readonly string BCRYPT_OBJECT_LENGTH = "ObjectLength";

		public static readonly string BCRYPT_CHAIN_MODE_GCM = "ChainingModeGCM";

		public static readonly string BCRYPT_AUTH_TAG_LENGTH = "AuthTagLength";

		public static readonly string BCRYPT_CHAINING_MODE = "ChainingMode";

		public static readonly string BCRYPT_KEY_DATA_BLOB = "KeyDataBlob";

		public static readonly string BCRYPT_AES_ALGORITHM = "AES";

		public static readonly string MS_PRIMITIVE_PROVIDER = "Microsoft Primitive Provider";

		public static readonly int BCRYPT_AUTH_MODE_CHAIN_CALLS_FLAG = 1;

		public static readonly int BCRYPT_INIT_AUTH_MODE_INFO_VERSION = 1;

		public static readonly uint STATUS_AUTH_TAG_MISMATCH = 3221266434u;

		[DllImport("bcrypt.dll")]
		internal static extern uint BCryptOpenAlgorithmProvider(out IntPtr phAlgorithm, [MarshalAs(UnmanagedType.LPWStr)] string pszAlgId, [MarshalAs(UnmanagedType.LPWStr)] string pszImplementation, uint dwFlags);

		[DllImport("bcrypt.dll")]
		internal static extern uint BCryptCloseAlgorithmProvider(IntPtr hAlgorithm, uint flags);

		[DllImport("bcrypt.dll")]
		internal static extern uint BCryptGetProperty(IntPtr hObject, [MarshalAs(UnmanagedType.LPWStr)] string pszProperty, byte[] pbOutput, int cbOutput, ref int pcbResult, uint flags);

		[DllImport("bcrypt.dll", EntryPoint = "BCryptSetProperty")]
		internal static extern uint BCryptSetAlgorithmProperty(IntPtr hObject, [MarshalAs(UnmanagedType.LPWStr)] string pszProperty, byte[] pbInput, int cbInput, int dwFlags);

		[DllImport("bcrypt.dll")]
		internal static extern uint BCryptImportKey(IntPtr hAlgorithm, IntPtr hImportKey, [MarshalAs(UnmanagedType.LPWStr)] string pszBlobType, out IntPtr phKey, IntPtr pbKeyObject, int cbKeyObject, byte[] pbInput, int cbInput, uint dwFlags);

		[DllImport("bcrypt.dll")]
		public static extern uint BCryptDestroyKey(IntPtr hKey);

		[DllImport("bcrypt.dll")]
		internal static extern uint BCryptEncrypt(IntPtr hKey, byte[] pbInput, int cbInput, ref BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO pPaddingInfo, byte[] pbIV, int cbIV, byte[] pbOutput, int cbOutput, ref int pcbResult, uint dwFlags);

		[DllImport("bcrypt.dll")]
		internal static extern uint BCryptDecrypt(IntPtr hKey, byte[] pbInput, int cbInput, ref BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO pPaddingInfo, byte[] pbIV, int cbIV, byte[] pbOutput, int cbOutput, ref int pcbResult, int dwFlags);
	}
}
