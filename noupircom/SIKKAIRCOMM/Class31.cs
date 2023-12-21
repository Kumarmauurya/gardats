using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Signers;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;

internal class Class31
{
	private class Class32
	{
		private string string_0 = "";

		private string string_1 = "";

		private AsymmetricCipherKeyPair asymmetricCipherKeyPair_0;

		public Class32()
		{
			RsaKeyPairGenerator rsaKeyPairGenerator = new RsaKeyPairGenerator();
			rsaKeyPairGenerator.Init(new KeyGenerationParameters(new SecureRandom(), 2048));
			AsymmetricCipherKeyPair asymmetricCipherKeyPair = rsaKeyPairGenerator.GenerateKeyPair();
			string_1 = Convert.ToBase64String(PrivateKeyInfoFactory.CreatePrivateKeyInfo(asymmetricCipherKeyPair.Private).ToAsn1Object().GetDerEncoded());
			string_0 = Convert.ToBase64String(SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(asymmetricCipherKeyPair.Public).ToAsn1Object().GetDerEncoded());
			asymmetricCipherKeyPair_0 = asymmetricCipherKeyPair;
		}

		public string method_0(string string_2, string string_3, ref string string_4)
		{
			string_2 = string_2.Replace(string_4, string_0);
			string_2 = string_2.ToLower();
			string_2 = new Regex("[^\\x00-\\x7F]|[\\p{Cc}&&[^\n\t]]|\\p{C}|\\s+", RegexOptions.None).Replace(string_2, string.Empty);
			string result = method_1(string_2, asymmetricCipherKeyPair_0.Private);
			Sha256Digest sha256Digest = new Sha256Digest();
			byte[] bytes = Encoding.UTF8.GetBytes(string_2);
			sha256Digest.BlockUpdate(bytes, 0, bytes.Length);
			RsaDigestSigner rsaDigestSigner = new RsaDigestSigner(sha256Digest);
			rsaDigestSigner.Init(true, asymmetricCipherKeyPair_0.Private);
			Convert.ToBase64String(rsaDigestSigner.GenerateSignature());
			string_3 = string_1;
			string_4 = string_0;
			return result;
		}

		public string method_1(string string_2, AsymmetricKeyParameter asymmetricKeyParameter_0)
		{
			try
			{
				byte[] bytes = Encoding.UTF8.GetBytes(string_2);
				ISigner signer = SignerUtilities.GetSigner("SHA-256withRSA");
				signer.Init(true, asymmetricKeyParameter_0);
				signer.BlockUpdate(bytes, 0, bytes.Length);
				return Convert.ToBase64String(signer.GenerateSignature());
			}
			catch (Exception ex)
			{
				Console.WriteLine("Signing Failed: " + ex.ToString());
				return null;
			}
		}
	}

	internal string string_0;

	internal string string_1;

	internal string string_2;

	private string string_3;

	private string string_4;

	private string string_5;

	private string string_6;

	private string string_7;

	private string string_8;

	private string string_9;

	private string string_10;

	private string string_11;

	private string string_12;

	private bool bool_0;

	private string string_13;

	internal string string_14 = "okhttp/3.12.1";

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private CookieContainer cookieContainer_0;

	private Dictionary<string, string> dictionary_0;

	internal string string_15;

	internal string string_16;

	internal string string_17;

	internal string string_18;

	internal string string_19;

	internal string string_20;

	internal string string_21;

	internal string string_22;

	internal string string_23;

	internal string string_24;

	internal string string_25;

	internal string string_26;

	internal string string_27;

	private string string_28;

	internal string method_0(string string_29)
	{
		string text = "";
		string[] array = string_29.Split(new string[1] { "||" }, StringSplitOptions.RemoveEmptyEntries);
		string_4 = array[1];
		string_12 = array[2];
		WebProxy webProxy_ = null;
		string_21 = "samsung";
		string_22 = "SM-J320F";
		string_19 = "samsung-SM-J320F-860d588d64558aa";
		string_19 = smethod_0(ref string_21, ref string_22);
		string[] array2 = string_19.Split(new string[1] { "-" }, StringSplitOptions.None);
		string_1 = array2[0];
		string_2 = array2[1];
		string_0 = array2[2];
		string_23 = "8.14.0";
		string_24 = "5.1.1";
		string_25 = "";
		string_3 = string_4;
		long num = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds / 1000;
		int num2 = 1;
		string_5 = "860d588d64558aa:1602774768259:16:16";
		string_5 = string_0 + ":" + num + ":" + num2 + ":" + num2;
		string_6 = "89300500203268030312";
		string_7 = "Basic bWFya2V0LWFwcDo5YTA3MTc2Mi1hNDk5LTRiZDktOTE0YS00MzYxZTdjM2Y0YmM=";
		DateTimeOffset.Now.ToUnixTimeSeconds();
		double totalSeconds = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
		string_8 = "1602774768";
		string_8 = totalSeconds.ToString();
		string string_30 = "";
		string_9 = "x-phone-number#" + string_3 + "||x-app-rid#" + string_5 + "||x-device-name#" + string_22 + "||x-app-version#" + string_23 + "||x-device-manufacturer#" + string_21 + "||x-iccid#" + string_6 + "||x-device-identifier#" + string_19 + "||x-epoch#" + string_8 + "||Authorization#" + string_7;
		string result;
		if (!method_1("https://accounts.paytm.com/devicebinding/config/sv1?deviceIdentifier=" + string_19 + "&deviceManufacturer=" + string_21 + "&deviceName=" + string_22 + "&client=androidapp&version=" + string_23 + "&playStore=false&lat=0.0&long=0.0&language=en&networkType=WIFI&osVersion=" + string_24 + "&locale=en-IN&flow=LOGIN_REGISTER", "", string_30, 2, webProxy_, ref cookieContainer_0, true, 50000, ref string_10, ref string_28))
		{
			int num3 = (int)MessageBox.Show("PAYTM Registration Failed-2");
			result = text;
		}
		else if (string_10.IndexOf("NO_MAPPING_FOUND") < 0)
		{
			int num4 = (int)MessageBox.Show("Some Thing Worng With PAYTM Registration Failed-1");
			result = text;
		}
		else
		{
			Class32 @class = new Class32();
			long num5 = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds / 1000;
			int num6 = num2 + 1;
			string_5 = string_0 + ":" + num5 + ":" + num6 + ":" + num6;
			string_8 = num5.ToString();
			string string_31 = "";
			string string_32 = "https://accounts.paytm.com/v2/simple/login/init/sv1?deviceIdentifier=" + string_19 + "&deviceManufacturer=" + string_21 + "&deviceName=" + string_22 + "&client=androidapp&version=" + string_23 + "&playStore=false&lat=0.0&long=0.0&language=en&networkType=WIFI&osVersion=" + string_24 + "&locale=en-IN";
			string text2 = "{\"loginId\":\"" + string_4 + "\"}";
			string_26 = "java_rsa_256hmac";
			string text3 = "/v2/simple/login/init/sv1|post|client=androidapp&deviceidentifier=" + string_19 + "&devicemanufacturer=" + string_21 + "&devicename=" + string_22 + "&language=en&lat=0.0&locale=en-in&long=0.0&networktype=wifi&osversion=" + string_24 + "&playstore=false&version=" + string_23 + "|authorization=" + string_7 + "&autoreadhash=asask/gtt2i&x-device-identifier=" + string_19 + "&x-device-manufacturer=" + string_21 + "&x-device-name=" + string_22.ToLower() + "&x-epoch=" + string_8 + "&x-public-key=" + string_26 + "|" + text2;
			string_27 = @class.method_0(text3, "", ref string_26);
			string_9 = "x-client-signature#" + string_27 + "||autoReadHash#asasK/GTt2i||x-app-rid#" + string_5 + "||x-device-name#" + string_22 + "||x-app-version#" + string_23 + "||x-device-manufacturer#" + string_21 + "||x-public-key#" + string_26 + "||x-device-identifier#" + string_19 + "||x-epoch#" + string_8 + "||Authorization#" + string_7;
			if (!method_1(string_32, text2, string_31, 2, webProxy_, ref cookieContainer_0, true, 50000, ref string_10, ref string_28))
			{
				int num7 = (int)MessageBox.Show("PAYTM Registration Failed-2");
				result = text;
			}
			else
			{
				if (string_10.IndexOf("Please enter OTP to continue login") <= 0)
				{
					if (string_10.IndexOf("Please enter password to continue.") < 0)
					{
						int num8 = (int)MessageBox.Show("Some Thing Worng With PAYTM Registration Failed-1");
						return text;
					}
					string text4 = string_10.Substring(string_10.IndexOf("stateToken") + 13);
					string_11 = text4.Substring(0, text4.IndexOf("\","));
					long num9 = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds / 1000;
					num6++;
					string_5 = string_0 + ":" + num9 + ":" + num6 + ":" + num6;
					string_8 = num9.ToString();
					string_31 = "";
					string string_33 = "https://accounts.paytm.com/v2/simple/login/validate/password/sv1?deviceIdentifier=" + string_19 + "&deviceManufacturer=" + string_21 + "&deviceName=" + string_22 + "&client=androidapp&version=" + string_23 + "&playStore=false&lat=0.0&long=0.0&language=en&networkType=WIFI&osVersion=" + string_24 + "&locale=en-IN";
					string text5 = "{\"password\":\"" + string_12 + "\",\"stateToken\":\"" + string_11 + "\"}";
					string_26 = "java_rsa_256hmac";
					string text6 = "/v2/simple/login/validate/password/sv1|post|client=androidapp&deviceidentifier=" + string_19 + "&devicemanufacturer=" + string_21 + "&devicename=" + string_22 + "&language=en&lat=0.0&locale=en-in&long=0.0&networktype=wifi&osversion=" + string_24 + "&playstore=false&version=" + string_23 + "|authorization=" + string_7 + "&x-device-identifier=" + string_19 + "&x-device-manufacturer=" + string_21 + "&x-device-name=" + string_22.ToLower() + "&x-epoch=" + string_8 + "|" + text5;
					string_27 = @class.method_0(text6, "", ref string_26);
					string_9 = "x-client-signature#" + string_27 + "||x-app-rid#" + string_5 + "||x-device-name#" + string_22 + "||x-app-version#" + string_23 + "||x-device-manufacturer#" + string_21 + "||x-device-identifier#" + string_19 + "||x-epoch#" + string_8 + "||Authorization#" + string_7;
					if (!method_1(string_33, text5, string_31, 2, webProxy_, ref cookieContainer_0, true, 50000, ref string_10, ref string_28))
					{
						int num10 = (int)MessageBox.Show("PAYTM Registration Failed-2");
						return text;
					}
				}
				if (string_10.IndexOf("Please enter OTP to continue login.") < 0)
				{
					int num11 = (int)MessageBox.Show("Some Thing Worng With PAYTM Registration Failed-2");
					result = text;
				}
				else
				{
					string text7 = Interaction.InputBox("Enter PayTM OTP Received on your Mobile for ByPass.", "Enter PAYTM OTP");
					string text8 = string_10.Substring(string_10.IndexOf("stateToken") + 13);
					string_11 = text8.Substring(0, text8.IndexOf("\","));
					long num9 = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
					num9 /= 1000;
					int num12 = num6 + 1;
					string_5 = string_0 + ":" + num9 + ":" + num12 + ":" + num12;
					string_8 = num9.ToString();
					string string_34 = "https://accounts.paytm.com/v2/simple/login/validate/otp/sv1?deviceIdentifier=" + string_19 + "&deviceManufacturer=" + string_21 + "&deviceName=" + string_22 + "&client=androidapp&version=" + string_23 + "&playStore=false&lat=0.0&long=0.0&language=en&networkType=WIFI&osVersion=" + string_24 + "&locale=en-IN";
					string text9 = "{\"otp\":\"" + text7 + "\",\"stateToken\":\"" + string_11 + "\"}";
					string_26 = "java_rsa_256hmac";
					string text10 = "/v2/simple/login/validate/otp/sv1|post|client=androidapp&deviceidentifier=" + string_19 + "&devicemanufacturer=" + string_21 + "&devicename=" + string_22 + "&language=en&lat=0.0&locale=en-in&long=0.0&networktype=wifi&osversion=" + string_24 + "&playstore=false&version=" + string_23 + "|authorization=" + string_7 + "&x-device-identifier=" + string_19 + "&x-device-manufacturer=" + string_21 + "&x-device-name=" + string_22.ToLower() + "&x-epoch=" + string_8 + "|" + text9;
					string_27 = @class.method_0(text10, "", ref string_26);
					string_9 = "x-client-signature#" + string_27 + "||x-app-rid#" + string_5 + "||x-device-name#" + string_22 + "||x-app-version#" + string_23 + "||x-device-manufacturer#" + string_21 + "||x-device-identifier#" + string_19 + "||x-epoch#" + string_8 + "||Authorization#" + string_7;
					if (!method_1(string_34, text9, string_31, 2, webProxy_, ref cookieContainer_0, true, 50000, ref string_10, ref string_28))
					{
						int num13 = (int)MessageBox.Show("PAYTM Registration OTP Verfiy Failed-3");
						result = text;
					}
					else if (string_10.IndexOf("status\":\"success") < 0)
					{
						int num14 = (int)MessageBox.Show("Some Thing Worng With PAYTM Registration Failed-3");
						result = text;
					}
					else
					{
						string text11 = string_10.Substring(string_10.IndexOf("oauthCode") + 12);
						string text12 = text11.Substring(0, text11.IndexOf("\""));
						num9 = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
						num9 /= 1000;
						int num15 = num12 + 1;
						string_5 = string_0 + ":" + num9 + ":" + num15 + ":" + num15;
						string_8 = num9.ToString();
						string string_35 = "";
						string string_36 = "https://accounts.paytm.com/oauth2/v3/token/sv1?deviceIdentifier=" + string_19 + "&deviceManufacturer=" + string_21 + "&deviceName=" + string_22 + "&client=androidapp&version=" + string_23 + "&playStore=false&lat=0.0&long=0.0&language=en&networkType=WIFI&osVersion=" + string_24 + "&locale=en-IN";
						string string_37 = "{\"code\":\"" + text12 + "\",\"deviceId\":\"" + string_19 + "\",\"grantType\":\"authorization_code\"}";
						string_9 = "x-app-rid#" + string_5 + "||x-device-name#" + string_22 + "||x-app-version#" + string_23 + "||x-device-manufacturer#" + string_21 + "||x-device-identifier#" + string_19 + "||x-epoch#" + string_8 + "||Authorization#" + string_7;
						if (!method_1(string_36, string_37, string_35, 2, webProxy_, ref cookieContainer_0, true, 50000, ref string_10, ref string_28))
						{
							int num16 = (int)MessageBox.Show("PAYTM Registration Device Register Failed-4");
							result = text;
						}
						else if (string_10.IndexOf("tokens") < 0)
						{
							int num17 = (int)MessageBox.Show("Some Thing Worng With PAYTM Registration Failed-4");
							result = text;
						}
						else
						{
							string text13 = string_10.Substring(string_10.IndexOf("{\"accessToken"));
							string text14 = text13.Substring(0, text13.IndexOf("},") + 1);
							string_10 = string_10.Substring(string_10.IndexOf(text14) + 20);
							string text15 = string_10.Substring(string_10.IndexOf("{\"accessToken"));
							string text16 = text15.Substring(0, text15.IndexOf("},") + 1);
							string_10 = string_10.Substring(string_10.IndexOf(text16) + 20);
							string text17 = string_10.Substring(string_10.IndexOf("{\"accessToken"));
							string text18 = text17.Substring(0, text17.IndexOf("},") + 1);
							string_10 = string_10.Substring(string_10.IndexOf(text18) + 20);
							string text19 = string_10.Substring(string_10.IndexOf("{\"accessToken"));
							string text20 = text19.Substring(0, text19.IndexOf("}"));
							string text21 = text14.Replace("\"", "");
							string text22 = text16.Replace("\"", "");
							string text23 = text18.Replace("\"", "");
							string text24 = text20.Replace("\"", "");
							string text25 = text23.Substring(text23.IndexOf(":") + 1);
							string text26 = text25.Substring(0, text25.IndexOf(","));
							num9 = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
							num9 /= 1000;
							int num18 = num15 + 1;
							string_5 = string_0 + ":" + num9 + ":" + num18 + ":" + num18;
							string string_38 = "";
							string string_39 = "https://paytm.com/v1/user/token/enc/generate?deviceIdentifier=" + string_19 + "&deviceManufacturer=" + string_21 + "&deviceName=" + string_22 + "&client=androidapp&version=" + string_23 + "&playStore=false&lat=0.0&long=0.0&language=en&networkType=WIFI&osVersion=" + string_24 + "&locale=en-IN";
							string string_40 = "";
							string_9 = "sso_token#" + text26 + "||x-app-rid#" + string_5;
							if (!method_1(string_39, string_40, string_38, 2, webProxy_, ref cookieContainer_0, true, 50000, ref string_10, ref string_28))
							{
								int num19 = (int)MessageBox.Show("Some Thing Error With PAYTM OTP Bypass,\n\r\nPlease Retry After Some Time.", "By-Passed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
								result = text;
							}
							else if (string_10.IndexOf("sso_token_enc") < 0)
							{
								int num20 = (int)MessageBox.Show("Some Thing Worng With PAYTM Registration Failed-5");
								result = text;
							}
							else
							{
								string text27 = "3549194" + new Random((int)DateTime.Now.Ticks).Next(300000, 900000) + "76";
								try
								{
									result = string_17 + "||" + text21 + "||" + text22 + "||" + text23 + "||" + text24 + "||" + string_19 + "||" + text27;
								}
								catch (Exception)
								{
									int num21 = (int)MessageBox.Show("Error occured while processing request!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
									result = text;
								}
							}
						}
					}
				}
			}
		}
		return result;
	}

	internal static string smethod_0(ref string string_29, ref string string_30)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>
		{
			{ "Mi3", "Xiomi" },
			{ "Mi4", "Xiomi" },
			{ "P600", "Micomax" },
			{ "GT_S5303B", "Samsung" },
			{ "GT_C3310R", "Samsung" },
			{ "A88_3i", "Micromax" },
			{ "Note_A2", "Karbonn" },
			{ "MSD7Android", "MAXX" },
			{ "N818", "ZTE" },
			{ "N909", "ZTE" },
			{ "Iris351", "Lava" },
			{ "AX8NoteII", "MAXX" },
			{ "MSD7Touch35", "MAXX" },
			{ "91_A3", "Karbonn" },
			{ "911_A91", "Micromax" },
			{ "Iris454", "Lava" },
			{ "X1000", "Xolo" },
			{ "K3_Note", "Lenovo" },
			{ "B407", "LEMON" },
			{ "Andi4v", "iball" },
			{ "Andi5l", "iball" },
			{ "A112", "Micromax" },
			{ "9_A4", "Karbonn" },
			{ "MI_530", "Spice" },
			{ "55_A62", "Micromax" },
			{ "60_A115", "Micromax" },
			{ "P880g", "LG" },
			{ "8_A520", "Lenovo" },
			{ "9_Q700", "XOLO" },
			{ "5_B700", "XOLO" },
			{ "6_A500", "Xolo" },
			{ "1_A800", "Xolo" },
			{ "2_A700", "XOLO" },
			{ "35_A90S", "Micromax" }
		};
		Random random = new Random((int)DateTime.Now.Ticks);
		KeyValuePair<string, string> keyValuePair = dictionary.ElementAt(random.Next(0, dictionary.Count - 1));
		string_30 = keyValuePair.Key;
		string_29 = keyValuePair.Value;
		return string_29 + "-" + string_30 + "-1449194" + random.Next(300000, 900000) + "760180f";
	}

	internal bool method_1(string string_29, string string_30, string string_31, int int_4, WebProxy webProxy_0, ref CookieContainer cookieContainer_1, bool bool_1, int int_5, ref string string_32, ref string string_33)
	{
		int num = 0;
		if (!string.IsNullOrEmpty(string_9))
		{
			string_13 = string_9;
		}
		string text = "Tls";
		WebProxy proxy = null;
		bool result;
		do
		{
			string_33 = "";
			string_32 = "";
			result = false;
			HttpWebResponse httpWebResponse = null;
			string text2 = "";
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string_29);
				httpWebRequest.Proxy = webProxy_0;
				httpWebRequest.Proxy = proxy;
				httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip;
				if ((text == "Tls") | (text == "Ssl3"))
				{
					ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				}
				if (int_5 > 0)
				{
					httpWebRequest.Timeout = int_5;
					httpWebRequest.ReadWriteTimeout = int_5;
				}
				byte[] bytes = Encoding.UTF8.GetBytes(string_30);
				if (bool_1)
				{
					if (cookieContainer_1 == null)
					{
						cookieContainer_1 = new CookieContainer();
					}
					httpWebRequest.CookieContainer = cookieContainer_1;
				}
				httpWebRequest.Method = "POST";
				httpWebRequest.ContentLength = bytes.Length;
				httpWebRequest.ContentType = "application/x-www-form-urlencoded";
				if (string_30.Contains("{\"") || int_4 == 2)
				{
					httpWebRequest.ContentType = "application/json";
				}
				httpWebRequest.UserAgent = string_14;
				if (!string.IsNullOrEmpty(string_13))
				{
					string[] array = Strings.Split(string_13, "||");
					int num2 = Information.UBound(array);
					for (int i = 0; i <= num2; i++)
					{
						string[] array2 = Strings.Split(array[i], "#");
						httpWebRequest.Headers.Set(array2[0], array2[1]);
					}
					string_9 = "";
				}
				if (string_30.Length > 0)
				{
					using (Stream stream = httpWebRequest.GetRequestStream())
					{
						stream.Write(bytes, 0, bytes.Length);
					}
				}
				else
				{
					httpWebRequest.Method = "GET";
				}
				httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				using (StreamReader textReader_ = smethod_1(httpWebResponse.GetResponseStream()))
				{
					text2 = smethod_2(textReader_);
				}
				string_32 = text2;
				result = true;
			}
			catch (Exception ex)
			{
				result = false;
				string_33 = ex.Message;
				if (!string_33.ToUpper().Contains("CONNECTION WAS CLOSED"))
				{
					string_33.ToUpper().Contains("SERVICEUNAVAILABLE");
				}
				if (string_33.Contains("The underlying connection was closed"))
				{
					text = "Tls12";
				}
				string_33.Contains("The underlying connection was closed");
				if (num >= 3)
				{
					return result;
				}
				num++;
			}
			finally
			{
				try
				{
					httpWebResponse?.Close();
				}
				catch
				{
				}
			}
		}
		while (!(string_32 != ""));
		return result;
	}

	private static StreamReader smethod_1(Stream stream_0)
	{
		return new StreamReader(stream_0);
	}

	private static string smethod_2(TextReader textReader_0)
	{
		return textReader_0.ReadToEnd();
	}
}
