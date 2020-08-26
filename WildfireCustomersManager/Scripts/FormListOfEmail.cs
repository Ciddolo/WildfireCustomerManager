using System;
using System.IO;
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
    public partial class FormListOfEmail : Form
    {
        public FormListOfEmail()
        {
            InitializeComponent();

            textBox1.Text = File.ReadAllText(FormMainApp.DEFAULT_EMAILS_PATH);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                string filePath;
                saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.FileName = "WildfireCustomersDatabaseEmails.txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = saveFileDialog.FileName;
                    var fileStream = saveFileDialog.OpenFile();
                    using (StreamWriter writer = new StreamWriter(fileStream))
                        writer.Write(textBox1.Text);
                }
            }
            this.Close();
        }
    }
}
