
namespace DLP_Win
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlMain = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdScan = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIf = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colContains = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colCondition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThen = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rulesetÖffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rulesetSpeichernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.stsMain = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtLogger = new System.Windows.Forms.TextBox();
            this.openRulesetDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveRulesetDialog = new System.Windows.Forms.SaveFileDialog();
            this.pnlMain.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.mnuMain.SuspendLayout();
            this.stsMain.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.panel1);
            this.pnlMain.Controls.Add(this.dataGridView1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(3, 3);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(786, 370);
            this.pnlMain.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdScan);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 341);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 29);
            this.panel1.TabIndex = 2;
            // 
            // cmdScan
            // 
            this.cmdScan.Location = new System.Drawing.Point(5, 3);
            this.cmdScan.Name = "cmdScan";
            this.cmdScan.Size = new System.Drawing.Size(100, 23);
            this.cmdScan.TabIndex = 0;
            this.cmdScan.Text = "Scan System";
            this.cmdScan.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIndex,
            this.colIf,
            this.colContains,
            this.colCondition,
            this.colThen});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(786, 370);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView1_CellValidating);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.dataGridView1_SortCompare);
            // 
            // colIndex
            // 
            this.dataGridView1.CellValueChanged -= dataGridView1_CellValueChanged;
            this.colIndex.HeaderText = "Index";
            this.colIndex.Name = "colIndex";
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            // 
            // colIf
            // 
            this.colIf.HeaderText = "Falls ...";
            this.colIf.Items.AddRange(new object[] {
            "Aktueller User",
            "Datei-Inhalt",
            "Datei-Name",
            "Inhalt",
            "Klassifizierung"});
            this.colIf.Name = "colIf";
            this.colIf.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIf.Sorted = true;
            this.colIf.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colContains
            // 
            this.colContains.HeaderText = "Selektion";
            this.colContains.Items.AddRange(new object[] {
            "!=",
            "==",
            "enthält",
            "enthält nicht",
            "REGEX"});
            this.colContains.Name = "colContains";
            this.colContains.Sorted = true;
            this.colContains.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colCondition
            // 
            this.colCondition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCondition.HeaderText = "Bedingung";
            this.colCondition.MinimumWidth = 50;
            this.colCondition.Name = "colCondition";
            this.colCondition.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colThen
            // 
            this.colThen.HeaderText = "dann ...";
            this.colThen.Items.AddRange(new object[] {
            "Blockiere",
            "Notifiziere"});
            this.colThen.Name = "colThen";
            this.colThen.Sorted = true;
            this.colThen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(800, 24);
            this.mnuMain.TabIndex = 2;
            this.mnuMain.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rulesetÖffnenToolStripMenuItem,
            this.rulesetSpeichernToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripMenuItemExit});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "&Datei";
            // 
            // rulesetÖffnenToolStripMenuItem
            // 
            this.rulesetÖffnenToolStripMenuItem.Name = "rulesetÖffnenToolStripMenuItem";
            this.rulesetÖffnenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.rulesetÖffnenToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.rulesetÖffnenToolStripMenuItem.Text = "Ruleset Ö&ffnen";
            this.rulesetÖffnenToolStripMenuItem.Click += new System.EventHandler(this.rulesetOpenToolStripMenuItem_Click);
            // 
            // rulesetSpeichernToolStripMenuItem
            // 
            this.rulesetSpeichernToolStripMenuItem.Name = "rulesetSpeichernToolStripMenuItem";
            this.rulesetSpeichernToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.rulesetSpeichernToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.rulesetSpeichernToolStripMenuItem.Text = "Ruleset &Speichern";
            this.rulesetSpeichernToolStripMenuItem.Click += new System.EventHandler(this.rulesetSaveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(206, 6);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(209, 22);
            this.toolStripMenuItemExit.Text = "B&eenden";
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.toolStripMenuItemExit_Click);
            // 
            // stsMain
            // 
            this.stsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.stsMain.Location = new System.Drawing.Point(0, 428);
            this.stsMain.Name = "stsMain";
            this.stsMain.Size = new System.Drawing.Size(800, 22);
            this.stsMain.TabIndex = 3;
            this.stsMain.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 404);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pnlMain);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 376);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Rulesets";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtLogger);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 376);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Logs";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtLogger
            // 
            this.txtLogger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLogger.Location = new System.Drawing.Point(3, 3);
            this.txtLogger.Multiline = true;
            this.txtLogger.Name = "txtLogger";
            this.txtLogger.Size = new System.Drawing.Size(786, 370);
            this.txtLogger.TabIndex = 0;
            // 
            // openRulesetDialog
            // 
            this.openRulesetDialog.DefaultExt = "json";
            this.openRulesetDialog.FileName = "ruleset.json";
            this.openRulesetDialog.Filter = "JSON-Datei (*.json)|*.json";
            this.openRulesetDialog.Title = "Ruleset öffnen";
            this.openRulesetDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openRulesetDialog_FileOk);
            // 
            // saveRulesetDialog
            // 
            this.saveRulesetDialog.DefaultExt = "json";
            this.saveRulesetDialog.FileName = "ruleset.json";
            this.saveRulesetDialog.Filter = "JSON-Date (*.json)|*.json";
            this.saveRulesetDialog.Title = "Ruleset speichern";
            this.saveRulesetDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveRulesetDialog_FileOk);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.stsMain);
            this.Controls.Add(this.mnuMain);
            this.Name = "frmMain";
            this.Text = "DLP Rule Mgmt";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.stsMain.ResumeLayout(false);
            this.stsMain.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.StatusStrip stsMain;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdScan;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem rulesetÖffnenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rulesetSpeichernToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.OpenFileDialog openRulesetDialog;
        private System.Windows.Forms.TextBox txtLogger;
        private System.Windows.Forms.SaveFileDialog saveRulesetDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIndex;
        private System.Windows.Forms.DataGridViewComboBoxColumn colIf;
        private System.Windows.Forms.DataGridViewComboBoxColumn colContains;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCondition;
        private System.Windows.Forms.DataGridViewComboBoxColumn colThen;
    }
}

