using System;
using System.ComponentModel;
using System.Data.Common;
using System.Drawing;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Microsoft.Win32;
using MySql.Data.MySqlClient;

namespace IRCommDLL
{
	public class reCaptcha : Form
	{
		private static readonly IntPtr intptr_0 = new IntPtr(-1);

		private IntPtr intptr_1 = IntPtr.Zero;

		private Control control_0;

		private StringBuilder stringBuilder_0 = new StringBuilder(256);

		private clsMain class28_0;

		private string string_0;

		internal string string_1;

		private CookieContainer cookieContainer_0;

		private string string_2;

		private WebException webException_0;

		private string string_3 = "datasource=127.0.0.1;port=3306;username=root;password=;database=phpmyadmin;";

		internal bool bool_0;

		private IContainer icontainer_0;

		private BunifuElipse bunifuElipse_0;

		private Panel pnlHeader;

		internal Label tktname;

		private BunifuImageButton btnCancel;

		private PictureBox pictureBox1;

		private Button button1;

		private IContainer components;

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

		internal reCaptcha(clsMain class28_1)
		{
			InitializeComponent();
			class28_0 = class28_1;
		}

		internal void method_0(Control control_1, Rectangle rectangle_0, string string_4, string string_5)
		{
			string_1 = null;
			string_0 = string_5;
			method_3(control_1, rectangle_0);
			try
			{
				try
				{
					method_4();
					frmCaptcha.SetWindowPos(base.Handle, intptr_0, 0, 0, 0, 0, 3u);
					method_2(null, null);
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

		internal void method_1(Control control_1, Rectangle rectangle_0, string string_4, string string_5)
		{
			string_1 = null;
			string_0 = string_5;
			method_3(control_1, rectangle_0);
			try
			{
				try
				{
					method_4();
					frmCaptcha.SetWindowPos(base.Handle, intptr_0, 0, 0, 0, 0, 3u);
					method_2(null, null);
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

		private void method_2(object sender, EventArgs e)
		{
			try
			{
				ThreadPool.QueueUserWorkItem(method_5, null);
			}
			catch
			{
			}
		}

		internal void method_3(Control control_1, Rectangle rectangle_0)
		{
			Control control = control_1.Controls[0];
			Control control2 = control_1.Parent;
			base.Size = rectangle_0.Size;
			base.StartPosition = FormStartPosition.Manual;
			base.Location = control2.Location;
			base.Left += 2;
			base.TopMost = true;
		}

		private void method_4()
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

		private void method_5(object object_0)
		{
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private string method_6(string string_4, string string_5)
		{
			try
			{
				string text = string_4.Substring(string_4.IndexOf(string_5));
				string text2 = text.Substring(text.IndexOf(string_5) + string_5.Length);
				return text2.Substring(0, text2.IndexOf("\""));
			}
			catch
			{
				return "error";
			}
		}

		internal string method_7()
		{
			string result = "";
			try
			{
				string text = "";
				WebProxy webProxy = new WebProxy();
				cookieContainer_0 = new CookieContainer();
				while (true)
				{
					string text2 = "http://localhost/set.php?username=" + string_0 + "&type=v2&action=Required&token=NULL";
					class28_0.Lock("Hitting Loading GoogleAPI: inp = " + text2);
					class28_0.Lock("Hitting Loading GoogleAPI: out = " + text);
					if (text.Contains("true"))
					{
						break;
					}
					Thread.Sleep(500);
				}
				Application.DoEvents();
				Thread.Sleep(2000);
				while (true)
				{
					string text3 = "http://localhost/get.php?username=" + string_0 + "&type=v2";
					class28_0.Lock("Hitting Loading GoogleAPI: inp = " + text3);
					class28_0.Lock("Hitting Loading GoogleAPI: out = " + text);
					if (text.Length > 50)
					{
						string text4 = method_6(text, "v\":[\"");
						string text5 = method_6(text, "c\":[\"");
						string text6 = method_6(text, "response\":[\"");
						string text7 = method_6(text, "t\":[\"");
						string text8 = method_6(text, "ct\":[\"");
						string text9 = method_6(text, "bg\":[\"");
						string text10 = "v=" + text4 + "&c=" + text5 + "&response=" + text6 + "&t=" + text7 + "&ct=" + text8 + "&bg=" + text9;
						text3 = "https://www.google.com/recaptcha/api2/userverify?k=6LcnQNYUAAAAAOm9HrBJ4QJIhdAuFrAckyUsQyjy";
						string text11 = "https://www.google.com/recaptcha/api2/bframe?hl=en&v=" + text4 + "&k=6LcnQNYUAAAAAOm9HrBJ4QJIhdAuFrAckyUsQyjy&cb=22f84l928qsk";
						class28_0.bool_0 = true;
						Cookie cookie = new Cookie("__Secure-3PAPISID", "yMHZnj5DNiG9SOxj/AxOPMytpdYuluhXkB")
						{
							Domain = "google.com"
						};
						cookieContainer_0.Add(cookie);
						cookie = new Cookie("CONSENT", "YES+IN.en+20161213-01-0")
						{
							Domain = "google.com"
						};
						cookieContainer_0.Add(cookie);
						cookie = new Cookie("ANID", "AHWqTUnO1nZR-VTZBw1bVYr2P-t1DJWxT9ez2-8EFCyw5TvTWGyOy83_3y7HYBgK")
						{
							Domain = "google.com"
						};
						cookieContainer_0.Add(cookie);
						cookie = new Cookie("__Secure-3PSID", "0AcMGATVwt8lHhRYwm-3KHt3P-x8_sEMqZNi9gB_jlLqoubrmg52WDeZG7TkZrm9jjwWKw.")
						{
							Domain = "google.com"
						};
						cookieContainer_0.Add(cookie);
						cookie = new Cookie("NID", "myw-n5AWW73qzuYUlE8IppOoZCZ9UQXgUda3Djgwf6xT3cIx-K1B8f6Ds7Lagcs2mnxeP06d7SOxHHcgeX_GCUQ1wFWIpBVABBguBJHLQjhO1Wfn4uuFWambMtGOubwABhCskFh_p6gu72E4TWlEXQyA-kXtT-X1EOYUL3wjdTOyiMIMTwSQ9pStlKXqgUT1YVHaNtugCpqle48u6w")
						{
							Domain = "google.com"
						};
						cookieContainer_0.Add(cookie);
						cookie = new Cookie("1P_JAR", "2020-08-16-02")
						{
							Domain = "google.com"
						};
						cookieContainer_0.Add(cookie);
					}
					else
					{
						Application.DoEvents();
						Thread.Sleep(250);
					}
					Thread.Sleep(100);
				}
			}
			catch
			{
				return result;
			}
		}

		internal string method_8(string string_4, string string_5)
		{
			string result = "";
			try
			{
				if (method_9(string_4, string_5))
				{
					method_10(string_4, string_5);
				}
				else
				{
					method_11(string_4, string_5);
				}
				while (true)
				{
					string cmdText = "SELECT * FROM pma__empty where username ='" + string_5 + "'";
					MySqlConnection mySqlConnection = new MySqlConnection(string_3);
					MySqlCommand mySqlCommand = new MySqlCommand(cmdText, mySqlConnection);
					((DbCommand)mySqlCommand).CommandTimeout = 60;
					try
					{
						((DbConnection)mySqlConnection).Open();
						MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
						if (((DbDataReader)mySqlDataReader).HasRows)
						{
							((DbDataReader)mySqlDataReader).Read();
							if (((DbDataReader)mySqlDataReader).GetString(2) == string_4 && ((DbDataReader)mySqlDataReader).GetString(3) == "newkey" && ((DbDataReader)mySqlDataReader).GetString(4) != "null")
							{
								if (string_4 == "v3")
								{
									string text = "key";
									string text2 = ((DbDataReader)mySqlDataReader).GetString(4).Substring(((DbDataReader)mySqlDataReader).GetString(4).IndexOf(text));
									string text3 = text2.Substring(text2.IndexOf(text) + text.Length + 3);
									result = text3.Substring(0, text3.IndexOf("\""));
								}
								else
								{
									result = method_13(((DbDataReader)mySqlDataReader).GetString(4), string_5);
								}
								((DbConnection)mySqlConnection).Close();
								return result;
							}
						}
						((DbConnection)mySqlConnection).Close();
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
					}
				}
			}
			catch
			{
				return result;
			}
		}

		private bool method_9(string string_4, string string_5)
		{
			bool result = false;
			string cmdText = "SELECT * FROM pma__empty where username ='" + string_5 + "'";
			MySqlConnection mySqlConnection = new MySqlConnection(string_3);
			MySqlCommand mySqlCommand = new MySqlCommand(cmdText, mySqlConnection);
			((DbCommand)mySqlCommand).CommandTimeout = 60;
			try
			{
				((DbConnection)mySqlConnection).Open();
				if (((DbDataReader)mySqlCommand.ExecuteReader()).HasRows)
				{
					result = true;
				}
				((DbConnection)mySqlConnection).Close();
				return result;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return result;
			}
		}

		private bool method_10(string string_4, string string_5)
		{
			string cmdText = "UPDATE `pma__empty` SET `type`='" + string_4 + "',`action`='Required',`token`='null' WHERE username = '" + string_5 + "'";
			MySqlConnection mySqlConnection = new MySqlConnection(string_3);
			MySqlCommand mySqlCommand = new MySqlCommand(cmdText, mySqlConnection);
			((DbCommand)mySqlCommand).CommandTimeout = 60;
			try
			{
				((DbConnection)mySqlConnection).Open();
				mySqlCommand.ExecuteReader();
				((DbConnection)mySqlConnection).Close();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		private bool method_11(string string_4, string string_5)
		{
			bool result = false;
			string cmdText = "INSERT INTO pma__empty(`id`, `username`, `type`, `action`, `token`) VALUES (NULL, '" + string_5 + "', '" + string_4 + "', 'Required', 'null')";
			MySqlConnection mySqlConnection = new MySqlConnection(string_3);
			MySqlCommand mySqlCommand = new MySqlCommand(cmdText, mySqlConnection);
			((DbCommand)mySqlCommand).CommandTimeout = 60;
			try
			{
				((DbConnection)mySqlConnection).Open();
				mySqlCommand.ExecuteReader();
				((DbConnection)mySqlConnection).Close();
				result = true;
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return result;
			}
		}

		private bool method_12(string string_4)
		{
			bool result = false;
			string cmdText = "DELETE FROM `pma__empty` WHERE username = '" + string_4 + "'";
			MySqlConnection mySqlConnection = new MySqlConnection(string_3);
			MySqlCommand mySqlCommand = new MySqlCommand(cmdText, mySqlConnection);
			((DbCommand)mySqlCommand).CommandTimeout = 60;
			try
			{
				((DbConnection)mySqlConnection).Open();
				mySqlCommand.ExecuteReader();
				((DbConnection)mySqlConnection).Close();
				result = true;
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return result;
			}
		}

		private string method_13(string string_4, string string_5)
		{
			return "";
		}

		internal string method_14(string string_4)
		{
			string_0 = string_4;
			string text = "";
			WebProxy webProxy = new WebProxy();
			string text2 = "http://localhost/set.php?username=" + string_0 + "&type=v3&action=Required&token=NULL";
			while (true)
			{
				class28_0.Lock("Hitting Loading GoogleAPI: inp = " + text2);
				class28_0.Lock("Hitting Loading GoogleAPI: out = " + text);
				if (text.Contains("true"))
				{
					break;
				}
				Thread.Sleep(1000);
				Thread.Sleep(1000);
			}
			Application.DoEvents();
			Thread.Sleep(3000);
			while (true)
			{
				text2 = "http://localhost/get.php?username=" + string_0 + "&type=v3";
				class28_0.Lock("Hitting Loading GoogleAPI: inp = " + text2);
				class28_0.Lock("Hitting Loading GoogleAPI: out = " + text);
				if (text.Length > 100)
				{
					break;
				}
				Thread.Sleep(100);
				Thread.Sleep(300);
			}
			string text3 = "key";
			string text4 = text.Substring(text.IndexOf(text3));
			string text5 = text4.Substring(text4.IndexOf(text3) + text3.Length + 3);
			return text5.Substring(0, text5.IndexOf("\""));
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(string_1))
			{
				base.DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			Close();
		}

		private string method_15()
		{
			string result = "";
			try
			{
				using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Google\\Chrome\\BLBeacon"))
				{
					if (registryKey != null)
					{
						object value = registryKey.GetValue("version");
						if (value != null)
						{
							result = value.ToString();
							return result;
						}
						return result;
					}
					return result;
				}
			}
			catch (Exception)
			{
				return result;
			}
		}

		private string method_16()
		{
			string result = "";
			try
			{
				using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Google\\Chrome Beta\\BLBeacon"))
				{
					if (registryKey != null)
					{
						object value = registryKey.GetValue("version");
						if (value != null)
						{
							result = value.ToString();
							return result;
						}
						return result;
					}
					return result;
				}
			}
			catch (Exception)
			{
				return result;
			}
		}

		protected override void Dispose(bool disposing)
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
			this.bunifuElipse_0 = new Bunifu.Framework.UI.BunifuElipse(this.components);
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pnlHeader = new System.Windows.Forms.Panel();
			this.tktname = new System.Windows.Forms.Label();
			this.btnCancel = new Bunifu.Framework.UI.BunifuImageButton();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			this.pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.btnCancel).BeginInit();
			base.SuspendLayout();
			this.bunifuElipse_0.ElipseRadius = 5;
			this.bunifuElipse_0.TargetControl = this;
			this.pictureBox1.Location = new System.Drawing.Point(0, 24);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(166, 50);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 1192;
			this.pictureBox1.TabStop = false;
			this.pnlHeader.BackColor = System.Drawing.Color.Teal;
			this.pnlHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pnlHeader.Controls.Add(this.tktname);
			this.pnlHeader.Controls.Add(this.btnCancel);
			this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHeader.Location = new System.Drawing.Point(0, 0);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Size = new System.Drawing.Size(170, 18);
			this.pnlHeader.TabIndex = 1191;
			this.tktname.AutoSize = true;
			this.tktname.BackColor = System.Drawing.Color.Transparent;
			this.tktname.ForeColor = System.Drawing.Color.White;
			this.tktname.Location = new System.Drawing.Point(4, 3);
			this.tktname.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.tktname.Name = "tktname";
			this.tktname.Size = new System.Drawing.Size(45, 13);
			this.tktname.TabIndex = 1189;
			this.tktname.Text = "tktname";
			this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnCancel.BackColor = System.Drawing.Color.Transparent;
			this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnCancel.ImageActive = null;
			this.btnCancel.Location = new System.Drawing.Point(150, 1);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(16, 16);
			this.btnCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.btnCancel.TabIndex = 1188;
			this.btnCancel.TabStop = false;
			this.btnCancel.Zoom = 10;
			this.btnCancel.Click += new System.EventHandler(btnCancel_Click);
			this.button1.BackColor = System.Drawing.Color.Green;
			this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Red;
			this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
			this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button1.ForeColor = System.Drawing.Color.White;
			this.button1.Location = new System.Drawing.Point(38, 79);
			this.button1.Margin = new System.Windows.Forms.Padding(2);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(76, 23);
			this.button1.TabIndex = 1193;
			this.button1.Text = "OK";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(button1_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(170, 108);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.pictureBox1);
			base.Controls.Add(this.pnlHeader);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Margin = new System.Windows.Forms.Padding(2);
			base.Name = "reCaptcha";
			this.Text = "reCaptcha";
			((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			this.pnlHeader.ResumeLayout(false);
			this.pnlHeader.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.btnCancel).EndInit();
			base.ResumeLayout(false);
		}
	}
}
