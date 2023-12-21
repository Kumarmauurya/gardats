using System;

namespace NativeCSharpJWTToken
{
	public class AesGcmEncryption
	{
		private int keyLength;

		public int KeySize => keyLength;

		public AesGcmEncryption(int keyLength)
		{
			this.keyLength = keyLength;
		}

		public static byte[][] Encrypt(byte[] aad, byte[] plainText, byte[] cek)
		{
			byte[] array = Arrays.Random(96);
			try
			{
				byte[][] array2 = AesGcm.Encrypt(cek, array, aad, plainText);
				return new byte[3][]
				{
					array,
					array2[0],
					array2[1]
				};
			}
			catch (Exception innerException)
			{
				throw new Exception("Unable to encrypt content.", innerException);
			}
		}

		public static byte[] Decrypt(byte[] aad, byte[] cek, byte[] iv, byte[] cipherText, byte[] authTag)
		{
			try
			{
				return AesGcm.Decrypt(cek, iv, aad, cipherText, authTag);
			}
			catch (Exception innerException)
			{
				throw new Exception("Unable to decrypt content or authentication tag do not match.", innerException);
			}
		}
	}
}
