using System;
using System.Runtime.InteropServices;
using System.Text;

namespace NativeCSharpJWTToken
{
	public static class AesGcm
	{
		public static byte[][] Encrypt(byte[] key, byte[] iv, byte[] aad, byte[] plainText)
		{
			IntPtr intPtr = OpenAlgorithmProvider(BCrypt.BCRYPT_AES_ALGORITHM, BCrypt.MS_PRIMITIVE_PROVIDER, BCrypt.BCRYPT_CHAIN_MODE_GCM);
			IntPtr hKey;
			IntPtr hglobal = ImportKey(intPtr, key, out hKey);
			byte[] array = new byte[MaxAuthTagSize(intPtr)];
			BCrypt.BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO pPaddingInfo = new BCrypt.BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO(iv, aad, array);
			byte[] array3;
			using (pPaddingInfo)
			{
				byte[] array2 = new byte[array.Length];
				int pcbResult = 0;
				uint num = BCrypt.BCryptEncrypt(hKey, plainText, plainText.Length, ref pPaddingInfo, array2, array2.Length, null, 0, ref pcbResult, 0u);
				if (num != 0)
				{
					throw new Exception($"BCrypt.BCryptEncrypt() (get size) failed with status code:{num}");
				}
				array3 = new byte[pcbResult];
				num = BCrypt.BCryptEncrypt(hKey, plainText, plainText.Length, ref pPaddingInfo, array2, array2.Length, array3, array3.Length, ref pcbResult, 0u);
				if (num != 0)
				{
					throw new Exception($"BCrypt.BCryptEncrypt() failed with status code:{num}");
				}
				Marshal.Copy(pPaddingInfo.pbTag, array, 0, pPaddingInfo.cbTag);
			}
			BCrypt.BCryptDestroyKey(hKey);
			Marshal.FreeHGlobal(hglobal);
			BCrypt.BCryptCloseAlgorithmProvider(intPtr, 0u);
			return new byte[2][] { array3, array };
		}

		public static byte[] Decrypt(byte[] key, byte[] iv, byte[] aad, byte[] cipherText, byte[] authTag)
		{
			IntPtr intPtr = OpenAlgorithmProvider(BCrypt.BCRYPT_AES_ALGORITHM, BCrypt.MS_PRIMITIVE_PROVIDER, BCrypt.BCRYPT_CHAIN_MODE_GCM);
			IntPtr hKey;
			IntPtr hglobal = ImportKey(intPtr, key, out hKey);
			BCrypt.BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO pPaddingInfo = new BCrypt.BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO(iv, aad, authTag);
			byte[] array2;
			using (pPaddingInfo)
			{
				byte[] array = new byte[MaxAuthTagSize(intPtr)];
				int pcbResult = 0;
				uint num = BCrypt.BCryptDecrypt(hKey, cipherText, cipherText.Length, ref pPaddingInfo, array, array.Length, null, 0, ref pcbResult, 0);
				if (num != 0)
				{
					throw new Exception($"BCrypt.BCryptDecrypt() (get size) failed with status code: {num}");
				}
				array2 = new byte[pcbResult];
				num = BCrypt.BCryptDecrypt(hKey, cipherText, cipherText.Length, ref pPaddingInfo, array, array.Length, array2, array2.Length, ref pcbResult, 0);
				if (num == BCrypt.STATUS_AUTH_TAG_MISMATCH)
				{
					throw new Exception("BCrypt.BCryptDecrypt(): authentication tag mismatch");
				}
				if (num != 0)
				{
					throw new Exception($"BCrypt.BCryptDecrypt() failed with status code:{num}");
				}
			}
			BCrypt.BCryptDestroyKey(hKey);
			Marshal.FreeHGlobal(hglobal);
			BCrypt.BCryptCloseAlgorithmProvider(intPtr, 0u);
			return array2;
		}

		private static int MaxAuthTagSize(IntPtr hAlg)
		{
			byte[] property = GetProperty(hAlg, BCrypt.BCRYPT_AUTH_TAG_LENGTH);
			return BitConverter.ToInt32(new byte[4]
			{
				property[4],
				property[5],
				property[6],
				property[7]
			}, 0);
		}

		private static IntPtr OpenAlgorithmProvider(string alg, string provider, string chainingMode)
		{
			IntPtr phAlgorithm = IntPtr.Zero;
			uint num = BCrypt.BCryptOpenAlgorithmProvider(out phAlgorithm, alg, provider, 0u);
			if (num != 0)
			{
				throw new Exception($"BCrypt.BCryptOpenAlgorithmProvider() failed with status code:{num}");
			}
			byte[] bytes = Encoding.Unicode.GetBytes(chainingMode);
			num = BCrypt.BCryptSetAlgorithmProperty(phAlgorithm, BCrypt.BCRYPT_CHAINING_MODE, bytes, bytes.Length, 0);
			if (num != 0)
			{
				throw new Exception($"BCrypt.BCryptSetAlgorithmProperty(BCrypt.BCRYPT_CHAINING_MODE, BCrypt.BCRYPT_CHAIN_MODE_GCM) failed with status code:{num}");
			}
			return phAlgorithm;
		}

		private static IntPtr ImportKey(IntPtr hAlg, byte[] key, out IntPtr hKey)
		{
			byte[] property = GetProperty(hAlg, BCrypt.BCRYPT_OBJECT_LENGTH);
			int num = BitConverter.ToInt32(property, 0);
			IntPtr intPtr = Marshal.AllocHGlobal(num);
			byte[] array = Arrays.Concat(BCrypt.BCRYPT_KEY_DATA_BLOB_MAGIC, BitConverter.GetBytes(1), BitConverter.GetBytes(key.Length), key);
			uint num2 = BCrypt.BCryptImportKey(hAlg, IntPtr.Zero, BCrypt.BCRYPT_KEY_DATA_BLOB, out hKey, intPtr, num, array, array.Length, 0u);
			if (num2 != 0)
			{
				throw new Exception($"BCrypt.BCryptImportKey() failed with status code:{num2}");
			}
			return intPtr;
		}

		private static byte[] GetProperty(IntPtr hAlg, string name)
		{
			int pcbResult = 0;
			uint num = BCrypt.BCryptGetProperty(hAlg, name, null, 0, ref pcbResult, 0u);
			if (num != 0)
			{
				throw new Exception($"BCrypt.BCryptGetProperty() (get size) failed with status code:{num}");
			}
			byte[] array = new byte[pcbResult];
			num = BCrypt.BCryptGetProperty(hAlg, name, array, array.Length, ref pcbResult, 0u);
			if (num != 0)
			{
				throw new Exception($"BCrypt.BCryptGetProperty() failed with status code:{num}");
			}
			return array;
		}
	}
}
