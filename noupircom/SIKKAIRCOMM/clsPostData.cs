using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

internal class clsPostData
{
	[CompilerGenerated]
	private sealed class Class43
	{
		public Random random_0;

		internal char method_0(string string_0)
		{
			return string_0[random_0.Next(string_0.Length)];
		}
	}

	public static bool ST;

	internal int int_TotalPax;

	private Dictionary<string, string> dictionary_0 = new Dictionary<string, string>();

	private Dictionary<string, string> dictionary_1 = new Dictionary<string, string>();

	internal int int_2;

	internal int int_3;

	internal int int_4;

	internal DateTime dateTime_0;

	internal string currentExecutable;

	internal string SRC_STN;

	internal string DEST_STN;

	internal string TRAIN_NO;

	internal string string_3;

    internal string EWALLET;

    internal string BRD_STN;

	internal string TKT_CLASS;

	internal string TKT_QUOTA;

    internal string easebuz;

    internal string easebuzDATA;

    internal string payzappDATA;//easebuz

    internal string DISHAUSERAGENT;//DishaBooking

    internal string DishaBooking;


    internal string TKT_QUOTAGN;

    internal string TKT_DAY;

	internal string TKT_MONTH;

	internal string TKT_YEAR;

	internal string J_Date;

	internal string string_11;

	internal string string_12 = "E_TICKET";

	internal bool TKT_ISADV;

	internal bool bool_1;

	internal bool TKT_ISBEDROLL;

	internal List<Class21> list_0;

	internal List<Class21> list_1;

	internal bool TKT_ISCONFIRM;

	internal bool TKT_ISAUTOUPGRD;

	internal string LoginType;

    internal string DISHAOCR;

    internal string IRCTC_PWD;

	internal string IRCTC_ID;

	internal string string_15;

	internal string string_17;

	internal string string_18;

	internal string string_20;

	internal string TKT_TRNTYPE = "";

	internal string string_26 = "";

	internal string string_27 = "";

	internal string TKT_COACH;

	internal string TKT_PAYMENT;

	internal string string_30;

	internal string TrainName;

    internal string isfood;


    internal string string_32;

    internal string upiid;

    internal string string_33;

	internal string BANKSAVEAS = "";//paidstatus

    internal string paidstatus = "";
    internal string OCRLINK = "";
    internal string cxtoken = "";

    internal string BANKDETAILS = "";

	internal string string_36 = "";

	internal string string_37 = "";

	internal string TransactionID;//PassengerResponse
    internal string PassengerResponse;


    internal string BNK_MOBILE;//class3_0.ewallettxndate
    //class3_0.ewallettimestamp
    //class3_0.ewalletamount

    internal string airtelotp;

    internal string ewallettxndate;

    internal string ewallettimestamp;

    internal string ewalletamount;

    internal string ewalletotp;

    internal string TxnToken;

    internal string Txnamt;

    internal string screen;

    internal string string_39 = "";

	internal string FAREDETAILS;

	internal string string_42;

	internal string string_43;

	internal string string_44;

	internal string string_45;

	internal string string_46;

	internal string string_47;

	internal string string_48;

	internal string string_49;

	internal string string_50;

	internal string string_51;

	internal string string_52;

	internal string string_53;

	internal string string_55;

	internal string string_57;

	internal string string_58;

	internal string _Authorization;

	internal string token;

    internal string dsession;

    internal string sessionid;

    internal string appid;

    internal string authkey;


    internal string otpuuid;

    internal string string_61;

	internal DateTime dateTime_1 = DateTime.Now;

	internal bool bool_6;

	internal bool bool_8;

	internal bool bool_9;

	internal bool fooden;


    public string string_62;

	internal Dictionary<string, string> dictionary_BnkData = new Dictionary<string, string>();

	private Dictionary<string, string> dictionary_Time = new Dictionary<string, string>();

	private static Predicate<string> predicate_0;

	private static Predicate<string> predicate_1;

	private static Predicate<string> predicate_2;

	public bool bool_opening;

	public bool bool_AC_TQ;

	public bool bool_SL_TQ;

	public bool bool_13;

	public string string_64 = "https://www.irctc.co.in/eticketing/javax.faces.resource/irctc_logo_en_IN.gif.jsf?ln=images";

	public string string_65 = "https://www.irctc.co.in/eticketing/captchaImage";

	public string string_66 = "https://www.irctc.co.in/eticketing/home";

	public string string_67 = "https://www.irctc.co.in/eticketing/trainbetweenstns.jsf";

	public string string_68 = "https://www.irctc.co.in/eticketing/mainpage.jsf";

	public string string_69 = "https://www.irctc.co.in/eticketing/journeySummary.jsf?cid=1";

	public string string_70 = "https://www.irctc.co.in/eticketing/jpInput.jsf?cid=1";

	internal string string_71 = "";

	internal string string_72;

	internal string string_74 = "";

	internal string string_75 = "";

	internal string string_76 = "";

	internal string _greq = "";

    internal string serverid = "";

    internal string string_78 = "";

	private string string_79;

	private string string_80;

	private string string_81;

	private string string_82;

	private string string_83;
	internal string otopaydata;

    internal string otopaydataweb;
	internal string hdfcupi;

    internal string cashfree;

    internal string[] Station_list;

    internal string[] Station_listWithDay;

    internal int frmStIndx;

    internal int toStIndx;

    internal string TrPassingDay;


    internal string Trday;
    internal string newdate;

    public SQLiteConnection SQL_String11 { get; private set; }

	[DllImport("user32.dll")]
	internal static extern void SetWindowText(IntPtr intPtr, string windowName);

	internal clsPostData()
	{
		Process[] processesByName = Process.GetProcessesByName("GADAR");
		Process process = processesByName[0];
		while (process.MainWindowHandle == IntPtr.Zero)
		{
			Application.DoEvents();
		}
		SetWindowText(process.MainWindowHandle, "kkkk");
		list_0 = new List<Class21>();
		list_1 = new List<Class21>();
	}

	internal clsPostData(string string_87)
	{
		ReadDataFromDB(string_87);
	}

	internal bool method_0()
	{
		bool result = true;
		if (TKT_CLASS == "1A" || TKT_CLASS == "EC" || TKT_CLASS == "2A" || TKT_CLASS == "3A" || TKT_CLASS == "CC" || TKT_CLASS == "EC" || TKT_CLASS == "3E" || TKT_QUOTA.ToUpper() == "GN" || TKT_QUOTA.ToUpper() == "LD")
		{
			result = false;
		}
		return result;
	}

	public static string Base64Decode(string base64EncodedData)
	{
		byte[] bytes = Convert.FromBase64String(base64EncodedData);
		return Encoding.UTF8.GetString(bytes);
	}

    public void GetStationList(string str4, string frm, string to)
    {
        try
        {
            string text = str4.Substring(str4.IndexOf("stationList"));
            text = text.Substring(text.IndexOf("[") + 1);
            text = text.Substring(0, text.LastIndexOf("]"));
            List<string> list = GetList(text);
            Station_list = new string[list.Count];
            Station_listWithDay = new string[list.Count + 1];
            string text2 = null;
            string text3 = null;
            string text4 = null;
            string text5 = null;
            for (int i = 0; i < list.Count; i++)
            {
                string[] array = list[i].ToString().Split(',');
                string text6 = array[6].Substring(array[6].IndexOf(":") + 2).Replace("\"", "");
                if (text6 == SRC_STN)
                {
                    Trday = array[1].Substring(array[1].IndexOf(":") + 2).Replace("\"", "");
                }
                int num = list[i].IndexOf("stationCode") + 14;
                int num2 = list[i].IndexOf("stationName") - 3;
                //
    //            int numD = list[i].IndexOf("distance") + 12;
    //            int numD1 = list[i].IndexOf("dayCount") - 3;
				//string distance = list[i].Substring(numD, numD1 - numD);
                //
                Station_list[i] = list[i].Substring(num, num2 - num);
                if (Station_list[i] == frm)
                {
                    frmStIndx = i;
                }
                if (Station_list[i] == to)
                {
                    toStIndx = i;
                }
                int num3 = list[i].IndexOf("dayCount") + 11;
                int num4 = list[i].IndexOf("stnSerialNumber") - 3;
                string text7 = list[i].Substring(num3, num4 - num3);
                if (Station_list[i] == frm)
                {
                    TrPassingDay = text7;
                }
                switch (text7)
                {
                    case "1":
                        text2 = text2 + Station_list[i] + ",";
                        break;
                    case "2":
                        text3 = text3 + Station_list[i] + ",";
                        break;
                    case "3":
                        text4 = text4 + Station_list[i] + ",";
                        break;
                    case "4":
                        text5 = text5 + Station_list[i] + ",";
                        break;
                }
                Station_listWithDay[i] = Station_list[i] + "," + text7 + "," + text6;
            }
        }
        catch
        {
        }
    }

    public string ExchangeStation(ref string frm, ref string to, ref DateTime jjdate1, int Dy, ref int Qy, int Cond)
    {
        string text = frm;
        string text2 = to;
        DateTime dateTime = jjdate1;
        int num = Station_list.Count();
        if (num < 12)
        {
            return dateTime.ToString("yyyMMdd");
        }
        num--;
        int num2 = frmStIndx;
        int num3 = toStIndx;
        if (Qy > 2)
        {
            Qy = 1;
        }
        int num4 = Qy;
        if (Cond == 0)
        {
            if (num2 == 0)
            {
                return dateTime.ToString("yyyMMdd");
            }
            num4 = num2 - Qy;
            if (num4 < 0)
            {
                num4 = 0;
            }
        }
        else
        {
            if (num3 == num)
            {
                return dateTime.ToString("yyyMMdd");
            }
            num4 = num3 + Qy;
            if (num4 > num)
            {
                num4 = num - Qy;
            }
        }
        while (true)
        {
            dateTime = jjdate1.AddDays(1 - Dy);
            try
            {
                if (Cond == 0)
                {
                    frm = Station_list[num4];
                    if (frm == to)
                    {
                        Qy = 0;
                        num4 = Qy;
                        continue;
                    }
                    if (frm == text)
                    {
                        Qy++;
                        num4 = Qy;
                        continue;
                    }
                    string text3 = Station_listWithDay[num4];
                    try
                    {
                        string[] array = text3.Split(',');
                        string text4 = array[0];
                        string s = array[1];
                        int num5 = int.Parse(s) - 1;
                        dateTime = dateTime.AddDays(num5);
                    }
                    catch
                    {
                    }
                    break;
                }
                to = Station_list[num4];
                if (frm == to)
                {
                    Qy = 1;
                    num4 = num - Qy;
                    continue;
                }
                if (to == text2)
                {
                    Qy++;
                    num4 = num - Qy;
                    continue;
                }
                break;
            }
            catch
            {
                break;
            }
        }
        return dateTime.ToString("yyyMMdd");
    }

    public static List<string> GetList(string str4)
    {
        List<string> list = new List<string>(str4.Split(new string[2] { "{", "}," }, StringSplitOptions.None));
        list.RemoveAll(RemoveEmptyString);
        if (predicate_0 == null)
        {
            predicate_0 = smethod_5i;
        }
        list.RemoveAll(predicate_0);
        if (predicate_1 == null)
        {
            predicate_1 = smethod_6i;
        }
        if (predicate_2 == null)
        {
            predicate_2 = smethod_7i;
        }
        list.RemoveAll(predicate_2);
        return list;
    }

    private static bool smethod_5i(string string_0)
    {
        if (string_0.ToLower().Contains(""))
        {
            return !string_0.ToLower().Contains("");
        }
        return true;
    }

    private static bool smethod_6i(string string_0)
    {
        return !string_0.EndsWith("\"");
    }

    private static bool smethod_7i(string string_0)
    {
        return string_0 == "</td>";
    }


    private static bool RemoveEmptyString(string s)
    {
        return s == "";
    }

    internal bool ReadDataFromDB(string string_87)
	{
		bool result = false;
		try
		{
			currentExecutable = AppDomain.CurrentDomain.FriendlyName.ToLower();
			DataTable dataTable = new DataTable();
			new SQLiteDataAdapter("SELECT RID, SRC_STN,DEST_STN,BRD_STN,TRAIN_NO,TKT_DAY,TKT_MONTH,TKT_YEAR,TKT_CLASS,TKT_QUOTA,TKT_TRNTYPE,TKT_TRDAY,TKT_ISADV,TKT_ISCONFIRM,TKT_ISAUTOUPGRD,TKT_ISBEDROLL,TKT_COACH,TKT_MOBILE,TKT_IRCTCID,TKT_PWD,TKT_PAYMENT,TKT_BANKSAVEAS,TKT_BANKDETAILS,TKT_FAREDETAILS,TKT_ISRET,TKT_ISPRI,RSRC_STN,RDEST_STN,RBRD_STN,RTRAIN_NO,RTKT_DAY,RTKT_MONTH,RTKT_YEAR,RTKT_CLASS,RTKT_QUOTA,RTKT_TRNTYPE,RTKT_TRDAY FROM TBL_TKT WHERE TKT_NAME = '" + string_87 + "'", clsMain.string_44).Fill(dataTable);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				DataRow dataRow = dataTable.Rows[0];
				int.Parse(dataRow["RID"].ToString());
				SRC_STN = dataRow["SRC_STN"].ToString();
				DEST_STN = dataRow["DEST_STN"].ToString();
				TRAIN_NO = dataRow["TRAIN_NO"].ToString();
				BRD_STN = dataRow["BRD_STN"].ToString();
				TKT_DAY = dataRow["TKT_DAY"].ToString();
				TKT_MONTH = dataRow["TKT_MONTH"].ToString();
				TKT_YEAR = dataRow["TKT_YEAR"].ToString();
				J_Date = TKT_DAY + "/" + TKT_MONTH + "/" + TKT_YEAR;
				dateTime_0 = DateTime.ParseExact(J_Date, "d/M/yyyy", CultureInfo.InvariantCulture);
				dateTime_0 = new DateTime(int.Parse(TKT_YEAR), int.Parse(TKT_MONTH), int.Parse(TKT_DAY));
				
				TKT_CLASS = dataRow["TKT_CLASS"].ToString().ToUpper();
				TKT_QUOTA = dataRow["TKT_QUOTA"].ToString();
				string_11 = "1";
				string text = dataRow["TKT_TRDAY"].ToString();
				if (text != "")
				{
					string_11 = text;
				}
				TKT_ISADV = bool.Parse(dataRow["TKT_ISADV"].ToString());
				TKT_ISBEDROLL = bool.Parse(dataRow["TKT_ISBEDROLL"].ToString());
				TKT_ISAUTOUPGRD = bool.Parse(dataRow["TKT_ISAUTOUPGRD"].ToString());
				TKT_ISCONFIRM = bool.Parse(dataRow["TKT_ISCONFIRM"].ToString());
				TKT_COACH = dataRow["TKT_COACH"].ToString();
				if (!string.IsNullOrEmpty(TKT_COACH) && TKT_COACH.Contains(";"))
				{
					TKT_COACH = TKT_COACH.Replace(";", "");
				}
				string[] array = dataRow["TKT_MOBILE"].ToString().Split(new string[1] { "||" }, StringSplitOptions.None);
				string_15 = array[0];
				string_79 = array[1];
				string_80 = array[2];
				string_81 = array[3];
				string_82 = array[4];
				string_83 = array[5];
				string_79 = "State Entry Rd, Railway Colony";
				string_80 = "110055";
				string_81 = "DELHI";
				string_82 = "Central Delhi";
				string_83 = "Pahar Ganj S.O";
				string_17 = string_87;
				IRCTC_ID = dataRow["TKT_IRCTCID"].ToString();
				IRCTC_PWD = dataRow["TKT_PWD"].ToString();
				TKT_PAYMENT = dataRow["TKT_PAYMENT"].ToString();
				TKT_TRNTYPE = dataRow["TKT_TRNTYPE"].ToString();
				BANKSAVEAS = dataRow["TKT_BANKSAVEAS"].ToString();
				BANKDETAILS = dataRow["TKT_BANKDETAILS"].ToString();
				new SQLiteDataAdapter("SELECT BANK_SAVEAS, BANK_DETAILS FROM TBL_BANK", clsMain.string_44).Fill(dataTable);
				if (dataTable != null && dataTable.Rows.Count > 0)
				{
					foreach (object row in dataTable.Rows)
					{
						DataRow dataRow2 = (DataRow)row;
						dictionary_BnkData.Add(dataRow2["BANK_SAVEAS"].ToString(), dataRow2["BANK_DETAILS"].ToString());
					}
				}
				FAREDETAILS = dataRow["TKT_FAREDETAILS"].ToString();
				bool_9 = false;
				string_42 = dataRow["TKT_ISRET"].ToString();
				bool_8 = bool.Parse(dataRow["TKT_ISPRI"].ToString());
				string_43 = dataRow["RSRC_STN"].ToString();
				if (string_43 != "")
				{
					bool_9 = true;
				}
				string_44 = dataRow["RDEST_STN"].ToString();
				string_45 = dataRow["RTRAIN_NO"].ToString();
				string_46 = dataRow["RBRD_STN"].ToString();
				string_47 = dataRow["RTKT_DAY"].ToString();
				string_48 = dataRow["RTKT_MONTH"].ToString();
				string_49 = dataRow["RTKT_YEAR"].ToString();
				string_50 = dataRow["RTKT_CLASS"].ToString();
				string_51 = dataRow["RTKT_QUOTA"].ToString();
				string_52 = dataRow["RTKT_TRNTYPE"].ToString();
				string_53 = dataRow["RTKT_TRDAY"].ToString();
				string_20 = SRC_STN + DEST_STN + TRAIN_NO + TKT_CLASS + J_Date;
				bool_6 = false;
				string text2 = "";
				list_0 = new List<Class21>();
				list_1 = new List<Class21>();
				dataTable.Dispose();
				dataTable = new DataTable();
				new SQLiteDataAdapter("SELECT PAX_NAME,PAX_AGE,PAX_SEX,PAX_BIRTH,PAX_FOOD,PAX_IDTYPE,PAX_IDNO,PAX_CONC FROM TBL_PAX WHERE TKT_ID = '" + string_87 + "'", clsMain.string_44).Fill(dataTable);
				foreach (object row2 in dataTable.Rows)
				{
					DataRow dataRow3 = (DataRow)row2;
					if (dataRow3["PAX_BIRTH"] != null && dataRow3["PAX_BIRTH"].GetType() != typeof(DBNull) && !string.IsNullOrEmpty(dataRow3["PAX_BIRTH"].ToString()))
					{
						int_TotalPax++;
						Class21 @class = new Class21();
						text2 += dataRow3["PAX_NAME"].ToString();
						if (int_TotalPax == 1)
						{
							string_20 += dataRow3["PAX_NAME"].ToString();
						}
						@class.string_0 = dataRow3["PAX_NAME"].ToString();
						@class.string_1 = dataRow3["PAX_AGE"].ToString();
						@class.string_2 = dataRow3["PAX_SEX"].ToString();
						@class.string_3 = dataRow3["PAX_BIRTH"].ToString();
						@class.string_5 = dataRow3["PAX_FOOD"].ToString();
						@class.string_6 = dataRow3["PAX_IDTYPE"].ToString();
						@class.string_7 = dataRow3["PAX_IDNO"].ToString();
						@class.string_4 = dataRow3["PAX_CONC"].ToString();
						list_0.Add(@class);
					}
					else
					{
						Class21 class2 = new Class21();
						class2.string_0 = dataRow3["PAX_NAME"].ToString();
						class2.string_1 = dataRow3["PAX_AGE"].ToString();
						class2.string_2 = dataRow3["PAX_SEX"].ToString();
						list_1.Add(class2);
					}
				}
				dateTime_1 = new DateTime(int.Parse(TKT_YEAR), int.Parse(TKT_MONTH), int.Parse(TKT_DAY));
				string_18 = SRC_STN + DEST_STN + TRAIN_NO + TKT_DAY + TKT_MONTH + TKT_YEAR + TKT_CLASS + text2;
				string_18 = string_18.Trim();
				result = true;
				return true;
			}
			MessageBox.Show("Ticket Not Found!");
			return result;
		}
		catch (Exception)
		{
			MessageBox.Show("Ticket Reading Failed!");
			return result;
		}
	}

	internal string method_2(string string_87)
	{
		string result = "";
		try
		{
			DataTable dataTable = new DataTable();
			new SQLiteDataAdapter("SELECT UserState FROM TBL_USER WHERE UserName = '" + string_87 + "'", clsMain.string_44).Fill(dataTable);
			foreach (object row in dataTable.Rows)
			{
				result = ((DataRow)row)[0].ToString().Split(new string[1] { "||" }, StringSplitOptions.None)[1];
			}
			return result;
		}
		catch (Exception)
		{
			return result;
		}
	}

	private string method_3(string string_87)
	{
		string text = "";
		try
		{
			if (string_87.Contains("registered Mobile Number"))
			{
				if (string_87.Contains("missing digits of"))
				{
					string value = "Mobile Number ";
					string text2 = string_87.Substring(string_87.IndexOf(value) + 14);
					text2 = text2.Substring(0, text2.IndexOf(" "));
					char[] array = text2.ToCharArray();
					char[] array2 = method_13(string_62, "mobile").ToCharArray();
					for (int i = 0; i < 10; i++)
					{
						if (array[i].ToString() == "X")
						{
							string text3 = array2[i].ToString();
							text += text3;
						}
					}
				}
				return text;
			}
			if (string_87.Contains("registered UserLoginID"))
			{
				string iRCTC_ID = IRCTC_ID;
				if (string_87.Contains("Is it Your") & string_87.Contains(iRCTC_ID))
				{
					text = "Y";
					return text;
				}
				text = "N";
				return text;
			}
			if (string_87.Contains("registered DOB") | string_87.Contains("registered Dob"))
			{
				string value2 = "";
				try
				{
					string text4 = method_13(string_62, "dob");
					if (text4 != "")
					{
						value2 = DateTime.ParseExact(text4, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture);
					}
				}
				catch
				{
				}
				if (string_87.Contains("Is it Your") & string_87.Contains(value2))
				{
					text = "Y";
					return text;
				}
				text = "N";
				return text;
			}
			if (string_87.Contains("registered EMAIL") | string_87.Contains("registered Email"))
			{
				string value3 = method_13(string_62, "email");
				if (string_87.Contains("Is it Your") & string_87.Contains(value3))
				{
					text = "Y";
					return text;
				}
				text = "N";
				return text;
			}
			if (string_87.Contains("registered PIN") | string_87.Contains("registered Pin"))
			{
				method_13(string_62, "pinCode");
				if (string_87.Contains("Is it Your"))
				{
					text = "Y";
					return text;
				}
				text = "N";
				return text;
			}
			if (string_87.Contains("your register mobile number"))
			{
				text = method_13(string_62, "mobile");
				return text;
			}
			if (string_87.Contains("your register email ID"))
			{
				text = method_13(string_62, "email");
				return text;
			}
			if (string_87.Contains("your register user login id"))
			{
				text = IRCTC_ID;
				return text;
			}
			if (string_87.Contains("your register date of birth in ddMMyyyy format"))
			{
				string text5 = "";
				try
				{
					string text6 = method_13(string_62, "dob");
					if (text6 != "")
					{
						text5 = DateTime.ParseExact(text6, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
					}
				}
				catch
				{
				}
				text = text5.Replace("-", "");
				return text;
			}
			if (string_87.Contains("You registered for IRCTC Ewallet Feature"))
			{
				text = "0";
				return text;
			}
			if (string_87.Contains("You give Feedback after Ticket Booking"))
			{
				text = "N";
				return text;
			}
			text = "N";
			return text;
		}
		catch (Exception ex)
		{
			MessageBox.Show("Here Paxs Data' Ques/Ans Some Occure. " + ex.Message.ToString());
			return text;
		}
	}

	internal void method_4(bool bool_14, string string_87, string string_88, string string_89, string string_90)
	{
		SQLiteConnection sQLiteConnection = new SQLiteConnection(clsMain.string_44);
		sQLiteConnection.Open();
		try
		{
			SQLiteCommand sQLiteCommand = new SQLiteCommand(sQLiteConnection);
			string text = string_90 + DateTime.Now.ToString("ddmmyy");
			if (bool_14)
			{
				sQLiteCommand.CommandText = "INSERT INTO TBL_HISTORY(TCNTRL_NAME, TKT_NAME, IRCTC_ID, stnFrom, stnTo, Journey_Date, BANK_NAME, AMT, PNR, Remarks, Create_Date) VALUES('" + text + "', '" + string_17 + "', '" + IRCTC_ID + "', '" + SRC_STN + "', '" + DEST_STN + "', '" + J_Date + "', '" + BANKSAVEAS + "', '" + string_88 + "', '" + string_89 + "', '" + string_87 + "', date('now'));";
				sQLiteCommand.ExecuteNonQuery();
			}
			else
			{
				sQLiteCommand.CommandText = "UPDATE tbl_TktHistory set PNR = '" + string_89 + "', Remarks = '" + string_87 + "' WHERE TCNTRL_NAME = '" + text + "';";
				sQLiteCommand.ExecuteNonQuery();
			}
			sQLiteCommand.CommandText = "UPDATE [TBL_USER] SET [UserState] = 'Book||" + DateTime.Now.Date.ToString("dd/M/yyyy") + "' WHERE [UserName] = '" + IRCTC_ID + "'";
			sQLiteCommand.ExecuteNonQuery();
		}
		catch
		{
		}
		finally
		{
			if (sQLiteConnection.State == ConnectionState.Open)
			{
				sQLiteConnection.Close();
			}
		}
	}

    internal void method_4_Disha(bool bool_14, string string_87, string string_88, string string_89, string string_90)
    {
        SQLiteConnection sQLiteConnection = new SQLiteConnection(clsMain.string_44);
        sQLiteConnection.Open();
        try
        {
            SQLiteCommand sQLiteCommand = new SQLiteCommand(sQLiteConnection);
            string text = string_90 + DateTime.Now.ToString("ddmmyy");
            if (bool_14)
            {
                sQLiteCommand.CommandText = "INSERT INTO TBL_HISTORY(TCNTRL_NAME, TKT_NAME, IRCTC_ID, stnFrom, stnTo, Journey_Date, BANK_NAME, AMT, PNR, Remarks, Create_Date) VALUES('" + text + "', '" + string_17 + "', '" + IRCTC_ID + "', '" + SRC_STN + "', '" + DEST_STN + "', '" + J_Date + "', '" + BANKSAVEAS + "', '" + string_88 + "', '" + string_89 + "', '" + string_87 + "', date('now'));";
                sQLiteCommand.ExecuteNonQuery();
            }
            else
            {
                sQLiteCommand.CommandText = "UPDATE tbl_TktHistory set PNR = '" + string_89 + "', Remarks = '" + string_87 + "' WHERE TCNTRL_NAME = '" + text + "';";
                sQLiteCommand.ExecuteNonQuery();
            }
            sQLiteCommand.CommandText = "UPDATE [TBL_USER] SET [UserState] = 'Active||" + DateTime.Now.Date.ToString("dd/M/yyyy") + "' WHERE [UserName] = '" + IRCTC_ID + "'";
            sQLiteCommand.ExecuteNonQuery();
        }
        catch
        {
        }
        finally
        {
            if (sQLiteConnection.State == ConnectionState.Open)
            {
                sQLiteConnection.Close();
            }
        }
    }

    private string method_5(int int_5, string string_87)
	{
		Random random_0 = new Random();
		return new string((from string_0 in Enumerable.Repeat(string_87, int_5)
			select string_0[random_0.Next(string_0.Length)]).ToArray());
	}

	public string method_6()
	{
		string text = method_5(15, "0123456789");
		method_5(20, "0123456789");
		method_5(16, "abcdefghijklmnopqrstuvwxyz0123456789");
		string s = DateAndTime.Now.ToString("yyyyMMddHHmmss") + IRCTC_ID + text;
		byte[] bytes = new ASCIIEncoding().GetBytes(s);
		byte[] array = new MD5CryptoServiceProvider().ComputeHash(bytes);
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < array.Length; i++)
		{
			stringBuilder.Append(array[i].ToString("x2"));
		}
		return stringBuilder.ToString().Substring(0, 8);
	}

	internal string method_7(string string_87)
	{
		string text = "";
		try
		{
			if (string_87.Contains("header"))
			{
				text = method_13(string_87, "header");
				if (text == "")
				{
					text = string_87.Substring(string_87.IndexOf("header") + 11);
					text = text.Substring(0, text.IndexOf("\","));
				}
				string text2 = text;
				if (text != "")
				{
					string text3 = method_3(text);
					text = text2 + "#" + text3;
					text = text3;
					return text;
				}
				text = "";
				return text;
			}
			return text;
		}
		catch
		{
			return text;
		}
	}

	internal string GetPassengerPOST(string string_87, string string_88, string resp)
	{
		if (resp.IndexOf("header") > 0)
		{
			method_7(resp);
		}
		string text = "";
		string text2 = "3";
		if (string_88.Contains("UPI") | string_88.Contains("PHONEPE") | string_88.Contains("PAYTMQR") | string_88.Contains("BHIM"))
		{
			text2 = "2";
		}
		//bool flag = false;
		//if (string_30.Contains("Food Choice is Optional in this train"))
		//{
  //          flag = true;
  //      };//string_30.Contains("foodChoiceEnabled\":\"true");
		bool bool_ = string_30.Contains("bedRollFlagEnabled\":\"true");
		bool bool_2 = TKT_QUOTA == "CK" || TKT_QUOTA == "PT" || TKT_QUOTA == "TQ";
		bool bool_3 = string_30.Contains("forgoConcession\":\"true");
		string text3 = "99";
		string text4 = "false";
		string text5 = "true";
		if (TKT_ISCONFIRM)
		{
			text3 = "4";
			text4 = "true";
			text5 = "false";
		}
		else if (bool_6)
		{
			text3 = "1";
		}
		object[] array = new object[5]
		{
			"{\"clusterFlag\":\"N\",\"onwardFlag\":\"N\",\"cod\":\"false\",\"reservationMode\":\"WS_TA_B2C\",\"autoUpgradationSelected\":false,\"gnToCkOpted\":false,\"paymentType\":\"" + text2 + "\",\"twoPhaseAuthRequired\":false,\"captureAddress\":0,\"wsUserLogin\":\"" + IRCTC_ID + "\",\"moreThanOneDay\":false,\"clientTransactionId\":\"" + string_87 + "\",\"boardingStation\":\"" + BRD_STN + "\",\"reservationUptoStation\":\"" + DEST_STN + "\",\"mobileNumber\":\"" + string_15 + "\",\"ticketType\":\"E\",\"mainJourneyTxnId\":null,\"mainJourneyPnr\":\"\",\"captcha\":\"\",\"generalistChildConfirm\":false,\"ftBooking\":false,\"loyaltyRedemptionBooking\":false,\"nosbBooking\":false,\"warrentType\":0,\"ftTnCAgree\":false,\"bookingChoice\":1,\"bookingConfirmChoice\":1,\"bookOnlyIfCnf\":" + text4 + ",\"returnJourney\":null,\"connectingJourney\":false,\"",
			"lapAvlRequestDTO\":[{\"trainNo\":\"" + TRAIN_NO + "\",\"journeyDate\":\"" + dateTime_0.ToString("yyyMMdd") + "\",\"fromStation\":\"" + SRC_STN + "\",\"toStation\":\"" + DEST_STN + "\",\"journeyClass\":\"" + TKT_CLASS + "\",\"quota\":\"" + TKT_QUOTA + "\",\"coachId\":null,\"reservationChoice\":\"" + text3 + "\",\"ignoreChoiceIfWl\":" + text5 + ",\"travelInsuranceOpted\":false,\"warrentType\":0,\"coachPreferred\":false,\"autoUpgradation\":false,\"bookOnlyIfCnf\":" + text4 + ",\"addMealInput\":null,\"concessionBooking\":false,\"passengerList\":[",
			null,
			null,
			null
		};
		int num = 1;
		foreach (Class21 item in list_0)
		{
			text += item.method_3(num, bool_2, fooden, bool_, TKT_QUOTA, bool_3);
			num++;
			int_4++;
			if (list_0.Count >= num)
			{
				text += ",";
			}
		}
		array[2] = string.Concat(new string[3] { text, "],\"ssQuotaSplitCoach\":\"N\"}],\"gstDetails\":{\"gstIn\":\"\",\"error\":null}", "}" });
		if (!string.IsNullOrEmpty(TKT_COACH) && TKT_COACH.Length == 3)
		{
			TKT_COACH = Interaction.InputBox("Please Enter Coach ID", "Coach ID", TKT_COACH);
		}
		return string.Concat(array);
	}

	internal string GetPassengerPOST_App(string string_87, string string_88, string resp)
	{
		if (resp.IndexOf("header") > 0)
		{
			method_7(resp);
		}
		if (string_15 == "9000000000")
		{
			string_15 = method_13(string_62, "mobile");
		}
		string text = "";
		string text2 = "3";
		if (string_88.Contains("UPI") | string_88.Contains("PHONEPE") | string_88.Contains("BHIM") | string_88.Contains("AIRPAYQR") | string_88.Contains("PAYTMQR") | string_88.Contains("EAZEBUZQR"))
		{
			text2 = "2";
		}
		//bool flag = string_30.Contains("foodChoiceEnabled\":\"true");
        //fooden = false;
        //if (string_30.Contains("Food Choice is Optional in this train"))
        //{
        //    fooden = true;
        //};
        bool bool_ = string_30.Contains("bedRollFlagEnabled\":\"true");
		bool bool_2 = TKT_QUOTA == "CK" || TKT_QUOTA == "PT" || TKT_QUOTA == "TQ";
		bool bool_3 = string_30.Contains("forgoConcession\":\"true");
		string text3 = "99";
		string text4 = "false";
		string text5 = "true";
		if (TKT_ISCONFIRM)
		{
			text3 = "4";
			text4 = "true";
			text5 = "false";
		}
		else if (bool_6)
		{
			text3 = "1";
		}
		object[] array = new object[5]
		{
			"{\"masterId\":null,\"wsUserLogin\":\"" + IRCTC_ID + "\",\"wsUserPassword\":null,\"wsUserTransactionPassword\":null,\"agentDeviceId\":null,\"alternateAvlInputDTO\":null,\"atasOpted\":null,\"autoUpgradationSelected\":false,\"bankId\":0,\"boardingStation\":\"" + BRD_STN + "\",\"bookNowPressTimeDiff\":0,\"bookingChoice\":0,\"bookingConfirmChoice\":0,\"bookingInitTime\":0,\"bookingOTP\":null,\"captcha\":null,\"captureAddress\":0,\"clientTransactionId\":\"" + string_87 + "\",\"clusterFlag\":\"N\",\"clusterJourneyClass\":null,\"cod\":\"false\",\"connectedPnrDataDTO\":null,\"connectingJourney\":false,\"covid19\":false,\"enrouteStation\":null,\"ftBooking\":false,\"generalistChildConfirm\":false,\"gnToCkOpted\":true,\"gstDetails\":null,\"hrmsTxnId\":0,\"iTicketDetailsDTO\":null,\"journalistBooking\":false,\"lapAvlRequestDTO\":[{\"addMealDetail\":null,\"agentOtpBooking\":false,\"coachId\":\"\",\"concessionBooking\":false,\"fromStation\":\"" + SRC_STN + "\",\"ignoreChoiceIfWl\":" + text5 + ",\"infantList\":[],\"jd\":null,\"journeyClass\":\"" + TKT_CLASS + "\",\"journeyDate\":\"" + dateTime_0.ToString("yyyMMdd") + "\",\"passengerList\":[",
			null,
			null,
			null,
			null
		};
		int num = 1;
		foreach (Class21 item in list_0)
		{
			text += item.method_3_app(num, bool_2, fooden, bool_, TKT_QUOTA, bool_3);
			num++;
			int_4++;
			if (list_0.Count >= num)
			{
				text += ",";
			}
		}
        array[1] = text + "],\"quota\":\"" + TKT_QUOTA + "\",\"reservationChoice\":" + text3 + ",\"ssQuotaSplitCoach\":\"N\",\"ticketChoiceLowerBerth\":null,\"ticketChoiceSameCoach\":false,\"toStation\":\"" + DEST_STN + "\",\"trainNo\":\"" + TRAIN_NO + "\",\"trainOwner\":null,\"travelInsuranceOpted\":false}],\"loyaltyRedemptionBooking\":false,\"mainJourneyPnr\":null,\"mainJourneyTktId\":null,\"mainJourneyTxnId\":null,\"mobileNumber\":\"" + string_15 + "\",\"moreThanOneDay\":false,\"mpBooking\":false,\"mpSecType\":null,\"name\":null,\"nget_transaction_id\":0,\"nlpCaptchaVarsDTO\":null,\"nosbBooking\":false,\"onwardFlag\":\"N\",\"otpBooking\":false,\"passBooking\":false,\"paymentType\":" + text2 + ",\"reservationMode\":\"WS_TA_B2C\",\"reservationUptoStation\":null,\"returnJourney\":false,\"ticketType\":\"E\",\"tktAddress\":null,\"twoPhaseAuthRequired\":false,\"viaPointStation\":null,\"warrentType\":null}";
		return string.Concat(array);
	}

    internal string GetPassengerPOST_DIKSHA(string string_87, string string_88, string resp)
    {
        if (resp.IndexOf("header") > 0)
        {
            method_7(resp);
        }
        if (string_15 == "9000000000")
        {
            string_15 = method_13(string_62, "mobile");
        }
        string text = "";
        string text2 = "3";
        if (string_88.Contains("UPI") | string_88.Contains("PHONEPE") | string_88.Contains("BHIM"))
        {
            text2 = "2";
        }
        bool flag = string_30.Contains("foodChoiceEnabled\":\"true");
        bool bool_ = string_30.Contains("bedRollFlagEnabled\":\"true");
        bool bool_2 = TKT_QUOTA == "CK" || TKT_QUOTA == "PT" || TKT_QUOTA == "TQ";
        bool bool_3 = string_30.Contains("forgoConcession\":\"true");
        string text3 = "99";
        string text4 = "false";
        string text5 = "true";
        if (TKT_ISCONFIRM)
        {
            text3 = "4";
            text4 = "true";
            text5 = "false";
        }
        else if (bool_6)
        {
            text3 = "1";
        }
        object[] array = new object[5]
        {
            "{\"masterId\":null,\"wsUserLogin\":\"" + IRCTC_ID + "\",\"wsUserPassword\":null,\"wsUserTransactionPassword\":null,\"agentDeviceId\":null,\"alternateAvlInputDTO\":null,\"atasOpted\":null,\"autoUpgradationSelected\":false,\"bankId\":0,\"boardingStation\":null,\"bookNowPressTimeDiff\":0,\"bookingChoice\":0,\"bookingConfirmChoice\":0,\"bookingInitTime\":0,\"bookingOTP\":null,\"captcha\":null,\"captureAddress\":0,\"clientTransactionId\":\"" + string_87 + "\",\"clusterFlag\":\"N\",\"clusterJourneyClass\":null,\"cod\":\"false\",\"connectedPnrDataDTO\":null,\"connectingJourney\":false,\"covid19\":false,\"enrouteStation\":null,\"ftBooking\":false,\"generalistChildConfirm\":false,\"gnToCkOpted\":true,\"gstDetails\":null,\"hrmsTxnId\":0,\"iTicketDetailsDTO\":null,\"journalistBooking\":false,\"lapAvlRequestDTO\":[{\"addMealDetail\":null,\"agentOtpBooking\":false,\"coachId\":\"\",\"concessionBooking\":false,\"fromStation\":\"" + SRC_STN + "\",\"ignoreChoiceIfWl\":" + text5 + ",\"infantList\":[],\"jd\":null,\"journeyClass\":\"" + TKT_CLASS + "\",\"journeyDate\":\"" + dateTime_0.ToString("yyyMMdd") + "\",\"passengerList\":[",
            null,
            null,
            null,
            null
        };
        int num = 1;
        foreach (Class21 item in list_0)
        {
            text += item.method_3_app(num, bool_2, flag, bool_, TKT_QUOTA, bool_3);
            num++;
            int_4++;
            if (list_0.Count >= num)
            {
                text += ",";
            }
        }
        array[1] = text + "],\"quota\":\"" + TKT_QUOTA + "\",\"reservationChoice\":" + text3 + ",\"ssQuotaSplitCoach\":\"N\",\"ticketChoiceLowerBerth\":null,\"ticketChoiceSameCoach\":false,\"toStation\":\"" + DEST_STN + "\",\"trainNo\":\"" + TRAIN_NO + "\",\"trainOwner\":null,\"travelInsuranceOpted\":false}],\"loyaltyRedemptionBooking\":false,\"mainJourneyPnr\":null,\"mainJourneyTktId\":null,\"mainJourneyTxnId\":null,\"mobileNumber\":\"" + string_15 + "\",\"moreThanOneDay\":false,\"mpBooking\":false,\"mpSecType\":null,\"name\":null,\"nget_transaction_id\":0,\"nlpCaptchaVarsDTO\":null,\"nosbBooking\":false,\"onwardFlag\":\"N\",\"otpBooking\":false,\"passBooking\":false,\"paymentType\":" + text2 + ",\"reservationMode\":\"WS_TA_B2C\",\"reservationUptoStation\":null,\"returnJourney\":false,\"ticketType\":\"E\",\"tktAddress\":null,\"twoPhaseAuthRequired\":false,\"viaPointStation\":null,\"warrentType\":null}";
        return string.Concat(array);
    }

    public List<string> method_11(string string_87)
	{
		List<string> list = new List<string>(string_87.Split(new string[2] { "{", "}," }, StringSplitOptions.None));
		list.RemoveAll(smethod_3);
		if (predicate_0 == null)
		{
			predicate_0 = smethod_0;
		}
		list.RemoveAll(predicate_0);
		if (predicate_1 == null)
		{
			predicate_1 = smethod_1;
		}
		if (predicate_2 == null)
		{
			predicate_2 = smethod_2;
		}
		list.RemoveAll(predicate_2);
		return list;
	}

	private static bool smethod_0(string string_87)
	{
		return !string_87.ToLower().Contains("") || !string_87.ToLower().Contains("");
	}

	private static bool smethod_1(string string_87)
	{
		return !string_87.EndsWith("\"");
	}

	private static bool smethod_2(string string_87)
	{
		return string_87 == "</td>";
	}

	private static bool smethod_3(string string_87)
	{
		return string_87 == "";
	}

	public static string smethod_4(string string_87, ref string string_88)
	{
		string text = "";
		try
		{
			string text2 = string_87.Replace("'", "\"");
			int num = text2.IndexOf("<form", StringComparison.CurrentCultureIgnoreCase);
			if (num < 0)
			{
				if (text2.IndexOf("http://") == 0 || text2.IndexOf("https://") == 0)
				{
					string_88 = text2;
				}
				return text;
			}
			try
			{
				int startIndex = text2.IndexOf(" action", num, StringComparison.CurrentCultureIgnoreCase);
				startIndex = text2.IndexOf("=", startIndex, StringComparison.CurrentCultureIgnoreCase);
				startIndex = text2.IndexOf("\"", startIndex) + 1;
				int num2 = text2.IndexOf("\"", startIndex);
				string_88 = text2.Substring(startIndex, num2 - startIndex);
				string_88 = string_88.Replace("&amp;", "&");
			}
			catch
			{
			}
			num = text2.IndexOf("<form", StringComparison.CurrentCultureIgnoreCase);
			int num3 = text2.IndexOf("</form", StringComparison.CurrentCultureIgnoreCase);
			while (num > -1)
			{
				string text3 = "";
				int num4 = text2.IndexOf("<input", num, StringComparison.CurrentCultureIgnoreCase);
				int num5 = text2.IndexOf("<select", num, StringComparison.CurrentCultureIgnoreCase);
				int num6 = -1;
				if (num4 == -1 && num5 == -1 && num6 == -1)
				{
					return text;
				}
				int num7 = num4;
				int[] array = new int[3] { num4, num5, num6 };
				for (int i = 1; i < array.Length; i++)
				{
					if (num7 > array[i] && array[i] != -1)
					{
						num7 = array[i];
					}
				}
				if (num7 == num4)
				{
					num = num4;
					text3 = "input";
				}
				else if (num7 == num5)
				{
					num = num5;
					text3 = "select";
				}
				else if (num7 == num6)
				{
					num = num6;
					text3 = "";
				}
				num = text2.IndexOf("<" + text3, num, StringComparison.CurrentCultureIgnoreCase);
				if (num >= num3)
				{
					return text;
				}
				num = text2.IndexOf("<input", num, StringComparison.CurrentCultureIgnoreCase);
				int num8 = text2.IndexOf(">", num) + 1;
				string text4 = text2.Substring(num, num8 - num);
				text4 = text4.Replace("\t", "").Replace("\n", "").Replace("\r", " ");
				num = num8;
				if (text4.Contains("type=\"submit\""))
				{
					continue;
				}
				int num9 = text4.IndexOf(" name", StringComparison.CurrentCultureIgnoreCase);
				if (num9 == -1)
				{
					continue;
				}
				num9 = text4.IndexOf("\"", num9) + 1;
				int num10 = text4.IndexOf("\"", num9);
				string text5 = text4.Substring(num9, num10 - num9);
				num9 = text4.IndexOf(" value", StringComparison.CurrentCultureIgnoreCase);
				string text6 = "";
				if (num9 > -1)
				{
					if (text4.IndexOf("\"", num9) > -1)
					{
						num9 = text4.IndexOf("\"", num9) + 1;
						num10 = text4.IndexOf("\"", num9);
					}
					else if (text4.IndexOf("'", num9) > -1)
					{
						num9 = text4.IndexOf("'", num9) + 1;
						num10 = text4.IndexOf("'", num9);
					}
					text6 = HttpUtility.UrlEncode(text4.Substring(num9, num10 - num9).Replace("&amp;", "&"));
				}
				text5 = text5 + "=" + text6;
				text = (string.IsNullOrEmpty(text) ? text5 : (text + "&" + text5));
			}
			return text;
		}
		catch
		{
			return text;
		}
	}

	public static string smethod_4_0(string string_87, ref string string_88)
	{
		string text = "";
		try
		{
			string text2 = string_87.Replace("'", "\"");
			int num = text2.IndexOf("<form", StringComparison.CurrentCultureIgnoreCase);
			if (num < 0)
			{
				if (text2.IndexOf("http://") == 0 || text2.IndexOf("https://") == 0)
				{
					string_88 = text2;
				}
				return text;
			}
			try
			{
				int startIndex = text2.IndexOf(" action", num, StringComparison.CurrentCultureIgnoreCase);
				startIndex = text2.IndexOf("=", startIndex, StringComparison.CurrentCultureIgnoreCase);
				startIndex = text2.IndexOf("\"", startIndex) + 1;
				int num2 = text2.IndexOf("\"", startIndex);
				string_88 = text2.Substring(startIndex, num2 - startIndex);
				string_88 = string_88.Replace("&amp;", "&");
			}
			catch
			{
			}
			num = text2.IndexOf("<form", StringComparison.CurrentCultureIgnoreCase);
			int num3 = text2.IndexOf("</form", StringComparison.CurrentCultureIgnoreCase);
			while (num > -1)
			{
				string text3 = "";
				int num4 = text2.IndexOf("<input", num, StringComparison.CurrentCultureIgnoreCase);
				int num5 = text2.IndexOf("<select", num, StringComparison.CurrentCultureIgnoreCase);
				int num6 = -1;
				if (num4 == -1 && num5 == -1 && num6 == -1)
				{
					return text;
				}
				int num7 = num4;
				int[] array = new int[3] { num4, num5, num6 };
				for (int i = 1; i < array.Length; i++)
				{
					if (num7 > array[i] && array[i] != -1)
					{
						num7 = array[i];
					}
				}
				if (num7 == num4)
				{
					num = num4;
					text3 = "input";
				}
				else if (num7 == num5)
				{
					num = num5;
					text3 = "select";
				}
				else if (num7 == num6)
				{
					num = num6;
					text3 = "";
				}
				num = text2.IndexOf("<" + text3, num, StringComparison.CurrentCultureIgnoreCase);
				if (num >= num3)
				{
					return text;
				}
				num = text2.IndexOf("<input", num, StringComparison.CurrentCultureIgnoreCase);
				int num8 = text2.IndexOf(">", num) + 1;
				string text4 = text2.Substring(num, num8 - num);
				text4 = text4.Replace("\t", "").Replace("\n", "").Replace("\r", " ");
				num = num8;
				if (text4.Contains("type=\"submit\""))
				{
					continue;
				}
				int num9 = text4.IndexOf(" name", StringComparison.CurrentCultureIgnoreCase);
				if (num9 == -1)
				{
					continue;
				}
				num9 = text4.IndexOf("\"", num9) + 1;
				int num10 = text4.IndexOf("\"", num9);
				string text5 = text4.Substring(num9, num10 - num9);
				num9 = text4.IndexOf(" value", StringComparison.CurrentCultureIgnoreCase);
				string text6 = "";
				if (num9 > -1)
				{
					if (text4.IndexOf("\"", num9) > -1)
					{
						num9 = text4.IndexOf("\"", num9) + 1;
						num10 = text4.IndexOf("\"", num9);
					}
					else if (text4.IndexOf("'", num9) > -1)
					{
						num9 = text4.IndexOf("'", num9) + 1;
						num10 = text4.IndexOf("'", num9);
					}
					text6 = WebUtility.UrlEncode(text4.Substring(num9, num10 - num9).Replace("&amp;", "&"));
				}
				text5 = text5 + "=" + text6;
				text = (string.IsNullOrEmpty(text) ? text5 : (text + "&" + text5));
			}
			return text;
		}
		catch
		{
			return text;
		}
	}

	public string method_13(string string_87, string string_88)
	{
		string text = "";
		try
		{
			string_87 = string_87.Replace("{", "");
			string_87 = string_87.Replace("}", "");
			string[] array = string_87.Split(',');
			int num = Information.UBound(array);
			for (int i = 0; i <= num; i++)
			{
				string text2 = array[i].ToString().Split('~')[0];
				if (text2.Contains("\"" + string_88))
				{
					text = text2.Substring(text2.IndexOf(string_88) + (string_88.Length + 3));
					text = text.Substring(0, text.IndexOf("\""));
					return text;
				}
			}
			return text;
		}
		catch
		{
			return text;
		}
	}

	public static string SetPost(string string_87, string string_88, string string_89)
	{
		string text = "";
		string text2 = "";
		string text3 = "";
		bool flag = false;
		try
		{
			if (string_87.IndexOf(string_88) == 0)
			{
				return string_87.Replace(string_88 + "=", string_88 + "=" + string_89);
			}
			text = string_87.Substring(0, string_87.IndexOf("&" + string_88 + "=") + 1);
			if (text == "")
			{
				return string_87 + "&" + string_88 + "=" + string_89;
			}
			text2 = string_87.Substring(string_87.IndexOf("&" + string_88 + "=") + 1);
			try
			{
				text3 = text2.Substring(0, text2.IndexOf("&"));
			}
			catch
			{
				flag = true;
				text3 = text2;
			}
			string text4 = text3.Substring(text3.IndexOf("=") + 1);
			string text5 = text3.Substring(0, text3.IndexOf("="));
			string text6 = text2.Substring(text2.IndexOf("&") + 1);
			if (string_89 == null)
			{
				goto IL_01fa;
			}
			if (Operators.CompareString(string_89, "del", true) == 0)
			{
				string_87 = text + text6;
			}
			else if (Operators.CompareString(string_89, "blnk", true) == 0)
			{
				string_87 = text + text5 + "=&" + text6;
			}
			else
			{
				if (Operators.CompareString(string_89, "intt", true) != 0)
				{
					goto IL_01fa;
				}
				if (Operators.CompareString(text4, "", true) != 0)
				{
					string_87 = text + text5 + "=" + (int)Convert.ToUInt32(text4) + "&" + text6;
				}
			}
			goto IL_023f;
			IL_01fa:
			string_87 = (flag ? (text + text5 + "=" + string_89) : (text + text5 + "=" + string_89 + "&" + text6));
			goto IL_023f;
			IL_023f:
			return string_87;
		}
		catch (Exception)
		{
			return string_87;
		}
	}

	public static string smethod_6(string string_87, ref string string_88, bool bool_14)
	{
		string string_89 = string_88;
		string result = smethod_4(string_87, ref string_89);
		string_88 = string_89;
		string_88 = string_88.Replace("&amp;", "&");
		return result;
	}

	public string Method_SerialInp(string string_87, ref string string_88, bool bool_14)
	{
		string string_89 = string_88;
		string result = smethod_4(string_87, ref string_89);
		string_88 = string_89;
		string_88 = string_88.Replace("&amp;", "&");
		return result;
	}

    public string Method_SerialInp_pho(string A_0, ref string A_1, bool A_2)
    {
        string strHtm = A_0;
        string strAction = A_1;
        bool flag = A_2;
        string text = A_1;
        bool flag2 = A_2;
        strHtm = GetHtmlSerialInpp(strHtm, ref strAction);
        A_1 = strAction;
        A_1 = A_1.Replace("&amp;", "&");
        return strHtm;
    }

    public static string GetHtmlSerialInpp(string strHtm, ref string strAction)
    {
        string text = "";
        try
        {
            string text2 = strHtm.Replace("'", "\"");
            int num = text2.IndexOf("<form", StringComparison.CurrentCultureIgnoreCase);
            if (num < 0)
            {
                if (text2.IndexOf("http://") == 0 || text2.IndexOf("https://") == 0)
                {
                    strAction = text2;
                }
                return text;
            }
            int num2 = 0;
            int num3 = 0;
            try
            {
                int startIndex = text2.IndexOf(" action", num, StringComparison.CurrentCultureIgnoreCase);
                startIndex = text2.IndexOf("=", startIndex, StringComparison.CurrentCultureIgnoreCase);
                startIndex = text2.IndexOf("\"", startIndex) + 1;
                num2 = text2.IndexOf("\"", startIndex);
                strAction = text2.Substring(startIndex, num2 - startIndex);
                strAction = strAction.Replace("&amp;", "&");
            }
            catch
            {
            }
            num = text2.IndexOf("<form", StringComparison.CurrentCultureIgnoreCase);
            num3 = text2.IndexOf("</form", StringComparison.CurrentCultureIgnoreCase);
            while (num > -1)
            {
                string text3 = "";
                int num4 = text2.IndexOf("<input", num, StringComparison.CurrentCultureIgnoreCase);
                int num5 = text2.IndexOf("<select", num, StringComparison.CurrentCultureIgnoreCase);
                int num6 = -1;
                if (num4 == -1 && num5 == -1 && num6 == -1)
                {
                    break;
                }
                int num7 = num4;
                int[] array = new int[3] { num4, num5, num6 };
                for (int i = 1; i < array.Length; i++)
                {
                    if (num7 > array[i] && array[i] != -1)
                    {
                        num7 = array[i];
                    }
                }
                if (num7 == num4)
                {
                    num = num4;
                    text3 = "input";
                }
                else if (num7 == num5)
                {
                    num = num5;
                    text3 = "select";
                }
                else if (num7 == num6)
                {
                    num = num6;
                    text3 = "";
                }
                num = text2.IndexOf("<" + text3, num, StringComparison.CurrentCultureIgnoreCase);
                if (num >= num3)
                {
                    return text;
                }
                num = text2.IndexOf("<input", num, StringComparison.CurrentCultureIgnoreCase);
                num2 = text2.IndexOf(">", num) + 1;
                string text4 = text2.Substring(num, num2 - num);
                text4 = text4.Replace("\t", "").Replace("\n", "").Replace("\r", " ");
                num = num2;
                if (text4.Contains("type=\"submit\""))
                {
                    continue;
                }
                int num8 = 0;
                int num9 = 0;
                num8 = text4.IndexOf(" name=", StringComparison.CurrentCultureIgnoreCase);
                if (num8 == -1)
                {
                    num8 = text4.IndexOf(" name", StringComparison.CurrentCultureIgnoreCase);
                    if (num8 == -1)
                    {
                        continue;
                    }
                }
                string text5 = "";
                num8 = text4.IndexOf("\"", num8) + 1;
                num9 = text4.IndexOf("\"", num8);
                text5 = text4.Substring(num8, num9 - num8);
                num8 = text4.IndexOf(" value=", StringComparison.CurrentCultureIgnoreCase);
                if (num8 == -1)
                {
                    num8 = text4.IndexOf(" value", StringComparison.CurrentCultureIgnoreCase);
                    if (num8 == -1)
                    {
                        continue;
                    }
                }
                string text6 = "";
                if (num8 > -1)
                {
                    if (text4.IndexOf("\"", num8) > -1)
                    {
                        num8 = text4.IndexOf("\"", num8) + 1;
                        num9 = text4.IndexOf("\"", num8);
                    }
                    else if (text4.IndexOf("'", num8) > -1)
                    {
                        num8 = text4.IndexOf("'", num8) + 1;
                        num9 = text4.IndexOf("'", num8);
                    }
                    else
                    {
                        num8 += 7;
                        num9 = text4.IndexOf(">", num8);
                    }
                    text6 = HttpUtility.UrlEncode(text4.Substring(num8, num9 - num8).Replace("&amp;", "&"));
                }
                text5 = text5 + "=" + text6;
                text = (string.IsNullOrEmpty(text) ? text5 : (text + "&" + text5));
            }
        }
        catch
        {
        }
        return text;
    }


    public string Method_SerialInp0(string string_87, ref string string_88, bool bool_14)
	{
		string string_89 = string_88;
		string result = smethod_4_0(string_87, ref string_89);
		string_88 = string_89;
		string_88 = string_88.Replace("&amp;", "&");
		return result;
	}

	public static string smethod_7(string string_87, string string_88, string string_89, string string_90)
	{
		return new Class10().method_2(string_87, string_88, string_89, string_90);
	}

	internal void GetBookPost(ref string url_, ref string postData, ref string reff0, bool isapp, bool adv)
	{
        
        reff0 = "https://www.irctc.co.in/nget/booking/train-list";
        url_ = "https://www.irctc.co.in/eticketing/protected/mapps1/boardingStationEnq";
        postData = "{\"clusterFlag\":\"N\",\"onwardFlag\":\"N\",\"cod\":\"false\",\"reservationMode\":\"WS_TA_B2C\",\"autoUpgradationSelected\":false,\"gnToCkOpted\":false,\"paymentType\":1,\"twoPhaseAuthRequired\":false,\"captureAddress\":0,\"alternateAvlInputDTO\":[{\"trainNo\":\"" + TRAIN_NO + "\",\"destStn\":\"" + DEST_STN + "\",\"srcStn\":\"" + SRC_STN + "\",\"jrnyDate\":\"" + dateTime_0.ToString("yyyMMdd") + "\",\"quotaCode\":\"" + TKT_QUOTA + "\",\"jrnyClass\":\"" + TKT_CLASS + "\",\"concessionPassengers\":false}],\"passBooking\":false,\"journalistBooking\":false}";
        if (isapp)
        {
            postData = "{\"masterId\":null,\"wsUserLogin\":null,\"wsUserPassword\":null,\"wsUserTransactionPassword\":null,\"agentDeviceId\":null,\"alternateAvlInputDTO\":[{\"availabilityStatus\":null,\"avlClasses\":null,\"concessionPassengers\":false,\"currentBooking\":null,\"destStn\":\"" + DEST_STN + "\",\"flexiFlag\":false,\"flexiJrnyDate\":null,\"ftBooking\":false,\"handicapFlag\":null,\"jd\":null,\"jpFlag\":false,\"jrnyClass\":\"" + TKT_CLASS + "\",\"jrnyDate\":\"" + dateTime_0.ToString("yyyMMdd") + "\",\"loyaltyBooking\":false,\"loyaltyRedemptionBooking\":null,\"quotaCode\":\"" + TKT_QUOTA + "\",\"reasonType\":\"\",\"returnTicket\":false,\"srcStn\":\"" + SRC_STN + "\",\"ticketType\":null,\"trainNo\":\"" + TRAIN_NO + "\"}],\"atasOpted\":null,\"autoUpgradationSelected\":false,\"bankId\":0,\"boardingStation\":null,\"bookNowPressTimeDiff\":0,\"bookingChoice\":0,\"bookingConfirmChoice\":0,\"bookingInitTime\":0,\"bookingOTP\":null,\"captcha\":null,\"captureAddress\":0,\"clientTransactionId\":null,\"clusterFlag\":\"N\",\"clusterJourneyClass\":null,\"cod\":\"false\",\"connectedPnrDataDTO\":null,\"connectingJourney\":false,\"covid19\":false,\"enrouteStation\":null,\"ftBooking\":false,\"generalistChildConfirm\":false,\"gnToCkOpted\":false,\"gstDetails\":null,\"hrmsTxnId\":0,\"iTicketDetailsDTO\":null,\"journalistBooking\":false,\"lapAvlRequestDTO\":null,\"loyaltyRedemptionBooking\":false,\"mainJourneyPnr\":null,\"mainJourneyTktId\":null,\"mainJourneyTxnId\":null,\"mobileNumber\":null,\"moreThanOneDay\":null,\"mpBooking\":false,\"mpSecType\":null,\"name\":null,\"nget_transaction_id\":0,\"nlpCaptchaVarsDTO\":null,\"nosbBooking\":false,\"onwardFlag\":\"N\",\"otpBooking\":false,\"passBooking\":false,\"paymentType\":1,\"reservationMode\":\"WS_TA_B2C\",\"reservationUptoStation\":null,\"returnJourney\":false,\"ticketType\":null,\"tktAddress\":null,\"twoPhaseAuthRequired\":false,\"viaPointStation\":null,\"warrentType\":null}";
			postData = "{\"masterId\":null,\"wsUserLogin\":null,\"wsUserPassword\":null,\"wsUserTransactionPassword\":null,\"agentDeviceId\":null,\"alternateAvlInputDTO\":[{\"availabilityStatus\":null,\"avlClasses\":null,\"concessionPassengers\":true,\"currentBooking\":null,\"destStn\":\"" + DEST_STN + "\",\"flexiFlag\":false,\"flexiJrnyDate\":null,\"ftBooking\":false,\"handicapFlag\":null,\"jd\":null,\"jpFlag\":false,\"jrnyClass\":\"" + TKT_CLASS + "\",\"jrnyDate\":\"" + dateTime_0.ToString("yyyMMdd") + "\",\"loyaltyBooking\":false,\"loyaltyRedemptionBooking\":null,\"quotaCode\":\"" + TKT_QUOTA + "\",\"reasonType\":\"\",\"returnTicket\":false,\"srcStn\":\"" + SRC_STN + "\",\"ticketType\":null,\"trainNo\":\"" + TRAIN_NO + "\"}],\"atasOpted\":null,\"autoUpgradationSelected\":false,\"bankId\":0,\"boardingStation\":null,\"bookNowPressTimeDiff\":0,\"bookingChoice\":0,\"bookingConfirmChoice\":0,\"bookingInitTime\":0,\"bookingOTP\":null,\"captcha\":null,\"captureAddress\":0,\"clientTransactionId\":null,\"clusterFlag\":\"N\",\"clusterJourneyClass\":null,\"cod\":\"false\",\"connectedPnrDataDTO\":null,\"connectingJourney\":false,\"covid19\":false,\"enrouteStation\":null,\"ftBooking\":false,\"generalistChildConfirm\":false,\"gnToCkOpted\":false,\"gstDetails\":null,\"hrmsTxnId\":0,\"iTicketDetailsDTO\":null,\"journalistBooking\":false,\"lapAvlRequestDTO\":null,\"loyaltyAccuralBooking\":false,\"loyaltyBankId\":null,\"loyaltyNumber\":null,\"loyaltyRedemptionBooking\":false,\"mainJourneyPnr\":null,\"mainJourneyTktId\":null,\"mainJourneyTxnId\":null,\"mobileNumber\":null,\"moreThanOneDay\":null,\"mpBooking\":false,\"mpSecType\":null,\"name\":null,\"nget_transaction_id\":0,\"nlpCaptchaVarsDTO\":null,\"nosbBooking\":false,\"onwardFlag\":\"N\",\"otpBooking\":false,\"passBooking\":false,\"paymentType\":1,\"reservationMode\":\"WS_TA_B2C\",\"reservationUptoStation\":null,\"returnJourney\":false,\"ticketType\":null,\"tktAddress\":null,\"twoPhaseAuthRequired\":false,\"viaPointStation\":null,\"warrentType\":null}";
		}
    }

    internal void GetBookPost_TEST(ref string url_, ref string postData, ref string reff0, bool isapp, bool adv)
    {

        reff0 = "https://www.irctc.co.in/nget/booking/train-list";
        url_ = "https://www.irctc.co.in/eticketing/protected/mapps1/boardingStationEnq";
        postData = "{\"clusterFlag\":\"N\",\"onwardFlag\":\"N\",\"cod\":\"false\",\"reservationMode\":\"WS_TA_B2C\",\"autoUpgradationSelected\":false,\"gnToCkOpted\":false,\"paymentType\":1,\"twoPhaseAuthRequired\":false,\"captureAddress\":0,\"alternateAvlInputDTO\":[{\"trainNo\":\"" + TRAIN_NO + "\",\"destStn\":\"" + DEST_STN + "\",\"srcStn\":\"" + SRC_STN + "\",\"jrnyDate\":\"" + dateTime_0.ToString("yyyMMdd") + "\",\"quotaCode\":\"" + TKT_QUOTA + "\",\"jrnyClass\":\"" + TKT_CLASS + "\",\"concessionPassengers\":false}],\"passBooking\":false,\"journalistBooking\":false}";
        if (isapp)
        {
            postData = "{\"masterId\":null,\"wsUserLogin\":null,\"wsUserPassword\":null,\"wsUserTransactionPassword\":null,\"agentDeviceId\":null,\"alternateAvlInputDTO\":[{\"availabilityStatus\":null,\"avlClasses\":null,\"concessionPassengers\":false,\"currentBooking\":null,\"destStn\":\"" + DEST_STN + "\",\"flexiFlag\":false,\"flexiJrnyDate\":null,\"ftBooking\":false,\"handicapFlag\":null,\"jd\":null,\"jpFlag\":false,\"jrnyClass\":\"" + TKT_CLASS + "\",\"jrnyDate\":\"" + dateTime_0.ToString("yyyMMdd") + "\",\"loyaltyBooking\":false,\"loyaltyRedemptionBooking\":null,\"quotaCode\":\"" + TKT_QUOTA + "\",\"reasonType\":\"\",\"returnTicket\":false,\"srcStn\":\"" + SRC_STN + "\",\"ticketType\":null,\"trainNo\":\"" + TRAIN_NO + "\"}],\"atasOpted\":null,\"autoUpgradationSelected\":false,\"bankId\":0,\"boardingStation\":null,\"bookNowPressTimeDiff\":0,\"bookingChoice\":0,\"bookingConfirmChoice\":0,\"bookingInitTime\":0,\"bookingOTP\":null,\"captcha\":null,\"captureAddress\":0,\"clientTransactionId\":null,\"clusterFlag\":\"N\",\"clusterJourneyClass\":null,\"cod\":\"false\",\"connectedPnrDataDTO\":null,\"connectingJourney\":false,\"covid19\":false,\"enrouteStation\":null,\"ftBooking\":false,\"generalistChildConfirm\":false,\"gnToCkOpted\":false,\"gstDetails\":null,\"hrmsTxnId\":0,\"iTicketDetailsDTO\":null,\"journalistBooking\":false,\"lapAvlRequestDTO\":null,\"loyaltyRedemptionBooking\":false,\"mainJourneyPnr\":null,\"mainJourneyTktId\":null,\"mainJourneyTxnId\":null,\"mobileNumber\":null,\"moreThanOneDay\":null,\"mpBooking\":false,\"mpSecType\":null,\"name\":null,\"nget_transaction_id\":0,\"nlpCaptchaVarsDTO\":null,\"nosbBooking\":false,\"onwardFlag\":\"N\",\"otpBooking\":false,\"passBooking\":false,\"paymentType\":1,\"reservationMode\":\"WS_TA_B2C\",\"reservationUptoStation\":null,\"returnJourney\":false,\"ticketType\":null,\"tktAddress\":null,\"twoPhaseAuthRequired\":false,\"viaPointStation\":null,\"warrentType\":null}";
            postData = "{\"masterId\":null,\"wsUserLogin\":null,\"wsUserPassword\":null,\"wsUserTransactionPassword\":null,\"agentDeviceId\":null,\"alternateAvlInputDTO\":[{\"availabilityStatus\":null,\"avlClasses\":null,\"concessionPassengers\":true,\"currentBooking\":null,\"destStn\":\"" + DEST_STN + "\",\"flexiFlag\":false,\"flexiJrnyDate\":null,\"ftBooking\":false,\"handicapFlag\":null,\"jd\":null,\"jpFlag\":false,\"jrnyClass\":\"" + TKT_CLASS + "\",\"jrnyDate\":\"" + TKT_QUOTAGN + "\",\"loyaltyBooking\":false,\"loyaltyRedemptionBooking\":null,\"quotaCode\":\"" + TKT_QUOTA + "\",\"reasonType\":\"\",\"returnTicket\":false,\"srcStn\":\"" + SRC_STN + "\",\"ticketType\":null,\"trainNo\":\"" + TRAIN_NO + "\"}],\"atasOpted\":null,\"autoUpgradationSelected\":false,\"bankId\":0,\"boardingStation\":null,\"bookNowPressTimeDiff\":0,\"bookingChoice\":0,\"bookingConfirmChoice\":0,\"bookingInitTime\":0,\"bookingOTP\":null,\"captcha\":null,\"captureAddress\":0,\"clientTransactionId\":null,\"clusterFlag\":\"N\",\"clusterJourneyClass\":null,\"cod\":\"false\",\"connectedPnrDataDTO\":null,\"connectingJourney\":false,\"covid19\":false,\"enrouteStation\":null,\"ftBooking\":false,\"generalistChildConfirm\":false,\"gnToCkOpted\":false,\"gstDetails\":null,\"hrmsTxnId\":0,\"iTicketDetailsDTO\":null,\"journalistBooking\":false,\"lapAvlRequestDTO\":null,\"loyaltyAccuralBooking\":false,\"loyaltyBankId\":null,\"loyaltyNumber\":null,\"loyaltyRedemptionBooking\":false,\"mainJourneyPnr\":null,\"mainJourneyTktId\":null,\"mainJourneyTxnId\":null,\"mobileNumber\":null,\"moreThanOneDay\":null,\"mpBooking\":false,\"mpSecType\":null,\"name\":null,\"nget_transaction_id\":0,\"nlpCaptchaVarsDTO\":null,\"nosbBooking\":false,\"onwardFlag\":\"N\",\"otpBooking\":false,\"passBooking\":false,\"paymentType\":1,\"reservationMode\":\"WS_TA_B2C\",\"reservationUptoStation\":null,\"returnJourney\":false,\"ticketType\":null,\"tktAddress\":null,\"twoPhaseAuthRequired\":false,\"viaPointStation\":null,\"warrentType\":null}";
        }
    }

    internal void GetBookPost_adv(ref string url_, ref string postData, ref string reff0)
    {
        reff0 = "https://www.irctc.co.in/nget/booking/train-list";
        url_ = "https://www.irctc.co.in/eticketing/protected/mapps1/boardingStationEnq";
        postData = "{\"clusterFlag\":\"N\",\"onwardFlag\":\"N\",\"cod\":\"false\",\"reservationMode\":\"WS_TA_B2C\",\"autoUpgradationSelected\":false,\"gnToCkOpted\":true,\"paymentType\":1,\"twoPhaseAuthRequired\":false,\"captureAddress\":0,\"alternateAvlInputDTO\":[{\"trainNo\":\"" + TRAIN_NO + "\",\"destStn\":\"" + DEST_STN + "\",\"srcStn\":\"" + SRC_STN + "\",\"jrnyDate\":\"" + dateTime_0.ToString("yyyMMdd") + "\",\"quotaCode\":\"" + TKT_QUOTA + "\",\"jrnyClass\":\"" + TKT_CLASS + "\"}],\"passBooking\":false,\"journalistBooking\":false}";
    }


    public static string Encrypt(string string_0, string string_4)
	{
		byte[] rgbIV = new byte[8] { 18, 52, 86, 120, 144, 171, 205, 239 };
		byte[] bytes = Encoding.UTF8.GetBytes(Strings.Left(string_4, 8));
		DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
		byte[] bytes2 = Encoding.UTF8.GetBytes(string_0);
		MemoryStream memoryStream = new MemoryStream();
		CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(bytes, rgbIV), CryptoStreamMode.Write);
		cryptoStream.Write(bytes2, 0, bytes2.Length);
		cryptoStream.FlushFinalBlock();
		return Convert.ToBase64String(memoryStream.ToArray());
	}

	public static string Decrypt(string string_0, string string_4)
	{
		if (string.IsNullOrEmpty(string_4))
		{
			string_4 = "4t56765y";
		}
		byte[] rgbIV = new byte[8] { 18, 52, 86, 120, 144, 171, 205, 239 };
		try
		{
			byte[] bytes = Encoding.UTF8.GetBytes(string_4.Substring(0, 8));
			DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
			byte[] array = Convert.FromBase64String(string_0);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(bytes, rgbIV), CryptoStreamMode.Write);
			cryptoStream.Write(array, 0, array.Length);
			cryptoStream.FlushFinalBlock();
			return Encoding.UTF8.GetString(memoryStream.ToArray());
		}
		catch (Exception ex)
		{
			return ex.Message;
		}
	}

	internal static string GetLocalTime()
	{
		return DateTime.Now.ToString("ddd MMM dd yyyy HHmmss \"GMT\"zzz", CultureInfo.CreateSpecificCulture("en-US")).Replace(",", "").Replace(":", "")
			.Replace("+", "");
	}

    internal string AvailablityPost(ref string requestUrl, bool isAPP, int PairID)
    {
        string text = "";
        requestUrl = "https://www.irctc.co.in/eticketing/protected/mapps1/avlFarenquiry/" + TRAIN_NO + "/" + dateTime_0.ToString("yyyMMdd") + "/" + SRC_STN + "/" + DEST_STN + "/" + TKT_CLASS + "/" + TKT_QUOTA + "/N";
        text = "{\"paymentFlag\":\"N\",\"concessionBooking\":false,\"ftBooking\":false,\"loyaltyRedemptionBooking\":false,\"ticketType\":\"E\",\"quotaCode\":\"" + TKT_QUOTA + "\",\"moreThanOneDay\":true,\"trainNumber\":\"" + TRAIN_NO + "\",\"fromStnCode\":\"" + SRC_STN + "\",\"toStnCode\":\"" + DEST_STN + "\",\"isLogedinReq\":true,\"journeyDate\":\"" + dateTime_0.ToString("yyyMMdd") + "\",\"classCode\":\"" + TKT_CLASS + "\"}";
        if (isAPP)
        {
            requestUrl = "https://www.irctc.co.in/eticketing/protected/mapps1/allLapAvlEnq";
            text = "{\"wsUserLogin\":\"\",\"ftBooking\":false,\"autoUpgradationSelected\":false,\"bookNowPressTimeDiff\":0,\"tktAddress\":{\"pinCode\":0,\"postOffice\":\"\",\"addressFlag\":0,\"colony\":\"\",\"street\":\"\",\"stateName\":\"\",\"address\":\"\",\"validRegdAddress\":false,\"city\":\"\",\"country\":\"\",\"phoneExt\":0,\"phoneNumber\":0},\"connectingJourney\":false,\"gnToCkOpted\":false,\"alternateAvlInputDTO\":[{\"trainNo\":\"" + TRAIN_NO + "\",\"avlClasses\":[\"" + TKT_CLASS + "\"],\"srcStn\":\"" + SRC_STN + "\",\"ftBooking\":false,\"returnTicket\":false,\"quotaCode\":\"" + TKT_QUOTA + "\",\"reasonType\":\"\",\"jpFlag\":false,\"jrnyClass\":\"" + TKT_CLASS + "\",\"jrnyDate\":\"" + dateTime_0.ToString("yyyMMdd") + "\",\"concessionPassengers\":false,\"loyaltyBooking\":false,\"destStn\":\"" + DEST_STN + "\",\"concessionBooking\":false}],\"loyaltyRedemptionBooking\":false,\"moreThanOneDay\":false,\"paymentType\":1,\"reservationMode\":\"WS_TA_B2C\",\"generalistChildConfirm\":false,\"bookingInitTime\":0,\"bookingConfirmChoice\":0,\"cod\":\"false\",\"bookingChoice\":0,\"onwardFlag\":\"N\",\"clusterFlag\":\"N\"}";
        }
        return text;
    }
}
