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
    public partial class FrmLaws : Form
    {
        private int type = 1;
        public List<int> deletes = new List<int>();

        public FrmLaws()
        {
            InitializeComponent();
        }

        private void btnFindLaw_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Law",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "pdf",
                Filter = "pdf files (*.pdf)|*.pdf"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtPathLaw.Text = openFileDialog.FileName;
            }
        }

        private void btnLoadLaw_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNameLaw.Text))
            {
                MessageBox.Show("Specify the name of the law", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtAlias.Text))
            {
                MessageBox.Show("Specify an alias for the law", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!FileValidator.IsValidFileName(txtAlias.Text))
            {
                MessageBox.Show("Alias not valid. Avoid special characters that could cause a problem", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageBox.Show("Specify a description for the law", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtPathLaw.Text))
            {
                MessageBox.Show("Specify a path of the .pdf file with the law", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Document document = new Document
            {
                name = txtNameLaw.Text,
                alias = txtAlias.Text,
                description = txtDescription.Text,
                docType = type
            };

            Response response = Assessment.createDocument(document, txtPathLaw.Text);
            if (response.code == 0)
            {
                MessageBox.Show("Law loaded with success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadLaws(1);
            }
            else
            {
                setBlocked();
                MessageBox.Show(response.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void setBlocked()
        {
            cmbLaws.Items.Clear();
            cmbLaws.Text = string.Empty;
            cmbLaws.Enabled = false;
            btnLoadLaw.Enabled = false;
            btnFindLaw.Enabled = false;
            btnDelete.Enabled = false;
            btnView.Enabled = false;
            txtPathLaw.Text = string.Empty;
            txtPathLaw.ReadOnly = true;
            txtNameLaw.Text = string.Empty;
            txtNameLaw.ReadOnly = true;
            txtAlias.Text = string.Empty;
            txtAlias.ReadOnly = true;
            txtDescription.Text = string.Empty;
            txtDescription.ReadOnly = true;
            txtId.Text = string.Empty;
            txtId.ReadOnly = true;
        }
        private void setCreateMode()
        {
            cmbLaws.Enabled = true;
            btnFindLaw.Enabled = true;
            btnLoadLaw.Enabled = true;
            btnDelete.Enabled = false;
            btnView.Enabled = false;
            txtPathLaw.Text = string.Empty;
            txtPathLaw.ReadOnly = true;
            txtNameLaw.Text = string.Empty;
            txtNameLaw.ReadOnly = false;
            txtAlias.Text = string.Empty;
            txtAlias.ReadOnly = false;
            txtDescription.Text = string.Empty;
            txtDescription.ReadOnly = false;
            txtId.Text = string.Empty;
            txtId.ReadOnly = true;
            txtNameLaw.Select();
        }

        private void setModifyMode()
        {
            cmbLaws.Enabled = true;
            btnFindLaw.Enabled = false;
            btnLoadLaw.Enabled = false;
            btnDelete.Enabled = true;
            btnView.Enabled = true;
            txtPathLaw.Text = string.Empty;
            txtPathLaw.ReadOnly = true;
            txtNameLaw.ReadOnly = true;
            txtAlias.ReadOnly = true;
            txtDescription.ReadOnly = true;
            txtId.ReadOnly = true;
        }

        private void LoadLaws(int index)
        {
            Documents documents = Assessment.getDocuments(type);
            if (documents.code == 0)
            {
                List<Document> laws = documents.documents;
                Document document = new Document { id = 0, name = "Create new..." };

                laws.Insert(0, document);

                cmbLaws.Items.Clear();
                cmbLaws.Text = string.Empty;
                string text;

                foreach (Document law in laws)
                {
                    if (law.id == 0)
                        text = law.name;
                    else
                        text = law.name + " (" + law.alias + ")";

                    ComboBoxItem cmbItem = new ComboBoxItem
                    {
                        Value = law.id,
                        Text = text
                    };

                    cmbLaws.Items.Add(cmbItem);
                }

                cmbLaws.SelectedIndex = index;
            }
            else
            {
                setBlocked();
                MessageBox.Show(documents.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbLaws_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse((cmbLaws.SelectedItem as ComboBoxItem).Value.ToString());
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
                    txtNameLaw.Text = document.name;
                    txtAlias.Text = document.alias;
                    txtDescription.Text = document.description;
                    setModifyMode();
                }
                else
                {
                    setBlocked();
                    MessageBox.Show(document.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Laws_Load(object sender, EventArgs e)
        {
            LoadLaws(0);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadLaws(0);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = Confirmation.ShowCustomYesNo("Do you want to remove this law?", "Confirmation", "Yes", "No");

            if (result == DialogResult.Yes)
            {
                Response response = Assessment.deleteDocument(type, int.Parse(txtId.Text));
                if (response.code == 0)
                {
                    deletes.Add(int.Parse(txtId.Text));
                    MessageBox.Show("Law deleted with success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadLaws(0);
                }
                else
                {
                    setBlocked();
                    MessageBox.Show(response.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            Response response = Assessment.generateView(1, 0, int.Parse(txtId.Text));
            if (response.code == 0)
            {
                FrmView frmView = new FrmView(response.text);
                frmView.Show();
            }
            else
            {
                setBlocked();
                MessageBox.Show(response.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
