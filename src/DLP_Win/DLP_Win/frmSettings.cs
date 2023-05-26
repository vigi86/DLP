using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;
using System.Configuration;
using GemBox.Document;

namespace DLP_Win
{

    public partial class FrmSettings : Form
    {
        private Configuration configuration = new();
        private string ConfigFile { get; } = "config.json";

        public List<string> Extensions
        {
            get
            {
                return txtExtensions.Text.Split(' ').ToList();
            }
        }
        public string Searchfolder
        {
            get
            {
                return configuration.SearchFolder;
            }
        }
        public string Quarantinefolder
        {
            get
            {
                return configuration.QuarantineFolder;
            }
        }

        public FrmSettings()
        {
            InitializeComponent();
            ReadConfigurationFromFile();
        }

        private void CmdSave_Click(object sender, EventArgs e)
        {
            WriteConfiguration();
            this.Close();
        }

        private void WriteConfiguration()
        {
            configuration.Extensions = txtExtensions.Text;
            configuration.QuarantineFolder = txtQuarantineFolder.Text;
            configuration.SearchFolder = txtSearchFolder.Text;

            string json = JsonSerializer.Serialize(configuration, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(ConfigFile, json);
        }

        public void ReadConfigurationFromFile()
        {
            if (File.Exists(ConfigFile))
            {
                string json = File.ReadAllText(ConfigFile);
                configuration = JsonSerializer.Deserialize<Configuration>(json);

                txtExtensions.Text = configuration.Extensions;
                txtQuarantineFolder.Text = configuration.QuarantineFolder;
                txtSearchFolder.Text = configuration.SearchFolder;
            }
            else
            {
                txtExtensions.Text = configuration.Extensions = "txt doc docx";
                txtQuarantineFolder.Text = configuration.QuarantineFolder = $"{Application.StartupPath}QUARANTINE";
                txtSearchFolder.Text = configuration.SearchFolder = $"{Application.StartupPath}MaliciousFolder";
            }
        }
    }

    public class Configuration
    {
        public string Extensions { get; set; }
        public string QuarantineFolder { get; set; }
        public string SearchFolder { get; set; }
    }
}
