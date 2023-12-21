using System;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

internal class Class12
{
	public sealed class Class14
	{
		public Random random_0;

		public char method_0(string string_0)
		{
			return string_0[random_0.Next(string_0.Length)];
		}
	}

	private sealed class Class15
	{
		public Random random_0;

		public char method_0(string string_0)
		{
			return string_0[random_0.Next(string_0.Length)];
		}
	}

	private static int int_0 = 16;

	internal static void smethod_0(SecureString secureString_0, int int_1, string string_0)
	{
		secureString_0.AppendChar(smethod_2(39));
		secureString_0.AppendChar(smethod_2(2));
		secureString_0.AppendChar(smethod_2(48));
		secureString_0.AppendChar(smethod_2(55));
		secureString_0.AppendChar(smethod_2(28));
		secureString_0.AppendChar(smethod_2(22));
		secureString_0.AppendChar(smethod_2(38));
		secureString_0.AppendChar(smethod_2(14));
		secureString_0.AppendChar(smethod_2(55));
		Class18.int_0 = -1978466511;
		secureString_0.AppendChar(smethod_2(28));
		secureString_0.AppendChar(smethod_2(22));
		secureString_0.AppendChar(smethod_2(38));
		secureString_0.AppendChar(smethod_2(14));
		secureString_0.AppendChar(smethod_2(55));
		secureString_0.AppendChar(smethod_2(28));
	}

	public static string smethod_1(int int_1)
	{
		return new string(Enumerable.Repeat("0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz", int_1).Select(new Class14
		{
			random_0 = new Random()
		}.method_0).ToArray());
	}

	private static char smethod_2(int int_1)
	{
		Class15 @class = new Class15();
		@class.random_0 = new Random();
		string text = "ABCDEFGHIJKLMNOPQRSTUZ0123456789!@#$%^&*()abcdefghijklmnopqrstuvwxyz";
		string text2 = new string(Enumerable.Repeat(text, int_1).Select(@class.method_0).ToArray());
		return text[int_1];
	}

	public static string smethod_3(string string_0)
	{
		byte[] array = new byte[0];
		byte[] rgbIV = new byte[8] { 18, 52, 86, 120, 144, 171, 205, 239 };
		byte[] array2 = new byte[string_0.Length + 1];
		string text = Class7.smethod_0(clsMain.secureString_0).Substring(2, 8);
		try
		{
			byte[] bytes = Encoding.UTF8.GetBytes(text.Substring(0, 8));
			DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
			byte[] array3 = Convert.FromBase64String(string_0);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(bytes, rgbIV), CryptoStreamMode.Write);
			cryptoStream.Write(array3, 0, array3.Length);
			cryptoStream.FlushFinalBlock();
			return Encoding.UTF8.GetString(memoryStream.ToArray());
		}
		catch (Exception ex)
		{
			return ex.Message;
		}
	}

	public static string smethod_4(string string_0, string string_1, string string_2)
	{
		try
		{
			byte[] bytes = new SHA1Managed().ComputeHash(Encoding.Default.GetBytes(string_1));
			byte[] array = new SHA1Managed().ComputeHash(Encoding.Default.GetBytes(string_2 + Encoding.Default.GetString(bytes)));
			int num = 0;
			for (int i = 17; i < array.Length; i++)
			{
				num = (num << 8) | (array[i] & 0xFF);
			}
			int num2 = int.Parse(string_0);
			string text = Convert.ToString((num + num2) & 0xFFFFFF, 16);
			while (text.Length < 6)
			{
				text = "0" + text;
			}
			return text;
		}
		catch
		{
		}
		return "";
	}

	public static string smethod_5(string string_0, string string_1, string string_2)
	{
		try
		{
			if (string_2.Length > 20)
			{
				string_2 = string_2.Replace("-", "");
			}
			byte[] array = Encoding.Default.GetBytes(string_2);
			SHA1 sHA = new SHA1Managed();
			for (int i = 0; i < 17; i++)
			{
				array = sHA.ComputeHash(array);
			}
			byte[] bytes = new SHA1Managed().ComputeHash(Encoding.Default.GetBytes(string_1));
			byte[] array2 = new SHA1Managed().ComputeHash(Encoding.Default.GetBytes(Encoding.Default.GetString(array) + Encoding.Default.GetString(bytes)));
			int num = 0;
			for (int j = 17; j < array2.Length; j++)
			{
				num = (num << 8) | (array2[j] & 0xFF);
			}
			int num2 = int.Parse(string_0);
			string text = Convert.ToString((num + num2) & 0xFFFFFF, 16);
			while (text.Length < 6)
			{
				text = "0" + text;
			}
			return text;
		}
		catch
		{
		}
		return "";
	}

	internal static string smethod_6(string string_0, string string_1, byte[] byte_0)
	{
		byte[] array = new byte[0];
		try
		{
			byte[] bytes = Encoding.UTF8.GetBytes(string_1.Substring(0, 8));
			DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
			byte[] bytes2 = Encoding.UTF8.GetBytes(string_0);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(bytes, byte_0), CryptoStreamMode.Write);
			cryptoStream.Write(bytes2, 0, bytes2.Length);
			cryptoStream.FlushFinalBlock();
			return Convert.ToBase64String(memoryStream.ToArray());
		}
		catch (Exception ex)
		{
			return ex.Message;
		}
	}

	public static string smethod_7(string string_0)
	{
		string text = Class7.smethod_0(clsMain.secureString_0).Substring(2, 8);
		byte[] array = new byte[0];
		byte[] rgbIV = new byte[8] { 18, 52, 86, 120, 144, 171, 205, 239 };
		try
		{
			byte[] bytes = Encoding.UTF8.GetBytes(text.Substring(0, 8));
			byte[] bytes2 = Encoding.UTF8.GetBytes(string_0);
			DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(bytes, rgbIV), CryptoStreamMode.Write);
			cryptoStream.Write(bytes2, 0, bytes2.Length);
			cryptoStream.FlushFinalBlock();
			return "#" + Convert.ToBase64String(memoryStream.ToArray());
		}
		catch (Exception ex)
		{
			return ex.Message;
		}
	}

	public static string smethod_8(string string_0)
	{
		byte[] array = HashAlgorithm.Create("SHA-256").ComputeHash(Encoding.UTF8.GetBytes(string_0));
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < array.Length; i++)
		{
			stringBuilder.Append($"{array[i]:x2}");
		}
		return stringBuilder.ToString();
	}

	public static string smethod_9(string string_0)
	{
		byte[] array = new SHA512Managed().ComputeHash(Encoding.UTF8.GetBytes(string_0));
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < array.Length; i++)
		{
			stringBuilder.Append(array[i].ToString("x2"));
		}
		return stringBuilder.ToString();
	}

	public static string smethod_10(string string_0)
	{
		byte[] array = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(string_0));
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < array.Length; i++)
		{
			stringBuilder.Append(array[i].ToString("x2"));
		}
		return stringBuilder.ToString();
	}

	public static string smethod_11(string string_0, string string_1, string string_2, string string_3, int int_1)
	{
		return Convert.ToBase64String(smethod_12(Encoding.UTF8.GetBytes(string_0), smethod_13(string_1, string_2, string_3, int_1)));
	}

	private static byte[] smethod_12(byte[] byte_0, SymmetricAlgorithm symmetricAlgorithm_0)
	{
		return symmetricAlgorithm_0.CreateEncryptor().TransformFinalBlock(byte_0, 0, byte_0.Length);
	}

	private static SymmetricAlgorithm smethod_13(string string_0, string string_1, string string_2, int int_1)
	{
		byte[] array = new byte[16];
		byte[] array2 = new byte[16];
		byte[] bytes = new Rfc2898DeriveBytes(string_0, smethod_14(string_1), int_1).GetBytes(16);
		byte[] array3 = smethod_14(string_2);
		Array.Copy(array3, array2, Math.Min(array2.Length, array3.Length));
		RijndaelManaged rijndaelManaged = new RijndaelManaged();
		rijndaelManaged.Mode = CipherMode.CBC;
		rijndaelManaged.Padding = PaddingMode.PKCS7;
		rijndaelManaged.FeedbackSize = 128;
		rijndaelManaged.KeySize = 128;
		rijndaelManaged.BlockSize = 128;
		rijndaelManaged.Key = bytes;
		rijndaelManaged.IV = array2;
		return rijndaelManaged;
	}

	private static byte[] smethod_14(string string_0)
	{
		byte[] array = new byte[string_0.Length / 2];
		int num = 0;
		while (array.Length != 0)
		{
			array[num] = Convert.ToByte(string_0.Substring(num * 2, 2), 16);
			num++;
		}
		return array;
	}

	private static byte[] smethod_15(string string_0)
	{
		byte[] array = new byte[string_0.Length / 2];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = Convert.ToByte(string_0.Substring(i * 2, 2), 16);
		}
		return array;
	}

	public static string smethod_16(string string_0, bool bool_0)
	{
		using (SHA1Managed sHA1Managed = new SHA1Managed())
		{
			byte[] array = sHA1Managed.ComputeHash(Encoding.UTF8.GetBytes(string_0));
			StringBuilder stringBuilder = new StringBuilder(array.Length * 2);
			byte[] array2 = array;
			foreach (byte b in array2)
			{
				string text = "x2";
				if (bool_0)
				{
					text = "X2";
				}
				stringBuilder.Append(b.ToString(text));
			}
			return stringBuilder.ToString();
		}
	}

	public static string smethod_17(string string_0, string string_1)
	{
		byte[] rgbKey = smethod_18(string_1);
		if (string_0.Length % 16 > 0)
		{
			char c = '\0';
			for (int num = (string_0.Length / 16 + 1) * 16 - string_0.Length; num > 0; num--)
			{
				string_0 += c;
			}
		}
		byte[] byte_;
		using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
		{
			rijndaelManaged.Mode = CipherMode.ECB;
			rijndaelManaged.Padding = PaddingMode.None;
			ICryptoTransform transform = rijndaelManaged.CreateEncryptor(rgbKey, new byte[16]);
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (CryptoStream stream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
				{
					using (StreamWriter streamWriter = new StreamWriter(stream))
					{
						streamWriter.Write(string_0);
					}
					byte_ = memoryStream.ToArray();
				}
			}
		}
		return smethod_19(byte_);
	}

	private static byte[] smethod_18(string string_0)
	{
		byte[] array = new byte[string_0.Length / 2];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = Convert.ToByte(string_0.Substring(i * 2, 2), 16);
		}
		return array;
	}

	public static string smethod_19(byte[] byte_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < byte_0.Length; i++)
		{
			stringBuilder.Append(byte_0[i].ToString("x2"));
		}
		return stringBuilder.ToString();
	}

	public static string smethod_20(string string_0, string string_1)
	{
		byte[] array = new HMACSHA256(Encoding.UTF8.GetBytes(string_1)).ComputeHash(Encoding.UTF8.GetBytes(string_0));
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < array.Length; i++)
		{
			stringBuilder.Append(array[i].ToString("x2"));
		}
		return stringBuilder.ToString();
	}

	public static byte[] smethod_21(string string_0, string string_1, int int_1)
	{
		int cb = 32;
		return new Rfc2898DeriveBytes(Encoding.UTF8.GetBytes(string.IsNullOrEmpty(string_0) ? string.Empty : string_0), Encoding.UTF8.GetBytes(string_1), int_1).GetBytes(cb);
	}

	public static string smethod_22(string string_0)
	{
		string text = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";
		string text2 = "";
		int num = 0;
		do
		{
			int num2 = ((num < string_0.Length) ? string_0[num++] : '\0');
			int num3 = ((num < string_0.Length) ? string_0[num++] : '\0');
			int num4 = ((num < string_0.Length) ? string_0[num++] : '\0');
			int index = num2 >> 2;
			int index2 = ((num2 & 3) << 4) | (num3 >> 4);
			int index3 = ((num3 & 0xF) << 2) | (num4 >> 6);
			int index4 = num4 & 0x3F;
			if (num3 == 0)
			{
				index4 = 64;
				index3 = 64;
			}
			else if (num4 == 0)
			{
				index4 = 64;
			}
			string[] array = new string[5] { text2, null, null, null, null };
			array[1] = text[index].ToString();
			array[2] = text[index2].ToString();
			array[3] = text[index3].ToString();
			array[4] = text[index4].ToString();
			text2 = string.Concat(array);
		}
		while (num < string_0.Length);
		return text2;
	}

	public static string smethod_23(char char_0)
	{
		return char_0.ToString();
	}

	public static string smethod_24(byte byte_0)
	{
		return byte_0.ToString("X2");
	}

	public static string smethod_25(string string_0)
	{
		return Convert.ToBase64String(Encoding.UTF8.GetBytes(string_0));
	}

	public static string smethod_26(string string_0)
	{
		return Encoding.UTF8.GetString(Convert.FromBase64String(string_0));
	}

	private long method_0()
	{
		DateTime dateTime = new DateTime(1970, 1, 1);
		return (long)((DateTime.Now.ToUniversalTime() - dateTime).TotalMilliseconds + 0.5);
	}

	private static byte[] smethod_27()
	{
		using (RNGCryptoServiceProvider rNGCryptoServiceProvider = new RNGCryptoServiceProvider())
		{
			byte[] array = new byte[int_0];
			rNGCryptoServiceProvider.GetBytes(array);
			return array;
		}
	}

	public static string smethod_28(string string_0)
	{
		string result = "";
		try
		{
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			rijndaelManaged.KeySize = 128;
			rijndaelManaged.BlockSize = 128;
			rijndaelManaged.Padding = PaddingMode.PKCS7;
			rijndaelManaged.Mode = CipherMode.CBC;
			rijndaelManaged.Key = Convert.FromBase64String("Ug6Ua5Ph2uRgEaYL3Q2ohbbzdCfPbnh2PpqMdX6cGnk=");
			rijndaelManaged.IV = smethod_27();
			ICryptoTransform transform = rijndaelManaged.CreateEncryptor(rijndaelManaged.Key, rijndaelManaged.IV);
			byte[] inArray = null;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
				{
					byte[] bytes = Encoding.UTF8.GetBytes(string_0);
					cryptoStream.Write(bytes, 0, bytes.Length);
				}
				inArray = memoryStream.ToArray();
			}
			return smethod_29(smethod_31(rijndaelManaged.IV) + "|" + Convert.ToBase64String(inArray));
		}
		catch (Exception ex)
		{
			ex.Message.ToString();
			return result;
		}
	}

	public static string smethod_29(string string_0)
	{
		return Convert.ToBase64String(Encoding.GetEncoding(28591).GetBytes(string_0));
	}

	public static byte[] smethod_30(string string_0)
	{
		int num = string_0.Length / 2;
		byte[] array = new byte[num];
		using (StringReader stringReader = new StringReader(string_0))
		{
			for (int i = 0; i < num; i++)
			{
				array[i] = Convert.ToByte(new string(new char[2]
				{
					(char)stringReader.Read(),
					(char)stringReader.Read()
				}), 16);
			}
			return array;
		}
	}

	public static string smethod_31(byte[] byte_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < byte_0.Length; i++)
		{
			stringBuilder.Append(byte_0[i].ToString("x2"));
		}
		return stringBuilder.ToString();
	}

	public static string smethod_32(string string_0, string string_1)
	{
		byte[] array = new byte[string_0.Length + 1];
		byte[] bytes = Encoding.Default.GetBytes(string_0);
		byte[] array2 = new byte[string_1.Length + 1];
		byte[] bytes2 = Encoding.Default.GetBytes(string_1);
		int[] array3 = new int[256];
		int[] array4 = new int[256];
		byte[] array5 = new byte[bytes2.Length];
		for (int i = 0; i < 256; i++)
		{
			array3[i] = bytes[i % bytes.Length];
			array4[i] = i;
		}
		int num = 0;
		int j = 0;
		int num2 = num;
		for (; j < 256; j++)
		{
			num2 = (num2 + array4[j] + array3[j]) % 256;
			int num3 = array4[j];
			array4[j] = array4[num2];
			array4[num2] = num3;
		}
		int num4 = 0;
		int k = 0;
		int num5 = 0;
		int num6 = num4;
		for (; k < bytes2.Length; k++)
		{
			num6 = (num6 + 1) % 256;
			num5 = (num5 + array4[num6]) % 256;
			int num7 = array4[num6];
			array4[num6] = array4[num5];
			array4[num5] = num7;
			int num8 = array4[(array4[num6] + array4[num5]) % 256];
			array5[k] = (byte)(bytes2[k] ^ num8);
		}
		return Convert.ToBase64String(Encoding.UTF8.GetBytes(Encoding.Default.GetString(array5)));
	}

	public static string smethod_33(string string_0, string string_1)
	{
		byte[] array = new byte[string_0.Length];
		byte[] bytes = Encoding.Default.GetBytes(string_0);
		byte[] array2 = new byte[string_1.Length];
		byte[] bytes2 = Encoding.Default.GetBytes(string_1);
		int[] array3 = new int[256];
		int[] array4 = new int[256];
		byte[] array5 = new byte[bytes2.Length];
		for (int i = 0; i < 256; i++)
		{
			array3[i] = bytes[i % bytes.Length];
			array4[i] = i;
		}
		int num = 0;
		int j = 0;
		int num2 = num;
		for (; j < 256; j++)
		{
			num2 = (num2 + array4[j] + array3[j]) % 256;
			int num3 = array4[j];
			array4[j] = array4[num2];
			array4[num2] = num3;
		}
		int num4 = 0;
		int k = 0;
		int num5 = 0;
		int num6 = num4;
		for (; k < bytes2.Length; k++)
		{
			num6 = (num6 + 1) % 256;
			num5 = (num5 + array4[num6]) % 256;
			int num7 = array4[num6];
			array4[num6] = array4[num5];
			array4[num5] = num7;
			int num8 = array4[(array4[num6] + array4[num5]) % 256];
			array5[k] = (byte)(bytes2[k] ^ num8);
		}
		return Convert.ToBase64String(array5);
	}

	public string method_1(string string_0, int int_1, string string_1)
	{
		RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider(int_1);
		rSACryptoServiceProvider.FromXmlString(string_1);
		int num = int_1 / 8;
		byte[] bytes = Encoding.UTF32.GetBytes(string_0);
		int num2 = num - 42;
		int num3 = bytes.Length;
		int num4 = num3 / num2;
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i <= num4; i++)
		{
			byte[] array = new byte[(num3 - num2 * i > num2) ? num2 : (num3 - num2 * i)];
			Buffer.BlockCopy(bytes, num2 * i, array, 0, array.Length);
			byte[] array2 = rSACryptoServiceProvider.Encrypt(array, true);
			Array.Reverse(array2);
			stringBuilder.Append(Convert.ToBase64String(array2));
		}
		return stringBuilder.ToString();
	}

	public static string smethod_34(string string_0)
	{
        string text = "-----BEGIN PUBLIC KEY-----MIICIjANBgkqhkiG9w0BAQEFAAOCAg8AMIICCgKCAgEAuXyrIPrydyLR2xJyopyMdj+F4K+xxjHeTaLmm49TmgM3xElG7nFvr5Tzk3AIp+z+IhAnXcYs+o348iPB3oXQB75gvJ3CrLDh58AxE60XF42IkbpTrmdevSDhP4fAb7CFdL8/NcHNPzAfA+T1NejSbrcwtVrXUZSrxOX72h8GP54a8pMI7AqF3R2InsQcDReD2ayVlQgznjQfg0eE7WcUzWqDFx6UR2c7OE/9EGiNFUs3qzAKxZk+98oGxYwZyIuR0ZMZscERnsdIYKs1y+28YDDhoUqZ8g6nsbk8nPFVxeaMPU0V9b30Rf/V1YRjGuX8idVHn5mhnLkZVgpdiSm1MSrkvHzoL4mCN/VwP+QI68RXcSkp9gy1x8jlgvBkS39uVK3Yt7S23ivwL/3L0UOyR8pPWEo9YSQ+jiDfEhR9Vmtfr6oYvTyd+gGjMLGZlVDYy2sPf+V1iOuCXCy86AFWpLV6K4HOgTc9/b2dXJ87SwHY5UJWR2+2ZCdGWJbucrJgZ6CoP8DJXYiowgxABzyqWMrnFvB4foLjmkSYrQE/AIpvFbinB8t0fHxgBx4BZ5RLNpaCOPCby/KKeYgfcuTCf4Cmhw1+WkIIqDSPF13N5LKujbZs55X+VcnrC9S7qjqQqCAnwDEh3PUrVN2ElSH9k/o8n5EP5LA1d/MVgrY+Fa0CAwEAAQ==-----END PUBLIC KEY-----";
        text = text.Replace("-----BEGIN PUBLIC KEY-----", "").Replace("-----END PUBLIC KEY-----", "");
        Asn1Object asn1Object = Asn1Object.FromByteArray(Convert.FromBase64String(text));
        DerSequence derSequence = (DerSequence)asn1Object;
        DerBitString derBitString = (DerBitString)derSequence[1];
        DerSequence derSequence2 = (DerSequence)Asn1Object.FromByteArray(derBitString.GetBytes());
        DerInteger derInteger = (DerInteger)derSequence2[0];
        DerInteger derInteger2 = (DerInteger)derSequence2[1];
        RsaKeyParameters rsaKey = new RsaKeyParameters(isPrivate: false, derInteger.PositiveValue, derInteger2.PositiveValue);
        RSAParameters parameters = DotNetUtilities.ToRSAParameters(rsaKey);
        RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider(1024);
        rSACryptoServiceProvider.ImportParameters(parameters);
        byte[] bytes = Encoding.UTF8.GetBytes(string_0);
        byte[] inArray = rSACryptoServiceProvider.Encrypt(bytes, fOAEP: false);
        return Convert.ToBase64String(inArray);
    }

	public static string smethod_350(string string_0)
	{
		DerSequence derSequence = (DerSequence)Asn1Object.FromByteArray(((DerBitString)((Asn1Sequence)Asn1Object.FromByteArray(Convert.FromBase64String("-----BEGIN PUBLIC KEY-----MIIBITANBgkqhkiG9w0BAQEFAAOCAQ4AMIIBCQKCAQBhI7E6SVzciykd5y1wzpznGzgbRMpCQwJrV7Uxq92JM00nTWu8c9JH1tA9yASz1aDV7rixpMggNnCNfbBZbhmnK4Fp2cZLNO4V5z4ud2uCatUv3Q3Egb/8jnscCoPi0//Et83EBJ7CSLkNhDarQmX0MMO2TvHF01/Y78c6w7QmCBSfkn15cjZBorlGJg7rGrGgQRl/p2BUNbexd3dLc3EiqXIPHQt6wfr1T1iJDGxdHR7ZOksaR1fbvEKvlNKRYvlkeA/+pyvhuCyfs1ny0Krgllk8vl2OBFHKzkkfqJ30mr5NmIle9XqmFzqE4yJX70/00TaY/3wgQ4uSMBhiyH/hAgMBAAE=-----END PUBLIC KEY-----".Replace("-----BEGIN PUBLIC KEY-----", "").Replace("-----END PUBLIC KEY-----", ""))))[1]).GetBytes());
		RSAParameters parameters = DotNetUtilities.ToRSAParameters(new RsaKeyParameters(false, ((DerInteger)derSequence[0]).PositiveValue, ((DerInteger)derSequence[1]).PositiveValue));
		RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider(1024);
		rSACryptoServiceProvider.ImportParameters(parameters);
		Encoding.UTF8.GetBytes(string_0);
		using (new RSACryptoServiceProvider(1024))
		{
			rSACryptoServiceProvider.ImportParameters(parameters);
		}
		byte[] bytes = Encoding.UTF8.GetBytes(string_0);
		return Convert.ToBase64String(rSACryptoServiceProvider.Encrypt(bytes, false));
	}

	public static string smethod_340(string string_0)
	{
		string text = "-----BEGIN PUBLIC KEY-----MIIBITANBgkqhkiG9w0BAQEFAAOCAQ4AMIIBCQKCAQBhI7E6SVzciykd5y1wzpznGzgbRMpCQwJrV7Uxq92JM00nTWu8c9JH1tA9yASz1aDV7rixpMggNnCNfbBZbhmnK4Fp2cZLNO4V5z4ud2uCatUv3Q3Egb/8jnscCoPi0//Et83EBJ7CSLkNhDarQmX0MMO2TvHF01/Y78c6w7QmCBSfkn15cjZBorlGJg7rGrGgQRl/p2BUNbexd3dLc3EiqXIPHQt6wfr1T1iJDGxdHR7ZOksaR1fbvEKvlNKRYvlkeA/+pyvhuCyfs1ny0Krgllk8vl2OBFHKzkkfqJ30mr5NmIle9XqmFzqE4yJX70/00TaY/3wgQ4uSMBhiyH/hAgMBAAE=-----END PUBLIC KEY-----".Replace("-----BEGIN PUBLIC KEY-----", "").Replace("-----END PUBLIC KEY-----", "");
		DerSequence derSequence = (DerSequence)Asn1Object.FromByteArray(((DerBitString)((Asn1Sequence)Asn1Object.FromByteArray(Convert.FromBase64String(text)))[1]).GetBytes());
		RSAParameters parameters = DotNetUtilities.ToRSAParameters(new RsaKeyParameters(false, ((DerInteger)derSequence[0]).PositiveValue, ((DerInteger)derSequence[1]).PositiveValue));
		RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider(1024);
		rSACryptoServiceProvider.ImportParameters(parameters);
		Encoding.UTF8.GetBytes(string_0);
		using (RSACryptoServiceProvider rSACryptoServiceProvider2 = new RSACryptoServiceProvider(1024))
		{
			try
			{
				rSACryptoServiceProvider2.FromXmlString(text);
				byte[] rgb = Convert.FromBase64String(string_0);
				return Encoding.UTF8.GetString(rSACryptoServiceProvider2.Decrypt(rgb, true)).ToString();
			}
			finally
			{
				rSACryptoServiceProvider.PersistKeyInCsp = false;
			}
		}
	}

	public static string smethod_35(string string_0)
	{
		string text = "-----BEGIN PUBLIC KEY-----MIICIjANBgkqhkiG9w0BAQEFAAOCAg8AMIICCgKCAgEAuXyrIPrydyLR2xJyopyMdj+F4K+xxjHeTaLmm49TmgM3xElG7nFvr5Tzk3AIp+z+IhAnXcYs+o348iPB3oXQB75gvJ3CrLDh58AxE60XF42IkbpTrmdevSDhP4fAb7CFdL8/NcHNPzAfA+T1NejSbrcwtVrXUZSrxOX72h8GP54a8pMI7AqF3R2InsQcDReD2ayVlQgznjQfg0eE7WcUzWqDFx6UR2c7OE/9EGiNFUs3qzAKxZk+98oGxYwZyIuR0ZMZscERnsdIYKs1y+28YDDhoUqZ8g6nsbk8nPFVxeaMPU0V9b30Rf/V1YRjGuX8idVHn5mhnLkZVgpdiSm1MSrkvHzoL4mCN/VwP+QI68RXcSkp9gy1x8jlgvBkS39uVK3Yt7S23ivwL/3L0UOyR8pPWEo9YSQ+jiDfEhR9Vmtfr6oYvTyd+gGjMLGZlVDYy2sPf+V1iOuCXCy86AFWpLV6K4HOgTc9/b2dXJ87SwHY5UJWR2+2ZCdGWJbucrJgZ6CoP8DJXYiowgxABzyqWMrnFvB4foLjmkSYrQE/AIpvFbinB8t0fHxgBx4BZ5RLNpaCOPCby/KKeYgfcuTCf4Cmhw1+WkIIqDSPF13N5LKujbZs55X+VcnrC9S7qjqQqCAnwDEh3PUrVN2ElSH9k/o8n5EP5LA1d/MVgrY+Fa0CAwEAAQ==-----END PUBLIC KEY-----".Replace("-----BEGIN PUBLIC KEY-----", "").Replace("-----END PUBLIC KEY-----", "");
		DerSequence derSequence = (DerSequence)Asn1Object.FromByteArray(((DerBitString)((Asn1Sequence)Asn1Object.FromByteArray(Convert.FromBase64String(text)))[1]).GetBytes());
		RSAParameters parameters = DotNetUtilities.ToRSAParameters(new RsaKeyParameters(false, ((DerInteger)derSequence[0]).PositiveValue, ((DerInteger)derSequence[1]).PositiveValue));
		RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider(1024);
		rSACryptoServiceProvider.ImportParameters(parameters);
		Encoding.UTF8.GetBytes(string_0);
		using (RSACryptoServiceProvider rSACryptoServiceProvider2 = new RSACryptoServiceProvider(1024))
		{
			try
			{
				rSACryptoServiceProvider2.FromXmlString(text);
				byte[] rgb = Convert.FromBase64String(string_0);
				return Encoding.UTF8.GetString(rSACryptoServiceProvider2.Decrypt(rgb, true)).ToString();
			}
			finally
			{
				rSACryptoServiceProvider.PersistKeyInCsp = false;
			}
		}
	}

	public static string smethod_36(string string_0)
	{
		string text = "<RSAKeyValue><Modulus>hWziTkQaoD/j5m1ddjCIjfucT4THh93qAgHUn0FWfckz56iL7CAvRzueL93DhWVBxSm9bybnAW87b8RDKdRd7pGl5Z4D3ySaSlSpKYKrrT/wlbUG1Sm1QsMmsCFGRw4sht3IbzmZKHo4Lx3mnnwUec1QvHDU92RqaqC746N3UetyCoRNieVBY09A+lbL34VPkJK4M5hWoTO0wloExc8OKArBzjPgu2b6ZXw6rl6/3qhADriyNpRY/tWhh8XE5DY9N7xcrsDbNGsKvNcc8vcfN/TynKDSXdMSF8ICauaLFD5gQpoAKi3arWhpn0aw/WFBKxTNgGXIrBOSwaDSe4r5zt2un3KR+P03uEwOUhEp2Wl7sWJPM9igLdTrOQDA18JqymGHDp8eWNrxFBKMwYLlyACApSs9pDkSlsOcdhlvj0Ms1yxndCzIO1MY+4a/Rse89TUp/JiHvIfjQeNAymv/nhE/MYJBQcnWmTuv6/pCwS/julw0if+NP5dlBhrsTFyQZddu53+TD0K3NEHKVEMQ9ZRM2rKEt4k7x0wJYIP13i/6/qdo3D2mpDvbCly/wJbJW7x+FmOWA6u8DSuid+9dmFj0vEoTc5HTqOt0JvGg+hALaebGT7zDt+dCoWL3CYcg7hXQ0h133WaGGNs2lNxZ4qDKjyN5KLqL0/HtUtLFZuk=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
		byte[] bytes = Encoding.UTF8.GetBytes(string_0);
		using (RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider(1024))
		{
			try
			{
				rSACryptoServiceProvider.FromXmlString(text.ToString());
				return Convert.ToBase64String(rSACryptoServiceProvider.Encrypt(bytes, true));
			}
			finally
			{
				rSACryptoServiceProvider.PersistKeyInCsp = false;
			}
		}
	}

	public static string smethod_37(string string_0)
	{
		string text = "<html>\n<head>\n\n<script type=\"text/javascript\">\n\tvar m, y, v, b = \"0123456789abcdefghijklmnopqrstuvwxyz\", T = \"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/\", S = \" = \";\n\tfunction a(t) {                var e, i, r = \"\";                for (e = 0; e + 3 <= t.length; e += 3)                    i = parseInt(t.substring(e, e + 3), 16),                    r += T.charAt(i >> 6) + T.charAt(63 & i);                for (e + 1 == t.length ? (i = parseInt(t.substring(e, e + 1), 16),                r += T.charAt(i << 2)) : e + 2 == t.length && (i = parseInt(t.substring(e, e + 2), 16),                r += T.charAt(i >> 2) + T.charAt((3 & i) << 4)); (3 & r.length) > 0; )                    r += S;                return r            }</script>\n\n\n\n</head>\n\n<body>\n\n\n\n</body>\n\n</html> \n\n";
		WebBrowser webBrowser = new WebBrowser();
		webBrowser.Navigate("about:blank");
		webBrowser.Document.Write(text);
		return webBrowser.Document.InvokeScript("a", new object[1] { string_0 }).ToString();
	}
}
