using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLP_Win
{
    public partial class frmSettings : Form
    {
        public List<string> Extensions
        {
            get
            {
                return txtExtensions.Text.Split(' ').ToList();
            }
        }
        public frmSettings()
        {
            InitializeComponent();
        }
    }
}
