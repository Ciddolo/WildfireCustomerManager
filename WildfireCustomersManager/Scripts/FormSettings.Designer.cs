namespace WildfireCustomersManager
{
    partial class FormSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.buttonSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textDataPath = new System.Windows.Forms.TextBox();
            this.buttonDefault = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBackupPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(226, 93);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(130, 50);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Data path";
            // 
            // textDataPath
            // 
            this.textDataPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textDataPath.Location = new System.Drawing.Point(125, 15);
            this.textDataPath.Name = "textDataPath";
            this.textDataPath.ReadOnly = true;
            this.textDataPath.Size = new System.Drawing.Size(231, 22);
            this.textDataPath.TabIndex = 2;
            this.textDataPath.Click += new System.EventHandler(this.textDataPath_Click);
            // 
            // buttonDefault
            // 
            this.buttonDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDefault.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonDefault.ForeColor = System.Drawing.Color.White;
            this.buttonDefault.Location = new System.Drawing.Point(15, 93);
            this.buttonDefault.Name = "buttonDefault";
            this.buttonDefault.Size = new System.Drawing.Size(130, 49);
            this.buttonDefault.TabIndex = 3;
            this.buttonDefault.Text = "Default";
            this.buttonDefault.UseVisualStyleBackColor = false;
            this.buttonDefault.Click += new System.EventHandler(this.buttonDefault_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Backup path";
            // 
            // textBackupPath
            // 
            this.textBackupPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBackupPath.Location = new System.Drawing.Point(125, 52);
            this.textBackupPath.Name = "textBackupPath";
            this.textBackupPath.ReadOnly = true;
            this.textBackupPath.Size = new System.Drawing.Size(231, 22);
            this.textBackupPath.TabIndex = 5;
            this.textBackupPath.Click += new System.EventHandler(this.textBackupPath_Click);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(368, 155);
            this.Controls.Add(this.textBackupPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonDefault);
            this.Controls.Add(this.textDataPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textDataPath;
        private System.Windows.Forms.Button buttonDefault;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBackupPath;
    }
}