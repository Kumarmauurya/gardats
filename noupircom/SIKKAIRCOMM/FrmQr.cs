using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IRCommDLL
{
    
    public partial class FrmQr : Form
    {
        private string strin_1;

        public FrmQr()
        {
            InitializeComponent();
        }

        public Image LoadImage(string strin_1)
        {
            //data:image/gif;base64,
            //this image is a single pixel (black)
            byte[] bytes = Convert.FromBase64String(strin_1);

            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
            }

            return image;
        }

        public void Form1_Load(string strin_1 , string strin_2 , string strin_3)
        {
            pictureBox1.Image = LoadImage(strin_1);
            label1.Text = "Pay Using QR :- "+ strin_2+ "  Amt=  " + strin_3;
            ShowDialog();
           
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmQr_Load(object sender, EventArgs e)
        {

        }
    }
}
