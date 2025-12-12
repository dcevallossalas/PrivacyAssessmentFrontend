namespace PrivacyAssessment
{
    partial class FrmLaws
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtNameLaw = new TextBox();
            lblName = new Label();
            btnLoadLaw = new Button();
            lblPath = new Label();
            txtPathLaw = new TextBox();
            btnFindLaw = new Button();
            lblLaws = new Label();
            cmbLaws = new ComboBox();
            btnSearch = new Button();
            lblAlias = new Label();
            txtAlias = new TextBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            gbNormatives = new GroupBox();
            lblId = new Label();
            txtId = new TextBox();
            groupBox1 = new GroupBox();
            btnDelete = new Button();
            gbNormatives.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // txtNameLaw
            // 
            txtNameLaw.Location = new Point(143, 51);
            txtNameLaw.MaxLength = 50;
            txtNameLaw.Name = "txtNameLaw";
            txtNameLaw.Size = new Size(714, 27);
            txtNameLaw.TabIndex = 0;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(85, 54);
            lblName.Name = "lblName";
            lblName.Size = new Size(52, 20);
            lblName.TabIndex = 1;
            lblName.Text = "Name:";
            // 
            // btnLoadLaw
            // 
            btnLoadLaw.Location = new Point(194, 319);
            btnLoadLaw.Name = "btnLoadLaw";
            btnLoadLaw.Size = new Size(186, 65);
            btnLoadLaw.TabIndex = 7;
            btnLoadLaw.Text = "Load law";
            btnLoadLaw.UseVisualStyleBackColor = true;
            btnLoadLaw.Click += btnLoadLaw_Click;
            // 
            // lblPath
            // 
            lblPath.AutoSize = true;
            lblPath.Location = new Point(93, 282);
            lblPath.Name = "lblPath";
            lblPath.Size = new Size(40, 20);
            lblPath.TabIndex = 3;
            lblPath.Text = "Path:";
            // 
            // txtPathLaw
            // 
            txtPathLaw.Location = new Point(143, 275);
            txtPathLaw.Name = "txtPathLaw";
            txtPathLaw.ReadOnly = true;
            txtPathLaw.Size = new Size(714, 27);
            txtPathLaw.TabIndex = 4;
            // 
            // btnFindLaw
            // 
            btnFindLaw.Location = new Point(863, 273);
            btnFindLaw.Name = "btnFindLaw";
            btnFindLaw.Size = new Size(94, 29);
            btnFindLaw.TabIndex = 6;
            btnFindLaw.Text = "Browse";
            btnFindLaw.UseVisualStyleBackColor = true;
            btnFindLaw.Click += btnFindLaw_Click;
            // 
            // lblLaws
            // 
            lblLaws.AutoSize = true;
            lblLaws.Location = new Point(19, 42);
            lblLaws.Name = "lblLaws";
            lblLaws.Size = new Size(44, 20);
            lblLaws.TabIndex = 6;
            lblLaws.Text = "Laws:";
            // 
            // cmbLaws
            // 
            cmbLaws.FormattingEnabled = true;
            cmbLaws.Location = new Point(122, 38);
            cmbLaws.Name = "cmbLaws";
            cmbLaws.Size = new Size(679, 28);
            cmbLaws.TabIndex = 9;
            cmbLaws.SelectedIndexChanged += cmbLaws_SelectedIndexChanged;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(807, 38);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 10;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // lblAlias
            // 
            lblAlias.AutoSize = true;
            lblAlias.Location = new Point(93, 90);
            lblAlias.Name = "lblAlias";
            lblAlias.Size = new Size(44, 20);
            lblAlias.TabIndex = 9;
            lblAlias.Text = "Alias:";
            // 
            // txtAlias
            // 
            txtAlias.Location = new Point(143, 87);
            txtAlias.Name = "txtAlias";
            txtAlias.Size = new Size(714, 27);
            txtAlias.TabIndex = 1;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(49, 156);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(88, 20);
            lblDescription.TabIndex = 11;
            lblDescription.Text = "Description:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(143, 126);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(714, 84);
            txtDescription.TabIndex = 2;
            txtDescription.KeyPress += txtDescription_KeyPress;
            // 
            // gbNormatives
            // 
            gbNormatives.Controls.Add(cmbLaws);
            gbNormatives.Controls.Add(lblLaws);
            gbNormatives.Controls.Add(btnSearch);
            gbNormatives.Location = new Point(126, 12);
            gbNormatives.Name = "gbNormatives";
            gbNormatives.Size = new Size(930, 100);
            gbNormatives.TabIndex = 13;
            gbNormatives.TabStop = false;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(112, 21);
            lblId.Name = "lblId";
            lblId.Size = new Size(25, 20);
            lblId.TabIndex = 14;
            lblId.Text = "Id:";
            // 
            // txtId
            // 
            txtId.Location = new Point(143, 18);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(125, 27);
            txtId.TabIndex = 11;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnLoadLaw);
            groupBox1.Controls.Add(txtId);
            groupBox1.Controls.Add(lblId);
            groupBox1.Controls.Add(txtPathLaw);
            groupBox1.Controls.Add(lblPath);
            groupBox1.Controls.Add(lblName);
            groupBox1.Controls.Add(btnFindLaw);
            groupBox1.Controls.Add(txtNameLaw);
            groupBox1.Controls.Add(txtAlias);
            groupBox1.Controls.Add(lblAlias);
            groupBox1.Controls.Add(txtDescription);
            groupBox1.Controls.Add(lblDescription);
            groupBox1.Location = new Point(70, 118);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(986, 412);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(863, 334);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 35);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // FrmLaws
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1113, 559);
            Controls.Add(groupBox1);
            Controls.Add(gbNormatives);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FrmLaws";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Laws";
            Load += Laws_Load;
            gbNormatives.ResumeLayout(false);
            gbNormatives.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtNameLaw;
        private Label lblName;
        private Button btnLoadLaw;
        private Label lblPath;
        private TextBox txtPathLaw;
        private Button btnFindLaw;
        private Label lblLaws;
        private ComboBox cmbLaws;
        private Button btnSearch;
        private Label lblAlias;
        private TextBox txtAlias;
        private Label lblDescription;
        private TextBox txtDescription;
        private GroupBox gbNormatives;
        private Label lblId;
        private TextBox txtId;
        private GroupBox groupBox1;
        private Button btnDelete;
    }
}
