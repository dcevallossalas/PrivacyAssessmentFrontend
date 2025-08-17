using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AssessmentLibrary.AssessmentLogic;
using AssessmentLibrary.AssessmentModel;

namespace PrivacyAssessment
{
    public partial class FrmManagement : Form
    {
        int typeNomatives = 0;
        int typeLaws = 1;

        public FrmManagement()
        {
            InitializeComponent();
            loadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void setBlocked()
        {
            cmbNormatives.Items.Clear();
            cmbNormatives.Text = string.Empty;
            cmbNormatives.Enabled = false;
            btnCreate.Enabled = false;

            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtName.ReadOnly = true;
            txtAlias.Text = string.Empty;
            txtAlias.ReadOnly = true;
            txtDescription.Text = string.Empty;
            txtDescription.ReadOnly = true;
            txtGPT.Text = string.Empty;

            txtIdNormative.Text = string.Empty;
            txtNameNormative.Text = string.Empty;
            txtAliasNormative.Text = string.Empty;
            txtDescriptionNormative.Text = string.Empty;

            txtIdLaw.Text = string.Empty;
            txtNameLaw.Text = string.Empty;
            txtAliasLaw.Text = string.Empty;
            txtDescriptionLaw.Text = string.Empty;
        }

        private void setModifyMode()
        {
            txtName.ReadOnly = true; ;
            txtAlias.ReadOnly = true;
            txtDescription.ReadOnly = true;

            btnCreate.Enabled = false;
        }

        private void setCreateMode()
        {
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtName.ReadOnly = false;
            txtAlias.Text = string.Empty;
            txtAlias.ReadOnly = false;
            txtDescription.Text = string.Empty;
            txtDescription.ReadOnly = false;
            txtGPT.Text = string.Empty;

            btnCreate.Enabled = true;
        }

        private void loadData()
        {
            // Normatives
            Documents documents = Assessment.getDocuments(typeNomatives);
            if (documents.code == 0)
            {
                List<Document> normatives = documents.documents;
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

                cmbNormatives.SelectedIndex = 0;
            }
            else
            {
                setBlocked();
                MessageBox.Show(documents.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Laws
            documents = Assessment.getDocuments(typeLaws);
            if (documents.code == 0)
            {
                List<Document> laws = documents.documents;

                cmbLaws.Items.Clear();
                cmbLaws.Text = string.Empty;
                string text;

                foreach (Document law in laws)
                {
                    if (law.id == 0)
                        text = law.name;
                    else
                        text = law.name + "(" + law.alias + ")";

                    ComboBoxItem cmbItem = new ComboBoxItem
                    {
                        Value = law.id,
                        Text = text
                    };

                    cmbLaws.Items.Add(cmbItem);
                }

                cmbLaws.SelectedIndex = 0;
            }
            else
            {
                setBlocked();
                MessageBox.Show(documents.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void cmbNormatives_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeCaseStudy();
        }

        private void cmbLaws_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeCaseStudy();
        }

        private void changeCaseStudy()
        {
            int idNormative = 0;
            try
            {
                if (cmbNormatives.SelectedIndex >= 0)
                    idNormative = int.Parse((cmbNormatives.SelectedItem as ComboBoxItem).Value.ToString());
            }
            catch (Exception) { }

            int idLaw = 0;
            try
            {
                if (cmbLaws.SelectedIndex >= 0)
                    idLaw = int.Parse((cmbLaws.SelectedItem as ComboBoxItem).Value.ToString());
            }
            catch (Exception) { }

            if (idNormative > 0 && idLaw > 0)
            {
                Document normative = Assessment.getDocument(0, idNormative);
                if (normative.code == 0)
                {
                    txtIdNormative.Text = normative.id.ToString();
                    txtNameNormative.Text = normative.name;
                    txtAliasNormative.Text  = normative.alias;
                    txtDescriptionNormative.Text = normative.description;
                } else
                {
                    setBlocked();
                    MessageBox.Show(normative.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Document law = Assessment.getDocument(0, idLaw);
                if (law.code == 0)
                {
                    txtIdLaw.Text = law.id.ToString();
                    txtNameLaw.Text = law.name;
                    txtAliasLaw.Text = law.alias;
                    txtDescriptionLaw.Text = law.description;
                }
                else
                {
                    setBlocked();
                    MessageBox.Show(law.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Document document = Assessment.getCase(idNormative, idLaw);

                if (document.code == 0)
                {
                    if (document.id != 0)
                    {
                        txtId.Text = document.id.ToString();
                        txtName.Text = document.name;
                        txtAlias.Text = document.alias;
                        txtDescription.Text = document.description;
                        txtGPT.Text = document.gpt;
                        setModifyMode();
                    }
                    else
                    {
                        setCreateMode();
                    }
                }
                else
                {
                    setBlocked();
                    MessageBox.Show(document.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Specify the name of the case", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtAlias.Text))
            {
                MessageBox.Show("Specify an alias for the case", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!FileValidator.IsValidFileName(txtAlias.Text))
            {
                MessageBox.Show("Alias not valid. Avoid special characters that could cause a problem", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageBox.Show("Specify a description for the case", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Document document = new Document
            {
                name = txtName.Text,
                alias = txtAlias.Text,
                description = txtDescription.Text,
                id_extra1 = int.Parse(txtIdNormative.Text),
                id_extra2 = int.Parse(txtIdLaw.Text)
            };

            Response response = Assessment.createCase(document);
            if (response.code == 0)
            {
                setModifyMode();

                MessageBox.Show("Case created with success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                setBlocked();
                MessageBox.Show(response.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
