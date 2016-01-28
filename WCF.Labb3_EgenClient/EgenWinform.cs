using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
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
            try
            {
                //var tal = 7 / int.Parse("0");   //divide by zero exception
                client.GetEmployeeByID(Convert.ToInt32(textBox1.Text));
                textBox2.Text = client.GetEmployeeByID(Convert.ToInt32(textBox1.Text)).EmployeeID.ToString();
                textBox3.Text = client.GetEmployeeByID(Convert.ToInt32(textBox1.Text)).LastName;
                textBox4.Text = client.GetEmployeeByID(Convert.ToInt32(textBox1.Text)).FirstName;
                textBox5.Text = client.GetEmployeeByID(Convert.ToInt32(textBox1.Text)).Title;
                textBox6.Text = client.GetEmployeeByID(Convert.ToInt32(textBox1.Text)).Address;
                textBox7.Text = client.GetEmployeeByID(Convert.ToInt32(textBox1.Text)).City;
                textBox8.Text = client.GetEmployeeByID(Convert.ToInt32(textBox1.Text)).Country;
                textBox9.Text = client.GetEmployeeByID(Convert.ToInt32(textBox1.Text)).Notes;
            }
            catch (FaultException)
            {
                MessageBox.Show($"Kan ej hämta information om anställd!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                client.saveEmployee(Convert.ToInt32(textBox2.Text), textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text);
            }
            catch (FaultException)
            {
                MessageBox.Show($"Kan ej spara information om anställd!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            int result;
            if (!int.TryParse(textBox1.Text, out result))
            {
                MessageBox.Show(@"Måste ange en siffra");
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            int result;
            if (!int.TryParse(textBox2.Text, out result))
            {
                MessageBox.Show(@"Måste ange en siffra");
            }
        }

    }
}
