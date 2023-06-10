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
    public partial class Form4 : Form
    {
        Form1 form1;
        public Form4(Form1 owner)
        {
            form1 = owner;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ep = new MyLib.UlichniiPribor();
            ep.name = textBox1.Text.ToString();
            ep.watt = int.Parse(textBox2.Text);
            ep._IpClass = int.Parse(textBox3.Text);
            if (radioButton2.Checked == true)
            {
                ep.TurnOn();
            }
            if (radioButton1.Checked == true)
            {
                ep.TurnOff();
            }
            PowerSchet.listObject.ListOfAppl.Add(ep);
            form1.listBox1.Items.Add(ep.GetName());
            form1.label2.Text = PowerSchet.listObject.PowerUsage().ToString();
            this.Close();
        }

    }
}
