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
    public struct Settings
    {
        public string DataPath;
        public string BackupPath;
    }

    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            textDataPath.Text = FormMainApp.ProgramSettings.DataPath;
            textBackupPath.Text = FormMainApp.ProgramSettings.BackupPath;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            FormMainApp.ProgramSettings.DataPath = textDataPath.Text;
            FormMainApp.ProgramSettings.BackupPath = textBackupPath.Text;
            FormMainApp.SaveSettings();
            this.Close();
        }

        private void buttonDefault_Click(object sender, EventArgs e)
        {
            FormMainApp.ProgramSettings.DataPath = FormMainApp.DEFAULT_DATA_PATH;
            FormMainApp.ProgramSettings.BackupPath = FormMainApp.DEFAULT_BACKUP_PATH;
            FormMainApp.SaveSettings();
            this.Close();
        }

        private void textDataPath_Click(object sender, EventArgs e)
        {
            using ( FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string newPath = folderBrowserDialog.SelectedPath + @"\" + FormMainApp.DEFAULT_DATA_PATH;
                    textDataPath.Text = newPath;
                }
            }
        }

        private void textBackupPath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string newPath = folderBrowserDialog.SelectedPath + @"\" + FormMainApp.DEFAULT_BACKUP_PATH;
                    textBackupPath.Text = newPath;
                }
            }
        }
    }
}
