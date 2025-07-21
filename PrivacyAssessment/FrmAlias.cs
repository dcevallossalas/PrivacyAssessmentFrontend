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
    public partial class FrmAlias : Form
    {
        public string alias = string.Empty;

        public FrmAlias()
        {
            InitializeComponent();
            txtAlias.Focus();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            alias = txtAlias.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
