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
        public string name = string.Empty;

        public FrmAlias()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please, insert a valid name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } else if (string.IsNullOrEmpty(txtAlias.Text))
            {
                MessageBox.Show("Please, insert a valid alias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } else
            {
                name = txtName.Text;
                alias = txtAlias.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
