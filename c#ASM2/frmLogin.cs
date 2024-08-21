using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c_ASM2
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string error = "";

            if(txtName.Text == "")
            {
                error += "Name cannot be blank.\n";
                txtName.Focus();
            }else if(txtPassword.Text == "")
            {
                error += "Password cannot be blank.\n";
                txtPassword.Focus();    
            }

            if(error != "")
            {
                MessageBox.Show(error, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if(txtName.Text =="User" && txtPassword.Text == "asdfgh")
                {
                    MessageBox.Show("Logged in successfully.","" ,MessageBoxButtons.OK,MessageBoxIcon.Information);
                    Form2 form = new Form2();
                    this.Hide();
                    form.ShowDialog();
                    
                }else
                {
                    MessageBox.Show("Name or password is incorrect .", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtName.Focus();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
