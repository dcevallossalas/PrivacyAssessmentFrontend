using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrivacyAssessment
{
    public partial class FrmView : Form
    {
        public FrmView(string text)
        {
            InitializeComponent();
            txtContent.Text = text.Replace("\n", Environment.NewLine).Replace("\\n", Environment.NewLine);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
