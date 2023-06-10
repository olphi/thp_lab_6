using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        Form1 form1;
        public Form2(Form1 owner)
        {
            form1 = owner;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                Form3 form = new Form3(form1);
                form.ShowDialog();
            }
            if (radioButton2.Checked == true)
            {
                Form4 form = new Form4(form1);
                form.ShowDialog();
            }
            else if (radioButton3.Checked == true)
            {
                Form5 form = new Form5(form1);
                form.ShowDialog();
            }
            
            this.Close();
        }

    }
}
