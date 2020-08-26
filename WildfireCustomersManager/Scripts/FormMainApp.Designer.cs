namespace WildfireCustomersManager
{
    partial class FormMainApp
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainApp));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.GridBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridSurname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridTelephoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridPoints = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonShowValidCoupon = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonEmailExport = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonFind = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonBackup = new System.Windows.Forms.Button();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.buttonShowExpiredCoupons = new System.Windows.Forms.Button();
            this.buttonUseCoupons = new System.Windows.Forms.Button();
            this.buttonAddCoupon = new System.Windows.Forms.Button();
            this.buttonShowDiscount = new System.Windows.Forms.Button();
            this.buttonModifyNotes = new System.Windows.Forms.Button();
            this.buttonChexkExpire = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GridBarcode,
            this.GridName,
            this.GridSurname,
            this.GridEmail,
            this.GridTelephoneNumber,
            this.GridPoints,
            this.GridBalance,
            this.GridNotes});
            this.dataGridView1.Location = new System.Drawing.Point(12, 283);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1105, 308);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            // 
            // GridBarcode
            // 
            this.GridBarcode.HeaderText = "Barcode";
            this.GridBarcode.MinimumWidth = 6;
            this.GridBarcode.Name = "GridBarcode";
            this.GridBarcode.ReadOnly = true;
            this.GridBarcode.Width = 125;
            // 
            // GridName
            // 
            this.GridName.HeaderText = "Name";
            this.GridName.MinimumWidth = 6;
            this.GridName.Name = "GridName";
            this.GridName.Width = 150;
            // 
            // GridSurname
            // 
            this.GridSurname.HeaderText = "Surname";
            this.GridSurname.MinimumWidth = 6;
            this.GridSurname.Name = "GridSurname";
            this.GridSurname.Width = 150;
            // 
            // GridEmail
            // 
            this.GridEmail.HeaderText = "Email";
            this.GridEmail.MinimumWidth = 6;
            this.GridEmail.Name = "GridEmail";
            this.GridEmail.Width = 200;
            // 
            // GridTelephoneNumber
            // 
            this.GridTelephoneNumber.HeaderText = "Tel. Number";
            this.GridTelephoneNumber.MinimumWidth = 6;
            this.GridTelephoneNumber.Name = "GridTelephoneNumber";
            this.GridTelephoneNumber.Width = 125;
            // 
            // GridPoints
            // 
            this.GridPoints.HeaderText = "Points";
            this.GridPoints.MinimumWidth = 6;
            this.GridPoints.Name = "GridPoints";
            this.GridPoints.Width = 75;
            // 
            // GridBalance
            // 
            this.GridBalance.HeaderText = "Balance";
            this.GridBalance.MinimumWidth = 6;
            this.GridBalance.Name = "GridBalance";
            this.GridBalance.ReadOnly = true;
            this.GridBalance.Width = 75;
            // 
            // GridNotes
            // 
            this.GridNotes.HeaderText = "Notes";
            this.GridNotes.MinimumWidth = 6;
            this.GridNotes.Name = "GridNotes";
            this.GridNotes.Width = 125;
            // 
            // buttonShowValidCoupon
            // 
            this.buttonShowValidCoupon.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonShowValidCoupon.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowValidCoupon.ForeColor = System.Drawing.Color.White;
            this.buttonShowValidCoupon.Location = new System.Drawing.Point(212, 205);
            this.buttonShowValidCoupon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonShowValidCoupon.Name = "buttonShowValidCoupon";
            this.buttonShowValidCoupon.Size = new System.Drawing.Size(94, 46);
            this.buttonShowValidCoupon.TabIndex = 2;
            this.buttonShowValidCoupon.Text = "Valid Coupons";
            this.buttonShowValidCoupon.UseVisualStyleBackColor = false;
            this.buttonShowValidCoupon.Click += new System.EventHandler(this.buttonShowValidCoupon_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.ForeColor = System.Drawing.Color.White;
            this.buttonAdd.Location = new System.Drawing.Point(13, 155);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(94, 46);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "Add Customer";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonRemove.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemove.ForeColor = System.Drawing.Color.White;
            this.buttonRemove.Location = new System.Drawing.Point(113, 155);
            this.buttonRemove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(94, 46);
            this.buttonRemove.TabIndex = 1;
            this.buttonRemove.Text = "Remove Customer";
            this.buttonRemove.UseVisualStyleBackColor = false;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonEmailExport
            // 
            this.buttonEmailExport.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonEmailExport.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEmailExport.ForeColor = System.Drawing.Color.White;
            this.buttonEmailExport.Location = new System.Drawing.Point(895, 205);
            this.buttonEmailExport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonEmailExport.Name = "buttonEmailExport";
            this.buttonEmailExport.Size = new System.Drawing.Size(94, 46);
            this.buttonEmailExport.TabIndex = 6;
            this.buttonEmailExport.Text = "Export Email";
            this.buttonEmailExport.UseVisualStyleBackColor = false;
            this.buttonEmailExport.Click += new System.EventHandler(this.buttonEmailExport_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonLoad.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoad.ForeColor = System.Drawing.Color.White;
            this.buttonLoad.Location = new System.Drawing.Point(560, 205);
            this.buttonLoad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(94, 46);
            this.buttonLoad.TabIndex = 3;
            this.buttonLoad.Text = "Load Table";
            this.buttonLoad.UseVisualStyleBackColor = false;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonFind
            // 
            this.buttonFind.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonFind.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFind.ForeColor = System.Drawing.Color.White;
            this.buttonFind.Location = new System.Drawing.Point(112, 255);
            this.buttonFind.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(94, 25);
            this.buttonFind.TabIndex = 9;
            this.buttonFind.Text = "Find";
            this.buttonFind.UseVisualStyleBackColor = false;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(212, 257);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(877, 22);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.Black;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.ForeColor = System.Drawing.Color.White;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(13, 255);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(93, 24);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1131, 100);
            this.panel1.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(1017, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonRefresh.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRefresh.ForeColor = System.Drawing.Color.White;
            this.buttonRefresh.Location = new System.Drawing.Point(660, 206);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(94, 46);
            this.buttonRefresh.TabIndex = 4;
            this.buttonRefresh.Text = "Refresh Table";
            this.buttonRefresh.UseVisualStyleBackColor = false;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonBackup
            // 
            this.buttonBackup.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonBackup.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBackup.ForeColor = System.Drawing.Color.White;
            this.buttonBackup.Location = new System.Drawing.Point(760, 206);
            this.buttonBackup.Name = "buttonBackup";
            this.buttonBackup.Size = new System.Drawing.Size(94, 46);
            this.buttonBackup.TabIndex = 5;
            this.buttonBackup.Text = "Backup";
            this.buttonBackup.UseVisualStyleBackColor = false;
            this.buttonBackup.Click += new System.EventHandler(this.buttonBackup_Click);
            // 
            // buttonSettings
            // 
            this.buttonSettings.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonSettings.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSettings.ForeColor = System.Drawing.Color.White;
            this.buttonSettings.Location = new System.Drawing.Point(995, 205);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(94, 46);
            this.buttonSettings.TabIndex = 7;
            this.buttonSettings.Text = "Settings";
            this.buttonSettings.UseVisualStyleBackColor = false;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // buttonShowExpiredCoupons
            // 
            this.buttonShowExpiredCoupons.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonShowExpiredCoupons.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowExpiredCoupons.ForeColor = System.Drawing.Color.White;
            this.buttonShowExpiredCoupons.Location = new System.Drawing.Point(312, 205);
            this.buttonShowExpiredCoupons.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonShowExpiredCoupons.Name = "buttonShowExpiredCoupons";
            this.buttonShowExpiredCoupons.Size = new System.Drawing.Size(94, 46);
            this.buttonShowExpiredCoupons.TabIndex = 15;
            this.buttonShowExpiredCoupons.Text = "Expired Coupons";
            this.buttonShowExpiredCoupons.UseVisualStyleBackColor = false;
            this.buttonShowExpiredCoupons.Click += new System.EventHandler(this.buttonShowExpiredCoupons_Click);
            // 
            // buttonUseCoupons
            // 
            this.buttonUseCoupons.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonUseCoupons.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUseCoupons.ForeColor = System.Drawing.Color.White;
            this.buttonUseCoupons.Location = new System.Drawing.Point(113, 205);
            this.buttonUseCoupons.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonUseCoupons.Name = "buttonUseCoupons";
            this.buttonUseCoupons.Size = new System.Drawing.Size(94, 46);
            this.buttonUseCoupons.TabIndex = 16;
            this.buttonUseCoupons.Text = "Use Coupons";
            this.buttonUseCoupons.UseVisualStyleBackColor = false;
            this.buttonUseCoupons.Click += new System.EventHandler(this.buttonUseCoupons_Click);
            // 
            // buttonAddCoupon
            // 
            this.buttonAddCoupon.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonAddCoupon.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddCoupon.ForeColor = System.Drawing.Color.White;
            this.buttonAddCoupon.Location = new System.Drawing.Point(12, 205);
            this.buttonAddCoupon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAddCoupon.Name = "buttonAddCoupon";
            this.buttonAddCoupon.Size = new System.Drawing.Size(94, 46);
            this.buttonAddCoupon.TabIndex = 17;
            this.buttonAddCoupon.Text = "Add Coupon";
            this.buttonAddCoupon.UseVisualStyleBackColor = false;
            this.buttonAddCoupon.Click += new System.EventHandler(this.buttonAddCoupon_Click);
            // 
            // buttonShowDiscount
            // 
            this.buttonShowDiscount.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonShowDiscount.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowDiscount.ForeColor = System.Drawing.Color.White;
            this.buttonShowDiscount.Location = new System.Drawing.Point(213, 155);
            this.buttonShowDiscount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonShowDiscount.Name = "buttonShowDiscount";
            this.buttonShowDiscount.Size = new System.Drawing.Size(94, 46);
            this.buttonShowDiscount.TabIndex = 18;
            this.buttonShowDiscount.Text = "Show Discount";
            this.buttonShowDiscount.UseVisualStyleBackColor = false;
            this.buttonShowDiscount.Click += new System.EventHandler(this.buttonShowDiscount_Click);
            // 
            // buttonModifyNotes
            // 
            this.buttonModifyNotes.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonModifyNotes.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModifyNotes.ForeColor = System.Drawing.Color.White;
            this.buttonModifyNotes.Location = new System.Drawing.Point(312, 155);
            this.buttonModifyNotes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonModifyNotes.Name = "buttonModifyNotes";
            this.buttonModifyNotes.Size = new System.Drawing.Size(94, 46);
            this.buttonModifyNotes.TabIndex = 19;
            this.buttonModifyNotes.Text = "Show Notes";
            this.buttonModifyNotes.UseVisualStyleBackColor = false;
            this.buttonModifyNotes.Click += new System.EventHandler(this.buttonModifyNotes_Click);
            // 
            // buttonChexkExpire
            // 
            this.buttonChexkExpire.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonChexkExpire.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonChexkExpire.ForeColor = System.Drawing.Color.White;
            this.buttonChexkExpire.Location = new System.Drawing.Point(412, 205);
            this.buttonChexkExpire.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonChexkExpire.Name = "buttonChexkExpire";
            this.buttonChexkExpire.Size = new System.Drawing.Size(94, 46);
            this.buttonChexkExpire.TabIndex = 20;
            this.buttonChexkExpire.Text = "Check Coupons";
            this.buttonChexkExpire.UseVisualStyleBackColor = false;
            this.buttonChexkExpire.Click += new System.EventHandler(this.buttonChexkExpire_Click);
            // 
            // FormMainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1128, 603);
            this.Controls.Add(this.buttonChexkExpire);
            this.Controls.Add(this.buttonModifyNotes);
            this.Controls.Add(this.buttonShowDiscount);
            this.Controls.Add(this.buttonAddCoupon);
            this.Controls.Add(this.buttonUseCoupons);
            this.Controls.Add(this.buttonShowExpiredCoupons);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.buttonBackup);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonEmailExport);
            this.Controls.Add(this.buttonShowValidCoupon);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonFind);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormMainApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WildfireCustomersManager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMainApp_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonShowValidCoupon;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button buttonEmailExport;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonBackup;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridName;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridSurname;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridTelephoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridPoints;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridNotes;
        private System.Windows.Forms.Button buttonShowExpiredCoupons;
        private System.Windows.Forms.Button buttonUseCoupons;
        private System.Windows.Forms.Button buttonAddCoupon;
        private System.Windows.Forms.Button buttonShowDiscount;
        private System.Windows.Forms.Button buttonModifyNotes;
        private System.Windows.Forms.Button buttonChexkExpire;
    }
}

