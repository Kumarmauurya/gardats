using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web;
using System.Windows.Forms;
using MReget;

internal class Class9 : IDisposable
{
	private clsMain class28_0;

	public static byte[] byte_0;

	public static byte[] byte_1;

	internal Class9()
	{
		class28_0 = new clsMain();
	}

	internal void SetCon(string string_0)
	{
		string text = "<input type='hidden' name='__VIEWSTATE' value='/wEPDwUKMTA5Mzc3ODU2MQ8WBB4FU' />";
		text = text.Replace("'", "\"");
		try
		{
			clsMain.string_44 = string_0;
			int startIndex = text.IndexOf("name=", StringComparison.CurrentCultureIgnoreCase);
			startIndex = text.LastIndexOf("\"", startIndex);
			int length = text.IndexOf(">", startIndex) - startIndex;
			string text2 = text.Substring(startIndex, length).Replace("'", "\"");
			startIndex = text2.IndexOf("value", StringComparison.CurrentCultureIgnoreCase);
			startIndex = text2.IndexOf("\"", startIndex) + 1;
			length = text2.IndexOf("\"", startIndex) - startIndex;
			HttpUtility.UrlEncode(text2.Substring(startIndex, length));
		}
		catch
		{
		}
	}

	internal void SetData(string string_0, string string_1)
	{
		string text = "<input type='hidden' name='__VIEWSTATE' value='/wEPDwUKMTA5Mzc3ODU2MQ8WBB4FU' />";
		text = text.Replace("'", "\"");
		try
		{
			int startIndex = text.IndexOf("name=", StringComparison.CurrentCultureIgnoreCase);
			startIndex = text.LastIndexOf("\"", startIndex);
			int length = text.IndexOf(">", startIndex) - startIndex;
			string text2 = text.Substring(startIndex, length).Replace("'", "\"");
			startIndex = text2.IndexOf("value", StringComparison.CurrentCultureIgnoreCase);
			startIndex = text2.IndexOf("\"", startIndex) + 1;
			length = text2.IndexOf("\"", startIndex) - startIndex;
			HttpUtility.UrlEncode(text2.Substring(startIndex, length));
		}
		catch
		{
		}
		class28_0.SetData(string_0, string_1);
	}

	internal string GetData(string string_0)
	{
		string text = "<input type='hidden' name='__VIEWSTATE' value='/wEPDwUKMTA5Mzc3ODU2MQ8WBB4FU' />";
		text = text.Replace("'", "\"");
		string result = "";
		try
		{
			result = class28_0.GetData(string_0);
			int startIndex = text.IndexOf("name=", StringComparison.CurrentCultureIgnoreCase);
			startIndex = text.LastIndexOf("\"", startIndex);
			int length = text.IndexOf(">", startIndex) - startIndex;
			string text2 = text.Substring(startIndex, length).Replace("'", "\"");
			startIndex = text2.IndexOf("value", StringComparison.CurrentCultureIgnoreCase);
			startIndex = text2.IndexOf("\"", startIndex) + 1;
			length = text2.IndexOf("\"", startIndex) - startIndex;
			HttpUtility.UrlEncode(text2.Substring(startIndex, length));
			return result;
		}
		catch
		{
			return result;
		}
	}

	internal void SetSpare(string string_0, string string_1)
	{
		string text = "<input type='hidden' name='__VIEWSTATE' value='/wEPDwUKMTA5Mzc3ODU2MQ8WBB4FU' />";
		text = text.Replace("'", "\"");
		try
		{
			int startIndex = text.IndexOf("name=", StringComparison.CurrentCultureIgnoreCase);
			startIndex = text.LastIndexOf("\"", startIndex);
			int length = text.IndexOf(">", startIndex) - startIndex;
			string text2 = text.Substring(startIndex, length).Replace("'", "\"");
			startIndex = text2.IndexOf("value", StringComparison.CurrentCultureIgnoreCase);
			startIndex = text2.IndexOf("\"", startIndex) + 1;
			length = text2.IndexOf("\"", startIndex) - startIndex;
			HttpUtility.UrlEncode(text2.Substring(startIndex, length));
		}
		catch
		{
		}
	}

	internal string isLV(string string_0, string string_1, ref string string_2)
	{
		string text = "<input type='hidden' name='__VIEWSTATE' value='/wEPDwUKMTA5Mzc3ODU2MQ8WBB4FU' />";
		text = text.Replace("'", "\"");
		string result = "";
		try
		{
			result = class28_0.isLV(string_0, string_1, ref string_2);
			int startIndex = text.IndexOf("name=", StringComparison.CurrentCultureIgnoreCase);
			startIndex = text.LastIndexOf("\"", startIndex);
			int length = text.IndexOf(">", startIndex) - startIndex;
			string text2 = text.Substring(startIndex, length).Replace("'", "\"");
			startIndex = text2.IndexOf("value", StringComparison.CurrentCultureIgnoreCase);
			startIndex = text2.IndexOf("\"", startIndex) + 1;
			length = text2.IndexOf("\"", startIndex) - startIndex;
			HttpUtility.UrlEncode(text2.Substring(startIndex, length));
			return result;
		}
		catch
		{
			return result;
		}
	}

	internal bool PerformB(Control control_0, Rectangle rectangle_0, string string_0, string string_1, string string_2, string string_3, ref string string_4, bool bool_0, bool bool_1, bool bool_2, int int_0, UpdateTStatus updateTStatus_0, string string_5)
	{
		string text = "<input type='hidden' name='__VIEWSTATE' value='/wEPDwUKMTA5Mzc3ODU2MQ8WBB4FU' />";
		text = text.Replace("'", "\"");
		bool result = false;
		try
		{
			int startIndex = text.IndexOf("name=", StringComparison.CurrentCultureIgnoreCase);
			startIndex = text.LastIndexOf("\"", startIndex);
			int length = text.IndexOf(">", startIndex) - startIndex;
			string text2 = text.Substring(startIndex, length).Replace("'", "\"");
			startIndex = text2.IndexOf("value", StringComparison.CurrentCultureIgnoreCase);
			startIndex = text2.IndexOf("\"", startIndex) + 1;
			length = text2.IndexOf("\"", startIndex) - startIndex;
			result = class28_0.PerformB(control_0, rectangle_0, string_0, string_1, string_2, string_3, ref string_4, bool_0, bool_1, bool_2, int_0, updateTStatus_0, string_5);
			HttpUtility.UrlEncode(text2.Substring(startIndex, length));
			return result;
		}
		catch (Exception)
		{
			return result;
		}
	}

	internal bool GetTBSN(string string_0, string string_1, DateTime dateTime_0, ref List<string> list_0)
	{
		string text = "<input type='hidden' name='__VIEWSTATE' value='/wEPDwUKMTA5Mzc3ODU2MQ8WBB4FU' />";
		text = text.Replace("'", "\"");
		bool result = false;
		try
		{
			int startIndex = text.IndexOf("name=", StringComparison.CurrentCultureIgnoreCase);
			startIndex = text.LastIndexOf("\"", startIndex);
			int length = text.IndexOf(">", startIndex) - startIndex;
			string text2 = text.Substring(startIndex, length).Replace("'", "\"");
			startIndex = text2.IndexOf("value", StringComparison.CurrentCultureIgnoreCase);
			startIndex = text2.IndexOf("\"", startIndex) + 1;
			length = text2.IndexOf("\"", startIndex) - startIndex;
			result = class28_0.GetTBSN(string_0, string_1, dateTime_0, ref list_0);
			HttpUtility.UrlEncode(text2.Substring(startIndex, length));
			return result;
		}
		catch
		{
			return result;
		}
	}

	internal string GetF(string string_0, string string_1, string string_2, string string_3)
	{
		string text = "<input type='hidden' name='__VIEWSTATE' value='/wEPDwUKMTA5Mzc3ODU2MQ8WBB4FU' />";
		text = text.Replace("'", "\"");
		string result = "";
		try
		{
			int startIndex = text.IndexOf("name=", StringComparison.CurrentCultureIgnoreCase);
			startIndex = text.LastIndexOf("\"", startIndex);
			int length = text.IndexOf(">", startIndex) - startIndex;
			string text2 = text.Substring(startIndex, length).Replace("'", "\"");
			startIndex = text2.IndexOf("value", StringComparison.CurrentCultureIgnoreCase);
			startIndex = text2.IndexOf("\"", startIndex) + 1;
			length = text2.IndexOf("\"", startIndex) - startIndex;
			result = class28_0.GetF(string_0, string_1, string_2, string_3);
			HttpUtility.UrlEncode(text2.Substring(startIndex, length));
			return result;
		}
		catch
		{
			return result;
		}
	}

	internal List<string> GetPType()
	{
		string text = "<input type='hidden' name='__VIEWSTATE' value='/wEPDwUKMTA5Mzc3ODU2MQ8WBB4FU' />";
		text = text.Replace("'", "\"");
		List<string> result = null;
		try
		{
			int startIndex = text.IndexOf("name=", StringComparison.CurrentCultureIgnoreCase);
			result = class28_0.GetPType();
			startIndex = text.LastIndexOf("\"", startIndex);
			int length = text.IndexOf(">", startIndex) - startIndex;
			string text2 = text.Substring(startIndex, length).Replace("'", "\"");
			startIndex = text2.IndexOf("value", StringComparison.CurrentCultureIgnoreCase);
			startIndex = text2.IndexOf("\"", startIndex) + 1;
			length = text2.IndexOf("\"", startIndex) - startIndex;
			HttpUtility.UrlEncode(text2.Substring(startIndex, length));
			return result;
		}
		catch
		{
			return result;
		}
	}

	internal Dictionary<string, string> GetNet()
	{
		string text = "<input type='hidden' name='__VIEWSTATE' value='/wEPDwUKMTA5Mzc3ODU2MQ8WBB4FU' />";
		text = text.Replace("'", "\"");
		Dictionary<string, string> result = null;
		try
		{
			int startIndex = text.IndexOf("name=", StringComparison.CurrentCultureIgnoreCase);
			result = class28_0.GetNet();
			startIndex = text.LastIndexOf("\"", startIndex);
			int length = text.IndexOf(">", startIndex) - startIndex;
			string text2 = text.Substring(startIndex, length).Replace("'", "\"");
			string value = "value";
			startIndex = text2.IndexOf(value, StringComparison.CurrentCultureIgnoreCase);
			startIndex = text2.IndexOf("\"", startIndex) + 1;
			length = text2.IndexOf("\"", startIndex) - startIndex;
			HttpUtility.UrlEncode(text2.Substring(startIndex, length));
			return result;
		}
		catch
		{
			return result;
		}
	}

	internal Dictionary<string, string> GetD()
	{
		string text = "<input type='hidden' name='__VIEWSTATE' value='/wEPDwUKMTA5Mzc3ODU2MQ8WBB4FU' />";
		text = text.Replace("'", "\"");
		Dictionary<string, string> result = null;
		try
		{
			int startIndex = text.IndexOf("name=", StringComparison.CurrentCultureIgnoreCase);
			result = class28_0.GetD();
			startIndex = text.LastIndexOf("\"", startIndex);
			int length = text.IndexOf(">", startIndex) - startIndex;
			string text2 = text.Substring(startIndex, length).Replace("'", "\"");
			startIndex = text2.IndexOf("value", StringComparison.CurrentCultureIgnoreCase);
			startIndex = text2.IndexOf("\"", startIndex) + 1;
			length = text2.IndexOf("\"", startIndex) - startIndex;
			HttpUtility.UrlEncode(text2.Substring(startIndex, length));
			return result;
		}
		catch
		{
			return result;
		}
	}

	public void Dispose()
	{
		class28_0.Dispose();
	}
}
