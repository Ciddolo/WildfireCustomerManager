using System;
using System.Globalization;
using System.Text.RegularExpressions;
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
    public partial class FormAddCustomer : Form
    {
        public static string Barcode;

        public FormAddCustomer()
        {
            InitializeComponent();
        }

        public void AddCustomer()
        {
            if (textBoxName.Text == "")
            {
                MessageBox.Show("Invalid name", "Error!", MessageBoxButtons.OK);
                return;
            }

            if (textBoxSurname.Text == "")
            {
                MessageBox.Show("Invalid surname", "Error!", MessageBoxButtons.OK);
                return;
            }

            if (textBoxEmail.Text.Length > 0)
            {
                if (!CheckEmail(textBoxEmail.Text))
                {
                    MessageBox.Show("Invalid email", "Error!", MessageBoxButtons.OK);
                    return;
                }
            }

            if (textBoxTelephoneNumber.Text.Length > 0)
            {
                try
                {
                    float.Parse(textBoxTelephoneNumber.Text);
                }
                catch
                {
                    MessageBox.Show("Invalid telephone number", "Error!", MessageBoxButtons.OK);
                    return;
                }
            }

            if (textBoxBarcode.Text == "")
            {
                Random random = new Random();
                string chars = "abcdefghijklmnopqrstuwxyz".ToUpper();
                Barcode = new string(Enumerable.Repeat(chars, 9).Select(s => s[random.Next(s.Length)]).ToArray());
            }
            else
            {
                Barcode = textBoxBarcode.Text;

                if (FormMainApp.Customers.ContainsKey(Barcode))
                    return;
            }

            TextInfo textInfo = new CultureInfo("ita", false).TextInfo;
            string name = textInfo.ToTitleCase(textBoxName.Text);
            string surname = textInfo.ToTitleCase(textBoxSurname.Text); 
            string email = textBoxEmail.Text;
            string telephoneNumber = textBoxTelephoneNumber.Text;
            Customer newCustomer = new Customer(name, surname, email, telephoneNumber);

            BlankGrid();
            FormMainApp.AddCustomerToDictionary(Barcode, newCustomer);
            FormMainApp.SaveDatabase(FormMainApp.DEFAULT_DATA_PATH);
            AddCustomerToGrid(Barcode);
            Barcode = "";

            this.Close();
        }

        public bool CheckEmail(string email)
        {
            string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            Regex emailPattern = new Regex(validEmailPattern, RegexOptions.IgnoreCase);

            return emailPattern.IsMatch(email);
        }

        public void BlankGrid()
        {
            int n = FormMainApp.Grid.Rows.Count;

            for (int i = 0; i < n; i++)
                FormMainApp.Grid.Rows.RemoveAt(0);
        }

        private void AddCustomerToGrid(string barcode)
        {
            Customer customer;
            if (FormMainApp.Customers.TryGetValue(barcode, out customer))
            {
                FormMainApp.Grid.Rows.Add();
                FormMainApp.Grid.Rows[FormMainApp.Grid.Rows.Count - 1].Cells[0].Value = barcode;
                FormMainApp.Grid.Rows[FormMainApp.Grid.Rows.Count - 1].Cells[1].Value = customer.Name;
                FormMainApp.Grid.Rows[FormMainApp.Grid.Rows.Count - 1].Cells[2].Value = customer.Surname;
                FormMainApp.Grid.Rows[FormMainApp.Grid.Rows.Count - 1].Cells[3].Value = customer.Email;
                FormMainApp.Grid.Rows[FormMainApp.Grid.Rows.Count - 1].Cells[4].Value = customer.TelephoneNumber;
                FormMainApp.Grid.Rows[FormMainApp.Grid.Rows.Count - 1].Cells[5].Value = customer.Points;
                FormMainApp.Grid.Rows[FormMainApp.Grid.Rows.Count - 1].Cells[6].Value = customer.Balance;
                FormMainApp.Grid.Rows[FormMainApp.Grid.Rows.Count - 1].Cells[7].Value = customer.Notes;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddCustomer();
        }

        private void textBoxName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                AddCustomer();
        }

        private void textBoxSurname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                AddCustomer();
        }

        private void textBoxEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                AddCustomer();
        }

        private void textBoxTelephoneNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                AddCustomer();
        }
    }
}
