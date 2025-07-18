using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Windows.Forms;
using System.Xml.Linq;
using AssessmentLibrary;
using AssessmentLibrary.AssessmentLogic;
using AssessmentLibrary.AssessmentModel;
using RestSharp;
using Document = AssessmentLibrary.AssessmentModel.Document;

namespace PrivacyAssessment
{
    public partial class Normatives : Form
    {
        private int type = 0;

        public Normatives()
        {
            InitializeComponent();
        }

        private void btnFindNormative_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Normative",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtPathNormative.Text = openFileDialog.FileName;
            }
        }

        private void btnLoadNormative_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNameNormative.Text))
            {
                MessageBox.Show("Specify the name of the normative", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtAlias.Text))
            {
                MessageBox.Show("Specify an alias for the normative", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!FileValidator.IsValidFileName(txtAlias.Text))
            {
                MessageBox.Show("Alias not valid. Avoid special characters that could cause a problem", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageBox.Show("Specify a description for the normative", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtPathNormative.Text))
            {
                MessageBox.Show("Specify a path of the .txt file with the normative", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (lsbCategories.Items.Count <= 0)
            {
                MessageBox.Show("You must determine the principles and related categories", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<Principle> principles = new List<Principle>();

            foreach (var listBoxItem in lsbCategories.Items)
            {
                string[] values = listBoxItem.ToString().Split(" ");
                int principleId = int.Parse(values[1]);
                int categoryFrom = int.Parse(values[4]);
                int categoryTo = int.Parse(values[6]);

                Principle principle = new Principle
                {
                    principle = principleId,
                    category_from = categoryFrom,
                    category_to = categoryTo
                };
                principles.Add(principle);
            }
            Document document = new Document
            {
                name = txtNameNormative.Text,
                alias = txtAlias.Text,
                description = txtDescription.Text,
                docType = type,
                principles = principles
            };

            Response response = Assessment.createDocument(document, txtPathNormative.Text);
            if (response.code == 0)
            {
                MessageBox.Show("Normative loaded with success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadNormatives(1);
            }
            else
            {
                setBlocked();
                MessageBox.Show(response.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void setBlocked()
        {
            cmbNormatives.Items.Clear();
            cmbNormatives.Text = string.Empty;
            cmbNormatives.Enabled = false;
            btnLoadNormative.Enabled = false;
            btnFindNormative.Enabled = false;
            btnDelete.Enabled = false;
            txtPathNormative.Text = string.Empty;
            txtPathNormative.ReadOnly = true;
            txtNameNormative.Text = string.Empty;
            txtNameNormative.ReadOnly = true;
            txtAlias.Text = string.Empty;
            txtAlias.ReadOnly = true;
            txtDescription.Text = string.Empty;
            txtDescription.ReadOnly = true;
            txtId.Text = string.Empty;
            txtId.ReadOnly = true;
            txtPrinciple.Text = string.Empty;
            txtPrinciple.ReadOnly = true;
            txtCategoryFrom.Text = string.Empty;
            txtCategoryFrom.ReadOnly = true;
            txtCategoryTo.Text = string.Empty;
            txtCategoryTo.ReadOnly = true;
            btnDeleteCategory.Enabled = false;
            btnAddCategory.Enabled = false;
            lsbCategories.Items.Clear();
            lsbCategories.Enabled = false;
        }
        private void setCreateMode()
        {
            cmbNormatives.Enabled = true;
            btnFindNormative.Enabled = true;
            btnLoadNormative.Enabled = true;
            btnDelete.Enabled = false;
            txtPathNormative.Text = string.Empty;
            txtPathNormative.ReadOnly = true;
            txtNameNormative.Text = string.Empty;
            txtNameNormative.ReadOnly = false;
            txtAlias.Text = string.Empty;
            txtAlias.ReadOnly = false;
            txtDescription.Text = string.Empty;
            txtDescription.ReadOnly = false;
            txtId.Text = string.Empty;
            txtId.ReadOnly = true;
            txtPrinciple.Text = string.Empty;
            txtPrinciple.ReadOnly = false;
            txtCategoryFrom.Text = string.Empty;
            txtCategoryFrom.ReadOnly = false;
            txtCategoryTo.Text = string.Empty;
            txtCategoryTo.ReadOnly = false;
            btnDeleteCategory.Enabled = false;
            btnAddCategory.Enabled = true;
            lsbCategories.Items.Clear();
            lsbCategories.Enabled = true;
            txtNameNormative.Select();
        }
        private void setModifyMode()
        {
            cmbNormatives.Enabled = true;
            btnFindNormative.Enabled = false;
            btnLoadNormative.Enabled = false;
            btnDelete.Enabled = true;
            txtPathNormative.Text = string.Empty;
            txtPathNormative.ReadOnly = true;
            txtNameNormative.ReadOnly = true;
            txtAlias.ReadOnly = true;
            txtDescription.ReadOnly = true;
            txtId.ReadOnly = true;
            txtPrinciple.Text = string.Empty;
            txtPrinciple.ReadOnly = true;
            txtCategoryFrom.Text = string.Empty;
            txtCategoryFrom.ReadOnly = true;
            txtCategoryTo.Text = string.Empty;
            txtCategoryTo.ReadOnly = true;
            btnDeleteCategory.Enabled = false;
            btnAddCategory.Enabled = false;
            lsbCategories.Enabled = false;
        }

        private void LoadNormatives(int index)
        {
            Documents documents = Assessment.getDocuments(type);
            if (documents.code == 0)
            {
                List<Document> normatives = documents.documents;
                Document document = new Document { id = 0, name = "Create new..." };

                normatives.Insert(0, document);

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
                        Text = text
                    };

                    cmbNormatives.Items.Add(cmbItem);
                }

                cmbNormatives.SelectedIndex = index;
            }
            else
            {
                setBlocked();
                MessageBox.Show(documents.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbNormatives_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse((cmbNormatives.SelectedItem as ComboBoxItem).Value.ToString());
            if (id == 0)
            {
                setCreateMode();
            }
            else
            {
                Document document = Assessment.getDocument(type, id);

                if (document.code == 0)
                {
                    txtId.Text = document.id.ToString();
                    txtNameNormative.Text = document.name;
                    txtAlias.Text = document.alias;
                    txtDescription.Text = document.description;
                    lsbCategories.Items.Clear();

                    foreach (Principle principle in document.principles)
                    {
                        lsbCategories.Items.Add("Principle " + principle.principle +
                            " from category: " + principle.category_from + " to " +
                            principle.category_to);
                    }

                    setModifyMode();
                }
                else
                {
                    setBlocked();
                    MessageBox.Show(document.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Normatives_Load(object sender, EventArgs e)
        {
            LoadNormatives(0);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadNormatives(0);
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPrinciple.Text))
            {
                MessageBox.Show("You must enter a value of principle", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrEmpty(txtCategoryFrom.Text))
            {
                MessageBox.Show("You must enter a value of initial category", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            else if (string.IsNullOrEmpty(txtCategoryTo.Text))
            {
                MessageBox.Show("You must enter a value of final category", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int principle = int.Parse(txtPrinciple.Text);
            int categoryFrom = int.Parse(txtCategoryFrom.Text);
            int categoryTo = int.Parse(txtCategoryTo.Text);

            if (categoryTo < categoryFrom)
            {
                MessageBox.Show("Value of final category not valid. It must be equal to or greater than the initial category", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int principle_reference;
            int categoryFrom_reference;
            int categoryTo_reference;
            int counter = 0;

            foreach (var listBoxItem in lsbCategories.Items)
            {
                string[] values = listBoxItem.ToString().Split(" ");
                counter++;
                principle_reference = int.Parse(values[1]);
                categoryFrom_reference = int.Parse(values[4]);
                categoryTo_reference = int.Parse(values[6]);

                if ((categoryFrom >= categoryFrom_reference & categoryFrom <= categoryTo_reference) ||
                    (categoryTo >= categoryFrom_reference & categoryTo <= categoryTo_reference))
                {
                    MessageBox.Show("Overlapping with statement " + counter, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if ((categoryFrom_reference >= categoryFrom & categoryFrom_reference <= categoryTo) ||
                    (categoryTo_reference >= categoryFrom & categoryTo_reference <= categoryTo))
                {
                    MessageBox.Show("Overlapping with statement " + counter, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            lsbCategories.Items.Add("Principle " + principle + " from category: " + categoryFrom + " to " + categoryTo);
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            if (lsbCategories.SelectedIndex != -1)
            {
                lsbCategories.Items.RemoveAt(lsbCategories.SelectedIndex);
                btnDeleteCategory.Enabled = false;
                
            }
        }

        private void lsbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbCategories.SelectedIndex != -1)
            {
                btnDeleteCategory.Enabled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = Confirmation.ShowCustomYesNo("Do you want to remove this normative?", "Confirmation", "Yes", "No");

            if (result == DialogResult.Yes)
            {
                Response response = Assessment.deleteDocument(type, int.Parse(txtId.Text));
                if (response.code == 0)
                {
                    MessageBox.Show("Normative deleted with success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadNormatives(0);
                }
                else
                {
                    setBlocked();
                    MessageBox.Show(response.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtPrinciple_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCategoryFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCategoryTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}
