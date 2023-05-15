
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
			pnlMain = new System.Windows.Forms.Panel();
			panel1 = new System.Windows.Forms.Panel();
			cmdScan = new System.Windows.Forms.Button();
			dataGridView1 = new System.Windows.Forms.DataGridView();
			colIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
			colIf = new System.Windows.Forms.DataGridViewComboBoxColumn();
			colContains = new System.Windows.Forms.DataGridViewComboBoxColumn();
			colCondition = new System.Windows.Forms.DataGridViewTextBoxColumn();
			colThen = new System.Windows.Forms.DataGridViewComboBoxColumn();
			mnuMain = new System.Windows.Forms.MenuStrip();
			dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			rulesetÖffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			rulesetSpeichernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
			stsMain = new System.Windows.Forms.StatusStrip();
			toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
			toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			tabControl1 = new System.Windows.Forms.TabControl();
			tabPage1 = new System.Windows.Forms.TabPage();
			tabPage2 = new System.Windows.Forms.TabPage();
			txtLogger = new System.Windows.Forms.TextBox();
			openRulesetDialog = new System.Windows.Forms.OpenFileDialog();
			saveRulesetDialog = new System.Windows.Forms.SaveFileDialog();
			pnlMain.SuspendLayout();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			mnuMain.SuspendLayout();
			stsMain.SuspendLayout();
			tabControl1.SuspendLayout();
			tabPage1.SuspendLayout();
			tabPage2.SuspendLayout();
			SuspendLayout();
			// 
			// pnlMain
			// 
			pnlMain.Controls.Add(panel1);
			pnlMain.Controls.Add(dataGridView1);
			pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
			pnlMain.Location = new System.Drawing.Point(3, 3);
			pnlMain.Name = "pnlMain";
			pnlMain.Size = new System.Drawing.Size(786, 370);
			pnlMain.TabIndex = 1;
			// 
			// panel1
			// 
			panel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			panel1.Controls.Add(cmdScan);
			panel1.Location = new System.Drawing.Point(0, 335);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(786, 35);
			panel1.TabIndex = 2;
			// 
			// cmdScan
			// 
			cmdScan.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			cmdScan.BackColor = System.Drawing.Color.PaleGreen;
			cmdScan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			cmdScan.Location = new System.Drawing.Point(686, 3);
			cmdScan.Name = "cmdScan";
			cmdScan.Size = new System.Drawing.Size(100, 29);
			cmdScan.TabIndex = 0;
			cmdScan.Text = "System Scan";
			cmdScan.UseVisualStyleBackColor = false;
			cmdScan.Click += cmdScan_Click;
			// 
			// dataGridView1
			// 
			dataGridView1.AllowUserToOrderColumns = true;
			dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
			dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colIndex, colIf, colContains, colCondition, colThen });
			dataGridView1.Location = new System.Drawing.Point(0, 0);
			dataGridView1.MultiSelect = false;
			dataGridView1.Name = "dataGridView1";
			dataGridView1.RowTemplate.Height = 25;
			dataGridView1.Size = new System.Drawing.Size(786, 335);
			dataGridView1.TabIndex = 1;
			dataGridView1.CellBeginEdit += dataGridView1_CellBeginEdit;
			dataGridView1.CellValidating += dataGridView1_CellValidating;
			dataGridView1.SortCompare += dataGridView1_SortCompare;
			// 
			// colIndex
			// 
			colIndex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			colIndex.HeaderText = "Index";
			colIndex.Name = "colIndex";
			colIndex.Width = 61;
			// 
			// colIf
			// 
			colIf.HeaderText = "Falls ...";
			colIf.Items.AddRange(new object[] { "Datei-Inhalt", "Datei-Name" });
			colIf.Name = "colIf";
			colIf.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			colIf.Sorted = true;
			colIf.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// colContains
			// 
			colContains.HeaderText = "Selektion";
			colContains.Items.AddRange(new object[] { "enthält", "enthält nicht", "REGEX" });
			colContains.Name = "colContains";
			colContains.Sorted = true;
			colContains.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// colCondition
			// 
			colCondition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			colCondition.HeaderText = "Bedingung";
			colCondition.MinimumWidth = 100;
			colCondition.Name = "colCondition";
			colCondition.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			// 
			// colThen
			// 
			colThen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			colThen.HeaderText = "dann ...";
			colThen.Items.AddRange(new object[] { "in Quarantäne verschieben", "Loggen", "Notifizieren" });
			colThen.MinimumWidth = 100;
			colThen.Name = "colThen";
			colThen.Sorted = true;
			colThen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// mnuMain
			// 
			mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { dateiToolStripMenuItem });
			mnuMain.Location = new System.Drawing.Point(0, 0);
			mnuMain.Name = "mnuMain";
			mnuMain.Size = new System.Drawing.Size(800, 24);
			mnuMain.TabIndex = 2;
			mnuMain.Text = "menuStrip1";
			// 
			// dateiToolStripMenuItem
			// 
			dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { rulesetÖffnenToolStripMenuItem, rulesetSpeichernToolStripMenuItem, toolStripSeparator1, toolStripMenuItemExit });
			dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
			dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
			dateiToolStripMenuItem.Text = "&Datei";
			// 
			// rulesetÖffnenToolStripMenuItem
			// 
			rulesetÖffnenToolStripMenuItem.Name = "rulesetÖffnenToolStripMenuItem";
			rulesetÖffnenToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O;
			rulesetÖffnenToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
			rulesetÖffnenToolStripMenuItem.Text = "Ruleset Ö&ffnen";
			rulesetÖffnenToolStripMenuItem.Click += rulesetOpenToolStripMenuItem_Click;
			// 
			// rulesetSpeichernToolStripMenuItem
			// 
			rulesetSpeichernToolStripMenuItem.Name = "rulesetSpeichernToolStripMenuItem";
			rulesetSpeichernToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S;
			rulesetSpeichernToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
			rulesetSpeichernToolStripMenuItem.Text = "Ruleset &Speichern";
			rulesetSpeichernToolStripMenuItem.Click += rulesetSaveToolStripMenuItem_Click;
			// 
			// toolStripSeparator1
			// 
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new System.Drawing.Size(206, 6);
			// 
			// toolStripMenuItemExit
			// 
			toolStripMenuItemExit.Name = "toolStripMenuItemExit";
			toolStripMenuItemExit.ShortcutKeys = System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4;
			toolStripMenuItemExit.Size = new System.Drawing.Size(209, 22);
			toolStripMenuItemExit.Text = "B&eenden";
			toolStripMenuItemExit.Click += toolStripMenuItemExit_Click;
			// 
			// stsMain
			// 
			stsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripProgressBar1, toolStripStatusLabel1 });
			stsMain.Location = new System.Drawing.Point(0, 428);
			stsMain.Name = "stsMain";
			stsMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			stsMain.Size = new System.Drawing.Size(800, 22);
			stsMain.TabIndex = 3;
			stsMain.Text = "statusStrip1";
			// 
			// toolStripProgressBar1
			// 
			toolStripProgressBar1.Name = "toolStripProgressBar1";
			toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
			// 
			// toolStripStatusLabel1
			// 
			toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			toolStripStatusLabel1.Size = new System.Drawing.Size(172, 17);
			toolStripStatusLabel1.Text = "Knopf drücken für System Scan";
			// 
			// tabControl1
			// 
			tabControl1.Controls.Add(tabPage1);
			tabControl1.Controls.Add(tabPage2);
			tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			tabControl1.Location = new System.Drawing.Point(0, 24);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new System.Drawing.Size(800, 404);
			tabControl1.TabIndex = 4;
			// 
			// tabPage1
			// 
			tabPage1.Controls.Add(pnlMain);
			tabPage1.Location = new System.Drawing.Point(4, 24);
			tabPage1.Name = "tabPage1";
			tabPage1.Padding = new System.Windows.Forms.Padding(3);
			tabPage1.Size = new System.Drawing.Size(792, 376);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "Rulesets";
			tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			tabPage2.Controls.Add(txtLogger);
			tabPage2.Location = new System.Drawing.Point(4, 24);
			tabPage2.Name = "tabPage2";
			tabPage2.Padding = new System.Windows.Forms.Padding(3);
			tabPage2.Size = new System.Drawing.Size(792, 376);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "Logs";
			tabPage2.UseVisualStyleBackColor = true;
			// 
			// txtLogger
			// 
			txtLogger.Dock = System.Windows.Forms.DockStyle.Fill;
			txtLogger.Location = new System.Drawing.Point(3, 3);
			txtLogger.Multiline = true;
			txtLogger.Name = "txtLogger";
			txtLogger.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			txtLogger.Size = new System.Drawing.Size(786, 370);
			txtLogger.TabIndex = 0;
			// 
			// openRulesetDialog
			// 
			openRulesetDialog.DefaultExt = "json";
			openRulesetDialog.FileName = "ruleset.json";
			openRulesetDialog.Filter = "JSON-Datei (*.json)|*.json";
			openRulesetDialog.Title = "Ruleset öffnen";
			openRulesetDialog.FileOk += openRulesetDialog_FileOk;
			// 
			// saveRulesetDialog
			// 
			saveRulesetDialog.DefaultExt = "json";
			saveRulesetDialog.FileName = "ruleset.json";
			saveRulesetDialog.Filter = "JSON-Date (*.json)|*.json";
			saveRulesetDialog.Title = "Ruleset speichern";
			saveRulesetDialog.FileOk += saveRulesetDialog_FileOk;
			// 
			// frmMain
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(800, 450);
			Controls.Add(tabControl1);
			Controls.Add(stsMain);
			Controls.Add(mnuMain);
			Name = "frmMain";
			Text = "DLP Rule Mgmt";
			FormClosing += frmMain_FormClosing;
			DragDrop += frmMain_DragDrop;
			pnlMain.ResumeLayout(false);
			panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			mnuMain.ResumeLayout(false);
			mnuMain.PerformLayout();
			stsMain.ResumeLayout(false);
			stsMain.PerformLayout();
			tabControl1.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			tabPage2.ResumeLayout(false);
			tabPage2.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
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

