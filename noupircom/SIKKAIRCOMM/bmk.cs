using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IRCommDLL
{
    public partial class bmk : Form
    {
        internal string textbmk;

        public bmk()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textbmk = richTextBox1.Text;
            this.Close();
        }
    }
}
