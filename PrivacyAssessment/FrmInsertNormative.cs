using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AssessmentLibrary.AssessmentModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace PrivacyAssessment
{
    /// <summary>
    /// Class FrmInsertNormative
    /// Insert a normative for being used as a referenced
    /// </summary>
    public partial class FrmInsertNormative : Form
    {
        public int id_normative;
        public string alias;
        public string name;
        public List<Document> normatives;

        // Constructor
        // List the previously created normatives
        public FrmInsertNormative(List<Document> normatives)
        {
            InitializeComponent();
            this.normatives = normatives;

            cmbNormatives.Items.Clear();
            cmbNormatives.Text = string.Empty;
            string text;

            foreach (Document normative in normatives)
            {
                if (normative.id == 0)
                    text = normative.name;
                else
                    text = normative.name + "(" + normative.alias + ")";

                ComboBoxItem cmbItem = new ComboBoxItem
                {
                    Value = normative.id,
                    Name = normative.name,
                    Alias = normative.alias,
                    Text = text
                };

                cmbNormatives.Items.Add(cmbItem);
            }

            cmbNormatives.SelectedIndex = 0;
        }

        // Sets the alias for the normative being used as a reference
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtAlias.Text))
            {
                alias = txtAlias.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            } else
            {
                txtAlias.Focus();
                MessageBox.Show("Please, insert a valid alias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        // Displays the information of the selected normative
        private void cmbNormatives_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxItem cmbItem = cmbNormatives.SelectedItem as ComboBoxItem;
            int id = int.Parse(cmbItem.Value.ToString());

            if (id > 0)
            {
                txtAlias.Text = cmbItem.Alias;
                alias = cmbItem.Alias;
                txtName.Text = cmbItem.Name;
                name = cmbItem.Name;
                id_normative = id;
                txtAlias.Focus();
            }
        }
    }
}