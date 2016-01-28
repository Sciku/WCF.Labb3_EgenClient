using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WCF.Labb3_EgenClient
{
    public partial class EgenWinform : Form
    {
        private EmployeeServiceReference.EmployeeServiceClient client;
        public EgenWinform()
        {
            client = new EmployeeServiceReference.EmployeeServiceClient();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = client.GetEmployeeByID(Convert.ToInt32(textBox1.Text)).EmployeeID.ToString();
            textBox3.Text = client.GetEmployeeByID(Convert.ToInt32(textBox1.Text)).LastName;
            textBox4.Text = client.GetEmployeeByID(Convert.ToInt32(textBox1.Text)).FirstName;
            textBox5.Text = client.GetEmployeeByID(Convert.ToInt32(textBox1.Text)).Title;
            textBox6.Text = client.GetEmployeeByID(Convert.ToInt32(textBox1.Text)).Address;
            textBox7.Text = client.GetEmployeeByID(Convert.ToInt32(textBox1.Text)).City;
            textBox8.Text = client.GetEmployeeByID(Convert.ToInt32(textBox1.Text)).Country;
            textBox9.Text = client.GetEmployeeByID(Convert.ToInt32(textBox1.Text)).Notes;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            client.saveEmployee(Convert.ToInt32(textBox2.Text), textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text);
        }
    }
}
