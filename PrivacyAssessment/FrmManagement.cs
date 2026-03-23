using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AssessmentLibrary.AssessmentLogic;
using AssessmentLibrary.AssessmentModel;

namespace PrivacyAssessment
{
    /// <summary>
    /// Class Management
    /// Manages the information of cases executing queries with GPT
    /// </summary>
    public partial class FrmManagement : Form
    {
        int typeNomatives = 0;
        int typeLaws = 1;

        // Constructor
        public FrmManagement()
        {
            InitializeComponent();
            loadData();
        }

        // Searches the information of previously created normatives and laws
        private void btnSearch_Click(object sender, EventArgs e)
        {
            loadData();
        }

        // Sets a blocked mode to avoid the user to perform actions
        private void setBlocked()
        {
            cmbNormatives.Items.Clear();
            cmbLaws.Items.Clear();
            cmbNormatives.Text = string.Empty;
            cmbNormatives.Enabled = false;

            cmbLaws.Text = string.Empty;
            cmbLaws.Enabled = false;
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

            txtGPT.Text = string.Empty;
            txtCompliances.Text = string.Empty;
            txtNoncompliances.Text = string.Empty;
            btnGpt.Enabled = false;
            btnGptView.Enabled = false;
            btnCompliances.Enabled = false;
            btnCompliancesView.Enabled = false;
            btnNoncompliances.Enabled = false;
            btnNoncompliancesView.Enabled = false;
        }

        // Sets the modify mode in order to perform actions with GPT
        private void setModifyMode()
        {
            txtName.ReadOnly = true; ;
            txtAlias.ReadOnly = true;
            txtDescription.ReadOnly = true;
            txtGPT.ReadOnly = true;
            txtCompliances.ReadOnly = true;
            txtNoncompliances.ReadOnly = true;
            btnGpt.Enabled = true;
            btnCompliances.Enabled = true;
            btnNoncompliances.Enabled = true;

            if (string.IsNullOrEmpty(txtGPT.Text))
            {
                btnGptView.Enabled = false;
            }
            else
            {
                btnGptView.Enabled = true;
            }

            if (string.IsNullOrEmpty(txtCompliances.Text))
            {
                btnCompliancesView.Enabled = false;
            }
            else
            {
                btnCompliancesView.Enabled = true;
            }

            if (string.IsNullOrEmpty(txtNoncompliances.Text))
            {
                btnNoncompliancesView.Enabled = false;
            }
            else
            {
                btnNoncompliancesView.Enabled = true;
            }

            btnCreate.Enabled = false;
        }

        // Sets the create mode in order to create a new case of analysis
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
            txtCompliances.Text = string.Empty;
            txtNoncompliances.Text = string.Empty;
            btnGpt.Enabled = false;
            btnGptView.Enabled = false;
            btnCompliances.Enabled = false;
            btnCompliancesView.Enabled = false;
            btnNoncompliances.Enabled = false;
            btnNoncompliancesView.Enabled = false;
            btnCreate.Enabled = true;
        }

        // Loads a previously defined data of normatives and laws
        private void loadData()
        {
            // Normatives
            Documents documents = Assessment.getDocuments(typeNomatives);
            if (documents.code == 0)
            {
                List<AssessmentLibrary.AssessmentModel.Document> normatives = documents.documents;
                cmbNormatives.Items.Clear();
                cmbNormatives.Text = string.Empty;
                string text;

                foreach (AssessmentLibrary.AssessmentModel.Document normative in normatives)
                {
                    if (normative.id == 0)
                        text = normative.name;
                    else
                        text = normative.name + " (" + normative.alias + ")";

                    ComboBoxItem cmbItem = new ComboBoxItem
                    {
                        Value = normative.id,
                        Text = text
                    };

                    cmbNormatives.Items.Add(cmbItem);
                }

                if (cmbNormatives.Items.Count > 0)
                {
                    cmbNormatives.Enabled = true;
                    cmbNormatives.SelectedIndex = 0;
                }
                else
                {
                    setBlocked();
                }
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
                List<AssessmentLibrary.AssessmentModel.Document> laws = documents.documents;

                cmbLaws.Items.Clear();
                cmbLaws.Text = string.Empty;
                string text1;

                foreach (AssessmentLibrary.AssessmentModel.Document law in laws)
                {
                    if (law.id == 0)
                        text1 = law.name;
                    else
                        text1 = law.name + " (" + law.alias + ")";

                    ComboBoxItem cmbItem1 = new ComboBoxItem
                    {
                        Value = law.id,
                        Text = text1
                    };

                    cmbLaws.Items.Add(cmbItem1);
                }
                if (cmbLaws.Items.Count > 0)
                {
                    cmbLaws.Enabled = true;
                    cmbLaws.SelectedIndex = 0;
                }
                else
                {
                    setBlocked();
                }
            }
            else
            {
                setBlocked();
                MessageBox.Show(documents.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        // Changes the selected normative
        private void cmbNormatives_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeCaseStudy();
        }

        // Changes the selected law
        private void cmbLaws_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeCaseStudy();
        }

        // Displays the information of the case study corresponding to the selected normative and law
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
                AssessmentLibrary.AssessmentModel.Document normative = Assessment.getDocument(0, idNormative);
                if (normative.code == 0)
                {
                    txtIdNormative.Text = normative.id.ToString();
                    txtNameNormative.Text = normative.name;
                    txtAliasNormative.Text = normative.alias;
                    txtDescriptionNormative.Text = normative.description;
                }
                else
                {
                    setBlocked();
                    MessageBox.Show(normative.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                AssessmentLibrary.AssessmentModel.Document law = Assessment.getDocument(1, idLaw);
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

                AssessmentLibrary.AssessmentModel.Document document = Assessment.getCase(idNormative, idLaw);

                if (document.code == 0)
                {
                    if (document.id != 0)
                    {
                        txtId.Text = document.id.ToString();
                        txtName.Text = document.name;
                        txtAlias.Text = document.alias;
                        txtDescription.Text = document.description;

                        if (document.gpt == "gpt_0.json")
                        {
                            txtGPT.Text = string.Empty;
                        }
                        else
                        {
                            txtGPT.Text = document.gpt;
                        }

                        if (document.gpt_cs == "gpt_cs_0.txt")
                        {
                            txtCompliances.Text = string.Empty;
                        }
                        else
                        {
                            txtCompliances.Text = document.gpt_cs;
                        }

                        if (document.gpt_ncs == "gpt_ncs_0.txt")
                        {
                            txtNoncompliances.Text = string.Empty;
                        }
                        else
                        {
                            txtNoncompliances.Text = document.gpt_ncs;
                        }

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

        // Creates a new case study
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

            AssessmentLibrary.AssessmentModel.Document document = new AssessmentLibrary.AssessmentModel.Document
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
                txtId.Text = response.id.ToString();
                txtId.Focus();
                MessageBox.Show("Case created with success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                setBlocked();
                MessageBox.Show(response.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Determines the identified categories with GPT
        private void btnGpt_Click(object sender, EventArgs e)
        {
            Generate(0);
        }

        // Determines compliances with GPT
        private void btnCompliances_Click(object sender, EventArgs e)
        {
            Generate(1);
        }

        // Determines noncompliances with GPT
        private void btnNoncompliances_Click(object sender, EventArgs e)
        {
            Generate(2);
        }

        // Visualizes the results of identified categories
        private void btnGptView_Click(object sender, EventArgs e)
        {
            ViewQuery(2, 0);
        }

        // Visualizes the results of compliances

        private void btnCompliancesView_Click(object sender, EventArgs e)
        {
            ViewQuery(2, 1);
        }

        // Visualizes the results of noncompliances
        private void btnNoncompliancesView_Click(object sender, EventArgs e)
        {
            ViewQuery(2, 2);
        }

        // Generates a query to be performed with GPT
        private void Generate(int type)
        {
            string message = "Do you want to peform this operation?";
            DialogResult result = Confirmation.ShowCustomYesNo(message, "Confirmation", "Yes", "No");

            if (result == DialogResult.Yes)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                int idCase = int.Parse(txtId.Text);
                int idNormative = int.Parse(txtIdNormative.Text);
                int idLaw = int.Parse(txtIdLaw.Text);

                string apiKey_ciphered = File.ReadAllText(ConfigurationManager.AppSettings["apiKey_ciphered"]);
                string apiKey_private = File.ReadAllText(ConfigurationManager.AppSettings["apiKey_private"]);
                string apiKey = ApiKey.Decrypt(apiKey_ciphered, apiKey_private);

                GptQuery gptQuery = new GptQuery
                {
                    idCase = idCase,
                    idNormative = idNormative,
                    idLaw = idLaw,
                    type = type,
                    apiKey = apiKey
                };

                Response response = Assessment.generateQuery(gptQuery);
                if (response.code == 0)
                {
                    if (type == 0)
                    {
                        txtGPT.Text = "gpt_" + response.id.ToString() + ".json";
                        btnGpt.Enabled = true;
                        btnGptView.Enabled = true;
                    }
                    else if (type == 1)
                    {
                        txtCompliances.Text = "gpt_cs_" + response.id.ToString() + ".txt";
                        btnCompliances.Enabled = true;
                        btnCompliancesView.Enabled = true;
                    }
                    else if (type == 2)
                    {
                        txtNoncompliances.Text = "gpt_ncs_" + response.id.ToString() + ".txt";
                        btnNoncompliances.Enabled = true;
                        btnNoncompliancesView.Enabled = true;
                    }

                    stopwatch.Stop();

                    double seconds = stopwatch.Elapsed.TotalSeconds;
                    MessageBox.Show("Query executed with success in " + seconds.ToString("F3") + "seconds!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    setBlocked();
                    MessageBox.Show(response.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Visualizes the results obtained using GPT
        private void ViewQuery(int type, int subtype)
        {
            Response response = Assessment.generateView(type, subtype, int.Parse(txtId.Text));
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