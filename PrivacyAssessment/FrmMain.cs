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
using AssessmentLibrary.AssessmentLogic;
using AssessmentLibrary.AssessmentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.DataFormats;

namespace PrivacyAssessment
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            setBlocked();
            setFinalDisable();
        }

        public void setBlocked()
        {
            lsbCases.Items.Clear();
            btnManage.Enabled = false;
            btnAdd.Enabled = false;
            btnCombine.Enabled = false;
            btnDeleteCase.Enabled = false;
        }

        public void setEnable()
        {
            btnManage.Enabled = true;
            btnAdd.Enabled = true;
            btnCombine.Enabled = true;
            btnDeleteCase.Enabled = true;
        }

        public void setFinalEnable()
        {
            btnRename.Enabled = true;
            btnGenerate.Enabled = true;
            btnDelete.Enabled = true;

            if (lsbFinalCases.Items.Count >= 2)
            {
                if (lsbFinalCases.SelectedIndex == 0)
                {
                    btnUp.Enabled = false;
                    btnDown.Enabled = true;

                }
                else if (lsbFinalCases.SelectedIndex == lsbFinalCases.Items.Count - 1)
                {
                    btnUp.Enabled = true;
                    btnDown.Enabled = false;
                }
                else
                {
                    btnUp.Enabled = true;
                    btnDown.Enabled = true;
                }
            }
            else
            {
                btnUp.Enabled = false;
                btnDown.Enabled = false;
            }
        }

        public void setFinalDisable()
        {
            btnRename.Enabled = false;
            if (lsbFinalCases.Items.Count > 0)
            {
                btnGenerate.Enabled = true;
            }
            else
            {
                btnGenerate.Enabled = false;
            }

            btnDelete.Enabled = false;
            btnUp.Enabled = false;
            btnDown.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchCases();
        }

        private void SearchCases()
        {
            Cases cases = Assessment.getCases();
            if (cases.code == 0)
            {
                if (cases.cases.Count > 0)
                {
                    lsbCases.Items.Clear();

                    foreach (CaseItem caseItem in cases.cases)
                    {
                        lsbCases.Items.Add(caseItem);
                    }

                    lsbCases.SelectedIndex = 0;
                }
                else
                {
                    setBlocked();
                    MessageBox.Show("Any case of analysis found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                setBlocked();
                MessageBox.Show(cases.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lsbCases_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbCases.SelectedIndex != -1)
            {
                setEnable();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addItems();
        }

        private void addItems()
        {
            var items = lsbCases.SelectedItems;
            bool added = false;
            List<string> notAnalyzed = new List<string>();

            foreach (var item in items)
            {
                CaseItem caseItem = (CaseItem)item;
                Response response = itemWasAnalyzed(caseItem.id);

                if (response.code == 0)
                {
                    if (response.id <= 0)
                    {
                        notAnalyzed.Add(caseItem.alias);
                    }
                }
                else
                {
                    MessageBox.Show(response.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (notAnalyzed.Count > 0)
            {
                string error = "Elements not analyzed by GPT: ";

                foreach (string notAnalyzedItem in notAnalyzed)
                {
                    error = error + notAnalyzedItem + ",";
                }

                MessageBox.Show(error.Substring(0, error.Length - 1), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (var item in items)
            {
                CaseItem caseItem = (CaseItem)item;

                if (!itemExists(caseItem))
                {
                    lsbFinalCases.Items.Add(caseItem);
                    added = true;
                }
            }

            if (added)
                setFinalState();
        }

        private bool itemExists(CaseItem caseitem)
        {
            var items = lsbFinalCases.Items;
            foreach (var item in items)
            {
                CaseItem caseFinalItem = (CaseItem)item;
                if (caseFinalItem.id > 0 && caseFinalItem.id == caseitem.id)
                {
                    return true;
                }
            }

            return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lsbFinalCases.SelectedIndex != -1)
            {
                lsbFinalCases.Items.RemoveAt(lsbFinalCases.SelectedIndex);
                if (lsbFinalCases.Items.Count > 0)
                {
                    lsbFinalCases.SelectedIndex = 0;
                }
            }
        }

        private void lsbFinalCases_SelectedIndexChanged(object sender, EventArgs e)
        {
            setFinalState();
        }

        private void setFinalState()
        {
            if (lsbFinalCases.SelectedIndex != -1)
            {
                setFinalEnable();
            }
            else
            {
                setFinalDisable();
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            int index = lsbFinalCases.SelectedIndex;

            if (index > 0)
            {
                var item = lsbFinalCases.Items[index];
                lsbFinalCases.Items.RemoveAt(index);
                lsbFinalCases.Items.Insert(index - 1, item);
                lsbFinalCases.SelectedIndex = index - 1;
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            int index = lsbFinalCases.SelectedIndex;

            if (index >= 0 && index < lsbFinalCases.Items.Count - 1)
            {
                var item = lsbFinalCases.Items[index];
                lsbFinalCases.Items.RemoveAt(index);
                lsbFinalCases.Items.Insert(index + 1, item);
                lsbFinalCases.SelectedIndex = index + 1;
            }
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            if (lsbFinalCases.SelectedIndex != -1)
            {
                int index = lsbFinalCases.SelectedIndex;
                CaseItem item = (CaseItem)lsbFinalCases.Items[index];

                FrmAlias frmAlias = new FrmAlias();

                if (frmAlias.ShowDialog() == DialogResult.OK)
                {
                    string alias = frmAlias.alias;

                    if (!string.IsNullOrEmpty(alias))
                    {
                        item.alias = alias;
                    }
                }

                lsbFinalCases.Items[index] = item;

                lsbFinalCases.SelectedIndex = index;
            }
        }

        private void btnCombine_Click(object sender, EventArgs e)
        {
            if (lsbCases.SelectedItems.Count >= 2)
            {
                var items = lsbCases.SelectedItems;
                List<string> notAnalyzed = new List<string>();
                List<int> subcases = new List<int>();

                // Check GPT generation
                foreach (var item in items)
                {
                    CaseItem caseItem = (CaseItem)item;
                    Response response = itemWasAnalyzed(caseItem.id);
                    subcases.Add(caseItem.id);

                    if (response.code == 0)
                    {
                        if (response.id <= 0)
                        {
                            notAnalyzed.Add(caseItem.alias);
                        }
                    }
                    else
                    {
                        MessageBox.Show(response.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (notAnalyzed.Count > 0)
                {
                    string error = "Elements not analyzed by GPT: ";

                    foreach (string notAnalyzedItem in notAnalyzed)
                    {
                        error = error + notAnalyzedItem + ",";
                    }

                    MessageBox.Show(error.Substring(0, error.Length - 1), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Check repetition in final list box
                bool repeated = false;
                string alias_repeated = string.Empty;

                foreach (var item in lsbFinalCases.Items)
                {
                    CaseItem finalItem = (CaseItem)item;

                    if (finalItem.id == 0 && finalItem.subcases.Count == subcases.Count)
                    {
                        foreach (int i in finalItem.subcases)
                        {
                            if (subcases.Contains(i))
                            {
                                repeated = true;
                                alias_repeated = finalItem.alias;
                                MessageBox.Show("An item with these merge elements already added", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                }

                FrmAlias frmAlias = new FrmAlias();

                if (frmAlias.ShowDialog() == DialogResult.OK)
                {
                    string alias = frmAlias.alias;
                    CaseItem caseItem = new CaseItem
                    {
                        id = 0,
                        id_normative = 0,
                        id_law = 0,
                        name = "Compound analysis",
                        alias = alias,
                        alias_normative = "compound",
                        alias_law = "",
                        subcases = subcases
                    };

                    lsbFinalCases.Items.Add(caseItem);
                    setFinalState();
                }
            }
            else
            {
                addItems();
            }
        }

        private Response itemWasAnalyzed(int id)
        {
            Response response = Assessment.getVersion(id);
            return response;
        }

        private void btnNormatives_Click(object sender, EventArgs e)
        {
            FrmNormatives frmNormatives = new FrmNormatives();
            frmNormatives.ShowDialog();
        }

        private void btnLaws_Click(object sender, EventArgs e)
        {
            FrmLaws frmLaws = new FrmLaws();
            frmLaws.ShowDialog();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnDeleteCase_Click(object sender, EventArgs e)
        {
            int count = lsbCases.SelectedItems.Count;

            if (count > 0)
            {
                string message = "Do you want to remove this case of analysis?";

                if (count > 1)
                    message = "Do you want to remove these cases of analysis?";

                DialogResult result = Confirmation.ShowCustomYesNo(message, "Confirmation", "Yes", "No");
                List<int> deletes = new List<int>();

                if (result == DialogResult.Yes)
                {
                    for (int i = 0; i <= count - 1; i++)
                    {
                        Response response = Assessment.deleteCase(lsbCases.SelectedIndex);
                        if (response.code == 0)
                        {
                            deletes.Add(i);
                        }
                        else
                        {
                            MessageBox.Show(response.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    for (int j = lsbFinalCases.Items.Count - 1; j >= 0; j--)
                    {
                        CaseItem item = (CaseItem)lsbFinalCases.Items[j];

                        if (item.id == 0 && item.subcases != null && item.subcases.Count > 0)
                        {
                            foreach (int subcase in item.subcases)
                            {
                                if (deletes.Contains(subcase))
                                {
                                    lsbFinalCases.Items.RemoveAt(j);
                                    break;
                                }
                            }
                        }
                        else if (deletes.Contains(item.id))
                        {
                            lsbFinalCases.Items.RemoveAt(j);
                        }
                    }

                    for (int k = lsbCases.Items.Count - 1; k >= 0; k--)
                    {
                        CaseItem itemOriginal = (CaseItem)lsbCases.Items[k];

                        if (deletes.Contains(itemOriginal.id))
                            lsbCases.Items.RemoveAt(k);
                    }

                    if (count == 1)
                    {
                        MessageBox.Show("Case of analysis deleted with success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cases of analysis deleted with success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnInsertNormative_Click(object sender, EventArgs e)
        {
            List<int> addedNormatives = new List<int>();

            for (int i = 0; i <= lsbFinalCases.Items.Count - 1; i++)
            {
                CaseItem item = (CaseItem)lsbFinalCases.Items[i];

                if (item.id == 0 && item.id_normative > 0)
                {
                    addedNormatives.Add(item.id_normative);
                }
            }

            Documents documents = Assessment.getDocuments(0);
            if (documents.code == 0)
            {
                List<Document> normatives = documents.documents;

                if (normatives.Count > 0)
                {
                    for (int j = normatives.Count - 1; j >= 0; j--)
                    {
                        if (addedNormatives.Contains(normatives[j].id))
                        {
                            normatives.RemoveAt(j);
                        }
                    }

                    if (normatives.Count > 0)
                    {
                        FrmInsertNormative frmInsertNormative = new FrmInsertNormative(normatives);

                        if (frmInsertNormative.ShowDialog() == DialogResult.OK)
                        {
                            CaseItem caseItem = new CaseItem
                            {
                                id = 0,
                                id_normative = frmInsertNormative.id_normative,
                                alias = "Normative",
                                alias_normative = frmInsertNormative.alias
                            };

                            lsbFinalCases.Items.Add(caseItem);
                        }
                    }
                    else
                    {
                        MessageBox.Show("You have already added all possible normatives for analysis", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("There are no available normatives for analysis. Please, insert one", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                setBlocked();
                MessageBox.Show(documents.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}