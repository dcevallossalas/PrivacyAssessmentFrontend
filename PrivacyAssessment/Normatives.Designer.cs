namespace PrivacyAssessment
{
    partial class Normatives
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
            txtNameNormative = new TextBox();
            lblName = new Label();
            btnLoadNormative = new Button();
            lblPath = new Label();
            txtPathNormative = new TextBox();
            btnFindNormative = new Button();
            lblNormatives = new Label();
            cmbNormatives = new ComboBox();
            btnSearch = new Button();
            lblAlias = new Label();
            txtAlias = new TextBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            gbNormatives = new GroupBox();
            lblId = new Label();
            txtId = new TextBox();
            groupBox1 = new GroupBox();
            btnDeleteCategory = new Button();
            btnAddCategory = new Button();
            lsbCategories = new ListBox();
            lblCategoryTo = new Label();
            lblCategoryFrom = new Label();
            lblPrinciple = new Label();
            txtCategoryTo = new TextBox();
            txtCategoryFrom = new TextBox();
            txtPrinciple = new TextBox();
            btnDelete = new Button();
            gbNormatives.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // txtNameNormative
            // 
            txtNameNormative.Location = new Point(143, 51);
            txtNameNormative.MaxLength = 50;
            txtNameNormative.Name = "txtNameNormative";
            txtNameNormative.Size = new Size(466, 27);
            txtNameNormative.TabIndex = 0;
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
            // btnLoadNormative
            // 
            btnLoadNormative.Location = new Point(176, 457);
            btnLoadNormative.Name = "btnLoadNormative";
            btnLoadNormative.Size = new Size(186, 65);
            btnLoadNormative.TabIndex = 7;
            btnLoadNormative.Text = "Load normative";
            btnLoadNormative.UseVisualStyleBackColor = true;
            btnLoadNormative.Click += btnLoadNormative_Click;
            // 
            // lblPath
            // 
            lblPath.AutoSize = true;
            lblPath.Location = new Point(75, 420);
            lblPath.Name = "lblPath";
            lblPath.Size = new Size(40, 20);
            lblPath.TabIndex = 3;
            lblPath.Text = "Path:";
            // 
            // txtPathNormative
            // 
            txtPathNormative.Location = new Point(125, 413);
            txtPathNormative.Name = "txtPathNormative";
            txtPathNormative.ReadOnly = true;
            txtPathNormative.Size = new Size(393, 27);
            txtPathNormative.TabIndex = 4;
            // 
            // btnFindNormative
            // 
            btnFindNormative.Location = new Point(535, 413);
            btnFindNormative.Name = "btnFindNormative";
            btnFindNormative.Size = new Size(94, 29);
            btnFindNormative.TabIndex = 6;
            btnFindNormative.Text = "Browse";
            btnFindNormative.UseVisualStyleBackColor = true;
            btnFindNormative.Click += btnFindNormative_Click;
            // 
            // lblNormatives
            // 
            lblNormatives.AutoSize = true;
            lblNormatives.Location = new Point(19, 42);
            lblNormatives.Name = "lblNormatives";
            lblNormatives.Size = new Size(88, 20);
            lblNormatives.TabIndex = 6;
            lblNormatives.Text = "Normatives:";
            // 
            // cmbNormatives
            // 
            cmbNormatives.FormattingEnabled = true;
            cmbNormatives.Location = new Point(122, 38);
            cmbNormatives.Name = "cmbNormatives";
            cmbNormatives.Size = new Size(351, 28);
            cmbNormatives.TabIndex = 9;
            cmbNormatives.SelectedIndexChanged += cmbNormatives_SelectedIndexChanged;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(499, 38);
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
            txtAlias.Size = new Size(219, 27);
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
            txtDescription.Size = new Size(466, 84);
            txtDescription.TabIndex = 2;
            txtDescription.KeyPress += txtDescription_KeyPress;
            // 
            // gbNormatives
            // 
            gbNormatives.Controls.Add(cmbNormatives);
            gbNormatives.Controls.Add(lblNormatives);
            gbNormatives.Controls.Add(btnSearch);
            gbNormatives.Location = new Point(126, 12);
            gbNormatives.Name = "gbNormatives";
            gbNormatives.Size = new Size(614, 100);
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
            groupBox1.Controls.Add(btnDeleteCategory);
            groupBox1.Controls.Add(btnAddCategory);
            groupBox1.Controls.Add(lsbCategories);
            groupBox1.Controls.Add(lblCategoryTo);
            groupBox1.Controls.Add(lblCategoryFrom);
            groupBox1.Controls.Add(lblPrinciple);
            groupBox1.Controls.Add(txtCategoryTo);
            groupBox1.Controls.Add(txtCategoryFrom);
            groupBox1.Controls.Add(txtPrinciple);
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnLoadNormative);
            groupBox1.Controls.Add(txtId);
            groupBox1.Controls.Add(lblId);
            groupBox1.Controls.Add(txtPathNormative);
            groupBox1.Controls.Add(lblPath);
            groupBox1.Controls.Add(lblName);
            groupBox1.Controls.Add(btnFindNormative);
            groupBox1.Controls.Add(txtNameNormative);
            groupBox1.Controls.Add(txtAlias);
            groupBox1.Controls.Add(lblAlias);
            groupBox1.Controls.Add(txtDescription);
            groupBox1.Controls.Add(lblDescription);
            groupBox1.Location = new Point(70, 118);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(751, 540);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            // 
            // btnDeleteCategory
            // 
            btnDeleteCategory.Location = new Point(598, 323);
            btnDeleteCategory.Name = "btnDeleteCategory";
            btnDeleteCategory.Size = new Size(94, 29);
            btnDeleteCategory.TabIndex = 23;
            btnDeleteCategory.Text = "Delete";
            btnDeleteCategory.UseVisualStyleBackColor = true;
            btnDeleteCategory.Click += btnDeleteCategory_Click;
            // 
            // btnAddCategory
            // 
            btnAddCategory.Location = new Point(631, 234);
            btnAddCategory.Name = "btnAddCategory";
            btnAddCategory.Size = new Size(94, 29);
            btnAddCategory.TabIndex = 22;
            btnAddCategory.Text = "Add";
            btnAddCategory.UseVisualStyleBackColor = true;
            btnAddCategory.Click += btnAddCategory_Click;
            // 
            // lsbCategories
            // 
            lsbCategories.FormattingEnabled = true;
            lsbCategories.Location = new Point(143, 283);
            lsbCategories.Name = "lsbCategories";
            lsbCategories.Size = new Size(428, 104);
            lsbCategories.TabIndex = 21;
            lsbCategories.SelectedIndexChanged += lsbCategories_SelectedIndexChanged;
            // 
            // lblCategoryTo
            // 
            lblCategoryTo.AutoSize = true;
            lblCategoryTo.Location = new Point(449, 235);
            lblCategoryTo.Name = "lblCategoryTo";
            lblCategoryTo.Size = new Size(26, 20);
            lblCategoryTo.TabIndex = 20;
            lblCategoryTo.Text = "to:";
            // 
            // lblCategoryFrom
            // 
            lblCategoryFrom.AutoSize = true;
            lblCategoryFrom.Location = new Point(222, 235);
            lblCategoryFrom.Name = "lblCategoryFrom";
            lblCategoryFrom.Size = new Size(108, 20);
            lblCategoryFrom.TabIndex = 19;
            lblCategoryFrom.Text = "From category:";
            // 
            // lblPrinciple
            // 
            lblPrinciple.AutoSize = true;
            lblPrinciple.Location = new Point(65, 235);
            lblPrinciple.Name = "lblPrinciple";
            lblPrinciple.Size = new Size(69, 20);
            lblPrinciple.TabIndex = 18;
            lblPrinciple.Text = "Principle:";
            // 
            // txtCategoryTo
            // 
            txtCategoryTo.Location = new Point(484, 234);
            txtCategoryTo.Name = "txtCategoryTo";
            txtCategoryTo.Size = new Size(125, 27);
            txtCategoryTo.TabIndex = 17;
            txtCategoryTo.KeyPress += txtCategoryTo_KeyPress;
            // 
            // txtCategoryFrom
            // 
            txtCategoryFrom.Location = new Point(340, 232);
            txtCategoryFrom.Name = "txtCategoryFrom";
            txtCategoryFrom.Size = new Size(100, 27);
            txtCategoryFrom.TabIndex = 16;
            txtCategoryFrom.KeyPress += txtCategoryFrom_KeyPress;
            // 
            // txtPrinciple
            // 
            txtPrinciple.Location = new Point(142, 232);
            txtPrinciple.Name = "txtPrinciple";
            txtPrinciple.Size = new Size(69, 27);
            txtPrinciple.TabIndex = 15;
            txtPrinciple.KeyPress += txtPrinciple_KeyPress;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(424, 457);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 65);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // Normatives
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(892, 710);
            Controls.Add(groupBox1);
            Controls.Add(gbNormatives);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Normatives";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Normatives";
            Load += Normatives_Load;
            gbNormatives.ResumeLayout(false);
            gbNormatives.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtNameNormative;
        private Label lblName;
        private Button btnLoadNormative;
        private Label lblPath;
        private TextBox txtPathNormative;
        private Button btnFindNormative;
        private Label lblNormatives;
        private ComboBox cmbNormatives;
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
        private Label lblCategoryFrom;
        private Label lblPrinciple;
        private TextBox txtCategoryTo;
        private TextBox txtCategoryFrom;
        private TextBox txtPrinciple;
        private ListBox lsbCategories;
        private Label lblCategoryTo;
        private Button btnAddCategory;
        private Button btnDeleteCategory;
    }
}
