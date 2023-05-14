using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace DLP_Win
{
    public partial class frmMain : Form
    {
        private List<Ruleset> rulesets;
        private string originalCellValue;
        private bool datagridChanged = false;
        private string AHV_NR = Properties.Settings.Default.AHV_NR; //  @".*756\.\d{4}\.\d{4}\.\d{2}.*";
        private string CUSTOMER_NR = Properties.Settings.Default.CUSTOMER_NR; // @"\d{2}\.\d{5}-\d";

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public frmMain()
        {

            InitializeComponent();


            dataGridView1.DataSource = rulesets;
            string rulesetPath = Path.Combine(Application.StartupPath, "lof");
            if (File.Exists(rulesetPath))
            {
                string path;
                //Liest Datei mit letzten Pfad für Ruleset
                using (StreamReader reader = new StreamReader(rulesetPath))
                {
                    path = reader.ReadToEnd();
                    if (path != "")
                    {
                        //Setze Pfad für Öffnen/Speichern Dialoge
                        openRulesetDialog.InitialDirectory = path;
                        saveRulesetDialog.InitialDirectory = path;
                    }
                }

                //Ruleset einlesen
                if (File.Exists(path))
                {
                    openRulesetDialog.FileName = path;
                    openRulesetDialog_FileOk(this, new System.ComponentModel.CancelEventArgs());
                }
            }
            else
            {
                //Ansonsten setzte Applikationspfad als Startpfad
                openRulesetDialog.InitialDirectory = Application.StartupPath;
                saveRulesetDialog.InitialDirectory = Application.StartupPath;
            }
            this.dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
        }

        /// <summary>
        /// Event wenn Zellenwert geändert wurde.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.datagridChanged = true;

                if (e.ColumnIndex == dataGridView1.Columns["colIndex"].Index)
                {
                    dataGridView1.Sort(dataGridView1.Columns["colIndex"], System.ComponentModel.ListSortDirection.Ascending);
                }
            }
            catch (Exception ex)
            {
                txtLogger.Text += $"\n{ex}";
            }
        }

        /// <summary>
        /// Sortierfunktion für Spalte Index.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Name == "colIndex") // nur für die Spalte "Index"
            {
                int value1, value2;
                if (e.CellValue1 != null && e.CellValue2 != null)
                {
                    if (int.TryParse(e.CellValue1.ToString(), out value1) &&
                    int.TryParse(e.CellValue2.ToString(), out value2))
                    {
                        e.SortResult = value1.CompareTo(value2);
                        e.Handled = true;
                    }
                }
            }
        }

        /// <summary>
        /// Applikation beenden.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Event wenn Applikation schliesst.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (datagridChanged)
            {
                DialogResult result = MessageBox.Show("Möchtest du die Änderungen am Ruleset speichern?", "Speichern", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    saveRulesetDialog_FileOk(sender, new System.ComponentModel.CancelEventArgs());
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true; // Schliessen des Formulars abbrechen
                }
            }
        }

        /// <summary>
        /// Überprüft die Eingabe einer Zelle im Grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //Überprüft spezifisch die Spalte "Index" auf eine Zahl grösser 0.
            if (dataGridView1.Columns[e.ColumnIndex].Name == "colIndex")
            {
                try
                {
                    if (e.FormattedValue is not null)
                    {
                        if (e.FormattedValue.ToString() == "")
                        {
                            return;
                        }
                        if (Convert.ToInt32(e.FormattedValue) <= 0)
                        {
                            e.Cancel = true;
                            throw new Exception();
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Index muss eine Zahl ab 1 sein!", "Indexfehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtLogger.Text += $"\nIndexfehler:\n{ex}";
                    if (e.ColumnIndex != 0)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = this.originalCellValue;
                    }
                    else
                    {
                        if (Convert.ToInt32(this.originalCellValue) <= 0)
                        {
                            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                        }
                        else
                        {
                            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = this.originalCellValue;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Zwischenspeichern des Originalwertes vor der Validierung.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            this.originalCellValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
        }

        /// <summary>
        /// Datei wird geöffnet.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openRulesetDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string fileName = openRulesetDialog.FileName;
            string filePath = Path.Combine(Application.StartupPath, "lof");
            File.WriteAllText(filePath, fileName);

            if (!File.Exists(fileName))
            {
                MessageBox.Show("Die ausgewählte Datei existiert nicht.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true; // Abbrechen des Öffnens der Datei
            }
            else
            {
                dataGridView1.Rows.Clear();

                try
                {
                    // JSON-String in Liste von Ruleset-Objekten deserialisieren
                    using (StreamReader reader = new StreamReader(fileName))
                    {
                        string jsonString = reader.ReadToEnd();
                        rulesets = JsonSerializer.Deserialize<List<Ruleset>>(jsonString);
                    }

                    // DataGridView mit der Liste von Ruleset-Objekten aktualisieren
                    rulesets.Sort((x, y) => x.Index.CompareTo(y.Index));

                    foreach (var ruleset in rulesets)
                    {
                        int rowIndex = dataGridView1.Rows.Add();

                        // Werte in jede Zelle einfügen
                        dataGridView1.Rows[rowIndex].Cells[0].Value = ruleset.Index;
                        dataGridView1.Rows[rowIndex].Cells[1].Value = ruleset.If;
                        dataGridView1.Rows[rowIndex].Cells[2].Value = ruleset.Contains;
                        dataGridView1.Rows[rowIndex].Cells[3].Value = ruleset.Condition;
                        dataGridView1.Rows[rowIndex].Cells[4].Value = ruleset.Then;
                    }
                }
                catch (Exception ex)
                {
                    txtLogger.Text += ex;
                }
            }
        }

        /// <summary>
        /// Datei wird gespeichert.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveRulesetDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string fileName = saveRulesetDialog.FileName;
            string filePath = Path.Combine(Application.StartupPath, "lof");
            File.WriteAllText(filePath, fileName);

            if (rulesets is not null)
            {
                rulesets.Clear();
            }
            else
            {
                rulesets = new List<Ruleset>();
            }

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {

                Ruleset ruleset = new Ruleset();


                ruleset.Index = dataGridView1.Rows[i].Cells[0].Value != null ? Convert.ToUInt32(dataGridView1.Rows[i].Cells[0].Value) : 0;
                ruleset.If = dataGridView1.Rows[i].Cells[1].Value?.ToString();
                ruleset.Contains = dataGridView1.Rows[i].Cells[2].Value?.ToString();
                ruleset.Condition = dataGridView1.Rows[i].Cells[3].Value?.ToString();
                ruleset.Then = dataGridView1.Rows[i].Cells[4].Value?.ToString();

                rulesets.Add(ruleset);
            }
            // Liste von Ruleset-Objekten sortieren

            rulesets.Sort((x, y) => x.Index.CompareTo(y.Index));

            //var options = new JsonSerializerOptions
            //{
            //    WriteIndented = true, // Formatiere JSON mit Einrückungen und Zeilenumbrüchen
            //    //Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping // Verwende eine sichere JSON-Codierung
            //};

            // Rulesets-Liste als JSON-Datei speichern
            string jsonString = JsonSerializer.Serialize(rulesets); //, new JsonSerializerOptions() { WriteIndented = true });
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.Write(jsonString);
            }

            datagridChanged = false;
        }

        /// <summary>
        /// Dialog zum Datei öffnen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rulesetOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openRulesetDialog.ShowDialog();
        }

        /// <summary>
        /// Dialog zum Datei speichern.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rulesetSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveRulesetDialog.ShowDialog();
        }
    }
}
