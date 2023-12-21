using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Ionic.Zip;
using Microsoft.VisualBasic;

internal class frmCAP : Form
{
	[CompilerGenerated]
	private sealed class Class33
	{
		public Random random_0;

		internal char method_0(string string_0)
		{
			return string_0[random_0.Next(string_0.Length)];
		}
	}

	private static readonly IntPtr intptr_0 = new IntPtr(-1);

	private IntPtr intptr_1 = IntPtr.Zero;

	private Control control_0;

	private StringBuilder stringBuilder_0 = new StringBuilder(256);

	private object object_0;

	private string string_0;

	private bool bool_0;

	private bool bool_1;

	private Bitmap bitmap_0;

	private clsMain class28_0;

	internal string string_1;

	internal string string_2;

	private string string_3;

	private string string_4;

	private string string_5;

	private string string_6;

	private string string_7 = "t0068MgAAAERBVGbU0doQNALeQNjb4EluWL7F3Z7VIRl1xNDM9N3YJi0ZXpzT68l6lZPPOAyQM6VYKvBzNBAW6e8m7ODgk2s=";

	private Dictionary<string, string> dictionary_0 = new Dictionary<string, string>();

	private IContainer icontainer_0;

	private BunifuElipse bunifuElipse_0;

	private Panel pnlHeader;

	internal Label tktname;

	private BunifuImageButton btnCancel;

	private PictureBox picOriginal;

	public Button btnSubmit;

	internal TextBox txtImageData;

	public Button btnReferesh;

	private Panel panel1;

	private Button btnREF;

	private IContainer components;

	private System.Windows.Forms.Timer timer1;

	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	internal static extern bool SetWindowPos(IntPtr intptr_2, IntPtr intptr_3, int int_0, int int_1, int int_2, int int_3, uint uint_0);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern IntPtr GetFocus();

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	private static extern IntPtr GetForegroundWindow();

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	private static extern bool SetForegroundWindow(IntPtr intptr_2);

	[DllImport("user32.dll", SetLastError = true)]
	private static extern IntPtr SetParent(IntPtr intptr_2, IntPtr intptr_3);

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern int GetClassName(IntPtr intptr_2, StringBuilder stringBuilder_1, int int_0);

	internal frmCAP(clsMain class28_1)
	{
		InitializeComponent();
		class28_0 = class28_1;
	}

	private string method_0(Image image_0)
	{
		try
		{
			MemoryStream memoryStream = new MemoryStream();
			image_0.Save(memoryStream, ImageFormat.Bmp);
			memoryStream.Position = 0L;
			return Convert.ToBase64String(memoryStream.ToArray());
		}
		catch (Exception)
		{
			return "Error converting image to base64!";
		}
	}

	private string method_1(int int_0, string string_8)
	{
		Random random_0 = new Random();
		return new string((from string_0 in Enumerable.Repeat(string_8, int_0)
			select string_0[random_0.Next(string_0.Length)]).ToArray());
	}

	internal void method_2(Control control_1, Rectangle rectangle_0)
	{
		Control control = control_1.Controls[0];
		Control control2 = control_1.Parent;
		base.Size = rectangle_0.Size;
		base.StartPosition = FormStartPosition.Manual;
		base.Location = control2.Location;
		base.Left += 2;
		base.Height += -6;
		base.TopMost = true;
	}

	internal Bitmap method_3(Bitmap bitmap_1)
	{
		Color white = Color.White;
		Color pixel = bitmap_1.GetPixel(0, 0);
		Bitmap bitmap = new Bitmap(bitmap_1.Width, bitmap_1.Height);
		for (int i = 0; i < bitmap_1.Width; i++)
		{
			for (int j = 0; j < bitmap_1.Height; j++)
			{
				Color pixel2 = bitmap_1.GetPixel(i, j);
				if ((pixel2.R == pixel.R) & (pixel2.G == pixel.G) & (pixel2.B == pixel.B))
				{
					bitmap.SetPixel(i, j, white);
				}
				else
				{
					bitmap.SetPixel(i, j, pixel2);
				}
			}
		}
		return bitmap;
	}

	internal void method_4(Control control_1, Rectangle rectangle_0, Bitmap bitmap_1, string string_8, string string_9, string string_10)
	{
		method_2(control_1, rectangle_0);
		string_1 = string_8;
		string_2 = string_9;
		try
		{
			string_0 = string_10;
			try
			{
				method_5();
				frmCaptcha.SetWindowPos(base.Handle, intptr_0, 0, 0, 0, 0, 3u);
				btnReferesh_Click(null, null);
			}
			catch
			{
			}
			base.TopMost = true;
			ShowDialog();
		}
		catch (Exception)
		{
		}
	}

	private void btnReferesh_Click(object sender, EventArgs e)
	{
		try
		{
			txtImageData.Text = "";
			ThreadPool.QueueUserWorkItem(method_6, null);
		}
		catch
		{
		}
	}

	private void method_5()
	{
		try
		{
			intptr_1 = GetForegroundWindow();
			if (intptr_1 != IntPtr.Zero)
			{
				GetClassName(intptr_1, stringBuilder_0, stringBuilder_0.Capacity);
				control_0 = Control.FromHandle(intptr_1);
			}
		}
		catch
		{
			intptr_1 = IntPtr.Zero;
		}
	}

	private void method_6(object object_1)
	{
		try
		{
			string text = "";
			Bitmap bitmap = new Bitmap(method_11(string_0));
			if (bitmap.Height == 270 && bitmap.Width == 300)
			{
				picOriginal.BackgroundImageLayout = ImageLayout.Stretch;
				picOriginal.SizeMode = PictureBoxSizeMode.AutoSize;
				picOriginal.Location = new Point(0, -160);
				picOriginal.Image = bitmap;
				picOriginal.Refresh();
			}
			else if (bitmap.Height > 265)
			{
				bool_0 = false;
				bool_1 = true;
				picOriginal.Image = bitmap;
				picOriginal.Refresh();
				picOriginal.Location = new Point(-30, -217);
			}
			else if (bitmap.Height < 25)
			{
				int num = bitmap.Width;
				int num2 = bitmap.Height;
				bool_1 = false;
				bool_0 = false;
				picOriginal.Width = num;
				picOriginal.Height = num2;
				picOriginal.Location = new Point(-140, 31);
				picOriginal.Image = bitmap;
				picOriginal.Refresh();
			}
			else
			{
				if ((bitmap.Height > 90) & (bitmap.Height < 100))
				{
					picOriginal.Location = new Point(0, 21);
					picOriginal.Image = bitmap;
					picOriginal.Refresh();
					bool_0 = true;
					base.Height += 20;
				}
				if (bitmap.Height == 150 && bitmap.Width == 308)
				{
					picOriginal.Width = 219;
					picOriginal.Height = 100;
					picOriginal.Image = bitmap;
					picOriginal.BackgroundImageLayout = ImageLayout.Stretch;
					picOriginal.SizeMode = PictureBoxSizeMode.StretchImage;
					picOriginal.Location = new Point(0, -15);
					picOriginal.Refresh();
				}
				else
				{
					bool_0 = true;
					picOriginal.Location = new Point(0, 21);
					picOriginal.Image = bitmap;
					picOriginal.Refresh();
					base.Size = picOriginal.Size;
				}
			}
			if (!bool_0)
			{
				bool bool_ = clsMain.bool_16;
			}
			if (!(text != ""))
			{
				return;
			}
			txtImageData.Text = text;
			if (clsMain.bool_17 && (((text.Length > 3) & (text.Length < 7)) || (!bool_1 && text != "")))
			{
				if ((!bool_1 & !bool_0) && text.Contains(" "))
				{
					text = text.Replace(" ", "");
				}
				btnSubmit_Click(null, null);
			}
		}
		catch (Exception)
		{
		}
	}

	internal string method_7(Bitmap bitmap_1)
	{
		return "";
	}

	internal string method_8(Bitmap bitmap_1)
	{
		string str = Img2Base64(bitmap_1);
		return GetGoogleReCaptcha(1, str);
	}

	public static string Img2Base64(Bitmap bmp2)
	{
		string result = "";
		try
		{
			MemoryStream memoryStream = new MemoryStream();
			bmp2.Save(memoryStream, ImageFormat.Png);
			result = Convert.ToBase64String(memoryStream.ToArray());
		}
		catch
		{
		}
		return result;
	}

	internal string GetGoogleReCaptcha(int Y, string str3)
	{
		WebProxy webProxy_ = null;
		CookieContainer cookieContainer_ = new CookieContainer();
		string text = "2fda665461c9add243d65780be6e1bfb";
		string text2 = "";
		string string_ = "https://2captcha.com/in.php";
		string string_2 = "";
		string string_3 = "";
		string string_4;
		if (Y != 0 && Y == 1)
		{
			string_4 = "https://2captcha.com/in.php";
			string string_5 = "key=" + text + "&method=base64&body=" + HttpUtility.UrlEncode(str3);
			method_SBI(string_4, string_5, string_, "", 1, ref webProxy_, ref cookieContainer_, true, 50000, ref string_2, ref string_3);
			if (string_2 == "ERROR_ZERO_BALANCE")
			{
				MessageBox.Show("ERROR_ZERO_BALANCE");
				return "";
			}
			text2 = string_2.Substring(string_2.IndexOf("|") + 1);
		}
		string_4 = "https://2captcha.com/res.php?key=" + text + "&action=get&id=" + text2;
		do
		{
			Thread.Sleep(3000);
			method_SBI(string_4, "", string_, "", 1, ref webProxy_, ref cookieContainer_, true, 50000, ref string_2, ref string_3);
		}
		while (!string_2.Contains("OK"));
		return string_2.Substring(string_2.IndexOf("|") + 1);
	}

	public bool method_SBI(string string_14, string string_15, string string_16, string string_63i, int int_0, ref WebProxy webProxy_0, ref CookieContainer cookieContainer_1, bool bool_1, int int_1, ref string string_17, ref string string_18)
	{
		int num = 0;
		string text = "Tls";
		bool result;
		while (true)
		{
			string_18 = "";
			string_17 = "";
			result = false;
			HttpWebResponse httpWebResponse = null;
			HttpWebRequest httpWebRequest = null;
			string text2 = "";
			try
			{
				num++;
				if ((text == "Tls") | (text == "Ssl3"))
				{
					ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;
				}
				else if (text == "Tls12")
				{
					ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				}
				httpWebRequest = (HttpWebRequest)WebRequest.Create(string_14);
				httpWebRequest.Proxy = webProxy_0;
				httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
				if (int_1 > 0)
				{
					httpWebRequest.Timeout = int_1;
					httpWebRequest.ReadWriteTimeout = int_1;
				}
				ServicePoint servicePoint = ServicePointManager.FindServicePoint(new Uri(string_14));
				servicePoint.ConnectionLimit = 65000;
				servicePoint.Expect100Continue = false;
				servicePoint.UseNagleAlgorithm = false;
				servicePoint.MaxIdleTime = 60000;
				servicePoint.ConnectionLeaseTimeout = 60000;
				ServicePointManager.Expect100Continue = true;
				byte[] bytes = Encoding.UTF8.GetBytes(string_15);
				if (bool_1)
				{
					if (cookieContainer_1 == null)
					{
						cookieContainer_1 = new CookieContainer();
					}
					httpWebRequest.CookieContainer = cookieContainer_1;
				}
				httpWebRequest.Referer = string_16;
				httpWebRequest.Method = "POST";
				httpWebRequest.ContentLength = bytes.Length;
				httpWebRequest.ContentType = "application/x-www-form-urlencoded";
				if (string_16.Contains("json"))
				{
					httpWebRequest.ContentType = "application/json";
				}
				httpWebRequest.KeepAlive = true;
				httpWebRequest.UserAgent = "Apache-HttpClient/android/" + string_16;
				if (!string.IsNullOrEmpty(string_63i))
				{
					string[] array = Strings.Split(string_63i, "||");
					int num2 = Information.UBound(array);
					for (int i = 0; i <= num2; i++)
					{
						string[] array2 = Strings.Split(array[i], "#");
						httpWebRequest.Headers.Set(array2[0], array2[1]);
					}
				}
				if (string_15.Length > 0)
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
				using (StreamReader textReader_ = smethod_105(httpWebResponse.GetResponseStream()))
				{
					text2 = smethod_106(textReader_);
				}
				string_17 = text2;
				result = true;
			}
			catch (WebException ex)
			{
				result = false;
				string_18 = ex.Message;
				if (!string_18.ToUpper().Contains("CONNECTION WAS CLOSED"))
				{
					bool flag = !string_18.ToUpper().Contains("SERVICEUNAVAILABLE");
				}
				if (string_18.Contains("The underlying connection was closed"))
				{
					text = "Tls12";
				}
				if (num < 2)
				{
					continue;
				}
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
			break;
		}
		return result;
	}

	public StreamReader smethod_105(Stream stream_0)
	{
		return new StreamReader(stream_0);
	}

	public string smethod_106(TextReader textReader_0)
	{
		return textReader_0.ReadToEnd();
	}

	private void method_9(short short_0)
	{
	}

	internal string method_10(string string_8)
	{
		try
		{
			smethod_0(0);
			int.TryParse(Environment.GetEnvironmentVariable("OCR", EnvironmentVariableTarget.Process), out clsMain.int_1);
			DateTime now = DateTime.Now;
			string path = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Microsoft"), "nlpcap3");
			string arguments = "Nget|" + string_8;
			Process process = new Process();
			process.StartInfo.FileName = Path.Combine(path, "nlp_OCR.exe");
			process.StartInfo.Arguments = arguments;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardOutput = true;
			process.Start();
			StreamReader standardOutput = process.StandardOutput;
			process.WaitForExit(3500);
			string text = standardOutput.ReadLine();
			text = text.Replace(" ", "").Replace(":", "").Replace(".", "")
				.Replace(";", "")
				.Replace(",", "")
				.Replace("\"", "")
				.Replace("/", "")
				.Replace("|", "I")
				.Replace("&", "8");
			if (!process.HasExited)
			{
				process.Kill();
			}
			if (clsMain.int_1 == 0)
			{
				if (text.Length > 6)
				{
					text = text.Replace("S9", "9").Replace("9S", "9");
					text = text.Replace("S5", "5").Replace("5S", "5");
					text = text.Replace("0O", "0").Replace("O0", "0");
					text = text.Replace("86", "5");
					text = text.Replace("RAR", "AA");
					text = text.Replace("SA", "8");
					text = text.Replace("71", "1");
					text = text.Replace("S8", "8");
					text = text.Replace("S3", "3");
					text = text.Replace("B8", "5");
					text = text.Replace("6E", "6");
					text = text.Replace("1i", "1");
					text = text.Replace("jJ", "J");
				}
				text = text.Replace("2Z2", "Z");
				text = text.Replace("1I", "1");
				text = text.Replace("@", "");
				text = text.Replace("(", "L");
				return text.Replace("S9", "9");
			}
			return text;
		}
		catch (Exception)
		{
			return "";
		}
	}

	internal static void smethod_0(object object_1)
	{
		string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
		folderPath = Path.Combine(folderPath, "Microsoft");
		folderPath = Path.Combine(folderPath, "nlpcap3");
		if (!Directory.Exists(folderPath))
		{
			Directory.CreateDirectory(folderPath);
		}
		string path = Path.Combine(folderPath, "tessdata");
		bool flag = true;
		if (!File.Exists(Path.Combine(folderPath, "Dynamsoft.ImageCore.dll")))
		{
			flag = false;
		}
		else if (!File.Exists(Path.Combine(folderPath, "Dynamsoft.OCR.dll")))
		{
			flag = false;
		}
		else if (!File.Exists(Path.Combine(folderPath, "nlp_OCR.exe")))
		{
			flag = false;
		}
		else if (!File.Exists(Path.Combine(path, "eng.traineddata")))
		{
			flag = false;
		}
		string text = Path.Combine(folderPath, "NLP.dll");
		string text2 = Path.Combine(folderPath, "NLP.zip");
		if (!flag && !File.Exists(text))
		{
			Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("^.Booking.include.NLP.dll");
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
		if (!File.Exists(text))
		{
			return;
		}
		if (!File.Exists(text2))
		{
			File.Copy(text, text2, true);
		}
		File.Delete(text);
		try
		{
			ZipFile zipFile = ZipFile.Read(text2);
			try
			{
				zipFile.ExtractAll(folderPath);
			}
			finally
			{
				zipFile?.Dispose();
			}
			File.Delete(text2);
		}
		catch (Exception)
		{
		}
	}

	internal static void smethod_1(object object_1)
	{
		string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
		folderPath = Path.Combine(folderPath, "Microsoft");
		folderPath = Path.Combine(folderPath, "nlpcap2");
		if (!Directory.Exists(folderPath))
		{
			Directory.CreateDirectory(folderPath);
		}
		string path = Path.Combine(folderPath, "x86");
		string path2 = Path.Combine(folderPath, "x64");
		string path3 = Path.Combine(folderPath, "tessdata");
		bool flag = true;
		if (!File.Exists(Path.Combine(path2, "leptonica-1.78.0.dll")))
		{
			flag = false;
		}
		else if (!File.Exists(Path.Combine(path2, "tesseract41.dll")))
		{
			flag = false;
		}
		else if (!File.Exists(Path.Combine(path, "leptonica-1.78.0.dll")))
		{
			flag = false;
		}
		else if (!File.Exists(Path.Combine(path, "tesseract41.dll")))
		{
			flag = false;
		}
		else if (!File.Exists(Path.Combine(path3, "eng.traineddata")))
		{
			flag = false;
		}
		else if (!File.Exists("libcap.dll"))
		{
			flag = false;
		}
		else if (!File.Exists("Tesseract.dll"))
		{
			flag = false;
		}
		string text = Path.Combine(folderPath, "TMD.dll");
		if (!flag && !File.Exists(text))
		{
			Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("^.Booking.include.TMD.dll");
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
		if (!File.Exists(text))
		{
			return;
		}
		if (!File.Exists(Path.Combine(folderPath, "TMD.zip")))
		{
			File.Copy(text, "TMD.zip", true);
		}
		File.Delete(text);
		try
		{
			ZipFile zipFile = ZipFile.Read("TMD.zip");
			try
			{
				zipFile.ExtractAll(folderPath);
			}
			finally
			{
				zipFile?.Dispose();
			}
			File.Delete("TMD.zip");
		}
		catch (Exception)
		{
		}
	}

	internal Image method_11(string string_8)
	{
		byte[] array = Convert.FromBase64String(string_8);
		using (MemoryStream stream = new MemoryStream(array, 0, array.Length))
		{
			return Image.FromStream(stream, true);
		}
	}

	private void btnSubmit_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	private void txtImageData_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			btnSubmit_Click(null, null);
		}
	}

	private void btnREF_Click(object sender, EventArgs e)
	{
		try
		{
			btnREF.Visible = false;
			txtImageData.Text = "";
			method_12(0);
		}
		catch
		{
		}
	}

	private void method_12(object object_1)
	{
		if (class28_0.LoadNlpCaptcha(string_1, ref string_2, ref bitmap_0, ref string_0))
		{
			ThreadPool.QueueUserWorkItem(method_6, null);
		}
		btnREF.Visible = true;
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCAP));
            this.bunifuElipse_0 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtImageData = new System.Windows.Forms.TextBox();
            this.btnReferesh = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnREF = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.tktname = new System.Windows.Forms.Label();
            this.btnCancel = new Bunifu.Framework.UI.BunifuImageButton();
            this.picOriginal = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse_0
            // 
            this.bunifuElipse_0.ElipseRadius = 5;
            this.bunifuElipse_0.TargetControl = this;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.Lime;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.ForeColor = System.Drawing.Color.Black;
            this.btnSubmit.Location = new System.Drawing.Point(128, 6);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(95, 26);
            this.btnSubmit.TabIndex = 1196;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtImageData
            // 
            this.txtImageData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtImageData.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImageData.Location = new System.Drawing.Point(8, 6);
            this.txtImageData.Margin = new System.Windows.Forms.Padding(2);
            this.txtImageData.MaxLength = 20;
            this.txtImageData.Name = "txtImageData";
            this.txtImageData.Size = new System.Drawing.Size(113, 28);
            this.txtImageData.TabIndex = 1197;
            this.txtImageData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtImageData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImageData_KeyPress);
            // 
            // btnReferesh
            // 
            this.btnReferesh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(49)))), ((int)(((byte)(146)))));
            this.btnReferesh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReferesh.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnReferesh.ForeColor = System.Drawing.Color.White;
            this.btnReferesh.Location = new System.Drawing.Point(372, 32);
            this.btnReferesh.Margin = new System.Windows.Forms.Padding(4);
            this.btnReferesh.Name = "btnReferesh";
            this.btnReferesh.Size = new System.Drawing.Size(92, 26);
            this.btnReferesh.TabIndex = 1196;
            this.btnReferesh.Text = "Submit Payment";
            this.btnReferesh.UseVisualStyleBackColor = false;
            this.btnReferesh.Visible = false;
            this.btnReferesh.Click += new System.EventHandler(this.btnReferesh_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.btnREF);
            this.panel1.Controls.Add(this.btnSubmit);
            this.panel1.Controls.Add(this.txtImageData);
            this.panel1.Location = new System.Drawing.Point(0, 56);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 36);
            this.panel1.TabIndex = 1198;
            // 
            // btnREF
            // 
            this.btnREF.BackColor = System.Drawing.Color.Yellow;
            this.btnREF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnREF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnREF.Location = new System.Drawing.Point(226, 6);
            this.btnREF.Margin = new System.Windows.Forms.Padding(2);
            this.btnREF.Name = "btnREF";
            this.btnREF.Size = new System.Drawing.Size(32, 26);
            this.btnREF.TabIndex = 1198;
            this.btnREF.UseVisualStyleBackColor = false;
            this.btnREF.Click += new System.EventHandler(this.btnREF_Click);
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
            this.pnlHeader.Size = new System.Drawing.Size(275, 22);
            this.pnlHeader.TabIndex = 1190;
            // 
            // tktname
            // 
            this.tktname.AutoSize = true;
            this.tktname.BackColor = System.Drawing.Color.Transparent;
            this.tktname.ForeColor = System.Drawing.Color.White;
            this.tktname.Location = new System.Drawing.Point(-1, 2);
            this.tktname.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.tktname.Name = "tktname";
            this.tktname.Size = new System.Drawing.Size(51, 15);
            this.tktname.TabIndex = 1189;
            this.tktname.Text = "tktname";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageActive = null;
            this.btnCancel.Location = new System.Drawing.Point(254, -1);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(19, 19);
            this.btnCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnCancel.TabIndex = 1188;
            this.btnCancel.TabStop = false;
            this.btnCancel.Zoom = 10;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // picOriginal
            // 
            this.picOriginal.Location = new System.Drawing.Point(-56, 25);
            this.picOriginal.Margin = new System.Windows.Forms.Padding(2);
            this.picOriginal.Name = "picOriginal";
            this.picOriginal.Size = new System.Drawing.Size(308, 20);
            this.picOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picOriginal.TabIndex = 1191;
            this.picOriginal.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmCAP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(275, 92);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnReferesh);
            this.Controls.Add(this.picOriginal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmCAP";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "frmCAP";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).EndInit();
            this.ResumeLayout(false);

	}
}
