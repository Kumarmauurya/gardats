using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MReget;

namespace IRCommDLL
{
	public class IRComm : IDisposable, MRegetComm
	{
		private Class9 class9_0;

		public static byte[] byte_0;

		public static byte[] byte_1;

		public static byte[] byte_2;

		public static bool doesSurf;

		public static string NgetV3Token = "";

		public static byte[] byte_3;

		public static string AppName = "Gadar";

		public static string ExeName = "Gadar";

		public IRComm()
		{
			class9_0 = new Class9();
		}

		public void SetCon(string str)
		{
			class9_0.SetCon(str);
		}

		public void SetData(string key, string value)
		{
			class9_0.SetData(key, value);
		}

		public string GetData(string key)
		{
			return class9_0.GetData(key);
		}

		public void SetSpare(string str, string str1)
		{
			class9_0.SetSpare(str, str1);
		}

		public string isLV(string userID, string pwd, ref string errMessage)
		{
			return class9_0.isLV(userID, pwd, ref errMessage);
		}

		public bool PerformB(Control cntrl, Rectangle rect, string strName, string userDetails, string iDetails, string tCntrlName, ref string txnID, bool isConfirmReq, bool isBConfirmReq, bool isP, int SlotID, UpdateTStatus updtStatus, string fir)
		{
			return class9_0.PerformB(cntrl, rect, strName, userDetails, iDetails, tCntrlName, ref txnID, isConfirmReq, isBConfirmReq, isP, SlotID, updtStatus, fir);
		}

		public bool GetTBSN(string strF, string strT, DateTime dateTime_0, ref List<string> stn)
		{
			return class9_0.GetTBSN(strF, strT, dateTime_0, ref stn);
		}

		public string GetF(string strF, string strT, string strTrn, string cls)
		{
			return class9_0.GetF(strF, strT, strTrn, cls);
		}

		public List<string> GetPType()
		{
			return class9_0.GetPType();
		}

		public Dictionary<string, string> GetNet()
		{
			return class9_0.GetNet();
		}

		public Dictionary<string, string> GetD()
		{
			return class9_0.GetD();
		}

		public void Dispose()
		{
			class9_0.Dispose();
		}
	}
}
