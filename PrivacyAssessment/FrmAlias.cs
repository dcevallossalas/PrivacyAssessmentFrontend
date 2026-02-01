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
    /// <summary>
    /// Class FrmAlias
    /// Form to determine the alias to be used for the R statistics
    /// </summary>
    public partial class FrmAlias : Form
    {
        public string alias = string.Empty;
        public string name = string.Empty;
        CaseItem item = null;

        // Constructor
        public FrmAlias()
        {
            InitializeComponent();
        }

        // Constructor with an item component
        public FrmAlias(CaseItem item)
        {
            InitializeComponent();
            this.item = item;
        }

        // Displays general information when the form loads
        private void FrmAlias_Load(object sender, EventArgs e)
        {
            if (item != null)
            {
                txtName.Text = item.name;
                txtAlias.Text = item.alias;
            }
        }

        // Sets the new name for the alias
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