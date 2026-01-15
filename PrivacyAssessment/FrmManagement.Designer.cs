namespace PrivacyAssessment
{
    partial class FrmManagement
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
            grbComboBoxes = new GroupBox();
            btnSearch = new Button();
            cmbLaws = new ComboBox();
            cmbNormatives = new ComboBox();
            lblCmbsLaws = new Label();
            lblCmbNormatives = new Label();
            grbNormativeInformation = new GroupBox();
            txtDescriptionNormative = new TextBox();
            txtAliasNormative = new TextBox();
            txtNameNormative = new TextBox();
            txtIdNormative = new TextBox();
            lblDescriptionNormative = new Label();
            lblIdNormative = new Label();
            lblAliasNormative = new Label();
            lblNameNormative = new Label();
            grbLawInformation = new GroupBox();
            txtDescriptionLaw = new TextBox();
            lblDescriptionLaw = new Label();
            txtAliasLaw = new TextBox();
            lblIdLaw = new Label();
            txtNameLaw = new TextBox();
            lblNameLaw = new Label();
            txtIdLaw = new TextBox();
            lblAliasLaw = new Label();
            grbCase = new GroupBox();
            btnNoncompliancesView = new Button();
            btnNoncompliances = new Button();
            btnCompliancesView = new Button();
            btnCompliances = new Button();
            btnGptView = new Button();
            btnGpt = new Button();
            txtNoncompliances = new TextBox();
            txtCompliances = new TextBox();
            lblNoncompliances = new Label();
            lblCompliances = new Label();
            btnCreate = new Button();
            txtGPT = new TextBox();
            lblGPT = new Label();
            txtDescription = new TextBox();
            txtId = new TextBox();
            txtAlias = new TextBox();
            lblName = new Label();
            txtName = new TextBox();
            lblAlias = new Label();
            lblId = new Label();
            lblDescription = new Label();
            grbComboBoxes.SuspendLayout();
            grbNormativeInformation.SuspendLayout();
            grbLawInformation.SuspendLayout();
            grbCase.SuspendLayout();
            SuspendLayout();
            // 
            // grbComboBoxes
            // 
            grbComboBoxes.Controls.Add(btnSearch);
            grbComboBoxes.Controls.Add(cmbLaws);
            grbComboBoxes.Controls.Add(cmbNormatives);
            grbComboBoxes.Controls.Add(lblCmbsLaws);
            grbComboBoxes.Controls.Add(lblCmbNormatives);
            grbComboBoxes.Location = new Point(172, 32);
            grbComboBoxes.Name = "grbComboBoxes";
            grbComboBoxes.Size = new Size(1235, 125);
            grbComboBoxes.TabIndex = 0;
            grbComboBoxes.TabStop = false;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(1003, 25);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // cmbLaws
            // 
            cmbLaws.FormattingEnabled = true;
            cmbLaws.Location = new Point(185, 74);
            cmbLaws.Name = "cmbLaws";
            cmbLaws.Size = new Size(784, 28);
            cmbLaws.TabIndex = 3;
            cmbLaws.SelectedIndexChanged += cmbLaws_SelectedIndexChanged;
            // 
            // cmbNormatives
            // 
            cmbNormatives.FormattingEnabled = true;
            cmbNormatives.Location = new Point(186, 23);
            cmbNormatives.Name = "cmbNormatives";
            cmbNormatives.Size = new Size(783, 28);
            cmbNormatives.TabIndex = 2;
            cmbNormatives.SelectedIndexChanged += cmbNormatives_SelectedIndexChanged;
            // 
            // lblCmbsLaws
            // 
            lblCmbsLaws.AutoSize = true;
            lblCmbsLaws.Location = new Point(115, 78);
            lblCmbsLaws.Name = "lblCmbsLaws";
            lblCmbsLaws.Size = new Size(44, 20);
            lblCmbsLaws.TabIndex = 1;
            lblCmbsLaws.Text = "Laws:";
            // 
            // lblCmbNormatives
            // 
            lblCmbNormatives.AutoSize = true;
            lblCmbNormatives.Location = new Point(74, 29);
            lblCmbNormatives.Name = "lblCmbNormatives";
            lblCmbNormatives.Size = new Size(88, 20);
            lblCmbNormatives.TabIndex = 0;
            lblCmbNormatives.Text = "Normatives:";
            // 
            // grbNormativeInformation
            // 
            grbNormativeInformation.Controls.Add(txtDescriptionNormative);
            grbNormativeInformation.Controls.Add(txtAliasNormative);
            grbNormativeInformation.Controls.Add(txtNameNormative);
            grbNormativeInformation.Controls.Add(txtIdNormative);
            grbNormativeInformation.Controls.Add(lblDescriptionNormative);
            grbNormativeInformation.Controls.Add(lblIdNormative);
            grbNormativeInformation.Controls.Add(lblAliasNormative);
            grbNormativeInformation.Controls.Add(lblNameNormative);
            grbNormativeInformation.Location = new Point(62, 198);
            grbNormativeInformation.Name = "grbNormativeInformation";
            grbNormativeInformation.Size = new Size(725, 291);
            grbNormativeInformation.TabIndex = 1;
            grbNormativeInformation.TabStop = false;
            grbNormativeInformation.Text = "Normative information";
            // 
            // txtDescriptionNormative
            // 
            txtDescriptionNormative.Location = new Point(132, 173);
            txtDescriptionNormative.Multiline = true;
            txtDescriptionNormative.Name = "txtDescriptionNormative";
            txtDescriptionNormative.ReadOnly = true;
            txtDescriptionNormative.Size = new Size(546, 96);
            txtDescriptionNormative.TabIndex = 6;
            // 
            // txtAliasNormative
            // 
            txtAliasNormative.Location = new Point(137, 135);
            txtAliasNormative.Name = "txtAliasNormative";
            txtAliasNormative.ReadOnly = true;
            txtAliasNormative.Size = new Size(541, 27);
            txtAliasNormative.TabIndex = 5;
            // 
            // txtNameNormative
            // 
            txtNameNormative.Location = new Point(137, 88);
            txtNameNormative.Name = "txtNameNormative";
            txtNameNormative.ReadOnly = true;
            txtNameNormative.Size = new Size(541, 27);
            txtNameNormative.TabIndex = 4;
            // 
            // txtIdNormative
            // 
            txtIdNormative.Location = new Point(137, 42);
            txtIdNormative.Name = "txtIdNormative";
            txtIdNormative.ReadOnly = true;
            txtIdNormative.Size = new Size(541, 27);
            txtIdNormative.TabIndex = 3;
            // 
            // lblDescriptionNormative
            // 
            lblDescriptionNormative.AutoSize = true;
            lblDescriptionNormative.Location = new Point(19, 212);
            lblDescriptionNormative.Name = "lblDescriptionNormative";
            lblDescriptionNormative.Size = new Size(88, 20);
            lblDescriptionNormative.TabIndex = 3;
            lblDescriptionNormative.Text = "Description:";
            // 
            // lblIdNormative
            // 
            lblIdNormative.AutoSize = true;
            lblIdNormative.Location = new Point(19, 49);
            lblIdNormative.Name = "lblIdNormative";
            lblIdNormative.Size = new Size(27, 20);
            lblIdNormative.TabIndex = 0;
            lblIdNormative.Text = "ID:";
            // 
            // lblAliasNormative
            // 
            lblAliasNormative.AutoSize = true;
            lblAliasNormative.Location = new Point(19, 142);
            lblAliasNormative.Name = "lblAliasNormative";
            lblAliasNormative.Size = new Size(44, 20);
            lblAliasNormative.TabIndex = 2;
            lblAliasNormative.Text = "Alias:";
            // 
            // lblNameNormative
            // 
            lblNameNormative.AutoSize = true;
            lblNameNormative.Location = new Point(19, 95);
            lblNameNormative.Name = "lblNameNormative";
            lblNameNormative.Size = new Size(52, 20);
            lblNameNormative.TabIndex = 1;
            lblNameNormative.Text = "Name:";
            // 
            // grbLawInformation
            // 
            grbLawInformation.Controls.Add(txtDescriptionLaw);
            grbLawInformation.Controls.Add(lblDescriptionLaw);
            grbLawInformation.Controls.Add(txtAliasLaw);
            grbLawInformation.Controls.Add(lblIdLaw);
            grbLawInformation.Controls.Add(txtNameLaw);
            grbLawInformation.Controls.Add(lblNameLaw);
            grbLawInformation.Controls.Add(txtIdLaw);
            grbLawInformation.Controls.Add(lblAliasLaw);
            grbLawInformation.Location = new Point(62, 513);
            grbLawInformation.Name = "grbLawInformation";
            grbLawInformation.Size = new Size(725, 289);
            grbLawInformation.TabIndex = 2;
            grbLawInformation.TabStop = false;
            grbLawInformation.Text = "Law information";
            // 
            // txtDescriptionLaw
            // 
            txtDescriptionLaw.Location = new Point(132, 174);
            txtDescriptionLaw.Multiline = true;
            txtDescriptionLaw.Name = "txtDescriptionLaw";
            txtDescriptionLaw.ReadOnly = true;
            txtDescriptionLaw.Size = new Size(546, 96);
            txtDescriptionLaw.TabIndex = 10;
            // 
            // lblDescriptionLaw
            // 
            lblDescriptionLaw.AutoSize = true;
            lblDescriptionLaw.Location = new Point(20, 211);
            lblDescriptionLaw.Name = "lblDescriptionLaw";
            lblDescriptionLaw.Size = new Size(88, 20);
            lblDescriptionLaw.TabIndex = 7;
            lblDescriptionLaw.Text = "Description:";
            // 
            // txtAliasLaw
            // 
            txtAliasLaw.Location = new Point(137, 133);
            txtAliasLaw.Name = "txtAliasLaw";
            txtAliasLaw.ReadOnly = true;
            txtAliasLaw.Size = new Size(541, 27);
            txtAliasLaw.TabIndex = 9;
            // 
            // lblIdLaw
            // 
            lblIdLaw.AutoSize = true;
            lblIdLaw.Location = new Point(19, 50);
            lblIdLaw.Name = "lblIdLaw";
            lblIdLaw.Size = new Size(27, 20);
            lblIdLaw.TabIndex = 4;
            lblIdLaw.Text = "ID:";
            // 
            // txtNameLaw
            // 
            txtNameLaw.Location = new Point(137, 93);
            txtNameLaw.Name = "txtNameLaw";
            txtNameLaw.ReadOnly = true;
            txtNameLaw.Size = new Size(541, 27);
            txtNameLaw.TabIndex = 8;
            // 
            // lblNameLaw
            // 
            lblNameLaw.AutoSize = true;
            lblNameLaw.Location = new Point(20, 96);
            lblNameLaw.Name = "lblNameLaw";
            lblNameLaw.Size = new Size(52, 20);
            lblNameLaw.TabIndex = 5;
            lblNameLaw.Text = "Name:";
            // 
            // txtIdLaw
            // 
            txtIdLaw.Location = new Point(137, 50);
            txtIdLaw.Name = "txtIdLaw";
            txtIdLaw.ReadOnly = true;
            txtIdLaw.Size = new Size(541, 27);
            txtIdLaw.TabIndex = 7;
            // 
            // lblAliasLaw
            // 
            lblAliasLaw.AutoSize = true;
            lblAliasLaw.Location = new Point(19, 136);
            lblAliasLaw.Name = "lblAliasLaw";
            lblAliasLaw.Size = new Size(44, 20);
            lblAliasLaw.TabIndex = 6;
            lblAliasLaw.Text = "Alias:";
            // 
            // grbCase
            // 
            grbCase.Controls.Add(btnNoncompliancesView);
            grbCase.Controls.Add(btnNoncompliances);
            grbCase.Controls.Add(btnCompliancesView);
            grbCase.Controls.Add(btnCompliances);
            grbCase.Controls.Add(btnGptView);
            grbCase.Controls.Add(btnGpt);
            grbCase.Controls.Add(txtNoncompliances);
            grbCase.Controls.Add(txtCompliances);
            grbCase.Controls.Add(lblNoncompliances);
            grbCase.Controls.Add(lblCompliances);
            grbCase.Controls.Add(btnCreate);
            grbCase.Controls.Add(txtGPT);
            grbCase.Controls.Add(lblGPT);
            grbCase.Controls.Add(txtDescription);
            grbCase.Controls.Add(txtId);
            grbCase.Controls.Add(txtAlias);
            grbCase.Controls.Add(lblName);
            grbCase.Controls.Add(txtName);
            grbCase.Controls.Add(lblAlias);
            grbCase.Controls.Add(lblId);
            grbCase.Controls.Add(lblDescription);
            grbCase.Location = new Point(896, 231);
            grbCase.Name = "grbCase";
            grbCase.Size = new Size(604, 562);
            grbCase.TabIndex = 3;
            grbCase.TabStop = false;
            grbCase.Text = "Case study";
            // 
            // btnNoncompliancesView
            // 
            btnNoncompliancesView.Location = new Point(480, 424);
            btnNoncompliancesView.Name = "btnNoncompliancesView";
            btnNoncompliancesView.Size = new Size(94, 29);
            btnNoncompliancesView.TabIndex = 26;
            btnNoncompliancesView.Text = "View";
            btnNoncompliancesView.UseVisualStyleBackColor = true;
            btnNoncompliancesView.Click += btnNoncompliancesView_Click;
            // 
            // btnNoncompliances
            // 
            btnNoncompliances.Location = new Point(380, 424);
            btnNoncompliances.Name = "btnNoncompliances";
            btnNoncompliances.Size = new Size(94, 29);
            btnNoncompliances.TabIndex = 25;
            btnNoncompliances.Text = "Generate";
            btnNoncompliances.UseVisualStyleBackColor = true;
            btnNoncompliances.Click += btnNoncompliances_Click;
            // 
            // btnCompliancesView
            // 
            btnCompliancesView.Location = new Point(480, 364);
            btnCompliancesView.Name = "btnCompliancesView";
            btnCompliancesView.Size = new Size(94, 29);
            btnCompliancesView.TabIndex = 24;
            btnCompliancesView.Text = "View";
            btnCompliancesView.UseVisualStyleBackColor = true;
            btnCompliancesView.Click += btnCompliancesView_Click;
            // 
            // btnCompliances
            // 
            btnCompliances.Location = new Point(380, 364);
            btnCompliances.Name = "btnCompliances";
            btnCompliances.Size = new Size(94, 29);
            btnCompliances.TabIndex = 23;
            btnCompliances.Text = "Generate";
            btnCompliances.UseVisualStyleBackColor = true;
            btnCompliances.Click += btnCompliances_Click;
            // 
            // btnGptView
            // 
            btnGptView.Location = new Point(480, 303);
            btnGptView.Name = "btnGptView";
            btnGptView.Size = new Size(94, 29);
            btnGptView.TabIndex = 22;
            btnGptView.Text = "View";
            btnGptView.UseVisualStyleBackColor = true;
            btnGptView.Click += btnGptView_Click;
            // 
            // btnGpt
            // 
            btnGpt.Location = new Point(380, 303);
            btnGpt.Name = "btnGpt";
            btnGpt.Size = new Size(94, 29);
            btnGpt.TabIndex = 21;
            btnGpt.Text = "Generate";
            btnGpt.UseVisualStyleBackColor = true;
            btnGpt.Click += btnGpt_Click;
            // 
            // txtNoncompliances
            // 
            txtNoncompliances.Location = new Point(166, 424);
            txtNoncompliances.Name = "txtNoncompliances";
            txtNoncompliances.ReadOnly = true;
            txtNoncompliances.Size = new Size(200, 27);
            txtNoncompliances.TabIndex = 20;
            // 
            // txtCompliances
            // 
            txtCompliances.Location = new Point(166, 366);
            txtCompliances.Name = "txtCompliances";
            txtCompliances.ReadOnly = true;
            txtCompliances.Size = new Size(200, 27);
            txtCompliances.TabIndex = 19;
            // 
            // lblNoncompliances
            // 
            lblNoncompliances.AutoSize = true;
            lblNoncompliances.Location = new Point(17, 424);
            lblNoncompliances.Name = "lblNoncompliances";
            lblNoncompliances.Size = new Size(126, 20);
            lblNoncompliances.TabIndex = 18;
            lblNoncompliances.Text = "Non-compliances";
            // 
            // lblCompliances
            // 
            lblCompliances.AutoSize = true;
            lblCompliances.Location = new Point(17, 366);
            lblCompliances.Name = "lblCompliances";
            lblCompliances.Size = new Size(97, 20);
            lblCompliances.TabIndex = 17;
            lblCompliances.Text = "Compliances:";
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(297, 505);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(94, 29);
            btnCreate.TabIndex = 16;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // txtGPT
            // 
            txtGPT.Location = new Point(166, 303);
            txtGPT.Name = "txtGPT";
            txtGPT.ReadOnly = true;
            txtGPT.Size = new Size(200, 27);
            txtGPT.TabIndex = 4;
            // 
            // lblGPT
            // 
            lblGPT.AutoSize = true;
            lblGPT.Location = new Point(17, 303);
            lblGPT.Name = "lblGPT";
            lblGPT.Size = new Size(93, 20);
            lblGPT.TabIndex = 15;
            lblGPT.Text = "GPT analysis:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(166, 170);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ReadOnly = true;
            txtDescription.Size = new Size(400, 96);
            txtDescription.TabIndex = 14;
            // 
            // txtId
            // 
            txtId.Location = new Point(166, 44);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(400, 27);
            txtId.TabIndex = 10;
            // 
            // txtAlias
            // 
            txtAlias.Location = new Point(166, 133);
            txtAlias.Name = "txtAlias";
            txtAlias.ReadOnly = true;
            txtAlias.Size = new Size(400, 27);
            txtAlias.TabIndex = 13;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(15, 93);
            lblName.Name = "lblName";
            lblName.Size = new Size(52, 20);
            lblName.TabIndex = 8;
            lblName.Text = "Name:";
            // 
            // txtName
            // 
            txtName.Location = new Point(166, 86);
            txtName.Name = "txtName";
            txtName.ReadOnly = true;
            txtName.Size = new Size(400, 27);
            txtName.TabIndex = 12;
            // 
            // lblAlias
            // 
            lblAlias.AutoSize = true;
            lblAlias.Location = new Point(15, 140);
            lblAlias.Name = "lblAlias";
            lblAlias.Size = new Size(44, 20);
            lblAlias.TabIndex = 9;
            lblAlias.Text = "Alias:";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(15, 47);
            lblId.Name = "lblId";
            lblId.Size = new Size(27, 20);
            lblId.TabIndex = 7;
            lblId.Text = "ID:";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(15, 210);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(88, 20);
            lblDescription.TabIndex = 11;
            lblDescription.Text = "Description:";
            // 
            // FrmManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1550, 829);
            Controls.Add(grbCase);
            Controls.Add(grbLawInformation);
            Controls.Add(grbNormativeInformation);
            Controls.Add(grbComboBoxes);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Management";
            grbComboBoxes.ResumeLayout(false);
            grbComboBoxes.PerformLayout();
            grbNormativeInformation.ResumeLayout(false);
            grbNormativeInformation.PerformLayout();
            grbLawInformation.ResumeLayout(false);
            grbLawInformation.PerformLayout();
            grbCase.ResumeLayout(false);
            grbCase.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grbComboBoxes;
        private ComboBox cmbLaws;
        private ComboBox cmbNormatives;
        private Label lblCmbsLaws;
        private Label lblCmbNormatives;
        private Button btnSearch;
        private GroupBox grbNormativeInformation;
        private Label lblDescriptionNormative;
        private Label lblIdNormative;
        private Label lblAliasNormative;
        private Label lblNameNormative;
        private GroupBox grbLawInformation;
        private Label lblDescriptionLaw;
        private Label lblIdLaw;
        private Label lblNameLaw;
        private Label lblAliasLaw;
        private TextBox txtDescriptionNormative;
        private TextBox txtAliasNormative;
        private TextBox txtNameNormative;
        private TextBox txtIdNormative;
        private TextBox txtDescriptionLaw;
        private TextBox txtAliasLaw;
        private TextBox txtNameLaw;
        private TextBox txtIdLaw;
        private GroupBox grbCase;
        private Label lblGPT;
        private TextBox txtDescription;
        private TextBox txtId;
        private TextBox txtAlias;
        private Label lblName;
        private TextBox txtName;
        private Label lblAlias;
        private Label lblId;
        private Label lblDescription;
        private Button btnCreate;
        private TextBox txtGPT;
        private Button btnNoncompliancesView;
        private Button btnNoncompliances;
        private Button btnCompliancesView;
        private Button btnCompliances;
        private Button btnGptView;
        private Button btnGpt;
        private TextBox txtNoncompliances;
        private TextBox txtCompliances;
        private Label lblNoncompliances;
        private Label lblCompliances;
    }
}