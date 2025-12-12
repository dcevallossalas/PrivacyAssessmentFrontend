using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AssessmentLibrary.AssessmentModel;

namespace PrivacyAssessment
{
    public partial class FrmAlias : Form
    {
        public string alias = string.Empty;
        public string name = string.Empty;
        CaseItem item = null;

        public FrmAlias()
        {
            InitializeComponent();
        }

        public FrmAlias(CaseItem item)
        {
            InitializeComponent();
            this.item = item;
        }

        private void FrmAlias_Load(object sender, EventArgs e)
        {
            if (item != null)
            {
                txtName.Text = item.name;
                txtAlias.Text = item.alias;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please, insert a valid name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrEmpty(txtAlias.Text))
            {
                MessageBox.Show("Please, insert a valid alias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                name = txtName.Text;
                alias = txtAlias.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
