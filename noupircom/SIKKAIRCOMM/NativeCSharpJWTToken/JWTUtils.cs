using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Agreement;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;

namespace NativeCSharpJWTToken
{
	internal class JWTUtils
	{
		private static byte[] keyType = new byte[4] { 69, 67, 83, 51 };

		private static byte[] keyLength = new byte[4] { 48, 0, 0, 0 };

		private static readonly byte[] DefaultIV = new byte[8] { 166, 166, 166, 166, 166, 166, 166, 166 };

		private static int keyLengthBits = 128;

		private byte[] constPartKey = new byte[345]
		{
			48, 130, 1, 181, 48, 130, 1, 77, 6, 7,
			42, 134, 72, 206, 61, 2, 1, 48, 130, 1,
			64, 2, 1, 1, 48, 60, 6, 7, 42, 134,
			72, 206, 61, 1, 1, 2, 49, 0, 255, 255,
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
			255, 255, 255, 255, 255, 255, 255, 255, 255, 254,
			255, 255, 255, 255, 0, 0, 0, 0, 0, 0,
			0, 0, 255, 255, 255, 255, 48, 100, 4, 48,
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
			255, 254, 255, 255, 255, 255, 0, 0, 0, 0,
			0, 0, 0, 0, 255, 255, 255, 252, 4, 48,
			179, 49, 47, 167, 226, 62, 231, 228, 152, 142,
			5, 107, 227, 248, 45, 25, 24, 29, 156, 110,
			254, 129, 65, 18, 3, 20, 8, 143, 80, 19,
			135, 90, 198, 86, 57, 141, 138, 46, 209, 157,
			42, 133, 200, 237, 211, 236, 42, 239, 4, 97,
			4, 170, 135, 202, 34, 190, 139, 5, 55, 142,
			177, 199, 30, 243, 32, 173, 116, 110, 29, 59,
			98, 139, 167, 155, 152, 89, 247, 65, 224, 130,
			84, 42, 56, 85, 2, 242, 93, 191, 85, 41,
			108, 58, 84, 94, 56, 114, 118, 10, 183, 54,
			23, 222, 74, 150, 38, 44, 111, 93, 158, 152,
			191, 146, 146, 220, 41, 248, 244, 29, 189, 40,
			154, 20, 124, 233, 218, 49, 19, 181, 240, 184,
			192, 10, 96, 177, 206, 29, 126, 129, 157, 122,
			67, 29, 124, 144, 234, 14, 95, 2, 49, 0,
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
			255, 255, 255, 255, 199, 99, 77, 129, 244, 55,
			45, 223, 88, 26, 13, 178, 72, 176, 167, 122,
			236, 236, 25, 106, 204, 197, 41, 115, 2, 1,
			1, 3, 98, 0, 4
		};

		internal string createJwtToken(CngKey cngKey_0, string string_1, string string_2, string string_3)
		{
			string result = "";
			try
			{
				long num = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
				byte[] array = new byte[16];
				new Random().NextBytes(array);
				string value = Convert.ToBase64String(array);
				string key = "aud";
				string value2 = "MAPPS";
				string key2 = "sub";
				string value3 = "オケクキカ#";
				string key3 = "アイ#ウエオ";
				string key4 = "salutbébé";
				string key5 = "電子メールID";
				int length = string_2.Length;
				Dictionary<string, object> payload = new Dictionary<string, object>
				{
					{ "iss", string_2 },
					{ key, value2 },
					{
						"exp",
						num + 1200
					},
					{ "jti", value },
					{ "iat", num },
					{
						"nbf",
						num - 600
					},
					{ key2, value3 },
					{ key3, string_3 },
					{ key4, string_2 },
					{ key5, length }
				};
				Dictionary<string, object> extraHeaders = new Dictionary<string, object> { { "kid", "deviceyek" } };
				string payload2 = EncodeSignature(payload, cngKey_0, extraHeaders);
				Dictionary<string, object> extraHeaders2 = new Dictionary<string, object>
				{
					{ "kid", "serveryek" },
					{ "cty", "JWT" }
				};
				return Encode(payload2, string_1, extraHeaders2);
			}
			catch (Exception)
			{
				return result;
			}
		}

		internal CngKey getRandomAppCngKey()
		{
			return CngKey.Create(CngAlgorithm.ECDsaP384, null, new CngKeyCreationParameters
			{
				ExportPolicy = CngExportPolicies.AllowPlaintextExport
			});
		}

		internal string getStringRandomCngKeyForSendingToServer(CngKey cngKeyRandomApp)
		{
			return Convert.ToBase64String(constPartKey.Concat(cngKeyRandomApp.Export(CngKeyBlobFormat.EccPublicBlob).Skip(8).Take(96)
				.ToArray()).ToArray());
		}

		private AsymmetricCipherKeyPair GenerateRandomKeysInApp(int keySize)
		{
			ECKeyPairGenerator eCKeyPairGenerator = new ECKeyPairGenerator();
			KeyGenerationParameters parameters = new KeyGenerationParameters(new SecureRandom(), keySize);
			eCKeyPairGenerator.Init(parameters);
			return eCKeyPairGenerator.GenerateKeyPair();
		}

		private byte[] createPublicKeyArrayFromServer(string publicKeyFromServerString)
		{
			return ((ECPublicKeyParameters)PublicKeyFactory.CreateKey(Convert.FromBase64String(publicKeyFromServerString))).Q.GetEncoded();
		}

		private string EncodeSignature(object payload, object key, IDictionary<string, object> extraHeaders = null)
		{
			return EncodeSignatureNext(JSSerializerMapper.Serialize(payload), key, extraHeaders);
		}

		private string EncodeSignatureNext(string payload, object key, IDictionary<string, object> extraHeaders = null)
		{
			return EncodeBytesSignature(Encoding.UTF8.GetBytes(payload), key, extraHeaders);
		}

		private string EncodeBytesSignature(byte[] payload, object key, IDictionary<string, object> extraHeaders = null)
		{
			if (payload == null)
			{
				return null;
			}
			if (extraHeaders == null)
			{
				extraHeaders = new Dictionary<string, object> { { "typ", "JWT" } };
			}
			Dictionary<string, object> dictionary = new Dictionary<string, object> { { "alg", "ES384" } };
			Append(dictionary, extraHeaders);
			byte[] bytes = Encoding.UTF8.GetBytes(JSSerializerMapper.Serialize(dictionary));
			byte[] array = Sign(Encoding.UTF8.GetBytes(Compact.Serialize(bytes, payload)), key);
			return Compact.Serialize(bytes, payload, array);
		}

		private byte[] Sign(byte[] securedInput, object key)
		{
			try
			{
				if (!(key is CngKey))
				{
					throw new ArgumentException("EcdsaUsingSha algorithm expects key to be of either CngKey or ECDsa types.");
				}
				using (ECDsaCng eCDsaCng = new ECDsaCng((CngKey)key))
				{
					eCDsaCng.HashAlgorithm = CngAlgorithm.Sha384;
					return eCDsaCng.SignData(securedInput);
				}
			}
			catch (CryptographicException innerException)
			{
				throw new Exception("Unable to sign content.", innerException);
			}
		}

		private string Encode(string payload, string publicKeyFromServer, IDictionary<string, object> extraHeaders)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(payload);
			if (publicKeyFromServer == null || publicKeyFromServer.Length == 0)
			{
				throw new Exception($"Public Key From Server string empty! : {publicKeyFromServer}");
			}
			IDictionary<string, object> dictionary = new Dictionary<string, object>
			{
				{ "alg", "ECDH-ES+A128KW" },
				{ "enc", "A128GCM" },
				{ "zip", "DEF" }
			};
			Append(dictionary, extraHeaders);
			byte[][] array = WrapNewKey(128, publicKeyFromServer, dictionary);
			byte[] cek = array[0];
			byte[] array2 = array[1];
			byte[] plainText = Compress(bytes);
			byte[] bytes2 = Encoding.UTF8.GetBytes(JSSerializerMapper.Serialize(dictionary));
			byte[][] array3 = AesGcmEncryption.Encrypt(Encoding.UTF8.GetBytes(Compact.Serialize(bytes2)), plainText, cek);
			return Compact.Serialize(bytes2, array2, array3[0], array3[1], array3[2]);
		}

		private byte[] Compress(byte[] plainText)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (DeflateStream deflateStream = new DeflateStream(memoryStream, CompressionMode.Compress))
				{
					deflateStream.Write(plainText, 0, plainText.Length);
				}
				return memoryStream.ToArray();
			}
		}

		private void Append<K, V>(IDictionary<K, V> src, IDictionary<K, V> other)
		{
			if (src == null || other == null)
			{
				return;
			}
			foreach (KeyValuePair<K, V> item in other.Where((KeyValuePair<K, V> pair) => !src.ContainsKey(pair.Key)))
			{
				src.Add(item);
			}
		}

		private byte[][] WrapNewKey(int cekSizeBits, string key, IDictionary<string, object> header)
		{
			byte[] key2 = WrapNewKeyNext(keyLengthBits, key, header)[0];
			return WrapNewKeyLast(cekSizeBits, key2, header);
		}

		private byte[][] WrapNewKeyLast(int cekSizeBits, byte[] key, IDictionary<string, object> header)
		{
			byte[] array = Arrays.Random(cekSizeBits);
			byte[] array2 = AesKeyWrap(array, key);
			return new byte[2][] { array, array2 };
		}

		private byte[] AesKeyWrap(byte[] cek, byte[] kek)
		{
			byte[] array = DefaultIV;
			byte[][] array2 = Arrays.Slice(cek, 8);
			long num = array2.Length;
			for (long num2 = 0L; num2 < 6; num2++)
			{
				for (long num3 = 0L; num3 < num; num3++)
				{
					long right = num * num2 + num3 + 1;
					byte[] arr = AesEnc(kek, Arrays.Concat(array, array2[(int)(IntPtr)num3]));
					byte[] left = Arrays.FirstHalf(arr);
					array2[(int)(IntPtr)num3] = Arrays.SecondHalf(arr);
					array = Arrays.Xor(left, right);
				}
			}
			byte[][] array3 = new byte[num + 1][];
			array3[0] = array;
			for (long num4 = 1L; num4 <= num; num4++)
			{
				array3[(int)(IntPtr)num4] = array2[(int)(IntPtr)(num4 - 1)];
			}
			return Arrays.Concat(array3);
		}

		private byte[] AesEnc(byte[] sharedKey, byte[] plainText)
		{
			using (Aes aes = new AesCryptoServiceProvider())
			{
				aes.Key = sharedKey;
				aes.Mode = CipherMode.ECB;
				aes.Padding = PaddingMode.None;
				using (MemoryStream memoryStream = new MemoryStream())
				{
					using (ICryptoTransform transform = aes.CreateEncryptor(aes.Key, aes.IV))
					{
						using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
						{
							cryptoStream.Write(plainText, 0, plainText.Length);
							cryptoStream.FlushFinalBlock();
							return memoryStream.ToArray();
						}
					}
				}
			}
		}

		private byte[][] WrapNewKeyNext(int cekSizeBits, string key, IDictionary<string, object> header)
		{
			try
			{
				return new byte[2][]
				{
					NewKey(cekSizeBits, key, header),
					new byte[0]
				};
			}
			catch (Exception)
			{
				return new byte[0][];
			}
		}

		private byte[] NewKey(int keyLength, string publicKeyFromServer, IDictionary<string, object> header)
		{
			AsymmetricCipherKeyPair asymmetricCipherKeyPair = GenerateRandomKeysInApp(384);
			byte[] encoded = ((ECPublicKeyParameters)asymmetricCipherKeyPair.Public).Q.GetEncoded();
			IDictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary["kty"] = "EC";
			dictionary["x"] = Base64Url.Encode(encoded.Skip(1).Take(48).ToArray());
			dictionary["y"] = Base64Url.Encode(encoded.Skip(49).Take(48).ToArray());
			dictionary["crv"] = "P-384";
			header["epk"] = dictionary;
			((ECPrivateKeyParameters)asymmetricCipherKeyPair.Private).D.ToByteArray();
			ECPublicKeyParameters pubKey = (ECPublicKeyParameters)PublicKeyFactory.CreateKey(Convert.FromBase64String(publicKeyFromServer));
			ECDHCBasicAgreement eCDHCBasicAgreement = new ECDHCBasicAgreement();
			eCDHCBasicAgreement.Init(asymmetricCipherKeyPair.Private);
			byte[] array = eCDHCBasicAgreement.CalculateAgreement(pubKey).ToByteArray();
			if (array.Length > 48)
			{
				array = array.Skip(1).Take(48).ToArray();
			}
			byte[] array2 = new byte[30]
			{
				0, 0, 0, 14, 69, 67, 68, 72, 45, 69,
				83, 43, 65, 49, 50, 56, 75, 87, 0, 0,
				0, 0, 0, 0, 0, 0, 0, 0, 0, 128
			};
			byte[] array3 = new byte[4] { 0, 0, 0, 1 };
			int count = 16;
			IDigest digest = new Sha256Digest();
			byte[] array4 = new byte[digest.GetDigestSize()];
			digest.BlockUpdate(array3, 0, array3.Length);
			digest.BlockUpdate(array, 0, array.Length);
			digest.BlockUpdate(array2, 0, array2.Length);
			digest.DoFinal(array4, 0);
			return array4.Take(count).ToArray();
		}

		private static void Main(string[] args)
		{
			for (int i = 0; i < 50; i++)
			{
				Console.WriteLine("Input any button when ready");
				Console.ReadLine();
				string[] array = File.ReadAllLines("E:\\\\BackupDisk\\\\BaseApk\\\\IRCTC\\\\Log\\\\dss.key");
				string text = array[0];
				string text2 = array[1];
				string text3 = array[2];
			}
		}

		internal string getHash(string fakeImei, string fakeSimSerialNumber, string fakeAndroidId)
		{
			long mostSignificantBits = HashCodeJavaForString(fakeImei);
			long num = HashCodeJavaForString(fakeSimSerialNumber);
			long num2 = HashCodeJavaForString(fakeAndroidId);
			long leastSignificantBits = HashCodeJavaForString(fakeSimSerialNumber) | ((long)HashCodeJavaForString(fakeAndroidId) << 32);
			return new JavaUUID.Uuid(mostSignificantBits, leastSignificantBits).ToString();
		}

		internal string GetHash(ref string mup)
		{
			string text = RandomString(9, "abcdeflmno0123456789pqrstuvwxyz").ToUpper();
			string text2 = RandomString(5, "abcdefghijklstu0123456789vwxyz").ToUpper();
			string text3 = RandomString(5, "abcdhijklmnopqrwxyz0123456789").ToUpper();
			string text4 = RandomString(5, "0123456789");
			string text5 = RandomString(13, "opqrst0123456789abcdefghijklmn").ToUpper();
			string result = text + "=" + text2 + "=" + text3 + "=" + text4 + "=" + text5;
			mup = text.Remove(text.Length - 1) + "-" + text2.Remove(text2.Length - 1) + "-" + text3.Remove(text3.Length - 1) + "-" + text4.Remove(text4.Length - 1) + "-" + text5.Remove(text5.Length - 1);
			return result;
		}

		internal string RandomString(int int_28, string string_86)
		{
			char[] array = new char[int_28];
			Random random = new Random();
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = string_86[random.Next(string_86.Length)];
			}
			return new string(array);
		}

		private int HashCodeJavaForString(string value)
		{
			int num = 0;
			char[] array = value.ToCharArray();
			for (int i = 0; i < value.Length; i++)
			{
				num = 31 * num + array[i];
			}
			return num;
		}

		internal string getClientTransactionId(long userId)
		{
			string text = RandomString(15, "0123456789");
			string text2 = DateTime.Now.ToString("yyyyMMddHHmmss");
			string s = text + userId + text2;
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			MD5 mD = new MD5CryptoServiceProvider();
			byte[] bytes2 = mD.ComputeHash(bytes);
			BigInteger bigInteger = new BigInteger(1, bytes2);
			string text3 = bigInteger.ToString(16);
			return text3.Substring(0, 8);
		}
	}
}
