using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c_ASM2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string phone = txtPhone.Text;   
            

            if(string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Name cannot be blank", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
            }else if (string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Phone cannot be blank", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhone.Focus();
            }

            double waterThisMonth = Convert.ToDouble(txtWaterThisMonth.Text);
            double waterLastMonth = Convert.ToDouble(txtWaterLastMonth.Text);

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtWaterThisMonth_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtWaterLastMonth_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void clearForm()
        {
            txtName.Text = null;
            txtWaterThisMonth.Text = null;
            txtWaterLastMonth.Text = null;
            txtPhone.Text = null;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            txtPeopleNums.Text = null;

            
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.GridLines = true; 
            listView1.FullRowSelect= true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count > 0)
            {
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
        }
    }
}
