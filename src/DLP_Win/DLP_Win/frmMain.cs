using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Windows.Forms;

namespace DLP_Win
{
    public partial class frmMain : Form
    {
        private List<Ruleset> rulesets;
        private bool datagridChanged = false;
        private const string AHV_NR = @".*756\.\d{4}\.\d{4}\.\d{2}.*";
        private const string CUSTOMER_NR = @"\d{2}\.\d{5}-\d";
        public frmMain()
        {
            InitializeComponent();
            dataGridView1.DataSource = rulesets;


            // Beispiel-JSON-String
            //string jsonString = @"[
            //    {
            //        ""Index"": 1,
            //        ""If"": ""Datei-Inhalt"",
            //        ""Contains"": ""enthält"",
            //        ""Condition"": ""geheim"",
            //        ""Then"": ""Notifiziere""
            //    },
            //    {
            //        ""Index"": 2,
            //        ""If"": ""Datei-Name"",
            //        ""Contains"": ""enthält nicht"",
            //        ""Condition"": ""HSLU"",
            //        ""Then"": ""Blockiere""
            //    }
            //]";

            //// JSON-String in Liste von Ruleset-Objekten deserialisieren
            //rulesets = JsonSerializer.Deserialize<List<Ruleset>>(jsonString);

            //// DataGridView mit der Liste von Ruleset-Objekten aktualisieren
            //rulesets.Sort((x, y) => x.Index.CompareTo(y.Index));

            //foreach (var ruleset in rulesets)
            //{
            //    int rowIndex = dataGridView1.Rows.Add();

            //    // Werte in jede Zelle einfügen
            //    dataGridView1.Rows[rowIndex].Cells[0].Value = ruleset.Index;
            //    dataGridView1.Rows[rowIndex].Cells[1].Value = ruleset.If;
            //    dataGridView1.Rows[rowIndex].Cells[2].Value = ruleset.Contains;
            //    dataGridView1.Rows[rowIndex].Cells[3].Value = ruleset.Condition;
            //    dataGridView1.Rows[rowIndex].Cells[4].Value = ruleset.Then;
            //}

        }

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

        private void dataGridView1_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Name == "colIndex") // nur für die Spalte "Index"
            {
                int value1, value2;
                if (int.TryParse(e.CellValue1.ToString(), out value1) &&
                    int.TryParse(e.CellValue2.ToString(), out value2))
                {
                    e.SortResult = value1.CompareTo(value2);
                    e.Handled = true;
                }
            }
        }

        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //TODO: falls Änderungen, speichern.
            DialogResult result = MessageBox.Show("Möchtest du die Änderungen am Ruleset speichern?", "Speichern", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Änderungen speichern
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true; // Schliessen des Formulars abbrechen
            }
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if(dataGridView1.Columns[e.ColumnIndex].Name == "colIndex")
            {

            }
        }
    }
}
