namespace DBCompare
{
    partial class ObjectFetch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObjectFetch));
            this.btnCancel = new System.Windows.Forms.Button();
            this.bwScripting = new System.ComponentModel.BackgroundWorker();
            this.lwProgress = new System.Windows.Forms.ListView();
            this.Operation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::DBCompare.Properties.Resources.Microsoft_SqlServer_Management_SqlMgmt_Images_Stop;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(332, 322);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(67, 24);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lwProgress
            // 
            this.lwProgress.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Operation,
            this.Status});
            this.lwProgress.FullRowSelect = true;
            this.lwProgress.Location = new System.Drawing.Point(13, 13);
            this.lwProgress.Name = "lwProgress";
            this.lwProgress.Size = new System.Drawing.Size(386, 303);
            this.lwProgress.TabIndex = 3;
            this.lwProgress.UseCompatibleStateImageBehavior = false;
            this.lwProgress.View = System.Windows.Forms.View.Details;
            // 
            // Operation
            // 
            this.Operation.Text = "Operation";
            this.Operation.Width = 326;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 53;
            // 
            // ObjectFetch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 358);
            this.Controls.Add(this.lwProgress);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ObjectFetch";
            this.Text = "ObjectFetch";
            this.Load += new System.EventHandler(this.ObjectFetch_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.ComponentModel.BackgroundWorker bwScripting;
        private System.Windows.Forms.ListView lwProgress;
        private System.Windows.Forms.ColumnHeader Operation;
        private System.Windows.Forms.ColumnHeader Status;
    }
}