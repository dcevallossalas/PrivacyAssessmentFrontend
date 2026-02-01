using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
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
    /// <summary>
    /// Class FrmMain
    /// Manages the cases of analysis in order to display the final results
    /// </summary>
    public partial class FrmMain : Form
    {
        // Constructor
        public FrmMain()
        {
            InitializeComponent();
            setBlocked();
            setFinalDisable();
        }

        // Establishes a blocked mode in order to avoid the user to perform actions
        public void setBlocked()
        {
            lsbCases.Items.Clear();
            btnAdd.Enabled = false;
            btnCombine.Enabled = false;
            btnDeleteCase.Enabled = false;
        }

        // Enables the form in order to allow the user to perform actions
        public void setEnable()
        {
            btnManage.Enabled = true;
            btnAdd.Enabled = true;
            btnCombine.Enabled = true;
            btnDeleteCase.Enabled = true;
        }

        // Enables the actions to manipulate the final selected case items
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

        // Disables the actions to manipulate the final selected case items
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
            btnGenerate.Enabled = false;
        }

        // Searches the previosuly created cases
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchCases();
        }

        // Searches the previously created cases
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

        // Enables or disables the allowed actions according to the selected cases
        private void lsbCases_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbCases.SelectedIndex != -1 && lsbCases.Items.Count > 0)
            {
                setEnable();
            }
            else
            {
                if (lsbCases.SelectedIndex == -1 || lsbCases.Items.Count <= 0)
                {
                    btnDeleteCase.Enabled = false;
                    btnManage.Enabled = false;
                    btnAdd.Enabled = false;
                    btnCombine.Enabled = false;
                }
            }
        }

        // Adds a new case
        private void btnAdd_Click(object sender, EventArgs e)
        {
            addItems();
        }

        // Adds a new case
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

        // Determines if a case item has been previously selected
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

        // Deletes a previously selected case item
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

        // Sets the final state of the window according to the selected case
        private void lsbFinalCases_SelectedIndexChanged(object sender, EventArgs e)
        {
            setFinalState();
        }

        // Sets the final state of the form
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

        // Sets a previously selected case of analysis one position up
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

        // Sets a previously selected case of analysis one position down
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

        // Renames a selected case of analysis
        private void btnRename_Click(object sender, EventArgs e)
        {
            if (lsbFinalCases.SelectedIndex != -1)
            {
                int index = lsbFinalCases.SelectedIndex;
                CaseItem item = (CaseItem)lsbFinalCases.Items[index];

                FrmAlias frmAlias = new FrmAlias(item);

                if (frmAlias.ShowDialog() == DialogResult.OK)
                {
                    string name = frmAlias.name;
                    string alias = frmAlias.alias;

                    if (!string.IsNullOrEmpty(alias))
                    {
                        item.name = name;
                        item.alias = alias;
                    }
                }

                lsbFinalCases.Items[index] = item;

                lsbFinalCases.SelectedIndex = index;
            }
        }

        // Combines two or more selected case of analysis in order to performa a combined analysis
        private void btnCombine_Click(object sender, EventArgs e)
        {
            if (lsbCases.SelectedItems.Count >= 2)
            {
                var items = lsbCases.SelectedItems;
                List<string> notAnalyzed = new List<string>();
                List<int> subcases = new List<int>();
                List<int> subnormatives = new List<int>();
                List<int> sublaws = new List<int>();

                // Check GPT generation
                foreach (var item in items)
                {
                    CaseItem caseItem = (CaseItem)item;
                    Response response = itemWasAnalyzed(caseItem.id);
                    subcases.Add(caseItem.id);

                    if (!subnormatives.Contains(caseItem.id_normative))
                    {
                        subnormatives.Add(caseItem.id_normative);
                    }

                    if (!sublaws.Contains(caseItem.id_law))
                    {
                        sublaws.Add(caseItem.id_law);
                    }

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

                // Checks repetition in final list box
                bool repeated = false;
                string alias_repeated = string.Empty;

                foreach (var item in lsbFinalCases.Items)
                {
                    CaseItem finalItem = (CaseItem)item;

                    if (finalItem.id == 0 && finalItem.subcases != null && finalItem.subcases.Count == subcases.Count)
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
                    string name = frmAlias.name;
                    string alias = frmAlias.alias;

                    CaseItem caseItem = new CaseItem
                    {
                        id = 0,
                        id_normative = 0,
                        id_law = 0,
                        name = name,
                        alias = alias,
                        alias_normative = "compound",
                        alias_law = "",
                        subcases = subcases,
                        subnormatives = subnormatives,
                        sublaws = sublaws
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

        // Gets the curret version of previously selected case of analysis
        private Response itemWasAnalyzed(int id)
        {
            Response response = Assessment.getVersion(id);
            return response;
        }

        // Displays a window for managing the information of normatives
        private void btnNormatives_Click(object sender, EventArgs e)
        {
            FrmNormatives frmNormatives = new FrmNormatives();
            frmNormatives.ShowDialog();
            if (frmNormatives.deletes.Count > 0)
            {
                for (int j = lsbFinalCases.Items.Count - 1; j >= 0; j--)
                {
                    CaseItem item = (CaseItem)lsbFinalCases.Items[j];

                    if (item.id_normative == 0 && item.subnormatives != null && item.subnormatives.Count > 0)
                    {
                        foreach (int subnormative in item.subnormatives)
                        {
                            if (frmNormatives.deletes.Contains(subnormative))
                            {
                                lsbFinalCases.Items.RemoveAt(j);
                                break;
                            }
                        }
                    }
                    else if (item.id_normative > 0 && frmNormatives.deletes.Contains(item.id_normative))
                    {
                        lsbFinalCases.Items.RemoveAt(j);
                    }
                }

                for (int k = lsbCases.Items.Count - 1; k >= 0; k--)
                {
                    CaseItem itemOriginal = (CaseItem)lsbCases.Items[k];

                    if (frmNormatives.deletes.Contains(itemOriginal.id_normative))
                        lsbCases.Items.RemoveAt(k);
                }
            }
        }

        // Displays a window for managing the information of laws
        private void btnLaws_Click(object sender, EventArgs e)
        {
            FrmLaws frmLaws = new FrmLaws();
            frmLaws.ShowDialog();
            if (frmLaws.deletes.Count > 0)
            {
                for (int j = lsbFinalCases.Items.Count - 1; j >= 0; j--)
                {
                    CaseItem item = (CaseItem)lsbFinalCases.Items[j];

                    if (item.id_law == 0 && item.sublaws != null && item.sublaws.Count > 0)
                    {
                        foreach (int sublaw in item.sublaws)
                        {
                            if (frmLaws.deletes.Contains(sublaw))
                            {
                                lsbFinalCases.Items.RemoveAt(j);
                                break;
                            }
                        }
                    }
                    else if (item.id_law > 0 && frmLaws.deletes.Contains(item.id_law))
                    {
                        lsbFinalCases.Items.RemoveAt(j);
                    }
                }

                for (int k = lsbCases.Items.Count - 1; k >= 0; k--)
                {
                    CaseItem itemOriginal = (CaseItem)lsbCases.Items[k];

                    if (frmLaws.deletes.Contains(itemOriginal.id_law))
                        lsbCases.Items.RemoveAt(k);
                }
            }
        }

        // Deletes a previously created case of analysis
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
                        CaseItem item = (CaseItem)lsbCases.Items[i];
                        Response response = Assessment.deleteCase(item.id);
                        if (response.code == 0)
                        {
                            deletes.Add(item.id);
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

                    UpdateControls();
                }
            }
        }

        // Updates the current state of the controls of the form
        public void UpdateControls()
        {
            if (lsbCases.Items.Count <= 0)
            {
                btnAdd.Enabled = false;
                btnCombine.Enabled = false;
                btnDeleteCase.Enabled = false;
            }
            else
            {
                lsbCases.SelectedIndex = 0;
            }

            if (lsbFinalCases.Items.Count <= 0)
            {
                btnGenerate.Enabled = false;
            }
            else
            {
                lsbFinalCases.SelectedIndex = 0;
            }

        }

        // Displays a new window with the information to insert a normative as a reference for the results
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
                                name = frmInsertNormative.name,
                                alias = frmInsertNormative.alias,
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

        // Displays a window of management of cases
        private void btnManage_Click(object sender, EventArgs e)
        {
            FrmManagement frmManage = new FrmManagement();
            frmManage.ShowDialog();
        }

        // Consolidates the results for all selected case items and generate a dashborad with the results
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            var items = lsbFinalCases.Items;
            string path = ConfigurationManager.AppSettings["path"];
            string file1 = "category";
            List<CaseItem> values = new List<CaseItem>();

            foreach (var item in items)
            {
                CaseItem caseFinalItem = (CaseItem)item;
                file1 = file1 + "\n" + caseFinalItem.alias;
                values.Add(caseFinalItem);
            }

            File.WriteAllText(Path.Combine(path,"categories.csv"), file1);

            Response response = Assessment.generateFiles(values);
            if (response.code == 0)
            {
                File.WriteAllText(Path.Combine(path, "logprobs.csv"), response.text);
                // No data condition
                if (!response.text.Contains("\n"))
                {
                    MessageBox.Show("No data to process, make use of GPT first to retrieve results", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                GenerateDashboard();
            }
            else
            {
                MessageBox.Show(response.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Opens a browser in a new window to visualize the results
        private void GenerateDashboard()
        {
            try
            {
                string path = ConfigurationManager.AppSettings["path"];
                string rpath = ConfigurationManager.AppSettings["rpath"];
                string rscript = ConfigurationManager.AppSettings["rscript"];

                var info = new ProcessStartInfo
                {
                    FileName = Path.Combine(rpath, "Rscript.exe"),
                    Arguments = Path.Combine(path, rscript),
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    UseShellExecute = false
                };

                using (var proc = new Process { StartInfo = info })
                {
                    proc.Start();
                    string output = proc.StandardOutput.ReadToEnd();
                    string error = proc.StandardError.ReadToEnd();
                    proc.WaitForExit();

                    if (!string.IsNullOrEmpty(error) && !error.Contains("Output created:"))
                    {
                        MessageBox.Show("R Error: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    } else
                    {
                        MessageBox.Show("Operation executed with success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        using (var procBrowser = new Process())
                        {
                            procBrowser.StartInfo.UseShellExecute = true;
                            procBrowser.StartInfo.FileName = Path.Combine(path, "Statistics.html");
                            procBrowser.Start();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}