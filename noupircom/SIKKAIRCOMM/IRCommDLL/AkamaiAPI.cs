using System;
using System.IO;
using System.Net;

namespace IRCommDLL
{
	internal class AkamaiAPI
	{
		public static string bm_sv_;

		public static string _abck_;

		internal bool akm_App(string user, string pass, ref CookieContainer cc, ref string resp)
		{
			bool result = false;
			string text = "";
			while (true)
			{
				try
				{
					string requestUriString = "https://api.stage.crawless.com/project/8685b583-4198-43ef-bf20-a7e09c952cfa/workflow/e60451c0-7135-4ad2-bd4c-cef61e8917c1/task/api:prashant_no_login/run?args[username]=" + user + "&args[password]=" + pass + "&token=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJhY2NvdW50SWQiOiJiOGZiM2Y2Yi1lNDkzLTQ0NzYtYWQzZS04NzIzYTE5Y2NiMWEiLCJpYXQiOjE2NjgxMTE3OTMsImV4cCI6MTY5OTY2OTM5M30.3Y5XiZAo1h16YGPUdzIYzOr_Z4f6U51Bdi2gxBfaFCs";
					HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
					ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
					httpWebRequest.Timeout = 180000;
					httpWebRequest.ReadWriteTimeout = 180000;
					httpWebRequest.Method = "GET";
					using (StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream()))
					{
						text = streamReader.ReadToEnd();
						if (text.Length < 500)
						{
							continue;
						}
						string text2 = text.Substring(text.IndexOf("body_response") + 15);
						resp = text2.Substring(0, text2.IndexOf("},"));
						text2 = text.Substring(text.IndexOf("[") + 1);
						text = text2.Substring(0, text2.IndexOf("]"));
						string[] array = text.Split(new string[1] { "}," }, StringSplitOptions.None);
						string[] array2 = array;
						string[] array3 = array2;
						foreach (string text3 in array3)
						{
							string @string = GetString(text3, "name\":");
							string string2 = GetString(text3, "value\":");
							string string3 = GetString(text3, "domain\":");
							string string4 = GetString(text3, "path\":");
							bool secure = text3.Contains("secure\":true");
							bool httpOnly = text3.Contains("httpOnly\":true");
							Cookie cookie = new Cookie(@string, string2)
							{
								Domain = string3,
								Path = string4,
								Secure = secure,
								HttpOnly = httpOnly
							};
							cc.Add(cookie);
						}
						return result;
					}
				}
				catch
				{
				}
			}
		}

		internal bool akm_Web(string user, string pass, ref CookieContainer cc, ref string greq, ref string token, ref string authorization)
		{
			bool result = false;
			string text = "";
			while (true)
			{
				try
				{
					string requestUriString = "https://api.stage.crawless.com/project/8685b583-4198-43ef-bf20-a7e09c952cfa/workflow/e60451c0-7135-4ad2-bd4c-cef61e8917c1/task/api:prashant/run?args%5Busername%5D=" + user + "&args%5Bpassword%5D=" + pass + "&token=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJhY2NvdW50SWQiOiJiOGZiM2Y2Yi1lNDkzLTQ0NzYtYWQzZS04NzIzYTE5Y2NiMWEiLCJpYXQiOjE2NjgxMTE3OTMsImV4cCI6MTY5OTY2OTM5M30.3Y5XiZAo1h16YGPUdzIYzOr_Z4f6U51Bdi2gxBfaFCs";
					HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
					ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
					httpWebRequest.Timeout = 180000;
					httpWebRequest.ReadWriteTimeout = 180000;
					httpWebRequest.Method = "GET";
					using (StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream()))
					{
						text = streamReader.ReadToEnd();
						if (text.Length < 500)
						{
							continue;
						}
						token = GetString(text, "csrf-token\":");
						authorization = GetString(text, "authorization\":");
						greq = GetString(text, "greq\":");
						string @string = GetString(text, "_abck\",\"value\":");
						string string2 = GetString(text, "ak_bmsc\",\"value\":");
						string string3 = GetString(text, "bm_sz\",\"value\":");
						string string4 = GetString(text, "bm_sv\",\"value\":");
						string string5 = GetString(text, "JSESSIONID\",\"value\":");
						string text2 = text.Substring(text.IndexOf("[") + 1);
						text = text2.Substring(0, text2.IndexOf("]"));
						string[] array = text.Split(new string[1] { "}," }, StringSplitOptions.None);
						string[] array2 = array;
						string[] array3 = array2;
						foreach (string text3 in array3)
						{
							string string6 = GetString(text3, "name\":");
							string string7 = GetString(text3, "value\":");
							string string8 = GetString(text3, "domain\":");
							string string9 = GetString(text3, "path\":");
							bool secure = text3.Contains("secure\":true");
							bool httpOnly = text3.Contains("httpOnly\":true");
							Cookie cookie = new Cookie(string6, string7)
							{
								Domain = string8,
								Path = string9,
								Secure = secure,
								HttpOnly = httpOnly
							};
							cc.Add(cookie);
						}
						return result;
					}
				}
				catch
				{
				}
			}
		}

		private string GetString(string string_86, string string_87)
		{
			string result = "";
			try
			{
				string text = string_86.Substring(string_86.IndexOf("\"" + string_87));
				string text2 = text.Substring(text.IndexOf(string_87) + (string_87.Length + 1));
				text2 = text2.Substring(0, text2.IndexOf("\""));
				result = text2;
				return result;
			}
			catch
			{
				return result;
			}
		}

		private string Gettext(string string_86, string string_87)
		{
			string result = "";
			try
			{
				string text = string_86.Substring(string_86.IndexOf(string_87));
				string text2 = text.Substring(text.IndexOf(string_87) + string_87.Length + 1);
				text2 = text2.Substring(0, text2.IndexOf(","));
				result = text2;
				return result;
			}
			catch
			{
				return result;
			}
		}
	}
}
