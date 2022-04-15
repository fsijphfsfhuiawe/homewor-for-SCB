using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderWindowForm
{
    public delegate void MyDelegate(string text1, string text2, string text3, string text4);

    public partial class Form_Create : System.Windows.Forms.Form
    {
        public event MyDelegate MyEvent;

        public Form_Create()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyEvent(this.textBox1.Text, this.textBox2.Text, this.textBox3.Text, this.ID.Text);
            this.Close();
        }
    }
}
