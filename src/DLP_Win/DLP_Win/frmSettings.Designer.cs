namespace DLP_Win
{
    partial class frmSettings
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
            cmdSave = new System.Windows.Forms.Button();
            lblExtensions = new System.Windows.Forms.Label();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            groupBox1 = new System.Windows.Forms.GroupBox();
            txtExtensions = new System.Windows.Forms.TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // cmdSave
            // 
            cmdSave.Location = new System.Drawing.Point(301, 16);
            cmdSave.Name = "cmdSave";
            cmdSave.Size = new System.Drawing.Size(75, 23);
            cmdSave.TabIndex = 0;
            cmdSave.Text = "OK";
            cmdSave.UseVisualStyleBackColor = true;
            // 
            // lblExtensions
            // 
            lblExtensions.AutoSize = true;
            lblExtensions.Location = new System.Drawing.Point(6, 19);
            lblExtensions.Name = "lblExtensions";
            lblExtensions.Size = new System.Drawing.Size(68, 15);
            lblExtensions.TabIndex = 1;
            lblExtensions.Text = "Datentypen";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtExtensions);
            groupBox1.Controls.Add(lblExtensions);
            groupBox1.Controls.Add(cmdSave);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox1.Location = new System.Drawing.Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(388, 51);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Einstellungen";
            // 
            // txtExtensions
            // 
            txtExtensions.Location = new System.Drawing.Point(80, 16);
            txtExtensions.Name = "txtExtensions";
            txtExtensions.Size = new System.Drawing.Size(209, 23);
            txtExtensions.TabIndex = 2;
            txtExtensions.Text = "txt";
            // 
            // frmSettings
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(388, 51);
            Controls.Add(groupBox1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            Name = "frmSettings";
            Text = "Einstellungen";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Label lblExtensions;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtExtensions;
    }
}