namespace PrivacyAssessment
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSearch = new Button();
            lsbCases = new ListBox();
            btnManage = new Button();
            btnNormatives = new Button();
            btnLaws = new Button();
            lsbFinalCases = new ListBox();
            btnAdd = new Button();
            btnCombine = new Button();
            btnDelete = new Button();
            btnUp = new Button();
            btnDown = new Button();
            btnGenerate = new Button();
            btnRename = new Button();
            btnDeleteCase = new Button();
            btnInsertNormative = new Button();
            SuspendLayout();
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(222, 55);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 0;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // lsbCases
            // 
            lsbCases.FormattingEnabled = true;
            lsbCases.Location = new Point(31, 124);
            lsbCases.Name = "lsbCases";
            lsbCases.SelectionMode = SelectionMode.MultiExtended;
            lsbCases.Size = new Size(486, 184);
            lsbCases.TabIndex = 1;
            lsbCases.SelectedIndexChanged += lsbCases_SelectedIndexChanged;
            // 
            // btnManage
            // 
            btnManage.Location = new Point(423, 356);
            btnManage.Name = "btnManage";
            btnManage.Size = new Size(94, 29);
            btnManage.TabIndex = 2;
            btnManage.Text = "Manage";
            btnManage.UseVisualStyleBackColor = true;
            btnManage.Click += btnManage_Click_1;
            // 
            // btnNormatives
            // 
            btnNormatives.Location = new Point(35, 356);
            btnNormatives.Name = "btnNormatives";
            btnNormatives.Size = new Size(94, 29);
            btnNormatives.TabIndex = 3;
            btnNormatives.Text = "Normatives";
            btnNormatives.UseVisualStyleBackColor = true;
            btnNormatives.Click += btnNormatives_Click;
            // 
            // btnLaws
            // 
            btnLaws.Location = new Point(135, 356);
            btnLaws.Name = "btnLaws";
            btnLaws.Size = new Size(94, 29);
            btnLaws.TabIndex = 4;
            btnLaws.Text = "Laws";
            btnLaws.UseVisualStyleBackColor = true;
            btnLaws.Click += btnLaws_Click;
            // 
            // lsbFinalCases
            // 
            lsbFinalCases.FormattingEnabled = true;
            lsbFinalCases.Location = new Point(698, 126);
            lsbFinalCases.Name = "lsbFinalCases";
            lsbFinalCases.Size = new Size(486, 184);
            lsbFinalCases.TabIndex = 5;
            lsbFinalCases.SelectedIndexChanged += lsbFinalCases_SelectedIndexChanged;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(563, 181);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnCombine
            // 
            btnCombine.Location = new Point(563, 234);
            btnCombine.Name = "btnCombine";
            btnCombine.Size = new Size(94, 29);
            btnCombine.TabIndex = 7;
            btnCombine.Text = "Combine";
            btnCombine.UseVisualStyleBackColor = true;
            btnCombine.Click += btnCombine_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(1218, 271);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUp
            // 
            btnUp.Location = new Point(1218, 135);
            btnUp.Name = "btnUp";
            btnUp.Size = new Size(94, 29);
            btnUp.TabIndex = 9;
            btnUp.Text = "Up";
            btnUp.UseVisualStyleBackColor = true;
            btnUp.Click += btnUp_Click;
            // 
            // btnDown
            // 
            btnDown.Location = new Point(1218, 184);
            btnDown.Name = "btnDown";
            btnDown.Size = new Size(94, 29);
            btnDown.TabIndex = 10;
            btnDown.Text = "Down";
            btnDown.UseVisualStyleBackColor = true;
            btnDown.Click += btnDown_Click;
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(799, 356);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(94, 29);
            btnGenerate.TabIndex = 11;
            btnGenerate.Text = "Generate";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // btnRename
            // 
            btnRename.Location = new Point(699, 356);
            btnRename.Name = "btnRename";
            btnRename.Size = new Size(94, 29);
            btnRename.TabIndex = 12;
            btnRename.Text = "Rename";
            btnRename.UseVisualStyleBackColor = true;
            btnRename.Click += btnRename_Click;
            // 
            // btnDeleteCase
            // 
            btnDeleteCase.Location = new Point(423, 405);
            btnDeleteCase.Name = "btnDeleteCase";
            btnDeleteCase.Size = new Size(94, 29);
            btnDeleteCase.TabIndex = 13;
            btnDeleteCase.Text = "Delete";
            btnDeleteCase.UseVisualStyleBackColor = true;
            btnDeleteCase.Click += btnDeleteCase_Click;
            // 
            // btnInsertNormative
            // 
            btnInsertNormative.Location = new Point(1055, 356);
            btnInsertNormative.Name = "btnInsertNormative";
            btnInsertNormative.Size = new Size(129, 29);
            btnInsertNormative.TabIndex = 14;
            btnInsertNormative.Text = "Insert normative";
            btnInsertNormative.UseVisualStyleBackColor = true;
            btnInsertNormative.Click += btnInsertNormative_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1348, 469);
            Controls.Add(btnInsertNormative);
            Controls.Add(btnDeleteCase);
            Controls.Add(btnRename);
            Controls.Add(btnGenerate);
            Controls.Add(btnDown);
            Controls.Add(btnUp);
            Controls.Add(btnDelete);
            Controls.Add(btnCombine);
            Controls.Add(btnAdd);
            Controls.Add(lsbFinalCases);
            Controls.Add(btnLaws);
            Controls.Add(btnNormatives);
            Controls.Add(btnManage);
            Controls.Add(lsbCases);
            Controls.Add(btnSearch);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PRIVIA Normative Analyzer (PNA)";
            Load += FrmMain_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnSearch;
        private ListBox lsbCases;
        private Button btnManage;
        private Button btnNormatives;
        private Button btnLaws;
        private ListBox lsbFinalCases;
        private Button btnAdd;
        private Button btnCombine;
        private Button btnDelete;
        private Button btnUp;
        private Button btnDown;
        private Button btnGenerate;
        private Button btnRename;
        private Button btnDeleteCase;
        private Button btnInsertNormative;
    }
}