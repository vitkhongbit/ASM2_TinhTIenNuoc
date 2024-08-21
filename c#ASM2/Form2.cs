using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace c_ASM2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        double waterThisMonth;
        double waterLastMonth;


        private bool checkRadioButton()
        {
            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked && !radioButton4.Checked)
            {
                MessageBox.Show("you must choose the type of customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string phone = txtPhone.Text;
            double WaterConsumption = waterThisMonth - waterLastMonth;

            if (!Check())
            {
                return;
            }

            double totalCost = Caculate(WaterConsumption);

            if (totalCost == 0)
            {
                return;
            }

            txtShowCost.Text = totalCost.ToString();


            ListViewItem item = new ListViewItem(name);
            item.SubItems.Add(phone);
            item.SubItems.Add(waterThisMonth.ToString());
            item.SubItems.Add(waterLastMonth.ToString());
            item.SubItems.Add(GetCustomerType());
            item.SubItems.Add(WaterConsumption.ToString());
            item.SubItems.Add((totalCost).ToString());
            listView1.Items.Add(item);

            MessageBox.Show("Add success");
            ClearForm();
        }
        private bool Check()
        {
            string name = txtName.Text;
            string phone = txtPhone.Text;
            string error = "";

            if (string.IsNullOrEmpty(name))
            {
                error += "Name cannot be blank.\n";

                txtName.Focus();
            }
            else if (string.IsNullOrEmpty(phone))
            {
                error += "Phone cannot be blank.\n";


                txtName.Focus();
            }
            else if (!double.TryParse(txtWaterThisMonth.Text, out waterThisMonth))
            {
                error += "Water consumption this month must be positive.\n";


            }
            else if (!double.TryParse(txtWaterLastMonth.Text, out waterLastMonth))
            {
                error += "Water consumption last month must be positive.\n";

            }
            else if (waterThisMonth <= waterLastMonth)
            {
                error += "water consumption last month must be greater than this month.\n";
                txtWaterThisMonth.Focus();
            }
            else if (!checkRadioButton())
            {
                error += "You must choose the type of customer.\n";
            }


            if (error != "")
            {
                MessageBox.Show(error, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private double Caculate(double WaterConsumption)
        {
            int user;
            double WaterPerPerson = 0;
            double EnvironmentalTax = 0;

            if (radioButton1.Checked == true)
            {

                if (!int.TryParse(txtPeopleNums.Text, out user) || user <= 0)
                {
                    MessageBox.Show("You must enter a user number.", "warning", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txtPeopleNums.Focus();
                    return 0;

                }
                double ConsumptionPerPerson = WaterConsumption / user;
                if (ConsumptionPerPerson <= 10)
                {
                    WaterPerPerson = 5973;
                    EnvironmentalTax = 597.3;
                }
                else if (ConsumptionPerPerson <= 20)
                {
                    WaterPerPerson = 7052;
                    EnvironmentalTax = 705.2;

                }
                else if (ConsumptionPerPerson <= 30)
                {
                    WaterPerPerson = 8699;
                    EnvironmentalTax = 869.9;

                }
                else
                {
                    WaterPerPerson = 15929;
                    EnvironmentalTax = 1592.9;

                }
            }
            else if (radioButton2.Checked == true)
            {
                label4.Hide();
                txtPeopleNums.Hide();
                WaterPerPerson = 9955;
                EnvironmentalTax = 995.5;
            }
            else if (radioButton3.Checked == true)
            {
                label4.Hide();
                txtPeopleNums.Hide();
                WaterPerPerson = 11615;
                EnvironmentalTax = 1161.5;
            }
            else if (radioButton4.Checked == true)
            {
                label4.Hide();
                txtPeopleNums.Hide();
                WaterPerPerson = 22068;
                EnvironmentalTax = 2206.8;
            }
            label4.Show();
            txtPeopleNums.Show();
            double TotalMoney = WaterConsumption * (WaterPerPerson + EnvironmentalTax);
            double Vat = TotalMoney * 0.1;

            return TotalMoney + Vat;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];


                string Name = selectedItem.SubItems[0].Text;
                string Phone = selectedItem.SubItems[1].Text;
                string waterThisMonth = selectedItem.SubItems[2].Text;
                string waterLastMonth = selectedItem.SubItems[3].Text;
                string CustomerType = selectedItem.SubItems[4].Text;
                string WaterConsumption = selectedItem.SubItems[5].Text;
                string TotalCost = "";


                if (selectedItem.SubItems.Count > 6)
                {
                    TotalCost = selectedItem.SubItems[6].Text;
                }

                txtName.Text = Name;
                txtPhone.Text = Phone;
                txtWaterThisMonth.Text = waterThisMonth;
                txtWaterLastMonth.Text = waterLastMonth;
                SetCustomerType(CustomerType);
                txtShowCost.Text = TotalCost;


                label4.Show();
                txtPeopleNums.Show();


            }
        }
        private string GetCustomerType()
        {
            if (radioButton1.Checked) return "Household customer";
            if (radioButton2.Checked) return "Administrative agency, public services";
            if (radioButton3.Checked) return "Production units";
            if (radioButton4.Checked) return "Business services";
            return "";
        }
        private void SetCustomerType(string customerType)
        {
            switch (customerType)
            {
                case "Household customer":
                    radioButton1.Checked = true;
                    break;
                case "Administrative agency, public services":
                    radioButton2.Checked = true;
                    break;
                case "Production units":
                    radioButton3.Checked = true;
                    break;
                case "Business services":
                    radioButton4.Checked = true;
                    break;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.MultiSelect = true;
            listView1.Enabled = true;

            listView1.Columns.Add("Name", 100);
            listView1.Columns.Add("Phone", 100);
            listView1.Columns.Add("Water this month", 100);
            listView1.Columns.Add("Water last month", 100);
            listView1.Columns.Add("Customer type", 250);
            listView1.Columns.Add("Water consumtion", 150);
            listView1.Columns.Add("Total cost", 150);

        }
        private void ClearForm()
        {
            txtName.Clear();
            txtPhone.Clear();
            txtWaterThisMonth.Clear();
            txtWaterLastMonth.Clear();
            txtPeopleNums.Clear();
            txtShowCost.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                listView1.Items.Remove(listView1.SelectedItems[0]);
                MessageBox.Show("Delete success");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {

                ListViewItem item = listView1.SelectedItems[0];

                string name = txtName.Text;
                string phone = txtPhone.Text;
                double waterThisMonth, waterLastMonth;

                if (!double.TryParse(txtWaterThisMonth.Text, out waterThisMonth) || !double.TryParse(txtWaterLastMonth.Text, out waterLastMonth))
                {
                    MessageBox.Show("Water consumption values must be positive numbers.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string customerType = GetCustomerType();
                double waterConsumption = waterThisMonth - waterLastMonth;
                if (waterConsumption <= 0)
                {
                    MessageBox.Show("Water consumption this month must be greater than last month.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                double totalCost = Caculate(waterConsumption);
                item.SubItems.Clear();
                item.Text = name;
                item.SubItems.Add(phone);
                item.SubItems.Add(waterThisMonth.ToString());
                item.SubItems.Add(waterLastMonth.ToString());
                item.SubItems.Add(customerType);
                item.SubItems.Add(waterConsumption.ToString());
                item.SubItems.Add(totalCost.ToString());

                MessageBox.Show("Edit success");
                ClearForm();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPrinBill_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];

                string name = selectedItem.SubItems[0].Text;
                string phone = selectedItem.SubItems[1].Text;
                string customerType = Convert.ToString(GetCustomerType());
                double waterThisMonth = Convert.ToDouble(txtWaterLastMonth.Text);
                double waterLastMonth = Convert.ToDouble(txtWaterLastMonth.Text);

                double amountUsed = waterThisMonth - waterLastMonth;

                double pricePerUnit = 0;
                double envFeePerUnit = 0;

                if (customerType == "Household customer")
                {
                    if (amountUsed <= 10)
                    {
                        pricePerUnit = 5973;
                        envFeePerUnit = 597.3;
                    }
                    else if (amountUsed <= 20)
                    {
                        pricePerUnit = 7052;
                        envFeePerUnit = 705.2;
                    }
                    else if (amountUsed <= 30)
                    {
                        pricePerUnit = 8699;
                        envFeePerUnit = 869.9;
                    }
                    else
                    {
                        pricePerUnit = 15929;
                        envFeePerUnit = 1592.9;
                    }
                }
                else if (customerType == "Administrative agency, public services")
                {
                    pricePerUnit = 9955;
                    envFeePerUnit = 995.5;
                }
                else if (customerType == "Production units")
                {
                    pricePerUnit = 11615;
                    envFeePerUnit = 1161.5;
                }
                else if (customerType == "Business services")
                {
                    pricePerUnit = 22068;
                    envFeePerUnit = 2206.8;
                }

                double price =  pricePerUnit;
                double envFee = envFeePerUnit;
                double total = amountUsed*(price+envFee);
                double vat = total * 0.1;
                double totalPrice = total + vat;

                // Khởi tạo Form3 và truyền dữ liệu
                Form3 billForm = new Form3(name, phone, customerType, waterThisMonth.ToString(), waterLastMonth.ToString(), amountUsed.ToString(), price.ToString(), envFee.ToString(), vat.ToString(), totalPrice.ToString());
                billForm.Show();
            }
            else
            {
                MessageBox.Show("Please select a row to print the bill.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            //Form3 f = new Form3(txtName.Text,txtPhone.Text,Convert.ToString(GetCustomerType()),txtWaterThisMonth.Text,txtWaterLastMonth.Text, Convert.ToString(waterLastMonth),Convert.ToString(water);
            //f.ShowDialog();
        }
    }
}
