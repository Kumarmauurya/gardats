using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class frmOTP : Form
{
	internal string string_0;

	internal string string_1;

	private bool bool_0;

	private bool bool_1;

	private static readonly IntPtr intptr_0 = new IntPtr(-1);

	private IContainer icontainer_0;

	private BunifuElipse bunifuElipse_0;

	private Label label1;

	private TextBox textotp;

	private Button Submit;

	private Panel pnlHeader;

	internal Label tktname;

	private BunifuImageButton btnCancel;
    private Button button1;
    private IContainer components;

	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	internal static extern bool SetWindowPos(IntPtr intptr_1, IntPtr intptr_2, int int_0, int int_1, int int_2, int int_3, uint uint_0);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern IntPtr GetFocus();

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	private static extern IntPtr GetForegroundWindow();

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	private static extern bool SetForegroundWindow(IntPtr intptr_1);

	[DllImport("user32.dll", SetLastError = true)]
	private static extern IntPtr SetParent(IntPtr intptr_1, IntPtr intptr_2);

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern int GetClassName(IntPtr intptr_1, StringBuilder stringBuilder_0, int int_0);

	public frmOTP()
	{
		InitializeComponent();
	}

	internal void method_0(Control control_0, Rectangle rectangle_0)
	{
		Control control = control_0.Controls[0];
		base.Size = control_0.Size;
		base.Height = control_0.Height - 13;
		Control control2 = control_0.Parent;
		base.StartPosition = FormStartPosition.Manual;
		base.Location = control2.Location;
		base.TopMost = true;
	}

	internal void method_1(Control control_0, Rectangle rectangle_0, bool bool_2, string string_2, string string_3)
	{
		try
		{
			string text = string_3.Split('_')[0];
			if (text.Contains("AIRTELMONEY") || text.Contains("PAYTM") || text.Contains("iMudra"))
			{
				clsMain.dictionary_7.TryGetValue(string_3, out string_1);
			}
			else
			{
				string_1 = Environment.GetEnvironmentVariable("clientID", EnvironmentVariableTarget.Process);
			}
			if (bool_2)
			{
				label1.Text = "Getting OTP ! Please Wait...";
				//ThreadPool.QueueUserWorkItem(method_3, string_3);
			}
			else
			{
				label1.Text = "Enter OTP From Mobile";
			}
            button1.Visible = false;
            tktname.Text = string_2;
			method_0(control_0, rectangle_0);
			SetWindowPos(base.Handle, intptr_0, 0, 0, 0, 0, 3u);
			ShowDialog();
		}
		catch (ThreadAbortException)
		{
			Thread.ResetAbort();
		}
	}

    internal void method_1D(Control control_0, Rectangle rectangle_0, bool bool_2, string string_2, string string_3)
    {
        try
        {
            string text = string_3.Split('_')[0];
            if (text.Contains("AIRTELMONEY") || text.Contains("PAYTM") || text.Contains("iMudra"))
            {
                clsMain.dictionary_7.TryGetValue(string_3, out string_1);
            }
            else
            {
                string_1 = Environment.GetEnvironmentVariable("clientID", EnvironmentVariableTarget.Process);
            }
            if (bool_2)
            {
                label1.Text = string_2;//"Getting OTP ! Please Wait...";
                ThreadPool.QueueUserWorkItem(method_3, string_1);
                //method_3DEL();
                //ThreadPool.QueueUserWorkItem(method_3 , "");
            }
            else
            {
                label1.Text = string_2;
            }
            button1.Visible = false;

            tktname.Text = string_2;
            method_0(control_0, rectangle_0);
            SetWindowPos(base.Handle, intptr_0, 0, 0, 0, 0, 3u);
            ShowDialog();
        }
        catch (ThreadAbortException)
        {
            Thread.ResetAbort();
        }
    }

    internal void method_1AIRTELDC(Control control_0, Rectangle rectangle_0, bool bool_2, string string_2, string string_3)
    {
        try
        {
            string text = string_3.Split('_')[0];
            if (text.Contains("PAYTM") || text.Contains("iMudra"))
            {
                clsMain.dictionary_7.TryGetValue(string_3, out string_1);
            }
            else
            {
                string_1 = Environment.GetEnvironmentVariable("clientID", EnvironmentVariableTarget.Process);
            }
            if (bool_2)
            {
                label1.Text = string_2;//"Getting OTP ! Please Wait...";
                ThreadPool.QueueUserWorkItem(method_3_AIRTELDC, string_1);
                //method_3DEL();
                //ThreadPool.QueueUserWorkItem(method_3 , "");
            }
            else
            {
                label1.Text = string_2;
            }
            button1.Visible = false;

            tktname.Text = string_2;
            method_0(control_0, rectangle_0);
            SetWindowPos(base.Handle, intptr_0, 0, 0, 0, 0, 3u);
            ShowDialog();
        }
        catch (ThreadAbortException)
        {
            Thread.ResetAbort();
        }
    }

    internal void method_1AxisDc(Control control_0, Rectangle rectangle_0, bool bool_2, string string_2, string string_3)
    {
        try
        {
            string text = string_3.Split('_')[0];
            if (text.Contains("AIRTELMONEY") || text.Contains("PAYTM") || text.Contains("iMudra"))
            {
                clsMain.dictionary_7.TryGetValue(string_3, out string_1);
            }
            else
            {
                string_1 = Environment.GetEnvironmentVariable("clientID", EnvironmentVariableTarget.Process);
            }
            if (bool_2)
            {
                label1.Text = string_2;//"Getting OTP ! Please Wait...";
                ThreadPool.QueueUserWorkItem(method_3_AxisDC, string_1);
                //method_3DEL();
                //ThreadPool.QueueUserWorkItem(method_3 , "");
            }
            else
            {
                label1.Text = string_2;
            }
            button1.Visible = false;

            tktname.Text = string_2;
            method_0(control_0, rectangle_0);
            SetWindowPos(base.Handle, intptr_0, 0, 0, 0, 0, 3u);
            ShowDialog();
        }
        catch (ThreadAbortException)
        {
            Thread.ResetAbort();
        }
    }

    internal void method_1PaytmDc(Control control_0, Rectangle rectangle_0, bool bool_2, string string_2, string string_3)
    {
        try
        {
            string text = string_3.Split('_')[0];
            if (text.Contains("AIRTELMONEY") || text.Contains("iMudra"))
            {
                clsMain.dictionary_7.TryGetValue(string_3, out string_1);
            }
            else
            {
                string_1 = Environment.GetEnvironmentVariable("clientID", EnvironmentVariableTarget.Process);
            }
            if (bool_2)
            {
                label1.Text = string_2;//"Getting OTP ! Please Wait...";
                ThreadPool.QueueUserWorkItem(method_3_PAYTMDC, string_1);
                //method_3DEL();
                //ThreadPool.QueueUserWorkItem(method_3 , "");
            }
            else
            {
                label1.Text = string_2;
            }
            button1.Visible = false;

            tktname.Text = string_2;
            method_0(control_0, rectangle_0);
            SetWindowPos(base.Handle, intptr_0, 0, 0, 0, 0, 3u);
            ShowDialog();
           
        }
        catch (ThreadAbortException)
        {
            Thread.ResetAbort();
        }
    }

    internal void method_1ICICDC(Control control_0, Rectangle rectangle_0, bool bool_2, string string_2, string string_3)
    {
        try
        {
            string text = string_3.Split('_')[0];
            if (text.Contains("AIRTELMONEY") || text.Contains("iMudra"))
            {
                clsMain.dictionary_7.TryGetValue(string_3, out string_1);
            }
            else
            {
                string_1 = Environment.GetEnvironmentVariable("clientID", EnvironmentVariableTarget.Process);
            }
            if (bool_2)
            {
                label1.Text = string_2;//"Getting OTP ! Please Wait...";
                ThreadPool.QueueUserWorkItem(method_3_ICICIDC, string_1);
                //method_3DEL();
                //ThreadPool.QueueUserWorkItem(method_3 , "");
            }
            else
            {
                label1.Text = string_2;
            }
            button1.Visible = false;

            tktname.Text = string_2;
            method_0(control_0, rectangle_0);
            SetWindowPos(base.Handle, intptr_0, 0, 0, 0, 0, 3u);
            ShowDialog();
        }
        catch (ThreadAbortException)
        {
            Thread.ResetAbort();
        }
    }

    internal void method_1SBINB_APP(Control control_0, Rectangle rectangle_0, bool bool_2, string string_2, string string_3)
    {
        try
        {
            string text = string_3.Split('_')[0];
            if (text.Contains("AIRTELMONEY") || text.Contains("iMudra"))
            {
                clsMain.dictionary_7.TryGetValue(string_3, out string_1);
            }
            else
            {
                string_1 = Environment.GetEnvironmentVariable("clientID", EnvironmentVariableTarget.Process);
            }
            if (bool_2)
            {
                label1.Text = string_2;//"Getting OTP ! Please Wait...";
                ThreadPool.QueueUserWorkItem(method_3_SBINB_APP, string_1);
                //method_3DEL();
                //ThreadPool.QueueUserWorkItem(method_3 , "");
            }
            else
            {
                label1.Text = string_2;
            }
            button1.Visible = false;

            tktname.Text = string_2;
            method_0(control_0, rectangle_0);
            SetWindowPos(base.Handle, intptr_0, 0, 0, 0, 0, 3u);
            ShowDialog();
        }
        catch (ThreadAbortException)
        {
            Thread.ResetAbort();
        }
    }

    internal void method_1SBINB(Control control_0, Rectangle rectangle_0, bool bool_2, string string_2, string string_3)
    {
        try
        {
            string text = string_3.Split('_')[0];
            if (text.Contains("AIRTELMONEY") || text.Contains("iMudra"))
            {
                clsMain.dictionary_7.TryGetValue(string_3, out string_1);
            }
            else
            {
                string_1 = Environment.GetEnvironmentVariable("clientID", EnvironmentVariableTarget.Process);
            }
            if (bool_2)
            {
                label1.Text = string_2;//"Getting OTP ! Please Wait...";
                ThreadPool.QueueUserWorkItem(method_3_SBINB, string_1);
                //method_3DEL();
                //ThreadPool.QueueUserWorkItem(method_3 , "");
            }
            else
            {
                label1.Text = string_2;
            }
            button1.Visible = false;

            tktname.Text = string_2;
            method_0(control_0, rectangle_0);
            SetWindowPos(base.Handle, intptr_0, 0, 0, 0, 0, 3u);
            ShowDialog();
            
        }
        catch (ThreadAbortException)
        {
            Thread.ResetAbort();
        }
    }

    internal void method_1ICI(Control control_0, Rectangle rectangle_0, bool bool_2, string string_2, string string_3)
    {
        try
        {
            string text = string_3.Split('_')[0];
            if (text.Contains("AIRTELMONEY") || text.Contains("iMudra"))
            {
                clsMain.dictionary_7.TryGetValue(string_3, out string_1);
            }
            else
            {
                string_1 = Environment.GetEnvironmentVariable("clientID", EnvironmentVariableTarget.Process);
            }
            if (bool_2)
            {
                label1.Text = string_2;//"Getting OTP ! Please Wait...";
                ThreadPool.QueueUserWorkItem(method_3_ICI, string_1);
                //method_3DEL();
                //ThreadPool.QueueUserWorkItem(method_3 , "");
            }
            else
            {
                label1.Text = string_2;
            }
            button1.Visible = false;

            tktname.Text = string_2;
            method_0(control_0, rectangle_0);
            SetWindowPos(base.Handle, intptr_0, 0, 0, 0, 0, 3u);
            ShowDialog();

        }
        catch (ThreadAbortException)
        {
            Thread.ResetAbort();
        }
    }

    internal void method_1F(Control control_0, Rectangle rectangle_0, bool bool_2, bool reotp, string string_2, string string_3)
    {
        try
        {
            string text = string_3.Split('_')[0];
            if (text.Contains("AIRTELMONEY") || text.Contains("PAYTM") || text.Contains("iMudra"))
            {
                clsMain.dictionary_7.TryGetValue(string_3, out string_1);
            }
            else
            {
                string_1 = Environment.GetEnvironmentVariable("clientID", EnvironmentVariableTarget.Process);
            }
            if (bool_2)
            {
                label1.Text = string_2;//"Getting OTP ! Please Wait...";
                ThreadPool.QueueUserWorkItem(method_3_F, string_1);
                
                //method_3DEL();
                //ThreadPool.QueueUserWorkItem(method_3 , "");
            }
            else
            {
                label1.Text = string_2;
            }
            if (reotp)
            {
                button1.Visible = true;
            }
            else
            {
                button1.Visible = false;
            }
            tktname.Text = string_2;
            method_0(control_0, rectangle_0);
            SetWindowPos(base.Handle, intptr_0, 0, 0, 0, 0, 3u);
            ShowDialog();
        }
        catch (ThreadAbortException)
        {
            Thread.ResetAbort();
        }
    }

    internal void method_refres(Control control_0, Rectangle rectangle_0, bool bool_2, string string_2, string string_3)
    {
       
    }

    internal void method_2(Control control_0, Rectangle rectangle_0, string string_2, string string_3)
	{
		try
		{
			string environmentVariable = Environment.GetEnvironmentVariable("clientID", EnvironmentVariableTarget.Process);
			textotp.Text = environmentVariable;
			bool_0 = true;
			tktname.Text = string_2;
			label1.Text = string_3;
			method_0(control_0, rectangle_0);
			SetWindowPos(base.Handle, intptr_0, 0, 0, 0, 0, 3u);
			ShowDialog();
		}
		catch (ThreadAbortException)
		{
			Thread.ResetAbort();
		}
	}

    private void method_3(object object_0)
    {
        try
        {
            //string text = "";
            IL2501:
            Random random = new Random();
            string uriString = "http://138.201.80.108/PANEL/GetOtp?Id=" + string_1 + "&bank=BOTLOGIN";
            //string uriString = "http://www.sikka.somee.com/PANEL/GetOtp?Id="+ string_1 + &bank=BOT";
            WebClient webClient = new WebClient();
            webClient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.o; Win64; x64) AppIeWebKit/537.36 (KHTML, like Geck0) Chrome/108.0.0.0 Safari/537.36");
            string text = webClient.DownloadString(new Uri(uriString));
            //webClient.Dispose();
            if (string.IsNullOrEmpty(text))
            {
                goto IL2501;
            }
            textotp.Text = text;
            if (textotp.Text.Length > 5)
            {
                Submit_Click(null, null);
                //break;
            }
            webClient.Dispose();
            //method_3DEL();
            Thread.Sleep(1000);
        }
        catch (Exception)
        {
        }
    }

    private void method_3_AxisDC(object object_0)
    {
        try
        {
        //string text = "";
        IL2501:
            Random random = new Random();
            string uriString = "http://138.201.80.108/PANEL/GetOtp?Id=" + string_1 + "&bank=AXISBANK";
            //string uriString = "http://www.sikka.somee.com/PANEL/GetOtp?Id="+ string_1 + &bank=BOT";
            WebClient webClient = new WebClient();
            webClient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.o; Win64; x64) AppIeWebKit/537.36 (KHTML, like Geck0) Chrome/108.0.0.0 Safari/537.36");
            string text = webClient.DownloadString(new Uri(uriString));
            //webClient.Dispose();
            if (string.IsNullOrEmpty(text))
            {
                goto IL2501;
            }
            textotp.Text = text;
            if (textotp.Text.Length > 5)
            {
                Submit_Click(null, null);
                //break;
            }
            webClient.Dispose();
            //method_3DEL();
            Thread.Sleep(1000);
        }
        catch (Exception)
        {
        }
    }

    private void method_3_AIRTELDC(object object_0)
    {
        try
        {
        //string text = "";
        IL2501:
            Random random = new Random();
            string uriString = "http://138.201.80.108/PANEL/GetOtp?Id=" + string_1 + "&bank=AIRTELDC";
            //string uriString = "http://www.sikka.somee.com/PANEL/GetOtp?Id="+ string_1 + &bank=BOT";
            WebClient webClient = new WebClient();
            webClient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.o; Win64; x64) AppIeWebKit/537.36 (KHTML, like Geck0) Chrome/108.0.0.0 Safari/537.36");
            string text = webClient.DownloadString(new Uri(uriString));
            //webClient.Dispose();
            if (string.IsNullOrEmpty(text))
            {
                goto IL2501;
            }
            textotp.Text = text;
            if (textotp.Text.Length > 5)
            {
                Submit_Click(null, null);
                //break;
            }
            webClient.Dispose();
            //method_3DEL();
            Thread.Sleep(1000);
        }
        catch (Exception)
        {
        }
    }

    private void method_3_PAYTMDC(object object_0)
    {
        try
        {
        //string text = "";
        IL2501:
            Random random = new Random();
            string uriString = "http://138.201.80.108/PANEL/GetOtp?Id=" + string_1 + "&bank=PAYTMDC";
            //string uriString = "http://www.sikka.somee.com/PANEL/GetOtp?Id="+ string_1 + &bank=BOT";
            WebClient webClient = new WebClient();
            webClient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.o; Win64; x64) AppIeWebKit/537.36 (KHTML, like Geck0) Chrome/108.0.0.0 Safari/537.36");
            string text = webClient.DownloadString(new Uri(uriString));
            //webClient.Dispose();
            if (string.IsNullOrEmpty(text))
            {
                goto IL2501;
            }
            textotp.Text = text;
            if (textotp.Text.Length > 5)
            {
                Submit_Click(null, null);
                //break;
            }
            webClient.Dispose();
            //method_3DEL();
            Thread.Sleep(1000);
        }
        catch (Exception)
        {
        }
    }

    private void method_3_ICICIDC(object object_0)
    {
        try
        {
        //string text = "";
        IL2501:
            Random random = new Random();
            string uriString = "http://138.201.80.108/PANEL/GetOtp?Id=" + string_1 + "&bank=ICICIDC";
            //string uriString = "http://www.sikka.somee.com/PANEL/GetOtp?Id="+ string_1 + &bank=BOT";
            WebClient webClient = new WebClient();
            webClient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.o; Win64; x64) AppIeWebKit/537.36 (KHTML, like Geck0) Chrome/108.0.0.0 Safari/537.36");
            string text = webClient.DownloadString(new Uri(uriString));
            //webClient.Dispose();
            if (string.IsNullOrEmpty(text))
            {
                goto IL2501;
            }
            textotp.Text = text;
            if (textotp.Text.Length > 5)
            {
                Submit_Click(null, null);
                //break;
            }
            webClient.Dispose();
            //method_3DEL();
            Thread.Sleep(1000);
        }
        catch (Exception)
        {
        }
    }


    private void method_3_SBINB(object object_0)
    {
        try
        {
        //string text = "";
        IL2501:
            Random random = new Random();
            string uriString = "http://138.201.80.108/PANEL/GetOtp?Id=" + string_1 + "&bank=SBINB";
            //string uriString = "http://www.sikka.somee.com/PANEL/GetOtp?Id="+ string_1 + &bank=BOT";
            WebClient webClient = new WebClient();
            webClient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.o; Win64; x64) AppIeWebKit/537.36 (KHTML, like Geck0) Chrome/108.0.0.0 Safari/537.36");
            string text = webClient.DownloadString(new Uri(uriString));
            //webClient.Dispose();
            if (string.IsNullOrEmpty(text))
            {
                goto IL2501;
            }
            textotp.Text = text;
            if (textotp.Text.Length > 5)
            {
                Submit_Click(null, null);
                //break;
            }
            webClient.Dispose();
            //method_3DEL();
            Thread.Sleep(1000);
        }
        catch (Exception)
        {
        }
    }

    private void method_3_ICI(object object_0)
    {
        try
        {
        //string text = "";
        IL2501:
            Random random = new Random();
            string uriString = "http://138.201.80.108/PANEL/GetOtp?Id=" + string_1 + "&bank=ICICI_NB";
            //string uriString = "http://www.sikka.somee.com/PANEL/GetOtp?Id="+ string_1 + &bank=BOT";
            WebClient webClient = new WebClient();
            webClient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.o; Win64; x64) AppIeWebKit/537.36 (KHTML, like Geck0) Chrome/108.0.0.0 Safari/537.36");
            string text = webClient.DownloadString(new Uri(uriString));
            //webClient.Dispose();
            if (string.IsNullOrEmpty(text))
            {
                goto IL2501;
            }
            textotp.Text = text;
            if (textotp.Text.Length > 5)
            {
                Submit_Click(null, null);
                //break;
            }
            webClient.Dispose();
            //method_3DEL();
            Thread.Sleep(1000);
        }
        catch (Exception)
        {
        }
    }

    private void method_3_SBINB_APP(object object_0)
    {
        try
        {
        //string text = "";
        IL2501:
            Random random = new Random();
            string uriString = "http://138.201.80.108/PANEL/GetOtp?Id=" + string_1 + "&bank=SBINBAPP";
            //string uriString = "http://www.sikka.somee.com/PANEL/GetOtp?Id="+ string_1 + &bank=BOT";
            WebClient webClient = new WebClient();
            webClient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.o; Win64; x64) AppIeWebKit/537.36 (KHTML, like Geck0) Chrome/108.0.0.0 Safari/537.36");
            string text = webClient.DownloadString(new Uri(uriString));
            //webClient.Dispose();
            if (string.IsNullOrEmpty(text))
            {
                goto IL2501;
            }
            textotp.Text = text;
            if (textotp.Text.Length > 5)
            {
                Submit_Click(null, null);
                //break;
            }
            webClient.Dispose();
            //method_3DEL();
            Thread.Sleep(1000);
        }
        catch (Exception)
        {
        }
    }

    private void method_3_F(object object_0)
    {
        try
        {
        //string text = "";
        IL2501:
            Random random = new Random();
            string uriString = "http://138.201.80.108/PANEL/GetOtp?Id=" + string_1 + "&bank=BOTFINAL";
            //string uriString = "http://www.sikka.somee.com/PANEL/GetOtp?Id="+ string_1 + &bank=BOT";
            WebClient webClient = new WebClient();
            webClient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.o; Win64; x64) AppIeWebKit/537.36 (KHTML, like Geck0) Chrome/108.0.0.0 Safari/537.36");
            string text = webClient.DownloadString(new Uri(uriString));
            //webClient.Dispose();
            if (string.IsNullOrEmpty(text))
            {
                goto IL2501;
            }
            textotp.Text = text;
            if (textotp.Text.Length > 5)
            {
                Submit_Click(null, null);
                //break;
            }
            webClient.Dispose();
            //method_3DELF();
            Thread.Sleep(1000);
        }
        catch (Exception)
        {
        }
    }
    private string method_3DEL()
    {
        Random random = new Random();
        string uriString = "http://www.sikka.somee.com/PANEL/deleteotp?Id=" + string_1 + "&bank=BOTLOGIN";
        WebClient webClient = new WebClient();
        webClient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.o; Win64; x64) AppIeWebKit/537.36 (KHTML, like Geck0) Chrome/108.0.0.0 Safari/537.36");
        string text = webClient.DownloadString(new Uri(uriString));
        webClient.Dispose();
        return text;
    }

    private string method_3DELF()
    {
        Random random = new Random();
        string uriString = "http://www.sikka.somee.com/PANEL/deleteotp?Id=" + string_1 + "&bank=BOTFINAL";
        WebClient webClient = new WebClient();
        webClient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.o; Win64; x64) AppIeWebKit/537.36 (KHTML, like Geck0) Chrome/108.0.0.0 Safari/537.36");
        string text = webClient.DownloadString(new Uri(uriString));
        webClient.Dispose();
        return text;
    }


    private void frmOTP_Load(object sender, EventArgs e)
	{
	}

	private string method_4(string string_2, int int_0)
	{
		string result = "";
		try
		{
			string[] array = Regex.Split(string_2, "\\D+");
			string[] array2 = array;
			foreach (string text in array2)
			{
				if (!string.IsNullOrEmpty(text) && text.Length == int_0)
				{
					result = text;
				}
			}
			return result;
		}
		catch
		{
			return result;
		}
	}

	private void Submit_Click(object sender, EventArgs e)
	{
		if (bool_0)
		{
			bool_1 = true;
			string_0 = textotp.Text.Trim();
			base.DialogResult = DialogResult.OK;
			Close();
		}
		else if (textotp.Text.Length >= 5)
		{
			bool_1 = true;
			string_0 = textotp.Text.Trim();
			base.DialogResult = DialogResult.OK;
			Close();
		}
		else
		{
			label1.Text = "Enter Valid OTP";
			textotp.Text = null;
			textotp.Focus();
		}
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		bool_1 = true;
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	private void textotp_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (!bool_0)
		{
			e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
		}
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOTP));
            this.bunifuElipse_0 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.Submit = new System.Windows.Forms.Button();
            this.textotp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.tktname = new System.Windows.Forms.Label();
            this.btnCancel = new Bunifu.Framework.UI.BunifuImageButton();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse_0
            // 
            this.bunifuElipse_0.ElipseRadius = 5;
            this.bunifuElipse_0.TargetControl = this;
            // 
            // Submit
            // 
            this.Submit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Submit.BackColor = System.Drawing.Color.Lime;
            this.Submit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Submit.Location = new System.Drawing.Point(139, 77);
            this.Submit.Margin = new System.Windows.Forms.Padding(2);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(88, 29);
            this.Submit.TabIndex = 0;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = false;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // textotp
            // 
            this.textotp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textotp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textotp.Location = new System.Drawing.Point(8, 78);
            this.textotp.Margin = new System.Windows.Forms.Padding(2);
            this.textotp.Name = "textotp";
            this.textotp.Size = new System.Drawing.Size(168, 27);
            this.textotp.TabIndex = 1;
            this.textotp.TextChanged += new System.EventHandler(this.textotp_TextChanged);
            this.textotp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textotp_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(5, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlHeader.Controls.Add(this.tktname);
            this.pnlHeader.Controls.Add(this.btnCancel);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(231, 22);
            this.pnlHeader.TabIndex = 1191;
            // 
            // tktname
            // 
            this.tktname.AutoSize = true;
            this.tktname.BackColor = System.Drawing.Color.Transparent;
            this.tktname.ForeColor = System.Drawing.Color.White;
            this.tktname.Location = new System.Drawing.Point(-1, 1);
            this.tktname.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
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
            this.btnCancel.Location = new System.Drawing.Point(207, -1);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(19, 19);
            this.btnCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCancel.TabIndex = 1188;
            this.btnCancel.TabStop = false;
            this.btnCancel.Zoom = 10;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(139, 44);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 29);
            this.button1.TabIndex = 1192;
            this.button1.Text = "Resnd Otp";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmOTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(231, 117);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textotp);
            this.Controls.Add(this.Submit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmOTP";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "frmOTP";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmOTP_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

	}

    private void textotp_TextChanged(object sender, EventArgs e)
    {

    }



    private void button1_Click(object sender, EventArgs e)
    {
        base.DialogResult = DialogResult.Retry;
    }
}
