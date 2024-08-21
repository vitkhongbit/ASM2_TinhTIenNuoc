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
    public partial class Form3 : Form
    {
        private string username, Phone,TypeCus,waterThisMonth,waterLastMonth, amountOfWater, price, envrinormentFee, vat, totalPrice;
        public Form3()
        {
            InitializeComponent();
        }
        public Form3(string name, string phone, string TypeCus, string waterThisMonth, string waterLastMonth,string amountOfWaterUsed,string price,string envrinormentFee, string vat, string totalPrice)
        {
            InitializeComponent();
            this.username = name;
            this.Phone = phone;
            this.TypeCus = TypeCus;
            this.waterThisMonth = waterThisMonth;
            this.waterLastMonth = waterLastMonth;
            this.amountOfWater = amountOfWaterUsed;
            this.price = price;
            this.envrinormentFee = envrinormentFee;
            this.vat = vat;
            this.totalPrice = totalPrice;
        }




        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label15.Text = username;
            label16.Text = Phone;
            label17.Text = TypeCus;
            label18.Text = waterThisMonth;
            label19.Text = waterLastMonth;
            label20.Text = amountOfWater;
            label21.Text = price;
            label22.Text = envrinormentFee;
            label23.Text = vat;
            label24.Text = totalPrice;
        }
    }
}
