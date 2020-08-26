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
    public partial class FormUseCoupon : Form
    {
        public string CurrentBarcode;
        public Customer CurrentCustomer;

        public FormUseCoupon()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                float toPay = 0.0f;

                try
                {
                    toPay = float.Parse(textBox1.Text.Replace('.', ','));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Value is not valid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = "";
                    return;
                }

                DialogResult confirmDialog = MessageBox.Show("Use coupons to pay " + textBox1.Text + "?", "Confirm value", MessageBoxButtons.YesNo);

                if (confirmDialog == DialogResult.Yes)
                {
                    CurrentCustomer.Pay(toPay);
                    CurrentCustomer.CalculateBalance();

                    FormMainApp.UpdateCustomerToDictionary(CurrentBarcode, CurrentCustomer);
                    FormMainApp.SaveDatabase(FormMainApp.ProgramSettings.DataPath);
                    FormMainApp.Grid.Rows[FormMainApp.Grid.SelectedCells[0].RowIndex].Cells[6].Value = CurrentCustomer.Balance;
                    
                    this.Close();
                }
            }
        }
    }
}
