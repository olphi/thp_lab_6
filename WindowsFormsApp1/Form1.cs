using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyLib;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(this);
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form6 form = new Form6(this);
            form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < PowerSchet.listObject.ListOfAppl.Count(); i++)
            {
                if (listBox1.SelectedItem.ToString() == PowerSchet.listObject.ListOfAppl[i].GetName())
                {
                    PowerSchet.listObject.ListOfAppl.RemoveAt(i);
                }
            }
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            label2.Text = PowerSchet.listObject.PowerUsage().ToString();
        }
    }
}
