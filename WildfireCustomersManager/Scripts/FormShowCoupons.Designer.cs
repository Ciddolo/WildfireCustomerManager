namespace WildfireCustomersManager
{
    partial class FormShowCoupons
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormShowCoupons));
            this.dataGridCoupons = new System.Windows.Forms.DataGridView();
            this.EmissionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpireDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InitialValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCoupons)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridCoupons
            // 
            this.dataGridCoupons.AllowUserToAddRows = false;
            this.dataGridCoupons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridCoupons.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dataGridCoupons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCoupons.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EmissionDate,
            this.ExpireDate,
            this.InitialValue,
            this.CurrentValue});
            this.dataGridCoupons.Location = new System.Drawing.Point(20, 11);
            this.dataGridCoupons.Name = "dataGridCoupons";
            this.dataGridCoupons.RowHeadersWidth = 51;
            this.dataGridCoupons.RowTemplate.Height = 24;
            this.dataGridCoupons.Size = new System.Drawing.Size(752, 250);
            this.dataGridCoupons.TabIndex = 0;
            // 
            // EmissionDate
            // 
            this.EmissionDate.HeaderText = "EmissionDate";
            this.EmissionDate.MinimumWidth = 6;
            this.EmissionDate.Name = "EmissionDate";
            this.EmissionDate.ReadOnly = true;
            this.EmissionDate.Width = 200;
            // 
            // ExpireDate
            // 
            this.ExpireDate.HeaderText = "ExpireDate";
            this.ExpireDate.MinimumWidth = 6;
            this.ExpireDate.Name = "ExpireDate";
            this.ExpireDate.ReadOnly = true;
            this.ExpireDate.Width = 200;
            // 
            // InitialValue
            // 
            this.InitialValue.HeaderText = "InitialValue";
            this.InitialValue.MinimumWidth = 6;
            this.InitialValue.Name = "InitialValue";
            this.InitialValue.Width = 125;
            // 
            // CurrentValue
            // 
            this.CurrentValue.HeaderText = "CurrentValue";
            this.CurrentValue.MinimumWidth = 6;
            this.CurrentValue.Name = "CurrentValue";
            this.CurrentValue.Width = 125;
            // 
            // FormShowCoupons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(791, 275);
            this.Controls.Add(this.dataGridCoupons);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormShowCoupons";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Coupons";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCoupons)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridCoupons;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmissionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpireDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn InitialValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentValue;
    }
}