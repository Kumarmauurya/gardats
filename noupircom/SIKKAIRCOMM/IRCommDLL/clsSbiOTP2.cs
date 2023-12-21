using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web;
using Newtonsoft.Json;

namespace IRCommDLL
{
	internal class clsSbiOTP2
	{
		private class SbiUser
		{
			public static string SALT = "c8f4a4536cabfe8233d8d234d005d93e6a91702853cb2d93cb3c846e7ac6c322";

			public static string SECRET_KEY = "daf225199b408bdd641d8a8d4e8136c3900c37e1705853b9517a6393aab9b7eaccf1bc8763dabbcf08dd8af07c362774a9ccfe8494f7dcda8c6981d6950428f0";

			public static string MPIN_MAIN = "$652@!#*SaWeQ@";

			public static string APP_KEY_MAIN = "$*|@%$B!$E@u^#@A%!";

			public static string SERVER_HOST = "https://midentity.onlinesbi.com";

			public static int SERVER_PORT = 443;

			public static string KONY_APP_KEY = "aaee6accb1b00d19ddf0efb0f66a393";

			public static string KONY_APP_SECRET = "2f9b36d1f6f5c3e940cd940af1e59d4e";

			public static string KONY_SDK_VERSION = "SDK-GA-7.3.0.45";

			public static string KONY_PLATFORM = "android";

			public static string KONY_SDK_TYPE = "js";

			public static string KONY_API_VERSION = "1.0";

			public static string APP_ID = "OnlineOTP";

			public static string APP_NAME = "SBI Secure OTP";

			public static string APP_VERSION = "2.2.9";

			public static string CHANNEL = "rc";

			public static string CONFIG_APP_ID = "6200df4d-2986-4de4-bf3f-44973800fb0a";

			public static string CONFIG_BASE_ID = "06aaa59d-3531-4eb0-8be6-899fcf2554de";

			public static string CONFIG_APP_NAME = "SBISmartOTPChe";

			public static string KONY_RSID = "1666015648453-f86b-8242-a917";

			public static string PHONE_AUTHORIZATION = "+917304459011";

			public static string AUTH_SERVICE_PATH = "/authService/100000022/login";

			public static string FETCH_DATE_TIME_PATH = "/services1/SBISmartOTPCheService1/FetchDateTime";

			public static string SECURITY_SERVICE_PATH = "/services1/SBISmartOTPCheService1/SecurityService";

			public static string LOGIN_VALIDATE_PATH = "/services1/SBISmartOTPCheService1/LoginValidate";

			public static string ENABLE_HIGH_SECURITY_SERVICE_PATH = "/services1/SBISmartOTPCheService1/EnableHighSecurityService";

			public static string ENABLE_HIGH_SECURITY_CONFIRM_SERVICE_PATH = "/services1/SBISmartOTPCheService1/EnableHighSecurityConfirmService";

			public static string QUESTION_SUBMIT_SERVICE_PATH = "/services1/SBISmartOTPCheService1/QuestionSubmitService";

			public static string SMART_SEC_SERVICE_PATH = "/services1/SBISmartOTPCheService1/SmartSecService";

			public static string SECURITY_LOGIN_SERVICE_PATH = "/services1/SBISmartOTPCheService1/SecureLoginService";

			public static string FETCH_ONLINE_OTP_PATH = "/services1/SBISmartOTPCheService1/FetchOnlineOTP";

			public string androidId;

			public string phoneModel;

			public string userAgent;

			public string userId = "";

			public string osVersion;

			public string smsEncryptedText;

			public string username;

			public string password;

			public string mpinCode;

			public AuthServiceResponse authServiceResponse;

			public FetchDateTimeResponseBody dateTimeResponseBody;

			public SecurityServiceResponseBody securityServiceResponseBody;

			public LoginValidateResponseBody loginValidateResponseBody;

			public EnableHighSecurityServiceResponseBody enableHighSecurityServiceResponseBody;

			public EnableHighSecurityConfirmServiceResponseBody enableHighSecurityConfirmServiceResponseBody;

			public LoginValidateResponseBody loginValidateResponseBodyForSecureLogin;

			private CookieContainer cookieContainer = new CookieContainer();

			public bool isFiddlerProxyUseMust;

			public string ProxyHost;

			public int ProxyPort;

			public string ProxyUsername;

			public string ProxyPassword;

			public void authServiceRequest()
			{
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				string text = SERVER_HOST + AUTH_SERVICE_PATH;
				Console.WriteLine(text);
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
				httpWebRequest.CookieContainer = cookieContainer;
				if (isFiddlerProxyUseMust)
				{
					httpWebRequest.Proxy = new WebProxy("127.0.0.1", 8888);
				}
				else if (!string.IsNullOrEmpty(ProxyHost))
				{
					httpWebRequest.Proxy = new WebProxy($"{ProxyHost}:{ProxyPort}", true, null, new NetworkCredential(ProxyUsername, ProxyPassword));
				}
				httpWebRequest.Method = "POST";
				httpWebRequest.KeepAlive = true;
				httpWebRequest.UserAgent = userAgent;
				httpWebRequest.Headers.Add("Accept-Encoding", "gzip,deflate");
				httpWebRequest.ContentLength = 0L;
				httpWebRequest.ContentType = "application/x-www-form-urlencoded";
				httpWebRequest.Accept = "application/json";
				httpWebRequest.ServicePoint.Expect100Continue = true;
				httpWebRequest.ServicePoint.Expect100Continue = false;
				httpWebRequest.Headers["Cache-Control"] = "no-cache";
				httpWebRequest.Headers["X-Kony-SDK-Version"] = KONY_SDK_VERSION;
				httpWebRequest.Headers["X-Kony-App-Key"] = KONY_APP_KEY;
				httpWebRequest.Headers["X-Kony-App-Secret"] = KONY_APP_SECRET;
				httpWebRequest.Headers["X-Kony-Platform"] = KONY_PLATFORM;
				httpWebRequest.Headers["X-Kony-SDK-Type"] = KONY_SDK_TYPE;
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				Stream responseStream = httpWebResponse.GetResponseStream();
				string text2 = new StreamReader(responseStream).ReadToEnd();
				Console.WriteLine("Response for authServiceRequest request\n{0}", text2);
				responseStream.Close();
				if (httpWebResponse.StatusCode != HttpStatusCode.OK)
				{
					throw new IOException("Something wrong in vpaListRequest\n" + text2);
				}
				AuthServiceResponse authServiceResponse = JsonConvert.DeserializeObject<AuthServiceResponse>(text2);
				if (authServiceResponse.claims_token == null || authServiceResponse.claims_token.value == null || authServiceResponse.refresh_token == null)
				{
					throw new IOException("Something wrong in authServiceRequest request\n" + text2);
				}
				this.authServiceResponse = authServiceResponse;
			}

			public void fetchDateTimeRequest()
			{
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				string text = SERVER_HOST + FETCH_DATE_TIME_PATH;
				Console.WriteLine(text);
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("events", "[]");
				dictionary.Add("serviceID", "FetchDateTime");
				Header header = new Header();
				header.bankCode = "";
				header.token = "";
				header.userName = "";
				Console.WriteLine(JsonConvert.SerializeObject(header));
				dictionary.Add("header", Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(header))));
				BaseRequestBody baseRequestBody = new BaseRequestBody();
				baseRequestBody.body = new Body();
				baseRequestBody.security = new Security();
				baseRequestBody.security.appkey = "";
				baseRequestBody.security.mpin = "";
				baseRequestBody.security.token1 = "";
				baseRequestBody.security.token2 = "";
				Console.WriteLine(JsonConvert.SerializeObject(baseRequestBody));
				dictionary.Add("encData", SBISecureCrypt.EncryptEncData(JsonConvert.SerializeObject(baseRequestBody), "", MPIN_MAIN, APP_KEY_MAIN));
				dictionary.Add("requestKey", SBISecureCrypt.calcRequestKey(JsonConvert.SerializeObject(baseRequestBody)));
				dictionary.Add("appID", APP_ID);
				dictionary.Add("appver", APP_VERSION);
				dictionary.Add("channel", CHANNEL);
				dictionary.Add("platform", KONY_PLATFORM);
				dictionary.Add("cacheid", "");
				dictionary.Add("konyreportingparams", getKonyReportingParams("frmSimRegister", "FetchDateTime"));
				string formBody = getFormBody(dictionary);
				Console.WriteLine(formBody);
				byte[] bytes = Encoding.UTF8.GetBytes(formBody);
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
				httpWebRequest.CookieContainer = cookieContainer;
				if (isFiddlerProxyUseMust)
				{
					httpWebRequest.Proxy = new WebProxy("127.0.0.1", 8888);
				}
				else if (!string.IsNullOrEmpty(ProxyHost))
				{
					httpWebRequest.Proxy = new WebProxy($"{ProxyHost}:{ProxyPort}", true, null, new NetworkCredential(ProxyUsername, ProxyPassword));
				}
				httpWebRequest.Method = "POST";
				httpWebRequest.KeepAlive = true;
				httpWebRequest.UserAgent = userAgent;
				httpWebRequest.Headers.Add("Accept-Encoding", "gzip,deflate");
				httpWebRequest.ContentLength = bytes.Length;
				httpWebRequest.ContentType = "application/json";
				httpWebRequest.ServicePoint.Expect100Continue = true;
				httpWebRequest.Headers["Cache-Control"] = "no-cache";
				httpWebRequest.Headers["X-Kony-Authorizationn"] = authServiceResponse.claims_token.value;
				httpWebRequest.Headers["X-Kony-API-Version"] = KONY_API_VERSION;
				using (Stream stream = httpWebRequest.GetRequestStream())
				{
					stream.Write(bytes, 0, bytes.Length);
					stream.Close();
				}
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				Stream responseStream = httpWebResponse.GetResponseStream();
				string text2 = new StreamReader(responseStream).ReadToEnd();
				Console.WriteLine("Response for fetchDateTimeRequest request\n{0}", text2);
				responseStream.Close();
				if (httpWebResponse.StatusCode != HttpStatusCode.OK)
				{
					throw new IOException("Something wrong in fetchDateTimeRequest\n" + text2);
				}
				BaseResponseBody baseResponseBody = JsonConvert.DeserializeObject<BaseResponseBody>(text2);
				if (baseResponseBody.code != "null" || baseResponseBody.encData == null || baseResponseBody.status == null || baseResponseBody.httpStatusCode != 200)
				{
					throw new IOException("Something wrong in fetchDateTimeRequest request\n" + text2);
				}
				dateTimeResponseBody = JsonConvert.DeserializeObject<FetchDateTimeResponseBody>(SBISecureCrypt.DecryptResponseEncData(baseResponseBody.encData, "", MPIN_MAIN, APP_KEY_MAIN));
				Console.WriteLine(JsonConvert.SerializeObject(dateTimeResponseBody));
			}

			public string securityServiceRequest()
			{
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				string text = SERVER_HOST + SECURITY_SERVICE_PATH;
				Console.WriteLine(text);
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("events", "[]");
				dictionary.Add("serviceID", "SecurityService");
				dictionary.Add("optionalFlagFomUI", "false");
				Header header = new Header();
				header.bankCode = "";
				header.token = "";
				header.userName = "";
				Console.WriteLine(JsonConvert.SerializeObject(header));
				dictionary.Add("header", Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(header))));
				BaseRequestBody baseRequestBody = new BaseRequestBody();
				baseRequestBody.body = new Body();
				baseRequestBody.security = new Security();
				baseRequestBody.security.appkey = "";
				baseRequestBody.security.mpin = "";
				baseRequestBody.security.token1 = "";
				baseRequestBody.security.token2 = "";
				Console.WriteLine(JsonConvert.SerializeObject(baseRequestBody));
				dictionary.Add("encData", SBISecureCrypt.EncryptEncData(JsonConvert.SerializeObject(baseRequestBody), "", MPIN_MAIN, APP_KEY_MAIN));
				dictionary.Add("requestKey", SBISecureCrypt.calcRequestKey(JsonConvert.SerializeObject(baseRequestBody)));
				dictionary.Add("appID", APP_ID);
				dictionary.Add("appver", APP_VERSION);
				dictionary.Add("channel", CHANNEL);
				dictionary.Add("platform", KONY_PLATFORM);
				dictionary.Add("cacheid", "");
				dictionary.Add("konyreportingparams", getKonyReportingParams("frmRegister", "SecurityService"));
				string formBody = getFormBody(dictionary);
				Console.WriteLine(formBody);
				byte[] bytes = Encoding.UTF8.GetBytes(formBody);
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
				httpWebRequest.CookieContainer = cookieContainer;
				if (isFiddlerProxyUseMust)
				{
					httpWebRequest.Proxy = new WebProxy("127.0.0.1", 8888);
				}
				else if (!string.IsNullOrEmpty(ProxyHost))
				{
					httpWebRequest.Proxy = new WebProxy($"{ProxyHost}:{ProxyPort}", true, null, new NetworkCredential(ProxyUsername, ProxyPassword));
				}
				httpWebRequest.Method = "POST";
				httpWebRequest.KeepAlive = true;
				httpWebRequest.UserAgent = userAgent;
				httpWebRequest.Headers.Add("Accept-Encoding", "gzip,deflate");
				httpWebRequest.ContentLength = bytes.Length;
				httpWebRequest.ContentType = "application/json";
				httpWebRequest.ServicePoint.Expect100Continue = true;
				httpWebRequest.ServicePoint.Expect100Continue = false;
				httpWebRequest.Headers["Cache-Control"] = "no-cache";
				httpWebRequest.Headers["X-Kony-Authorizationn"] = authServiceResponse.claims_token.value;
				httpWebRequest.Headers["X-Kony-API-Version"] = KONY_API_VERSION;
				using (Stream stream = httpWebRequest.GetRequestStream())
				{
					stream.Write(bytes, 0, bytes.Length);
					stream.Close();
				}
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				Stream responseStream = httpWebResponse.GetResponseStream();
				string text2 = new StreamReader(responseStream).ReadToEnd();
				Console.WriteLine("Response for securityServiceRequest request\n{0}", text2);
				responseStream.Close();
				if (httpWebResponse.StatusCode != HttpStatusCode.OK)
				{
					throw new IOException("Something wrong in securityServiceRequest\n" + text2);
				}
				BaseResponseBody baseResponseBody = JsonConvert.DeserializeObject<BaseResponseBody>(text2);
				if (baseResponseBody.code != "null" || baseResponseBody.encData == null || baseResponseBody.status == null || baseResponseBody.httpStatusCode != 200)
				{
					throw new IOException("Something wrong in securityServiceRequest request\n" + text2);
				}
				securityServiceResponseBody = JsonConvert.DeserializeObject<SecurityServiceResponseBody>(SBISecureCrypt.DecryptResponseEncData(baseResponseBody.encData, "", MPIN_MAIN, APP_KEY_MAIN));
				Console.WriteLine(JsonConvert.SerializeObject(securityServiceResponseBody));
				return SBISecureCrypt.DecryptResponseEncData(baseResponseBody.encData, "", MPIN_MAIN, APP_KEY_MAIN);
			}

			public string loginValidateRequest()
			{
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				string text = "";
				string text2 = SERVER_HOST + LOGIN_VALIDATE_PATH;
				Console.WriteLine(text2);
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("events", "[]");
				dictionary.Add("serviceID", "LoginValidate");
				Header header = new Header();
				header.bankCode = "0";
				header.token = "";
				header.userName = username;
				Console.WriteLine(JsonConvert.SerializeObject(header));
				dictionary.Add("header", Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(header))));
				BaseRequestBody baseRequestBody = new BaseRequestBody();
				baseRequestBody.body = new Body();
				baseRequestBody.body.md5Password = SBISecureCrypt.md5Password(username, password, securityServiceResponseBody.keyId);
				baseRequestBody.body.shaPassword = SBISecureCrypt.shaPassword(username, password, securityServiceResponseBody.keyId);
				baseRequestBody.body.serviceId = securityServiceResponseBody.serviceId;
				baseRequestBody.body.deviceName = phoneModel;
				baseRequestBody.body.imeiNo = androidId;
				baseRequestBody.body.osName = KONY_PLATFORM;
				baseRequestBody.body.mobileAppVersion = APP_VERSION;
				baseRequestBody.body.oSversion = osVersion;
				baseRequestBody.body.encKeyValue = smsEncryptedText;
				baseRequestBody.body.currentDate = getIndiaDateTime().ToString("MM/dd/yyyy HH:mm:ss", CultureInfo.CreateSpecificCulture("en-US"));
				baseRequestBody.security = new Security();
				baseRequestBody.security.appkey = "";
				baseRequestBody.security.mpin = "";
				baseRequestBody.security.token1 = "";
				baseRequestBody.security.token2 = "";
				Console.WriteLine(JsonConvert.SerializeObject(baseRequestBody));
				dictionary.Add("encData", SBISecureCrypt.EncryptEncData(JsonConvert.SerializeObject(baseRequestBody), username, MPIN_MAIN, APP_KEY_MAIN));
				dictionary.Add("requestKey", SBISecureCrypt.calcRequestKey(JsonConvert.SerializeObject(baseRequestBody)));
				dictionary.Add("jSessionId", "");
				dictionary.Add("ipAddress", "");
				dictionary.Add("appID", APP_ID);
				dictionary.Add("appver", APP_VERSION);
				dictionary.Add("channel", CHANNEL);
				dictionary.Add("platform", KONY_PLATFORM);
				dictionary.Add("cacheid", "");
				dictionary.Add("konyreportingparams", getKonyReportingParams("frmRegister", "LoginValidate"));
				string formBody = getFormBody(dictionary);
				Console.WriteLine(formBody);
				byte[] bytes = Encoding.UTF8.GetBytes(formBody);
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text2);
				httpWebRequest.CookieContainer = cookieContainer;
				if (isFiddlerProxyUseMust)
				{
					httpWebRequest.Proxy = new WebProxy("127.0.0.1", 8888);
				}
				else if (!string.IsNullOrEmpty(ProxyHost))
				{
					httpWebRequest.Proxy = new WebProxy($"{ProxyHost}:{ProxyPort}", true, null, new NetworkCredential(ProxyUsername, ProxyPassword));
				}
				httpWebRequest.Method = "POST";
				httpWebRequest.KeepAlive = true;
				httpWebRequest.UserAgent = userAgent;
				httpWebRequest.Headers.Add("Accept-Encoding", "gzip,deflate");
				httpWebRequest.ContentLength = bytes.Length;
				httpWebRequest.ContentType = "application/json";
				httpWebRequest.ServicePoint.Expect100Continue = true;
				httpWebRequest.Headers["Cache-Control"] = "no-cache";
				httpWebRequest.Headers["X-Kony-Authorizationn"] = authServiceResponse.claims_token.value;
				httpWebRequest.Headers["X-Kony-API-Version"] = KONY_API_VERSION;
				using (Stream stream = httpWebRequest.GetRequestStream())
				{
					stream.Write(bytes, 0, bytes.Length);
					stream.Close();
				}
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				Stream responseStream = httpWebResponse.GetResponseStream();
				string text3 = new StreamReader(responseStream).ReadToEnd();
				Console.WriteLine("Response for loginValidateRequest request\n{0}", text3);
				responseStream.Close();
				if (httpWebResponse.StatusCode != HttpStatusCode.OK)
				{
					throw new IOException("Something wrong in loginValidateRequest\n" + text3);
				}
				BaseResponseBody baseResponseBody = JsonConvert.DeserializeObject<BaseResponseBody>(text3);
				if (baseResponseBody.code != "null" || baseResponseBody.encData == null || baseResponseBody.status == null || baseResponseBody.httpStatusCode != 200)
				{
					throw new IOException("Something wrong in loginValidateRequest request\n" + text3);
				}
				text = SBISecureCrypt.DecryptResponseEncData(baseResponseBody.encData, username, MPIN_MAIN, APP_KEY_MAIN);
				loginValidateResponseBody = JsonConvert.DeserializeObject<LoginValidateResponseBody>(SBISecureCrypt.DecryptResponseEncData(baseResponseBody.encData, username, MPIN_MAIN, APP_KEY_MAIN));
				Console.WriteLine(JsonConvert.SerializeObject(loginValidateResponseBody));
				return text;
			}

			public string enableHighSecurityServiceRequest()
			{
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				string text = "";
				string text2 = SERVER_HOST + ENABLE_HIGH_SECURITY_SERVICE_PATH;
				Console.WriteLine(text2);
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("events", "[]");
				dictionary.Add("serviceID", "EnableHighSecurityService");
				Header header = new Header();
				header.bankCode = "0";
				header.token = "";
				header.userName = username;
				Console.WriteLine(JsonConvert.SerializeObject(header));
				dictionary.Add("header", Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(header))));
				BaseRequestBody baseRequestBody = new BaseRequestBody();
				baseRequestBody.body = new Body();
				baseRequestBody.security = new Security();
				baseRequestBody.security.appkey = APP_KEY_MAIN;
				baseRequestBody.security.mpin = MPIN_MAIN;
				baseRequestBody.security.token1 = loginValidateResponseBody.jSessionId;
				baseRequestBody.security.token2 = loginValidateResponseBody.uId;
				Console.WriteLine(JsonConvert.SerializeObject(baseRequestBody));
				dictionary.Add("encData", SBISecureCrypt.EncryptEncData(JsonConvert.SerializeObject(baseRequestBody), username, MPIN_MAIN, APP_KEY_MAIN));
				dictionary.Add("requestKey", SBISecureCrypt.calcRequestKey(JsonConvert.SerializeObject(baseRequestBody)));
				dictionary.Add("appID", APP_ID);
				dictionary.Add("appver", APP_VERSION);
				dictionary.Add("channel", CHANNEL);
				dictionary.Add("platform", KONY_PLATFORM);
				dictionary.Add("cacheid", "");
				dictionary.Add("konyreportingparams", getKonyReportingParams("frmAgree", "EnableHighSecurityService"));
				string formBody = getFormBody(dictionary);
				Console.WriteLine(formBody);
				byte[] bytes = Encoding.UTF8.GetBytes(formBody);
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text2);
				httpWebRequest.CookieContainer = cookieContainer;
				if (isFiddlerProxyUseMust)
				{
					httpWebRequest.Proxy = new WebProxy("127.0.0.1", 8888);
				}
				else if (!string.IsNullOrEmpty(ProxyHost))
				{
					httpWebRequest.Proxy = new WebProxy($"{ProxyHost}:{ProxyPort}", true, null, new NetworkCredential(ProxyUsername, ProxyPassword));
				}
				httpWebRequest.Method = "POST";
				httpWebRequest.KeepAlive = true;
				httpWebRequest.UserAgent = userAgent;
				httpWebRequest.Headers.Add("Accept-Encoding", "gzip,deflate");
				httpWebRequest.ContentLength = bytes.Length;
				httpWebRequest.ContentType = "application/json";
				httpWebRequest.ServicePoint.Expect100Continue = true;
				httpWebRequest.Headers["Cache-Control"] = "no-cache";
				httpWebRequest.Headers["X-Kony-Authorizationn"] = authServiceResponse.claims_token.value;
				httpWebRequest.Headers["X-Kony-API-Version"] = KONY_API_VERSION;
				using (Stream stream = httpWebRequest.GetRequestStream())
				{
					stream.Write(bytes, 0, bytes.Length);
					stream.Close();
				}
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				Stream responseStream = httpWebResponse.GetResponseStream();
				string text3 = new StreamReader(responseStream).ReadToEnd();
				Console.WriteLine("Response for enableHighSecurityServiceRequest request\n{0}", text3);
				responseStream.Close();
				if (httpWebResponse.StatusCode != HttpStatusCode.OK)
				{
					throw new IOException("Something wrong in enableHighSecurityServiceRequest\n" + text3);
				}
				BaseResponseBody baseResponseBody = JsonConvert.DeserializeObject<BaseResponseBody>(text3);
				if (baseResponseBody.code != "null" || baseResponseBody.encData == null || baseResponseBody.status == null || baseResponseBody.httpStatusCode != 200)
				{
					throw new IOException("Something wrong in enableHighSecurityServiceRequest request\n" + text3);
				}
				enableHighSecurityServiceResponseBody = JsonConvert.DeserializeObject<EnableHighSecurityServiceResponseBody>(SBISecureCrypt.DecryptResponseEncData(baseResponseBody.encData, username, MPIN_MAIN, APP_KEY_MAIN));
				Console.WriteLine(JsonConvert.SerializeObject(enableHighSecurityServiceResponseBody));
				return SBISecureCrypt.DecryptResponseEncData(baseResponseBody.encData, username, MPIN_MAIN, APP_KEY_MAIN);
			}

			public void enableHighSecurityConfirmServiceRequest(string otpCode)
			{
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				string text = SERVER_HOST + ENABLE_HIGH_SECURITY_CONFIRM_SERVICE_PATH;
				Console.WriteLine(text);
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("events", "[]");
				dictionary.Add("serviceID", "EnableHighSecurityConfirmService");
				Header header = new Header();
				header.bankCode = "0";
				header.token = "";
				header.userName = username;
				Console.WriteLine(JsonConvert.SerializeObject(header));
				dictionary.Add("header", Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(header))));
				BaseRequestBody baseRequestBody = new BaseRequestBody();
				baseRequestBody.body = new Body();
				baseRequestBody.body.deviceId = androidId;
				baseRequestBody.body.otp = otpCode;
				baseRequestBody.security = new Security();
				baseRequestBody.security.appkey = APP_KEY_MAIN;
				baseRequestBody.security.mpin = MPIN_MAIN;
				baseRequestBody.security.token1 = loginValidateResponseBody.jSessionId;
				baseRequestBody.security.token2 = loginValidateResponseBody.uId;
				Console.WriteLine(JsonConvert.SerializeObject(baseRequestBody));
				dictionary.Add("encData", SBISecureCrypt.EncryptEncData(JsonConvert.SerializeObject(baseRequestBody), username, MPIN_MAIN, APP_KEY_MAIN));
				dictionary.Add("requestKey", SBISecureCrypt.calcRequestKey(JsonConvert.SerializeObject(baseRequestBody)));
				dictionary.Add("appID", APP_ID);
				dictionary.Add("appver", APP_VERSION);
				dictionary.Add("channel", CHANNEL);
				dictionary.Add("platform", KONY_PLATFORM);
				dictionary.Add("cacheid", "");
				dictionary.Add("konyreportingparams", getKonyReportingParams("frmOTPConfirm", "EnableHighSecurityConfirmService"));
				string formBody = getFormBody(dictionary);
				Console.WriteLine(formBody);
				byte[] bytes = Encoding.UTF8.GetBytes(formBody);
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
				httpWebRequest.CookieContainer = cookieContainer;
				if (isFiddlerProxyUseMust)
				{
					httpWebRequest.Proxy = new WebProxy("127.0.0.1", 8888);
				}
				else if (!string.IsNullOrEmpty(ProxyHost))
				{
					httpWebRequest.Proxy = new WebProxy($"{ProxyHost}:{ProxyPort}", true, null, new NetworkCredential(ProxyUsername, ProxyPassword));
				}
				httpWebRequest.Method = "POST";
				httpWebRequest.KeepAlive = true;
				httpWebRequest.UserAgent = userAgent;
				httpWebRequest.Headers.Add("Accept-Encoding", "gzip,deflate");
				httpWebRequest.ContentLength = bytes.Length;
				httpWebRequest.ContentType = "application/json";
				httpWebRequest.ServicePoint.Expect100Continue = true;
				httpWebRequest.Headers["Cache-Control"] = "no-cache";
				httpWebRequest.Headers["X-Kony-Authorizationn"] = authServiceResponse.claims_token.value;
				httpWebRequest.Headers["X-Kony-API-Version"] = KONY_API_VERSION;
				using (Stream stream = httpWebRequest.GetRequestStream())
				{
					stream.Write(bytes, 0, bytes.Length);
					stream.Close();
				}
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				Stream responseStream = httpWebResponse.GetResponseStream();
				string text2 = new StreamReader(responseStream).ReadToEnd();
				Console.WriteLine("Response for enableHighSecurityConfirmServiceRequest request\n{0}", text2);
				responseStream.Close();
				if (httpWebResponse.StatusCode != HttpStatusCode.OK)
				{
					throw new IOException("Something wrong in enableHighSecurityConfirmServiceRequest\n" + text2);
				}
				BaseResponseBody baseResponseBody = JsonConvert.DeserializeObject<BaseResponseBody>(text2);
				if (baseResponseBody.code != "null" || baseResponseBody.encData == null || baseResponseBody.status == null || baseResponseBody.httpStatusCode != 200)
				{
					throw new IOException("Something wrong in enableHighSecurityConfirmServiceRequest request\n" + text2);
				}
				enableHighSecurityConfirmServiceResponseBody = JsonConvert.DeserializeObject<EnableHighSecurityConfirmServiceResponseBody>(SBISecureCrypt.DecryptResponseEncData(baseResponseBody.encData, username, MPIN_MAIN, APP_KEY_MAIN));
				Console.WriteLine(JsonConvert.SerializeObject(enableHighSecurityConfirmServiceResponseBody));
			}

			public string questionSubmitServiceRequest(string mpinCode)
			{
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				string text = "";
				this.mpinCode = mpinCode;
				string text2 = SERVER_HOST + QUESTION_SUBMIT_SERVICE_PATH;
				Console.WriteLine(text2);
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("events", "[]");
				dictionary.Add("serviceID", "QuestionSubmitService");
				Header header = new Header();
				header.bankCode = "0";
				header.token = "";
				header.userName = username;
				Console.WriteLine(JsonConvert.SerializeObject(header));
				dictionary.Add("header", Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(header))));
				BaseRequestBody baseRequestBody = new BaseRequestBody();
				baseRequestBody.body = new Body();
				baseRequestBody.body.deviceId = androidId;
				baseRequestBody.body.answer = "andanswers";
				baseRequestBody.body.question = "stop sending questions";
				baseRequestBody.body.shaMpin = SBISecureCrypt.shaMpinSet(username, mpinCode);
				baseRequestBody.body.securityKey = enableHighSecurityConfirmServiceResponseBody.securityKey;
				baseRequestBody.security = new Security();
				baseRequestBody.security.appkey = enableHighSecurityConfirmServiceResponseBody.securityKey;
				baseRequestBody.security.mpin = androidId;
				baseRequestBody.security.token1 = loginValidateResponseBody.jSessionId;
				baseRequestBody.security.token2 = loginValidateResponseBody.uId;
				Console.WriteLine(JsonConvert.SerializeObject(baseRequestBody));
				dictionary.Add("encData", SBISecureCrypt.EncryptEncData(JsonConvert.SerializeObject(baseRequestBody), username, androidId, enableHighSecurityConfirmServiceResponseBody.mobAppKey));
				dictionary.Add("requestKey", SBISecureCrypt.calcRequestKey(JsonConvert.SerializeObject(baseRequestBody)));
				dictionary.Add("appID", APP_ID);
				dictionary.Add("appver", APP_VERSION);
				dictionary.Add("channel", CHANNEL);
				dictionary.Add("platform", KONY_PLATFORM);
				dictionary.Add("cacheid", "");
				dictionary.Add("konyreportingparams", getKonyReportingParams("frmSetPINNew", "QuestionSubmitService"));
				string formBody = getFormBody(dictionary);
				Console.WriteLine(formBody);
				byte[] bytes = Encoding.UTF8.GetBytes(formBody);
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text2);
				httpWebRequest.CookieContainer = cookieContainer;
				if (isFiddlerProxyUseMust)
				{
					httpWebRequest.Proxy = new WebProxy("127.0.0.1", 8888);
				}
				else if (!string.IsNullOrEmpty(ProxyHost))
				{
					httpWebRequest.Proxy = new WebProxy($"{ProxyHost}:{ProxyPort}", true, null, new NetworkCredential(ProxyUsername, ProxyPassword));
				}
				httpWebRequest.Method = "POST";
				httpWebRequest.KeepAlive = true;
				httpWebRequest.UserAgent = userAgent;
				httpWebRequest.Headers.Add("Accept-Encoding", "gzip,deflate");
				httpWebRequest.ContentLength = bytes.Length;
				httpWebRequest.ContentType = "application/json";
				httpWebRequest.ServicePoint.Expect100Continue = true;
				httpWebRequest.Headers["Cache-Control"] = "no-cache";
				httpWebRequest.Headers["X-Kony-Authorizationn"] = authServiceResponse.claims_token.value;
				httpWebRequest.Headers["X-Kony-API-Version"] = KONY_API_VERSION;
				using (Stream stream = httpWebRequest.GetRequestStream())
				{
					stream.Write(bytes, 0, bytes.Length);
					stream.Close();
				}
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				Stream responseStream = httpWebResponse.GetResponseStream();
				string text3 = new StreamReader(responseStream).ReadToEnd();
				Console.WriteLine("Response for questionSubmitServiceRequest request\n{0}", text3);
				responseStream.Close();
				if (httpWebResponse.StatusCode != HttpStatusCode.OK)
				{
					throw new IOException("Something wrong in questionSubmitServiceRequest\n" + text3);
				}
				BaseResponseBody baseResponseBody = JsonConvert.DeserializeObject<BaseResponseBody>(text3);
				if (baseResponseBody.code != "null" || baseResponseBody.encData == null || baseResponseBody.status == null || baseResponseBody.httpStatusCode != 200)
				{
					throw new IOException("Something wrong in questionSubmitServiceRequest request\n" + text3);
				}
				text = SBISecureCrypt.DecryptResponseEncData(baseResponseBody.encData, username, androidId, enableHighSecurityConfirmServiceResponseBody.mobAppKey);
				QuestionSubmitServiceResponseBody questionSubmitServiceResponseBody = JsonConvert.DeserializeObject<QuestionSubmitServiceResponseBody>(text);
				if (questionSubmitServiceResponseBody == null || !questionSubmitServiceResponseBody.status.Equals("success"))
				{
					throw new IOException("Something wrong in questionSubmitServiceRequest request\n" + text3);
				}
				return text;
			}

			public void smartSecServiceRequest()
			{
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				string text = SERVER_HOST + SMART_SEC_SERVICE_PATH;
				Console.WriteLine(text);
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("events", "[]");
				dictionary.Add("serviceID", "SmartSecService");
				dictionary.Add("optionalFlagFomUI", "false");
				Header header = new Header();
				header.bankCode = "";
				header.token = "";
				header.userName = "";
				Console.WriteLine(JsonConvert.SerializeObject(header));
				dictionary.Add("header", Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(header))));
				BaseRequestBody baseRequestBody = new BaseRequestBody();
				baseRequestBody.body = new Body();
				baseRequestBody.security = new Security();
				baseRequestBody.security.appkey = "";
				baseRequestBody.security.mpin = "";
				baseRequestBody.security.token1 = "";
				baseRequestBody.security.token2 = "";
				Console.WriteLine(JsonConvert.SerializeObject(baseRequestBody));
				dictionary.Add("encData", SBISecureCrypt.EncryptEncData(JsonConvert.SerializeObject(baseRequestBody), "", MPIN_MAIN, APP_KEY_MAIN));
				dictionary.Add("requestKey", SBISecureCrypt.calcRequestKey(JsonConvert.SerializeObject(baseRequestBody)));
				dictionary.Add("appID", APP_ID);
				dictionary.Add("appver", APP_VERSION);
				dictionary.Add("channel", CHANNEL);
				dictionary.Add("platform", KONY_PLATFORM);
				dictionary.Add("cacheid", "");
				dictionary.Add("konyreportingparams", getKonyReportingParams("frmLoginWithMPin", "SmartSecService"));
				string formBody = getFormBody(dictionary);
				Console.WriteLine(formBody);
				byte[] bytes = Encoding.UTF8.GetBytes(formBody);
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
				httpWebRequest.CookieContainer = cookieContainer;
				if (isFiddlerProxyUseMust)
				{
					httpWebRequest.Proxy = new WebProxy("127.0.0.1", 8888);
				}
				else if (!string.IsNullOrEmpty(ProxyHost))
				{
					httpWebRequest.Proxy = new WebProxy($"{ProxyHost}:{ProxyPort}", true, null, new NetworkCredential(ProxyUsername, ProxyPassword));
				}
				httpWebRequest.Method = "POST";
				httpWebRequest.KeepAlive = true;
				httpWebRequest.UserAgent = userAgent;
				httpWebRequest.Headers.Add("Accept-Encoding", "gzip,deflate");
				httpWebRequest.ContentLength = bytes.Length;
				httpWebRequest.ContentType = "application/json";
				httpWebRequest.ServicePoint.Expect100Continue = true;
				httpWebRequest.Headers["Cache-Control"] = "no-cache";
				httpWebRequest.Headers["X-Kony-Authorizationn"] = authServiceResponse.claims_token.value;
				httpWebRequest.Headers["X-Kony-API-Version"] = KONY_API_VERSION;
				using (Stream stream = httpWebRequest.GetRequestStream())
				{
					stream.Write(bytes, 0, bytes.Length);
					stream.Close();
				}
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				Stream responseStream = httpWebResponse.GetResponseStream();
				string text2 = new StreamReader(responseStream).ReadToEnd();
				Console.WriteLine("Response for smartSecServiceRequest request\n{0}", text2);
				responseStream.Close();
				if (httpWebResponse.StatusCode != HttpStatusCode.OK)
				{
					throw new IOException("Something wrong in smartSecServiceRequest\n" + text2);
				}
				BaseResponseBody baseResponseBody = JsonConvert.DeserializeObject<BaseResponseBody>(text2);
				if (baseResponseBody.code != "null" || baseResponseBody.encData == null || baseResponseBody.status == null || baseResponseBody.httpStatusCode != 200)
				{
					throw new IOException("Something wrong in smartSecServiceRequest request\n" + text2);
				}
				securityServiceResponseBody = JsonConvert.DeserializeObject<SecurityServiceResponseBody>(SBISecureCrypt.DecryptResponseEncData(baseResponseBody.encData, "", MPIN_MAIN, APP_KEY_MAIN));
				Console.WriteLine(JsonConvert.SerializeObject(securityServiceResponseBody));
			}

			public void secureLoginServiceRequest()
			{
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				string text = SERVER_HOST + SECURITY_LOGIN_SERVICE_PATH;
				Console.WriteLine(text);
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("events", "[]");
				dictionary.Add("serviceID", "SecureLoginService");
				Header header = new Header();
				header.bankCode = "0";
				header.token = "";
				header.userName = username;
				Console.WriteLine(JsonConvert.SerializeObject(header));
				dictionary.Add("header", Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(header))));
				BaseRequestBody baseRequestBody = new BaseRequestBody();
				baseRequestBody.body = new Body();
				baseRequestBody.body.secretKey = enableHighSecurityConfirmServiceResponseBody.securityKey;
				baseRequestBody.body.shaMpin = SBISecureCrypt.shaMpin(username, mpinCode, securityServiceResponseBody.keyId);
				baseRequestBody.body.serviceId = securityServiceResponseBody.serviceId;
				baseRequestBody.body.deviceName = phoneModel;
				baseRequestBody.body.imeiNo = androidId;
				baseRequestBody.body.osName = KONY_PLATFORM;
				baseRequestBody.body.mobileAppVersion = APP_VERSION;
				baseRequestBody.body.oSversion = osVersion;
				baseRequestBody.security = new Security();
				baseRequestBody.security.appkey = "";
				baseRequestBody.security.mpin = "";
				baseRequestBody.security.token1 = "";
				baseRequestBody.security.token2 = "";
				Console.WriteLine(JsonConvert.SerializeObject(baseRequestBody));
				dictionary.Add("encData", SBISecureCrypt.EncryptEncData(JsonConvert.SerializeObject(baseRequestBody), username, androidId, enableHighSecurityConfirmServiceResponseBody.mobAppKey));
				dictionary.Add("requestKey", SBISecureCrypt.calcRequestKey(JsonConvert.SerializeObject(baseRequestBody)));
				dictionary.Add("jSessionId", loginValidateResponseBody.jSessionId);
				dictionary.Add("ipAddress", "");
				dictionary.Add("appID", APP_ID);
				dictionary.Add("appver", APP_VERSION);
				dictionary.Add("channel", CHANNEL);
				dictionary.Add("platform", KONY_PLATFORM);
				dictionary.Add("cacheid", "");
				dictionary.Add("konyreportingparams", getKonyReportingParams("frmLoginWithMPin", "SecureLoginService"));
				string formBody = getFormBody(dictionary);
				Console.WriteLine(formBody);
				byte[] bytes = Encoding.UTF8.GetBytes(formBody);
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
				httpWebRequest.CookieContainer = cookieContainer;
				if (isFiddlerProxyUseMust)
				{
					httpWebRequest.Proxy = new WebProxy("127.0.0.1", 8888);
				}
				else if (!string.IsNullOrEmpty(ProxyHost))
				{
					httpWebRequest.Proxy = new WebProxy($"{ProxyHost}:{ProxyPort}", true, null, new NetworkCredential(ProxyUsername, ProxyPassword));
				}
				httpWebRequest.Method = "POST";
				httpWebRequest.KeepAlive = true;
				httpWebRequest.UserAgent = userAgent;
				httpWebRequest.Headers.Add("Accept-Encoding", "gzip,deflate");
				httpWebRequest.ContentLength = bytes.Length;
				httpWebRequest.ContentType = "application/json";
				httpWebRequest.ServicePoint.Expect100Continue = true;
				httpWebRequest.ServicePoint.Expect100Continue = false;
				httpWebRequest.Headers["Cache-Control"] = "no-cache";
				httpWebRequest.Headers["X-Kony-Authorizationn"] = authServiceResponse.claims_token.value;
				httpWebRequest.Headers["X-Kony-API-Version"] = KONY_API_VERSION;
				using (Stream stream = httpWebRequest.GetRequestStream())
				{
					stream.Write(bytes, 0, bytes.Length);
					stream.Close();
				}
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				Stream responseStream = httpWebResponse.GetResponseStream();
				string text2 = new StreamReader(responseStream).ReadToEnd();
				Console.WriteLine("Response for secureLoginServiceRequest request\n{0}", text2);
				responseStream.Close();
				if (httpWebResponse.StatusCode != HttpStatusCode.OK)
				{
					throw new IOException("Something wrong in secureLoginServiceRequest\n" + text2);
				}
				BaseResponseBody baseResponseBody = JsonConvert.DeserializeObject<BaseResponseBody>(text2);
				if (baseResponseBody.code != "null" || baseResponseBody.encData == null || baseResponseBody.status == null || baseResponseBody.httpStatusCode != 200)
				{
					throw new IOException("Something wrong in secureLoginServiceRequest request\n" + text2);
				}
				loginValidateResponseBodyForSecureLogin = JsonConvert.DeserializeObject<LoginValidateResponseBody>(SBISecureCrypt.DecryptResponseEncData(baseResponseBody.encData, username, androidId, enableHighSecurityConfirmServiceResponseBody.mobAppKey));
				Console.WriteLine(JsonConvert.SerializeObject(loginValidateResponseBodyForSecureLogin));
				if (loginValidateResponseBodyForSecureLogin.status)
				{
					loginValidateResponseBody.jSessionId = loginValidateResponseBodyForSecureLogin.jSessionId;
					loginValidateResponseBody.uId = loginValidateResponseBodyForSecureLogin.uId;
				}
			}

			public string fetchOnlineOTPRequest()
			{
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				string text = SERVER_HOST + FETCH_ONLINE_OTP_PATH;
				Console.WriteLine(text);
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("events", "[]");
				dictionary.Add("serviceID", "FetchOnlineOTP");
				Header header = new Header();
				header.bankCode = "0";
				header.token = "";
				header.userName = username;
				Console.WriteLine(JsonConvert.SerializeObject(header));
				dictionary.Add("header", Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(header))));
				BaseRequestBody baseRequestBody = new BaseRequestBody();
				baseRequestBody.body = new Body();
				baseRequestBody.body.secretKey = enableHighSecurityConfirmServiceResponseBody.securityKey;
				baseRequestBody.security = new Security();
				baseRequestBody.security.appkey = enableHighSecurityConfirmServiceResponseBody.mobAppKey;
				baseRequestBody.security.mpin = androidId;
				baseRequestBody.security.token1 = loginValidateResponseBody.jSessionId;
				baseRequestBody.security.token2 = loginValidateResponseBody.uId;
				Console.WriteLine(JsonConvert.SerializeObject(baseRequestBody));
				dictionary.Add("encData", SBISecureCrypt.EncryptEncData(JsonConvert.SerializeObject(baseRequestBody), username, androidId, enableHighSecurityConfirmServiceResponseBody.mobAppKey));
				dictionary.Add("requestKey", SBISecureCrypt.calcRequestKey(JsonConvert.SerializeObject(baseRequestBody)));
				dictionary.Add("appID", APP_ID);
				dictionary.Add("appver", APP_VERSION);
				dictionary.Add("channel", CHANNEL);
				dictionary.Add("platform", KONY_PLATFORM);
				dictionary.Add("cacheid", "");
				dictionary.Add("konyreportingparams", getKonyReportingParams("frmLandingPageNew", "FetchOnlineOTP"));
				string formBody = getFormBody(dictionary);
				Console.WriteLine(formBody);
				byte[] bytes = Encoding.UTF8.GetBytes(formBody);
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
				httpWebRequest.CookieContainer = cookieContainer;
				if (isFiddlerProxyUseMust)
				{
					httpWebRequest.Proxy = new WebProxy("127.0.0.1", 8888);
				}
				else if (!string.IsNullOrEmpty(ProxyHost))
				{
					httpWebRequest.Proxy = new WebProxy($"{ProxyHost}:{ProxyPort}", true, null, new NetworkCredential(ProxyUsername, ProxyPassword));
				}
				httpWebRequest.Method = "POST";
				httpWebRequest.KeepAlive = true;
				httpWebRequest.UserAgent = userAgent;
				httpWebRequest.Headers.Add("Accept-Encoding", "gzip,deflate");
				httpWebRequest.ContentLength = bytes.Length;
				httpWebRequest.ContentType = "application/json";
				httpWebRequest.ServicePoint.Expect100Continue = true;
				httpWebRequest.Headers["Cache-Control"] = "no-cache";
				httpWebRequest.Headers["X-Kony-Authorizationn"] = authServiceResponse.claims_token.value;
				httpWebRequest.Headers["X-Kony-API-Version"] = KONY_API_VERSION;
				using (Stream stream = httpWebRequest.GetRequestStream())
				{
					stream.Write(bytes, 0, bytes.Length);
					stream.Close();
				}
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				Stream responseStream = httpWebResponse.GetResponseStream();
				string text2 = new StreamReader(responseStream).ReadToEnd();
				Console.WriteLine("Response for fetchOnlineOTPRequest request\n{0}", text2);
				responseStream.Close();
				if (httpWebResponse.StatusCode != HttpStatusCode.OK)
				{
					throw new IOException("Something wrong in fetchOnlineOTPRequest\n" + text2);
				}
				BaseResponseBody baseResponseBody = JsonConvert.DeserializeObject<BaseResponseBody>(text2);
				if (baseResponseBody.code != "null" || baseResponseBody.encData == null || baseResponseBody.status == null || baseResponseBody.httpStatusCode != 200)
				{
					throw new IOException("Something wrong in fetchOnlineOTPRequest request\n" + text2);
				}
				return SBISecureCrypt.DecryptResponseEncData(baseResponseBody.encData, username, androidId, enableHighSecurityConfirmServiceResponseBody.mobAppKey);
			}

			private DateTime getIndiaDateTime()
			{
				DateTime dateTime = DateTime.Now.ToUniversalTime();
				TimeZoneInfo destinationTimeZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
				return TimeZoneInfo.ConvertTimeFromUtc(dateTime, destinationTimeZone);
			}

			private string getKonyReportingParams(string form, string serviceId)
			{
				ReportParams reportParams = new ReportParams();
				reportParams.os = osVersion;
				reportParams.dm = phoneModel;
				reportParams.did = androidId;
				reportParams.ua = phoneModel;
				reportParams.aid = APP_ID;
				reportParams.aname = APP_NAME;
				reportParams.chnl = "mobile";
				reportParams.plat = KONY_PLATFORM;
				reportParams.aver = APP_VERSION;
				reportParams.atype = "native";
				reportParams.stype = "b2c";
				reportParams.kuid = "";
				reportParams.mfaid = CONFIG_APP_ID;
				reportParams.mfbaseid = CONFIG_BASE_ID;
				reportParams.mfaname = CONFIG_APP_NAME;
				reportParams.sdkversion = KONY_SDK_VERSION;
				reportParams.sdktype = KONY_SDK_TYPE;
				reportParams.fid = form;
				reportParams.rsid = KONY_RSID;
				reportParams.svcid = serviceId;
				string text = JsonConvert.SerializeObject(reportParams);
				Console.WriteLine(text);
				return text;
			}

			private string getFormBody(Dictionary<string, string> map)
			{
				StringBuilder stringBuilder = new StringBuilder();
				foreach (KeyValuePair<string, string> item in map)
				{
					stringBuilder.Append(SBISecureCrypt.UpperCaseUrlEncode(item.Key, Encoding.UTF8)).Append("=").Append(SBISecureCrypt.UpperCaseUrlEncode(item.Value, Encoding.UTF8))
						.Append("&");
				}
				return stringBuilder.Remove(stringBuilder.Length - 1, 1).ToString();
			}

			public static void saveUserInFile(string pathToFile, SbiUser user)
			{
				string contents = JsonConvert.SerializeObject(user, Formatting.Indented);
				File.WriteAllText(pathToFile, contents);
			}

			public static SbiUser createUserFromFile(string pathToFile)
			{
				string value = File.ReadAllText(pathToFile);
				return JsonConvert.DeserializeObject<SbiUser>(value);
			}
		}

		private class SBISecureCrypt
		{
			public static string EncryptEncData(string plnData, string userId, string mpin, string appKey)
			{
				byte[] plainTextBytes = EncryptAESCBC(plnData, HexStrToBytes(GetKey(mpin, appKey)), HexStrToBytes(GetIV(userId, mpin)));
				return Base64Encode(plainTextBytes, false);
			}

			public static string DecryptRequestEncData(string encData, string userId, string mpin, string appKey)
			{
				byte[] encTextBytes = Base64Decode(HttpUtility.UrlDecode(encData));
				byte[] bytes = DecryptAESCBC(encTextBytes, HexStrToBytes(GetKey(mpin, appKey)), HexStrToBytes(GetIV(userId, mpin)));
				return Encoding.UTF8.GetString(bytes);
			}

			public static string DecryptResponseEncData(string encData, string userId, string mpin, string appKey)
			{
				byte[] encTextBytes = Base64Decode(encData);
				byte[] bytes = DecryptAESCBC(encTextBytes, HexStrToBytes(GetKey(mpin, appKey)), HexStrToBytes(GetIV(userId, mpin)));
				string @string = Encoding.UTF8.GetString(bytes);
				Console.WriteLine(@string);
				return @string;
			}

			internal static string GetKey(string mpin, string appKey)
			{
				return SHA256(mpin + appKey).ToUpper();
			}

			internal static string GetIV(string userId, string mpin)
			{
				string input = Reverse(FormatUserId(userId)) + Reverse(mpin);
				return SHA256(input).Substring(0, 32).ToUpper();
			}

			public static string Reverse(string s)
			{
				char[] array = s.ToCharArray();
				Array.Reverse(array);
				return new string(array);
			}

			internal static string FormatUserId(string userId)
			{
				return (userId + userId).Substring(0, (userId.Length >= 5) ? 10 : (userId.Length * 2));
			}

			private static string SHA256(string input)
			{
				HashAlgorithm hashAlgorithm = HashAlgorithm.Create("SHA-256");
				byte[] bytes = Encoding.UTF8.GetBytes(input);
				byte[] bArr = hashAlgorithm.ComputeHash(bytes);
				return BytesToHexStr(bArr);
			}

			public static string calcRequestKey(string postBody)
			{
				return SHA256(postBody + "#" + SbiUser.SALT);
			}

			private static string MD5(string input)
			{
				HashAlgorithm hashAlgorithm = HashAlgorithm.Create("MD5");
				byte[] bytes = Encoding.UTF8.GetBytes(input);
				byte[] bArr = hashAlgorithm.ComputeHash(bytes);
				return BytesToHexStr(bArr);
			}

			public static string SHA512(string input)
			{
				HashAlgorithm hashAlgorithm = HashAlgorithm.Create("SHA-512");
				byte[] bytes = Encoding.UTF8.GetBytes(input);
				byte[] bArr = hashAlgorithm.ComputeHash(bytes);
				return BytesToHexStr(bArr);
			}

			internal static byte[] EncryptAESCBC(string plainText, byte[] aesKeyBytes, byte[] ivBytes)
			{
				byte[] bytes = Encoding.UTF8.GetBytes(plainText);
				RijndaelManaged cBCRijndaelManaged = GetCBCRijndaelManaged(aesKeyBytes, ivBytes);
				return cBCRijndaelManaged.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length);
			}

			internal static byte[] DecryptAESCBC(byte[] encTextBytes, byte[] aesKeyBytes, byte[] ivBytes)
			{
				RijndaelManaged cBCRijndaelManaged = GetCBCRijndaelManaged(aesKeyBytes, ivBytes);
				return cBCRijndaelManaged.CreateDecryptor().TransformFinalBlock(encTextBytes, 0, encTextBytes.Length);
			}

			public static RijndaelManaged GetCBCRijndaelManaged(byte[] secretKeyBytes, byte[] ivBytes)
			{
				return new RijndaelManaged
				{
					Mode = CipherMode.CBC,
					Padding = PaddingMode.PKCS7,
					KeySize = 256,
					BlockSize = 128,
					Key = secretKeyBytes,
					IV = ivBytes
				};
			}

			public static string UpperCaseUrlEncode(string s, Encoding encoding)
			{
				char[] array = HttpUtility.UrlEncode(s, encoding).ToCharArray();
				for (int i = 0; i < array.Length - 2; i++)
				{
					if (array[i] == '%')
					{
						array[i + 1] = char.ToUpper(array[i + 1]);
						array[i + 2] = char.ToUpper(array[i + 2]);
					}
				}
				return new string(array);
			}

			public static string ConvertStringToHexString(string text)
			{
				byte[] bytes = Encoding.UTF8.GetBytes(text);
				StringBuilder stringBuilder = new StringBuilder();
				byte[] array = bytes;
				byte[] array2 = array;
				foreach (byte b in array2)
				{
					stringBuilder.Append(b.ToString("x"));
				}
				return stringBuilder.ToString();
			}

			public static string BytesToHexStr(byte[] bArr)
			{
				if (bArr == null)
				{
					return null;
				}
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < bArr.Length; i++)
				{
					stringBuilder.Append($"{bArr[i]:x2}");
				}
				return stringBuilder.ToString();
			}

			public static byte[] HexStrToBytes(string text)
			{
				byte[] array = new byte[text.Length / 2];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = byte.Parse(text.Substring(i * 2, 2), NumberStyles.HexNumber);
				}
				return array;
			}

			public static string Base64Encode(string plainText, bool isUrlSafe)
			{
				byte[] bytes = Encoding.UTF8.GetBytes(plainText);
				string text = Convert.ToBase64String(bytes);
				if (isUrlSafe)
				{
					text = text.Replace('+', '-').Replace('/', '_');
				}
				return text;
			}

			public static string Base64Encode(byte[] plainTextBytes, bool isUrlSafe)
			{
				string text = Convert.ToBase64String(plainTextBytes);
				if (isUrlSafe)
				{
					text = text.Replace('+', '-').Replace('/', '_');
				}
				return text;
			}

			public static byte[] Base64Decode(string base64EncodedData)
			{
				return Convert.FromBase64String(base64EncodedData);
			}

			public static string md5Password(string username, string password, string keyId)
			{
				string input = username + "#" + password;
				string text = MD5(input);
				string input2 = text + "#" + keyId;
				return MD5(input2);
			}

			public static string shaPassword(string username, string password, string keyId)
			{
				string input = username + "#" + password;
				string text = SHA512(input);
				string input2 = text + "#" + keyId;
				return SHA512(input2);
			}

			public static string shaMpin(string username, string mPin, string keyId)
			{
				string input = username + "~" + mPin;
				string text = SHA512(input);
				string input2 = text + "#" + keyId;
				return SHA512(input2);
			}

			public static string shaMpinSet(string username, string mPin)
			{
				string input = username + "~" + mPin;
				return SHA512(input);
			}
		}

		public class AuthServiceResponse
		{
			public Claims_Token claims_token { get; set; }

			public string refresh_token { get; set; }
		}

		[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
		public class Claims_Token
		{
			public string value { get; set; }

			public long exp { get; set; }
		}

		[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
		public class BaseRequestBody
		{
			public Body body { get; set; }

			public Security security { get; set; }
		}

		[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
		public class Body
		{
			public string md5Password { get; set; }

			public string shaPassword { get; set; }

			public string serviceId { get; set; }

			public string deviceName { get; set; }

			public string imeiNo { get; set; }

			public string osName { get; set; }

			public string mobileAppVersion { get; set; }

			public string oSversion { get; set; }

			public string encKeyValue { get; set; }

			public string currentDate { get; set; }

			public string deviceId { get; set; }

			public string otp { get; set; }

			public string secretKey { get; set; }

			public string shaMpin { get; set; }

			public string securityKey { get; set; }

			public string answer { get; set; }

			public string question { get; set; }
		}

		[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
		public class Security
		{
			public string appkey { get; set; }

			public string mpin { get; set; }

			public string token1 { get; set; }

			public string token2 { get; set; }
		}

		public class BaseResponseBody
		{
			public string code { get; set; }

			public string encData { get; set; }

			public int opstatus { get; set; }

			public string status { get; set; }

			public int httpStatusCode { get; set; }
		}

		public class EnableHighSecurityConfirmServiceResponseBody
		{
			public string uId { get; set; }

			public string jSessionId { get; set; }

			public bool isValidOTP { get; set; }

			public string securityKey { get; set; }

			public string mobAppKey { get; set; }
		}

		public class EnableHighSecurityServiceResponseBody
		{
			public string uId { get; set; }

			public string jSessionId { get; set; }

			public bool isSecureUser { get; set; }

			public string status { get; set; }
		}

		public class FetchDateTimeResponseBody
		{
			public string currentDate { get; set; }
		}

		public class Header
		{
			public string userName { get; set; }

			public string bankCode { get; set; }

			public string token { get; set; }
		}

		public class LoginValidateResponseBody
		{
			public string uId { get; set; }

			public string jSessionId { get; set; }

			public string displayName { get; set; }

			public string systemDate { get; set; }

			public string errorCode { get; set; }

			public string keyId { get; set; }

			public object promoMessage { get; set; }

			public string lastLoginDate { get; set; }

			public string serviceId { get; set; }

			public string userName { get; set; }

			public bool status { get; set; }
		}

		public class QuestionSubmitServiceResponseBody
		{
			public string errorCode { get; set; }

			public string maxUserCount { get; set; }

			public string userType { get; set; }

			public string errorMsg { get; set; }

			public string status { get; set; }
		}

		public class ReportParams
		{
			public string os { get; set; }

			public string dm { get; set; }

			public string did { get; set; }

			public string ua { get; set; }

			public string aid { get; set; }

			public string aname { get; set; }

			public string chnl { get; set; }

			public string plat { get; set; }

			public string aver { get; set; }

			public string atype { get; set; }

			public string stype { get; set; }

			public string kuid { get; set; }

			public string mfaid { get; set; }

			public string mfbaseid { get; set; }

			public string mfaname { get; set; }

			public string sdkversion { get; set; }

			public string sdktype { get; set; }

			public string fid { get; set; }

			public string rsid { get; set; }

			public string svcid { get; set; }
		}

		public class SecurityServiceResponseBody
		{
			public string keyId { get; set; }

			public string serviceId { get; set; }
		}

		public static bool seassion;

		private SbiUser SbiUser0;

		internal void start()
		{
		}

		internal string GetOTP(string user)
		{
			string result = "";
			try
			{
				string[] array = user.Split(new string[1] { "||" }, StringSplitOptions.None);
				string text = array[0].Trim();
				string text2 = "./SBI";
				string text3 = "SBI_" + text;
				string text4 = text2 + "\\" + text3 + ".rg";
				if (File.Exists(text4))
				{
					if (!seassion)
					{
						SbiUser0 = new SbiUser();
						SbiUser0 = SbiUser.createUserFromFile(text4);
					}
					if (SbiUser0.authServiceResponse.claims_token.exp < DateTimeOffset.Now.ToUnixTimeMilliseconds())
					{
						SbiUser0.authServiceRequest();
						SbiUser0.smartSecServiceRequest();
						SbiUser0.secureLoginServiceRequest();
						seassion = true;
					}
					int num = 0;
					while (true)
					{
						string text5 = SbiUser0.fetchOnlineOTPRequest();
						if (text5.Contains("status\":\"Success\""))
						{
							string text6 = text5.Substring(text5.IndexOf("onlineOtp") + 12);
							result = text6.Substring(0, text6.IndexOf("\""));
							break;
						}
						num++;
						if (num > 5)
						{
							break;
						}
						Thread.Sleep(754);
					}
				}
			}
			catch
			{
			}
			return result;
		}
	}
}
