using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WildfireCustomersManager
{
    public partial class FormAddCoupon : Form
    {
        public string CurrentBarcode;

        public FormAddCoupon()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Coupon newCoupon;

                if (!FormMainApp.Customers.TryGetValue(CurrentBarcode, out Customer editCustomer))
                    return;

                try
                {
                    newCoupon = new Coupon(float.Parse(textBox1.Text.Replace('.', ',')), DateTime.Now, checkBox1.Checked);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Value is not valid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = "";
                    return;
                }

                DialogResult confirmDialog = MessageBox.Show("Add new coupon of " + textBox1.Text + "?", "Confirm value", MessageBoxButtons.YesNo);

                if (confirmDialog == DialogResult.Yes)
                {
                    editCustomer.ValidCoupons.Add(newCoupon);
                    editCustomer.CalculateBalance();

                    FormMainApp.UpdateCustomerToDictionary(CurrentBarcode, editCustomer);
                    FormMainApp.SaveDatabase(FormMainApp.ProgramSettings.DataPath);
                    FormMainApp.Grid.Rows[FormMainApp.Grid.SelectedCells[0].RowIndex].Cells[6].Value = editCustomer.Balance;

                    this.Close();
                }
            }
        }
    }
}
