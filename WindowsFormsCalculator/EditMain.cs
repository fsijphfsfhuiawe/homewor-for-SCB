using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsCalculator
{
    public partial class EditMain : Form
    {
        public EditMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float a = Convert.ToSingle(textBox2.Text);
            float b = Convert.ToSingle(textBox1.Text);
            float anws = 0;
            if (Add.Checked)
                anws = a + b;
            else if (Sub.Checked)
                anws = a - b;
            else if (Mul.Checked)
                anws = a * b;
            else if (radioButton1.Checked)
                anws = a / b;
            MessageBox.Show("The anwser is " + anws, "RESULT",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
