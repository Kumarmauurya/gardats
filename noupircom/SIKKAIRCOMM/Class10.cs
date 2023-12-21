using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Web;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

internal class Class10
{
	private static CultureInfo cultureInfo_0;

	public static object object_0;

	public static object object_1;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo CultureInfo_0
	{
		get
		{
			return cultureInfo_0;
		}
		set
		{
			cultureInfo_0 = value;
		}
	}

	internal Class10()
	{
	}

	public HtmlDocument method_0(string string_0)
	{
		try
		{
			WebBrowser webBrowser = new WebBrowser();
			webBrowser.ScriptErrorsSuppressed = true;
			webBrowser.DocumentText = string_0;
			webBrowser.Document.OpenNew(true);
			webBrowser.Document.Write(string_0);
			webBrowser.Refresh();
			return webBrowser.Document;
		}
		catch
		{
		}
		return null;
	}

	public string method_1(string string_0, ref string string_1, bool bool_0)
	{
		string_1 = "";
		try
		{
			string text = string_0.Replace("'", "\"");
			int num = text.IndexOf(" action=", StringComparison.CurrentCultureIgnoreCase);
			if (num <= 0)
			{
				num = text.IndexOf(" action =", StringComparison.CurrentCultureIgnoreCase);
			}
			num = text.IndexOf("\"", num) + 1;
			int num2 = text.IndexOf("\"", num);
			string_1 = text.Substring(num, num2 - num);
		}
		catch
		{
		}
		string text2 = "";
		try
		{
			IEnumerator enumerator = null;
			IEnumerator enumerator2 = null;
			string_0 = string_0.Replace("document.forms[0].submit();", "").Replace(".submit();", "");
			HtmlElement htmlElement = method_0(string_0).GetElementsByTagName("form")[0];
			try
			{
				int num3 = 0;
				foreach (object item in htmlElement.GetElementsByTagName("input"))
				{
					HtmlElement htmlElement2 = (HtmlElement)item;
					if (Operators.CompareString(htmlElement2.Name, "", true) != 0 && !htmlElement2.Name.Contains("reset") && !htmlElement2.Name.Contains("submit"))
					{
						if (Operators.CompareString(htmlElement2.GetAttribute("type"), "radio", true) != 0)
						{
							string text3 = htmlElement2.Name + "=" + HttpUtility.UrlEncode(htmlElement2.GetAttribute("value"));
							text2 = ((num3 != 0) ? (text2 + "&" + text3) : text3);
						}
						else if (Operators.CompareString(htmlElement2.GetAttribute("checked"), "checked", true) == 0)
						{
							string text4 = htmlElement2.Name + "=" + HttpUtility.UrlEncode(htmlElement2.GetAttribute("value"));
							text2 = ((num3 != 0) ? (text2 + "&" + text4) : text4);
						}
					}
					num3++;
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			try
			{
				enumerator2 = htmlElement.GetElementsByTagName("select").GetEnumerator();
				while (enumerator2.MoveNext())
				{
					IEnumerator enumerator4 = null;
					HtmlElement htmlElement3 = (HtmlElement)enumerator2.Current;
					string attribute = htmlElement3.GetAttribute("name");
					try
					{
						foreach (object item2 in htmlElement3.GetElementsByTagName("option"))
						{
							HtmlElement htmlElement4 = (HtmlElement)item2;
							if (Operators.CompareString(htmlElement4.GetAttribute("selected"), "True", true) == 0)
							{
								text2 = text2 + "&" + attribute + "=" + HttpUtility.UrlEncode(htmlElement4.GetAttribute("value"));
							}
						}
					}
					finally
					{
						if (enumerator4 is IDisposable)
						{
							(enumerator4 as IDisposable).Dispose();
						}
					}
				}
			}
			finally
			{
				if (enumerator2 is IDisposable)
				{
					(enumerator2 as IDisposable).Dispose();
				}
			}
			return text2;
		}
		catch (Exception ex)
		{
			ex.Message.ToString();
			return text2;
		}
	}

	public string method_2(string string_0, string string_1, string string_2, string string_3)
	{
		string text = "";
		try
		{
			IEnumerator enumerator = null;
			IEnumerator enumerator2 = null;
			HtmlDocument htmlDocument = method_0(string_1);
			HtmlElement htmlElement = ((Operators.CompareString(string_0, "", true) != 0) ? htmlDocument.GetElementById(string_0) : htmlDocument.GetElementsByTagName("form")[0]);
			if (string_2 == "input")
			{
				HtmlElementCollection elementsByTagName = htmlElement.GetElementsByTagName("input");
				int num = 0;
				try
				{
					foreach (object item in elementsByTagName)
					{
						HtmlElement htmlElement2 = (HtmlElement)item;
						if (Operators.CompareString(htmlElement2.Name, "", true) != 0 && Operators.CompareString(htmlElement2.Name, "reset", true) != 0 && Operators.CompareString(htmlElement2.Name, "submit", true) != 0 && Operators.CompareString(htmlElement2.GetAttribute("type"), "radio", true) != 0)
						{
							htmlElement2.Name = htmlElement2.Name + "=" + HttpUtility.UrlEncode(htmlElement2.GetAttribute("value"));
							if (htmlElement2.Name == string_3)
							{
								text = HttpUtility.UrlEncode(htmlElement2.GetAttribute("value"));
							}
						}
						num++;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
			}
			if (string_2 == "option")
			{
				HtmlElementCollection elementsByTagName2 = htmlElement.GetElementsByTagName("select");
				try
				{
					enumerator2 = elementsByTagName2.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						IEnumerator enumerator4 = null;
						HtmlElement htmlElement3 = (HtmlElement)enumerator2.Current;
						htmlElement3.GetAttribute("name");
						try
						{
							foreach (object item2 in htmlElement3.GetElementsByTagName("option"))
							{
								HtmlElement htmlElement4 = (HtmlElement)item2;
								if (htmlElement4.Parent.Name.Contains(string_3))
								{
									text = text + "&" + htmlElement4.InnerHtml + "=" + HttpUtility.UrlEncode(htmlElement4.GetAttribute("value"));
								}
							}
						}
						finally
						{
							if (enumerator4 is IDisposable)
							{
								(enumerator4 as IDisposable).Dispose();
							}
						}
					}
				}
				finally
				{
					if (enumerator2 is IDisposable)
					{
						(enumerator2 as IDisposable).Dispose();
					}
				}
			}
			text = HttpUtility.UrlDecode(text);
			return text;
		}
		catch (Exception)
		{
			return text;
		}
	}
}
