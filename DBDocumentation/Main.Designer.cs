namespace DBDocumentation
{
    partial class Main
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.txtOutputForder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.cmdCompare = new System.Windows.Forms.Button();
            this.pnlServer1 = new System.Windows.Forms.Panel();
            this.cmdRefreshServer1 = new System.Windows.Forms.Button();
            this.lblDatabase1 = new System.Windows.Forms.Label();
            this.cboDatabase1 = new System.Windows.Forms.ComboBox();
            this.lblPassword1 = new System.Windows.Forms.Label();
            this.lblUserName1 = new System.Windows.Forms.Label();
            this.txtPassword1 = new System.Windows.Forms.TextBox();
            this.txtUser1 = new System.Windows.Forms.TextBox();
            this.rbSQLServerAuthentication1 = new System.Windows.Forms.RadioButton();
            this.rbWindowsAuthentication1 = new System.Windows.Forms.RadioButton();
            this.cboServer1 = new System.Windows.Forms.ComboBox();
            this.lblServer1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            this.pnlServer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(383, 56);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(60, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Connection Options";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DBDocumentation.Properties.Resources.Misc_Database_3_icon;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 53);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.txtOutputForder);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.propertyGrid1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(354, 317);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Generation Options";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(323, 281);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 20);
            this.button1.TabIndex = 3;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtOutputForder
            // 
            this.txtOutputForder.Location = new System.Drawing.Point(6, 281);
            this.txtOutputForder.Name = "txtOutputForder";
            this.txtOutputForder.Size = new System.Drawing.Size(311, 20);
            this.txtOutputForder.TabIndex = 2;
            this.txtOutputForder.Text = "E:\\temp\\Documentation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 264);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Output Directory:";
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.HelpVisible = false;
            this.propertyGrid1.Location = new System.Drawing.Point(6, 6);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(342, 255);
            this.propertyGrid1.TabIndex = 0;
            this.propertyGrid1.ToolbarVisible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.pnlSettings);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(354, 317);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Login Options";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblStatus);
            this.groupBox1.Location = new System.Drawing.Point(6, 228);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 83);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generation status";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(20, 38);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(35, 13);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "label3";
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.cmdCompare);
            this.pnlSettings.Controls.Add(this.pnlServer1);
            this.pnlSettings.Location = new System.Drawing.Point(3, 6);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(347, 216);
            this.pnlSettings.TabIndex = 0;
            // 
            // cmdCompare
            // 
            this.cmdCompare.Location = new System.Drawing.Point(257, 190);
            this.cmdCompare.Name = "cmdCompare";
            this.cmdCompare.Size = new System.Drawing.Size(75, 23);
            this.cmdCompare.TabIndex = 3;
            this.cmdCompare.Text = "Login";
            this.cmdCompare.UseVisualStyleBackColor = true;
            this.cmdCompare.Click += new System.EventHandler(this.cmdCompare_Click);
            // 
            // pnlServer1
            // 
            this.pnlServer1.Controls.Add(this.cmdRefreshServer1);
            this.pnlServer1.Controls.Add(this.lblDatabase1);
            this.pnlServer1.Controls.Add(this.cboDatabase1);
            this.pnlServer1.Controls.Add(this.lblPassword1);
            this.pnlServer1.Controls.Add(this.lblUserName1);
            this.pnlServer1.Controls.Add(this.txtPassword1);
            this.pnlServer1.Controls.Add(this.txtUser1);
            this.pnlServer1.Controls.Add(this.rbSQLServerAuthentication1);
            this.pnlServer1.Controls.Add(this.rbWindowsAuthentication1);
            this.pnlServer1.Controls.Add(this.cboServer1);
            this.pnlServer1.Controls.Add(this.lblServer1);
            this.pnlServer1.Location = new System.Drawing.Point(15, 17);
            this.pnlServer1.Name = "pnlServer1";
            this.pnlServer1.Size = new System.Drawing.Size(317, 171);
            this.pnlServer1.TabIndex = 1;
            // 
            // cmdRefreshServer1
            // 
            this.cmdRefreshServer1.Location = new System.Drawing.Point(285, 4);
            this.cmdRefreshServer1.Name = "cmdRefreshServer1";
            this.cmdRefreshServer1.Size = new System.Drawing.Size(21, 23);
            this.cmdRefreshServer1.TabIndex = 10;
            this.cmdRefreshServer1.UseVisualStyleBackColor = true;
            this.cmdRefreshServer1.Click += new System.EventHandler(this.cmdRefreshServer1_Click);
            // 
            // lblDatabase1
            // 
            this.lblDatabase1.AutoSize = true;
            this.lblDatabase1.Location = new System.Drawing.Point(5, 133);
            this.lblDatabase1.Name = "lblDatabase1";
            this.lblDatabase1.Size = new System.Drawing.Size(56, 13);
            this.lblDatabase1.TabIndex = 9;
            this.lblDatabase1.Text = "Database:";
            // 
            // cboDatabase1
            // 
            this.cboDatabase1.FormattingEnabled = true;
            this.cboDatabase1.Location = new System.Drawing.Point(63, 130);
            this.cboDatabase1.Name = "cboDatabase1";
            this.cboDatabase1.Size = new System.Drawing.Size(243, 21);
            this.cboDatabase1.TabIndex = 8;
            this.cboDatabase1.Text = "Dynamic";
            this.cboDatabase1.SelectedIndexChanged += new System.EventHandler(this.cboDatabase1_SelectedIndexChanged);
            this.cboDatabase1.Click += new System.EventHandler(this.cboDatabase1_Click);
            // 
            // lblPassword1
            // 
            this.lblPassword1.AutoSize = true;
            this.lblPassword1.Location = new System.Drawing.Point(96, 107);
            this.lblPassword1.Name = "lblPassword1";
            this.lblPassword1.Size = new System.Drawing.Size(56, 13);
            this.lblPassword1.TabIndex = 7;
            this.lblPassword1.Text = "Password:";
            // 
            // lblUserName1
            // 
            this.lblUserName1.AutoSize = true;
            this.lblUserName1.Location = new System.Drawing.Point(89, 81);
            this.lblUserName1.Name = "lblUserName1";
            this.lblUserName1.Size = new System.Drawing.Size(63, 13);
            this.lblUserName1.TabIndex = 6;
            this.lblUserName1.Text = "User Name:";
            // 
            // txtPassword1
            // 
            this.txtPassword1.Location = new System.Drawing.Point(158, 104);
            this.txtPassword1.Name = "txtPassword1";
            this.txtPassword1.PasswordChar = '*';
            this.txtPassword1.Size = new System.Drawing.Size(148, 20);
            this.txtPassword1.TabIndex = 5;
            this.txtPassword1.Text = "chaaron";
            // 
            // txtUser1
            // 
            this.txtUser1.Location = new System.Drawing.Point(158, 78);
            this.txtUser1.Name = "txtUser1";
            this.txtUser1.Size = new System.Drawing.Size(148, 20);
            this.txtUser1.TabIndex = 4;
            this.txtUser1.Text = "kanasz";
            // 
            // rbSQLServerAuthentication1
            // 
            this.rbSQLServerAuthentication1.AutoSize = true;
            this.rbSQLServerAuthentication1.Checked = true;
            this.rbSQLServerAuthentication1.Location = new System.Drawing.Point(63, 55);
            this.rbSQLServerAuthentication1.Name = "rbSQLServerAuthentication1";
            this.rbSQLServerAuthentication1.Size = new System.Drawing.Size(150, 17);
            this.rbSQLServerAuthentication1.TabIndex = 3;
            this.rbSQLServerAuthentication1.TabStop = true;
            this.rbSQLServerAuthentication1.Text = "SQL Server authentication";
            this.rbSQLServerAuthentication1.UseVisualStyleBackColor = true;
            this.rbSQLServerAuthentication1.CheckedChanged += new System.EventHandler(this.rbSQLServerAuthentication1_CheckedChanged);
            // 
            // rbWindowsAuthentication1
            // 
            this.rbWindowsAuthentication1.AutoSize = true;
            this.rbWindowsAuthentication1.Location = new System.Drawing.Point(63, 32);
            this.rbWindowsAuthentication1.Name = "rbWindowsAuthentication1";
            this.rbWindowsAuthentication1.Size = new System.Drawing.Size(139, 17);
            this.rbWindowsAuthentication1.TabIndex = 2;
            this.rbWindowsAuthentication1.Text = "Windows authentication";
            this.rbWindowsAuthentication1.UseVisualStyleBackColor = true;
            this.rbWindowsAuthentication1.CheckedChanged += new System.EventHandler(this.rbWindowsAuthentication1_CheckedChanged);
            // 
            // cboServer1
            // 
            this.cboServer1.FormattingEnabled = true;
            this.cboServer1.Location = new System.Drawing.Point(63, 4);
            this.cboServer1.Name = "cboServer1";
            this.cboServer1.Size = new System.Drawing.Size(216, 21);
            this.cboServer1.TabIndex = 1;
            this.cboServer1.Text = "posta";
            this.cboServer1.Click += new System.EventHandler(this.cboServer1_Click);
            // 
            // lblServer1
            // 
            this.lblServer1.AutoSize = true;
            this.lblServer1.Location = new System.Drawing.Point(20, 7);
            this.lblServer1.Name = "lblServer1";
            this.lblServer1.Size = new System.Drawing.Size(41, 13);
            this.lblServer1.TabIndex = 0;
            this.lblServer1.Text = "Server:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 77);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(362, 343);
            this.tabControl1.TabIndex = 3;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 432);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "Main";
            this.Text = "DB Documentation Tool";
            this.Load += new System.EventHandler(this.Main_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlSettings.ResumeLayout(false);
            this.pnlServer1.ResumeLayout(false);
            this.pnlServer1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel pnlSettings;
        private System.Windows.Forms.Button cmdCompare;
        private System.Windows.Forms.Panel pnlServer1;
        private System.Windows.Forms.Button cmdRefreshServer1;
        private System.Windows.Forms.Label lblDatabase1;
        private System.Windows.Forms.ComboBox cboDatabase1;
        private System.Windows.Forms.Label lblPassword1;
        private System.Windows.Forms.Label lblUserName1;
        private System.Windows.Forms.TextBox txtPassword1;
        private System.Windows.Forms.TextBox txtUser1;
        private System.Windows.Forms.RadioButton rbSQLServerAuthentication1;
        private System.Windows.Forms.RadioButton rbWindowsAuthentication1;
        private System.Windows.Forms.ComboBox cboServer1;
        private System.Windows.Forms.Label lblServer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtOutputForder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lblStatus;


    }
}

