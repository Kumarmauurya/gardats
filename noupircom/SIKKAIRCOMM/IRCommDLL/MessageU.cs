using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;

namespace IRCommDLL
{
	public class MessageU : Form
	{
		public static int TL;

		internal CookieContainer ccm;

		private IContainer components = null;

		private BunifuElipse bunifuElipse_0;

		private Panel panel1;

		private Button button2;

		private Button button1;

		private Button button3;

		private WebBrowser webBrowser1;

		public MessageU()
		{
			InitializeComponent();
		}

		internal void shw(int it)
		{
			ShowDialog();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			TL = 1;
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			TL = 2;
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private async void button3_Click(object sender, EventArgs e)
		{
			ccm = new CookieContainer();
			webBrowser1.ScriptErrorsSuppressed = true;
			webBrowser1.Navigate("https://www.irctc.co.in/nget/train-search");
			await PageLoad(40);
			string x = webBrowser1.Document.Cookie;
			new Dictionary<string, string>();
			string[] array = x.Split(';');
			string[] array2 = array;
			foreach (string s in array2)
			{
				if (!string.IsNullOrEmpty(s))
				{
					string name = string.Empty;
					string value3 = string.Empty;
					if (s.StartsWith("_abck="))
					{
						name = "_abck";
						value3 = s.Replace("_abck=", "");
					}
					if (s.StartsWith("bm_sv="))
					{
						name = "bm_sv";
						value3 = s.Replace("bm_sv=", "");
					}
					if (s.StartsWith("bm_sz="))
					{
						name = "bm_sz";
						value3 = s.Replace("bm_sz=", "");
					}
					if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(value3))
					{
						value3 = value3.Replace(" ", "+");
						Cookie cookieW1 = new Cookie(name, value3)
						{
							Domain = "irctc.co.in"
						};
						ccm.Add(cookieW1);
					}
				}
			}
		}

		private async Task PageLoad(int TimeOut)
		{
			TaskCompletionSource<bool> PageLoaded = null;
			PageLoaded = new TaskCompletionSource<bool>();
			int TimeElapsed = 0;
			webBrowser1.DocumentCompleted += delegate
			{
				if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !PageLoaded.Task.IsCompleted)
				{
					PageLoaded.SetResult(true);
				}
			};
			while (PageLoaded.Task.Status != TaskStatus.RanToCompletion)
			{
				await Task.Delay(10);
				TimeElapsed++;
				if (TimeElapsed >= TimeOut * 100)
				{
					PageLoaded.TrySetResult(true);
				}
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IRCommDLL.MessageU));
			this.bunifuElipse_0 = new Bunifu.Framework.UI.BunifuElipse(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.webBrowser1 = new System.Windows.Forms.WebBrowser();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.bunifuElipse_0.ElipseRadius = 5;
			this.bunifuElipse_0.TargetControl = this;
			this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 514);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(911, 48);
			this.panel1.TabIndex = 1;
			this.button2.Location = new System.Drawing.Point(12, 10);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(167, 29);
			this.button2.TabIndex = 0;
			this.button2.Text = "Open Google Chrome";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(button2_Click);
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.button1.Location = new System.Drawing.Point(265, 10);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(93, 29);
			this.button1.TabIndex = 0;
			this.button1.Text = "Proceed";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(button1_Click);
			this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.button3.Location = new System.Drawing.Point(806, 479);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(93, 29);
			this.button3.TabIndex = 2;
			this.button3.Text = "Proceed";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(button3_Click);
			this.webBrowser1.Location = new System.Drawing.Point(22, -4);
			this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.Size = new System.Drawing.Size(877, 477);
			this.webBrowser1.TabIndex = 3;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(911, 562);
			base.Controls.Add(this.webBrowser1);
			base.Controls.Add(this.button3);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "MessageU";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MessageU";
			base.TopMost = true;
			this.panel1.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
