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
    public partial class Form6 : Form
    {
        Form1 form1;
        public Form6(Form1 owner)
        {
            form1 = owner;
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var ep = new MyLib.ElectroPribor();
            ep.name = textBox1.Text.ToString();
            ep.watt = int.Parse(textBoxWeight.Text);
            if (radioButton2.Checked == true)
            {
                ep.TurnOn();
            }
            if (radioButton1.Checked == true)
            {
                ep.TurnOff();
            }
            PowerSchet.listObject.ListOfAppl.Insert(form1.listBox1.SelectedIndex, ep);
            PowerSchet.listObject.ListOfAppl.RemoveAt(form1.listBox1.SelectedIndex + 1);
            form1.listBox1.Items.Insert(form1.listBox1.SelectedIndex, ep.GetName());
            form1.listBox1.Items.RemoveAt(form1.listBox1.SelectedIndex);
            form1.label2.Text = PowerSchet.listObject.PowerUsage().ToString();
            this.Close();
        }

    }
}
