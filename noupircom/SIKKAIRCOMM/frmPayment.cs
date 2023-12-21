using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Bunifu.Framework.UI;

internal class frmPayment : Form
{
	private clsPostData class42_0;

	private const uint uint_0 = 1u;

	private const uint uint_1 = 2u;

	internal const uint uint_2 = 3u;

	internal static readonly IntPtr intptr_0 = new IntPtr(-1);

	private Dictionary<string, string> dictionary_0 = new Dictionary<string, string>();

	internal string string_0 = "";

	internal string string_1 = "";

	internal string string_2 = "";

	private string string_3;

	internal bool bool_0;

	internal bool bool_1;

	internal bool bool_2;

	internal bool bool_3;

	internal bool bool_4;

	internal bool bool_5;

	internal bool bool_6;

	internal bool bool_7;

	internal string string_4;

	private IContainer icontainer_1;

	private IContainer icontainer_0;

	internal Label lblError;

	internal Label tktname;

	private WebBrowser webBrowser1;

	private BunifuImageButton btnCancel;

	private Panel pnlHeader;

	public Button btnSubmit;

	public Button btnNxt;

	private BunifuElipse bunifuElipse_0;

	private IContainer components;

	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetWindowPos(IntPtr intptr_1, IntPtr intptr_2, int int_0, int int_1, int int_2, int int_3, uint uint_3);

	public frmPayment()
	{
		InitializeComponent();
		base.Name = "frmPayment-" + Thread.CurrentThread.Name;
		btnNxt.Visible = false;
	}

	internal void method_0(Control control_0, Rectangle rectangle_0)
	{
		Control control = control_0.Controls[0];
		Control control2 = control_0.Parent;
		base.StartPosition = FormStartPosition.Manual;
		base.Location = control2.Location;
		base.TopMost = true;
		base.Left += 2;
	}

	internal void method_1(Control control_0, Rectangle rectangle_0, clsPostData class42_1, string string_5)
	{
		class42_0 = class42_1;
		string_3 = string_5;
		method_0(control_0, rectangle_0);
		lblError.Text = string_1;
		lblError.Visible = true;
		try
		{
			SetWindowPos(base.Handle, intptr_0, 0, 0, 0, 0, 3u);
			ShowDialog();
		}
		catch (ThreadAbortException)
		{
			Thread.ResetAbort();
		}
		catch (Exception)
		{
		}
	}

	internal void method_2(Control control_0, Rectangle rectangle_0, clsPostData class42_1, string string_5)
	{
		class42_0 = class42_1;
		method_0(control_0, rectangle_0);
		lblError.Text = string_1;
		lblError.Visible = true;
		try
		{
			SetWindowPos(base.Handle, intptr_0, 0, 0, 0, 0, 3u);
			ThreadPool.QueueUserWorkItem(method_3, string_5);
			ShowDialog();
		}
		catch (ThreadAbortException)
		{
			Thread.ResetAbort();
		}
		catch (Exception)
		{
		}
	}

	private void method_3(object object_0)
	{
		try
		{
			string item = object_0.ToString();
			clsMain.list_6.Contains(item);
			while (clsMain.list_6.Contains(item))
			{
				Application.DoEvents();
				Thread.Sleep(456);
			}
			clsMain.list_6.Add(item);
			base.DialogResult = DialogResult.OK;
			Close();
		}
		catch
		{
		}
	}

	private void frmPayment_Load(object sender, EventArgs e)
	{
	}

	private void btnNxt_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
	{
		try
		{
			string_4 = webBrowser1.DocumentText;
			webBrowser1.Dispose();
			base.DialogResult = DialogResult.OK;
			Close();
		}
		catch
		{
		}
	}

	internal void method_4(Control control_0, Rectangle rectangle_0, string string_5)
	{
		try
		{
			method_0(control_0, rectangle_0);
			SetWindowPos(base.Handle, intptr_0, 0, 0, 0, 0, 3u);
			base.Size = new Size(0, 0);
			string_4 = "";
			webBrowser1.ScriptErrorsSuppressed = true;
			webBrowser1.Navigate(string_5);
			ShowDialog();
		}
		catch
		{
		}
	}

	private void lblError_Click(object sender, EventArgs e)
	{
		MessageBox.Show(lblError.Text, "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayment));
            this.lblError = new System.Windows.Forms.Label();
            this.tktname = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnNxt = new System.Windows.Forms.Button();
            this.btnCancel = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuElipse_0 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            this.SuspendLayout();
            // 
            // lblError
            // 
            this.lblError.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblError.ForeColor = System.Drawing.Color.Black;
            this.lblError.Location = new System.Drawing.Point(-1, 20);
            this.lblError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(278, 35);
            this.lblError.TabIndex = 18;
            this.lblError.Text = "Select another Payment";
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblError.Visible = false;
            this.lblError.Click += new System.EventHandler(this.lblError_Click);
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
            this.tktname.TabIndex = 23;
            this.tktname.Text = "tktname";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(495, 2);
            this.webBrowser1.Margin = new System.Windows.Forms.Padding(2);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(19, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(238, 104);
            this.webBrowser1.TabIndex = 134;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.Lime;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.ForeColor = System.Drawing.Color.Black;
            this.btnSubmit.Location = new System.Drawing.Point(12, 58);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(250, 29);
            this.btnSubmit.TabIndex = 1194;
            this.btnSubmit.Text = "Process Payment";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnNxt_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlHeader.Controls.Add(this.tktname);
            this.pnlHeader.Controls.Add(this.btnNxt);
            this.pnlHeader.Controls.Add(this.btnCancel);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.ForeColor = System.Drawing.Color.White;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(276, 22);
            this.pnlHeader.TabIndex = 1188;
            // 
            // btnNxt
            // 
            this.btnNxt.BackColor = System.Drawing.Color.Coral;
            this.btnNxt.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNxt.Location = new System.Drawing.Point(310, 0);
            this.btnNxt.Margin = new System.Windows.Forms.Padding(4);
            this.btnNxt.Name = "btnNxt";
            this.btnNxt.Size = new System.Drawing.Size(51, 26);
            this.btnNxt.TabIndex = 1195;
            this.btnNxt.Text = "Next";
            this.btnNxt.UseVisualStyleBackColor = false;
            this.btnNxt.Click += new System.EventHandler(this.btnNxt_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageActive = null;
            this.btnCancel.Location = new System.Drawing.Point(254, -1);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(19, 19);
            this.btnCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCancel.TabIndex = 1187;
            this.btnCancel.TabStop = false;
            this.btnCancel.Zoom = 10;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // bunifuElipse_0
            // 
            this.bunifuElipse_0.ElipseRadius = 5;
            this.bunifuElipse_0.TargetControl = this;
            // 
            // frmPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(276, 101);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.webBrowser1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPayment";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "frmPayment";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmPayment_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            this.ResumeLayout(false);

	}
}
