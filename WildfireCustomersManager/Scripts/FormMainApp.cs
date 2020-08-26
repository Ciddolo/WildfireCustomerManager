using System;
using System.Globalization;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace WildfireCustomersManager
{
    public enum FindData
    {
        Barcode,
        Name,
        Surname,
        Email,
        TelephoneNumber
    }

    public partial class FormMainApp : Form
    {
        public static DataGridView Grid;
        public static DataGridViewRow Row;
        public static DataGridViewCell Cell;
        public static Dictionary<string, Customer> Customers = new Dictionary<string, Customer>();
        public static Settings ProgramSettings = new Settings();
        public static Timer timer = new Timer();

        public const string DEFAULT_DATA_PATH = @"Data/WildfireCustomersDatabase.json";
        public const string DEFAULT_SETTINGS_PATH = @"Data/WildfireCustomersDatabaseSettings.json";
        public const string DEFAULT_EMAILS_PATH = @"Data/WildfireCustomersDatabaseEmails.txt";
        public const string DEFAULT_BACKUP_PATH = @"Backup/";

        private delegate void WhatToFind();
        private WhatToFind find;

        //DEFAULT

        public FormMainApp()
        {
            InitializeComponent();
            InitComboBox();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadSettings();
            Grid = dataGridView1;
            FindDispatcher();
            LoadDatabase(ProgramSettings.DataPath);
            AddCustomersToGrid();
            ExpireAlert();

            timer.Interval = 3600000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Enabled = true;
        }

        //MISCELLANEOUS

        public bool ExpireAlert()
        {
            string message = "Following customers have coupons about to expire: \n";
            bool couponsAboutToExpire = false;
            foreach (Customer customer in Customers.Values)
            {
                if (customer.CheckCouponsAboutToExpire())
                {
                    couponsAboutToExpire = true;
                    message += String.Format("{0} {1}\n", customer.Name, customer.Surname);
                }
            }
            if (couponsAboutToExpire)
                MessageBox.Show(message, "Coupons about to expire!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return couponsAboutToExpire;
        }

        public void AutoBackup()
        {
            if (ProgramSettings.BackupPath == "")
            {
                MessageBox.Show("Invalid backup path!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string todayDate = DateTime.Now.ToString("u").Split(' ')[0];
            string todayTime = DateTime.Now.ToString("T").Replace(':', '.');
            string todayName = String.Format("{0}-WildfireCustomersDatabase.json", todayTime);
            string todayDirectory = String.Format("{0}/{1}", ProgramSettings.BackupPath, todayDate);
            string todayPath = String.Format("{0}/{1}", todayDirectory, todayName);

            if (!Directory.Exists(todayDirectory))
                Directory.CreateDirectory(todayDirectory);

            SaveDatabase(todayPath);
        }

        public string GetBarcodeFromSelectedCell()
        {
            try
            {
                return Grid.Rows[Grid.SelectedCells[0].RowIndex].Cells[0].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Database not loaded or nothing selected.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        public static string GetNewBarcode()
        {
            string barcode = "";
            bool barcodeAvailable = false;

            while (!barcodeAvailable)
            {
                Random random = new Random();
                barcode = random.Next(999999999).ToString("000000000");

                if (!Customers.TryGetValue(barcode, out Customer barcodeTry))
                    barcodeAvailable = true;
            }

            return barcode;
        }

        private void InitComboBox()
        {
            List<string> toFind = new List<string>();
            toFind.Add(FindData.Barcode.ToString());
            toFind.Add(FindData.Name.ToString());
            toFind.Add(FindData.Surname.ToString());
            toFind.Add(FindData.Email.ToString());
            toFind.Add(FindData.TelephoneNumber.ToString());
            comboBox1.DataSource = toFind;
        }

        private void FindBarcode()
        {
            if (textBox1.Text == "")
                return;

            BlankGrid();

            if (Customers.TryGetValue(textBox1.Text, out Customer customer))
                AddCustomerToGrid(textBox1.Text, customer);

            textBox1.Text = "";
        }

        private void FindSurname()
        {
            if (textBox1.Text == "")
                return;

            BlankGrid();
            foreach (var customer in Customers)
            {
                if (customer.Value.Surname.ToUpper() == textBox1.Text.ToUpper())
                    AddCustomerToGrid(customer.Key, customer.Value);
            }

            textBox1.Text = "";
        }

        private void FindName()
        {
            if (textBox1.Text == "")
                return;

            BlankGrid();
            foreach (var customer in Customers)
            {
                if (customer.Value.Name.ToUpper() == textBox1.Text.ToUpper())
                    AddCustomerToGrid(customer.Key, customer.Value);
            }

            textBox1.Text = "";
        }

        private void FindEmail()
        {
            if (textBox1.Text == "")
                return;

            BlankGrid();
            foreach (var customer in Customers)
            {
                if (customer.Value.Email.ToUpper() == textBox1.Text.ToUpper())
                    AddCustomerToGrid(customer.Key, customer.Value);
            }

            textBox1.Text = "";
        }

        private void FindTelephoneNumber()
        {
            if (textBox1.Text == "")
                return;

            BlankGrid();
            foreach (var customer in Customers)
            {
                if (customer.Value.TelephoneNumber.ToUpper() == textBox1.Text.ToUpper())
                    AddCustomerToGrid(customer.Key, customer.Value);
            }

            textBox1.Text = "";
        }

        private void FindDispatcher()
        {
            switch (comboBox1.Text)
            {
                case "Barcode":
                    find = FindBarcode;
                    break;
                case "Name":
                    find = FindName;
                    break;
                case "Surname":
                    find = FindSurname;
                    break;
                case "Email":
                    find = FindEmail;
                    break;
                case "TelephoneNumber":
                    find = FindTelephoneNumber;
                    break;
            }
        }

        private void Edit()
        {
            if (Grid.SelectedCells.Count <= 0)
                return;
            if (Grid.SelectedCells[0].ColumnIndex == 0)
                return;
            if (Grid.SelectedCells[0].ColumnIndex == 6)
                return;
            if (textBox1.Text.Length <= 0)
                textBox1.Text = "";

            Cell = Grid.SelectedCells[0];
            Cell.Value = textBox1.Text;

            string barcode = Grid.Rows[Cell.RowIndex].Cells[0].Value.ToString();

            if (!Customers.TryGetValue(barcode, out Customer editCustomer))
                return;

            switch (Cell.ColumnIndex)
            {
                case 1:
                    if (textBox1.Text == "")
                        editCustomer.Name = "";
                    else
                    {
                        editCustomer.Name = textBox1.Text[0].ToString().ToUpper() + textBox1.Text.Substring(1, textBox1.Text.Length - 1);
                        Cell.Value = editCustomer.Name;
                    }
                    break;
                case 2:
                    if (textBox1.Text == "")
                        editCustomer.Surname = "";
                    else
                    {
                        editCustomer.Surname = textBox1.Text[0].ToString().ToUpper() + textBox1.Text.Substring(1, textBox1.Text.Length - 1);
                        Cell.Value = editCustomer.Surname;
                    }
                    break;
                case 3:
                    editCustomer.Email = textBox1.Text;
                    break;
                case 4:
                    editCustomer.TelephoneNumber = textBox1.Text;
                    break;
                case 5:
                    editCustomer.Points = textBox1.Text;
                    break;
                case 6:
                    float.TryParse(textBox1.Text, out editCustomer.Balance);
                    break;
                case 7:
                    editCustomer.Notes = textBox1.Text;
                    break;
            }

            UpdateCustomerToDictionary(barcode, editCustomer);
            SaveDatabase(ProgramSettings.DataPath);

            textBox1.Text = "";
        }

        private void Remove()
        {
            if (Grid.SelectedCells.Count <= 0)
                return;

            Cell = Grid.SelectedCells[0];
            Row = Grid.Rows[Cell.RowIndex];
            string barcode = Row.Cells[0].Value.ToString();
            string message = String.Format("Are you sure to remove {0} {1}?", Row.Cells[1].Value.ToString(), Row.Cells[2].Value.ToString());

            DialogResult confirmDialog = MessageBox.Show(message, "Remove customer", MessageBoxButtons.YesNo);

            if (confirmDialog == DialogResult.Yes)
            {
                Customers.Remove(barcode);
                Grid.Rows.Remove(Row);
                SaveDatabase(ProgramSettings.DataPath);
            }
        }

        private void AddCustomer()
        {
            textBox1.Text = "";
            FormAddCustomer addCustomer = new FormAddCustomer();
            addCustomer.ShowDialog();
        }

        private void AddCoupon()
        {
            string barcode = GetBarcodeFromSelectedCell();
            if (barcode == "")
                return;

            Customer currentCustomer = GetCustomer(barcode);
            if (currentCustomer == null)
                return;

            FormAddCoupon newCoupon = new FormAddCoupon();

            newCoupon.CurrentBarcode = barcode;

            newCoupon.ShowDialog();
        }

        private void ModifyNotes()
        {
            string barcode = GetBarcodeFromSelectedCell();
            if (barcode == "")
                return;

            Cell = Grid.SelectedCells[0];

            FormNotes formNotes = new FormNotes();

            string name = Grid.Rows[Cell.RowIndex].Cells[1].Value.ToString();
            string surname = Grid.Rows[Cell.RowIndex].Cells[2].Value.ToString();
            formNotes.CurrentBarcode = barcode;
            formNotes.Title = name + surname;
            formNotes.Note = Grid.Rows[Cell.RowIndex].Cells[7].Value.ToString();

            formNotes.Show();
        }

        private void ExportEmails()
        {
            string writer = "";
            foreach (var customer in Customers)
                writer += customer.Value.Email + Environment.NewLine;

            File.WriteAllText(@DEFAULT_EMAILS_PATH, writer);

            FormListOfEmail emailExport = new FormListOfEmail();
            emailExport.ShowDialog();
        }

        private void Backup()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                string filePath;
                saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.FileName = "WildfireCustomersDatabase.json";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = saveFileDialog.FileName;
                    SaveDatabase(filePath);
                }
            }
        }

        private void Settings()
        {
            FormSettings formSettings = new FormSettings();
            formSettings.ShowDialog();
        }

        //DATABASE

        public static void SaveDatabase(string path)
        {
            File.WriteAllText(@path, JsonConvert.SerializeObject(Customers));
        }

        public static void LoadDatabase(string path)
        {
            try
            {
                string customersLoaded = File.ReadAllText(path);
                Customers = JsonConvert.DeserializeObject<Dictionary<string, Customer>>(customersLoaded);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Nothing to load!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (Customer customer in Customers.Values)
            {
                customer.CalculateBalance();
            }
        }

        public static void SaveSettings()
        {
            File.WriteAllText(DEFAULT_SETTINGS_PATH, JsonConvert.SerializeObject(ProgramSettings));
        }

        public static void LoadSettings()
        {
            try
            {
                string settingsLoaded = File.ReadAllText(DEFAULT_SETTINGS_PATH);
                ProgramSettings = JsonConvert.DeserializeObject<Settings>(settingsLoaded);
            }
            catch
            {
                ProgramSettings.DataPath = DEFAULT_DATA_PATH;
                ProgramSettings.BackupPath = DEFAULT_BACKUP_PATH;
                SaveSettings();
            }
        }

        //DICTIONARY

        public static void AddCustomerToDictionary(Customer customer)
        {
            Customers.Add(GetNewBarcode(), customer);
        }

        public static void AddCustomerToDictionary(string barcode, Customer customer)
        {
            Customers.Add(barcode, customer);
        }

        public static void UpdateCustomerToDictionary(String barcode, Customer customer)
        {
            Customers[barcode] = customer;
            SaveDatabase(ProgramSettings.DataPath);
        }

        public static Customer GetCustomer(string barcode)
        {
            if (!Customers.TryGetValue(barcode, out Customer customer))
            {
                MessageBox.Show("Barcode not in database.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                customer = null;
            }

            return customer;
        }

        //GRID

        public void BlankGrid()
        {
            int n = Grid.Rows.Count;

            for (int i = 0; i < n; i++)
                Grid.Rows.RemoveAt(0);
        }

        public static void AddCustomersToGrid()
        {
            foreach (var customer in Customers)
            {
                Grid.Rows.Add();
                Grid.Rows[Grid.Rows.Count - 1].Cells[0].Value = customer.Key;
                Grid.Rows[Grid.Rows.Count - 1].Cells[1].Value = customer.Value.Name;
                Grid.Rows[Grid.Rows.Count - 1].Cells[2].Value = customer.Value.Surname;
                Grid.Rows[Grid.Rows.Count - 1].Cells[3].Value = customer.Value.Email;
                Grid.Rows[Grid.Rows.Count - 1].Cells[4].Value = customer.Value.TelephoneNumber;
                Grid.Rows[Grid.Rows.Count - 1].Cells[5].Value = customer.Value.Points;
                Grid.Rows[Grid.Rows.Count - 1].Cells[6].Value = customer.Value.Balance;
                Grid.Rows[Grid.Rows.Count - 1].Cells[7].Value = customer.Value.Notes;
            }
        }

        public static void AddCustomerToGrid(string barcode, Customer customer)
        {
            Grid.Rows.Add();
            Grid.Rows[Grid.Rows.Count - 1].Cells[0].Value = barcode;
            Grid.Rows[Grid.Rows.Count - 1].Cells[1].Value = customer.Name;
            Grid.Rows[Grid.Rows.Count - 1].Cells[2].Value = customer.Surname;
            Grid.Rows[Grid.Rows.Count - 1].Cells[3].Value = customer.Email;
            Grid.Rows[Grid.Rows.Count - 1].Cells[4].Value = customer.TelephoneNumber;
            Grid.Rows[Grid.Rows.Count - 1].Cells[5].Value = customer.Points;
            Grid.Rows[Grid.Rows.Count - 1].Cells[6].Value = customer.Balance;
            Grid.Rows[Grid.Rows.Count - 1].Cells[7].Value = customer.Notes;
        }

        public static void AddCustomerToGrid(string barcode)
        {
            Customer customer;
            if (Customers.TryGetValue(barcode, out customer))
            {
                Grid.Rows.Add();
                Grid.Rows[Grid.Rows.Count - 1].Cells[0].Value = barcode;
                Grid.Rows[Grid.Rows.Count - 1].Cells[1].Value = customer.Name;
                Grid.Rows[Grid.Rows.Count - 1].Cells[2].Value = customer.Surname;
                Grid.Rows[Grid.Rows.Count - 1].Cells[3].Value = customer.Email;
                Grid.Rows[Grid.Rows.Count - 1].Cells[4].Value = customer.TelephoneNumber;
                Grid.Rows[Grid.Rows.Count - 1].Cells[5].Value = customer.Points;
                Grid.Rows[Grid.Rows.Count - 1].Cells[6].Value = customer.Balance;
                Grid.Rows[Grid.Rows.Count - 1].Cells[7].Value = customer.Notes;
            }
        }

        //BUTTONS

        private void buttonChexkExpire_Click(object sender, EventArgs e)
        {
            if (!ExpireAlert())
                MessageBox.Show("No coupon about to expire.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonModifyNotes_Click(object sender, EventArgs e)
        {
            ModifyNotes();
        }

        private void buttonShowDiscount_Click(object sender, EventArgs e)
        {
            if (Grid.SelectedCells.Count == 0)
                return;

            string barcode = GetBarcodeFromSelectedCell();
            if (barcode == "")
                return;

            if (!Customers.TryGetValue(barcode, out Customer editCustomer))
                return;

            editCustomer.CalculateDiscount();
        }

        private void buttonShowValidCoupon_Click(object sender, EventArgs e)
        {
            string barcode = GetBarcodeFromSelectedCell();
            if (barcode == "")
                return;

            Customer currentCustomer = GetCustomer(barcode);
            if (currentCustomer == null)
                return;

            FormShowCoupons couponsGrid = new FormShowCoupons();

            couponsGrid.LoadGrid(currentCustomer.ValidCoupons);

            couponsGrid.ShowDialog();
        }

        private void buttonShowExpiredCoupons_Click(object sender, EventArgs e)
        {
            string barcode = GetBarcodeFromSelectedCell();
            if (barcode == "")
                return;

            Customer currentCustomer = GetCustomer(barcode);
            if (currentCustomer == null)
                return;

            FormShowCoupons couponsGrid = new FormShowCoupons();

            couponsGrid.LoadGrid(currentCustomer.ExpiredCoupons);

            couponsGrid.ShowDialog();
        }

        private void buttonUseCoupons_Click(object sender, EventArgs e)
        {
            string barcode = GetBarcodeFromSelectedCell();
            if (barcode == "")
                return;

            Customer currentCustomer = GetCustomer(barcode);
            if (currentCustomer == null)
                return;

            FormUseCoupon useCoupon = new FormUseCoupon();

            useCoupon.CurrentBarcode = barcode;
            useCoupon.CurrentCustomer = currentCustomer;

            useCoupon.ShowDialog();
        }

        private void buttonAddCoupon_Click(object sender, EventArgs e)
        {
            AddCoupon();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            Remove();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            BlankGrid();
            LoadDatabase(ProgramSettings.DataPath);
            AddCustomersToGrid();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddCustomer();
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            find();
        }

        private void buttonEmailExport_Click(object sender, EventArgs e)
        {
            ExportEmails();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            BlankGrid();
            AddCustomersToGrid();
        }

        private void buttonBackup_Click(object sender, EventArgs e)
        {
            Backup();
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            Settings();
        }

        //OTHER EVENTS

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Grid.SelectedCells.Count <= 0)
                return;

            Cell = Grid.SelectedCells[0];

            if (e.KeyChar != '\r')
                return;

            string barcode = GetBarcodeFromSelectedCell();
            if (barcode == "")
                return;

            if (!Customers.TryGetValue(barcode, out Customer editCustomer))
                return;

            UpdateCustomerToDictionary(barcode, editCustomer);
            SaveDatabase(ProgramSettings.DataPath);
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string barcode = GetBarcodeFromSelectedCell();
            if (barcode == "")
                return;

            if (!Customers.TryGetValue(barcode, out Customer editCustomer))
                return;

            TextInfo textInfo = new CultureInfo("ita", false).TextInfo;

            DataGridViewCell currentCell = Grid.Rows[e.RowIndex].Cells[e.ColumnIndex];

            string newValue;

            if (currentCell.Value == null)
                newValue = "";
            else
                newValue = Grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            switch (e.ColumnIndex)
            {
                default:
                    break;

                case 1:
                    if (newValue == "")
                        currentCell.Value = editCustomer.Name;
                    else
                        currentCell.Value = textInfo.ToTitleCase(newValue);

                    if (editCustomer.Name != currentCell.Value.ToString())
                    {
                        DialogResult confirmDialog = MessageBox.Show(String.Format("Are you sure to modify {0} in {1}?", editCustomer.Name, currentCell.Value), "Confirm Modify", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (confirmDialog == DialogResult.Yes)
                        {
                            editCustomer.Name = currentCell.Value.ToString();
                            UpdateCustomerToDictionary(barcode, editCustomer);
                            SaveDatabase(ProgramSettings.DataPath);
                        }
                        else
                            currentCell.Value = editCustomer.Name;
                    }
                    break;

                case 2:
                    if (newValue == "")
                        currentCell.Value = editCustomer.Surname;
                    else
                        currentCell.Value = textInfo.ToTitleCase(newValue);

                    if (editCustomer.Surname != currentCell.Value.ToString())
                    {
                        DialogResult confirmDialog = MessageBox.Show(String.Format("Are you sure to modify {0} in {1}?", editCustomer.Surname, currentCell.Value), "Confirm Modify", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (confirmDialog == DialogResult.Yes)
                        {
                            editCustomer.Surname = currentCell.Value.ToString();
                            UpdateCustomerToDictionary(barcode, editCustomer);
                            SaveDatabase(ProgramSettings.DataPath);
                        }
                        else
                            currentCell.Value = editCustomer.Surname;
                    }
                    break;

                case 3:
                    currentCell.Value = newValue;

                    string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                                             + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                                             + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

                    Regex emailPattern = new Regex(validEmailPattern, RegexOptions.IgnoreCase);

                    if (!emailPattern.IsMatch(newValue))
                    {
                        if (newValue != "")
                        {
                            MessageBox.Show("Invalid email!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            currentCell.Value = editCustomer.Email;
                            break;
                        }
                    }

                    if (editCustomer.Email != currentCell.Value.ToString())
                    {
                        DialogResult confirmDialog = MessageBox.Show(String.Format("Are you sure to modify {0} in {1}?", editCustomer.Email, currentCell.Value), "Confirm Modify", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (confirmDialog == DialogResult.Yes)
                        {
                            editCustomer.Email = currentCell.Value.ToString();
                            UpdateCustomerToDictionary(barcode, editCustomer);
                            SaveDatabase(ProgramSettings.DataPath);
                        }
                        else
                            currentCell.Value = editCustomer.Email;
                    }
                    break;

                case 4:
                    currentCell.Value = newValue;

                    string validTelephoneNumberPattern = @"^[0-9]*$";

                    Regex telephoneNumberPattern = new Regex(validTelephoneNumberPattern, RegexOptions.IgnoreCase);

                    if (!telephoneNumberPattern.IsMatch(newValue))
                    {
                        if (newValue != "")
                        {
                            MessageBox.Show("Invalid telephone number!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            currentCell.Value = editCustomer.TelephoneNumber;
                            break;
                        }
                    }

                    if (editCustomer.TelephoneNumber != currentCell.Value.ToString())
                    {
                        DialogResult confirmDialog = MessageBox.Show(String.Format("Are you sure to modify {0} in {1}?", editCustomer.TelephoneNumber, currentCell.Value), "Confirm Modify", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (confirmDialog == DialogResult.Yes)
                        {
                            editCustomer.TelephoneNumber = currentCell.Value.ToString();
                            UpdateCustomerToDictionary(barcode, editCustomer);
                            SaveDatabase(ProgramSettings.DataPath);
                        }
                        else
                            currentCell.Value = editCustomer.TelephoneNumber;
                    }
                    break;

                case 5:
                    currentCell.Value = newValue;

                    string validPointsPattern = @"^[0-9]*$";

                    Regex pointsPattern = new Regex(validPointsPattern, RegexOptions.IgnoreCase);

                    if (!pointsPattern.IsMatch(newValue))
                    {
                        if (newValue != "")
                        {
                            MessageBox.Show("Invalid points value!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            currentCell.Value = editCustomer.Points;
                            break;
                        }
                    }

                    if (editCustomer.Points != currentCell.Value.ToString())
                    {
                        DialogResult confirmDialog = MessageBox.Show(String.Format("Are you sure to modify {0} in {1}?", editCustomer.Points, currentCell.Value), "Confirm Modify", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (confirmDialog == DialogResult.Yes)
                        {
                            editCustomer.Points = currentCell.Value.ToString();
                            UpdateCustomerToDictionary(barcode, editCustomer);
                            SaveDatabase(ProgramSettings.DataPath);
                        }
                        else
                            currentCell.Value = editCustomer.Points;
                    }
                    break;

                case 7:
                    currentCell.Value = newValue;

                    if (editCustomer.Notes != currentCell.Value.ToString())
                    {
                        DialogResult confirmDialog = MessageBox.Show("Are you sure to modify notes?", "Confirm Modify", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (confirmDialog == DialogResult.Yes)
                        {
                            editCustomer.Notes = currentCell.Value.ToString();
                            UpdateCustomerToDictionary(barcode, editCustomer);
                            SaveDatabase(ProgramSettings.DataPath);
                        }
                        else
                            currentCell.Value = editCustomer.Notes;
                    }
                    break;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Grid.SelectedCells.Count == 0)
                return;

            string barcode = GetBarcodeFromSelectedCell();
            if (barcode == "")
                return;

            if (!Customers.TryGetValue(barcode, out Customer editCustomer))
                return;

            if (Grid.SelectedCells[0].ColumnIndex == 5)
                editCustomer.CalculateDiscount();

            if (Grid.SelectedCells[0].ColumnIndex == 6)
                AddCoupon();

            if (Grid.SelectedCells[0].ColumnIndex == 7)
                ModifyNotes();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                find();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FindDispatcher();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            AutoBackup();
        }

        private void FormMainApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            AutoBackup();
        }
    }
}
