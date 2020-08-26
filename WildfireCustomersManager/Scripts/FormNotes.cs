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
    public partial class FormNotes : Form
    {
        public string CurrentBarcode;
        public string Title;
        public string Note;

        public FormNotes()
        {
            InitializeComponent();
        }

        private void FormNotes_Load(object sender, EventArgs e)
        {
            textBox1.Text = Note;
            this.Text = Title + "Notes";
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (!FormMainApp.Customers.TryGetValue(CurrentBarcode, out Customer editCustomer))
                return;

            FormMainApp.Grid.Rows[FormMainApp.Cell.RowIndex].Cells[7].Value = textBox1.Text;

            editCustomer.Notes = textBox1.Text;

            FormMainApp.Customers.Remove(CurrentBarcode);
            FormMainApp.Customers.Add(CurrentBarcode, editCustomer);

            FormMainApp.SaveDatabase(FormMainApp.ProgramSettings.DataPath);

            this.Close();
        }
    }
}
