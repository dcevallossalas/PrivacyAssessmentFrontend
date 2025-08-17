namespace PrivacyAssessment
{
    partial class FrmInsertNormative
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
            cmbNormatives = new ComboBox();
            lblNormatives = new Label();
            label1 = new Label();
            txtAlias = new TextBox();
            btnAceptar = new Button();
            SuspendLayout();
            // 
            // cmbNormatives
            // 
            cmbNormatives.FormattingEnabled = true;
            cmbNormatives.Location = new Point(271, 88);
            cmbNormatives.Name = "cmbNormatives";
            cmbNormatives.Size = new Size(351, 28);
            cmbNormatives.TabIndex = 11;
            cmbNormatives.SelectedIndexChanged += cmbNormatives_SelectedIndexChanged;
            // 
            // lblNormatives
            // 
            lblNormatives.AutoSize = true;
            lblNormatives.Location = new Point(168, 92);
            lblNormatives.Name = "lblNormatives";
            lblNormatives.Size = new Size(88, 20);
            lblNormatives.TabIndex = 10;
            lblNormatives.Text = "Normatives:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(168, 186);
            label1.Name = "label1";
            label1.Size = new Size(44, 20);
            label1.TabIndex = 12;
            label1.Text = "Alias:";
            // 
            // txtAlias
            // 
            txtAlias.Location = new Point(271, 179);
            txtAlias.Name = "txtAlias";
            txtAlias.Size = new Size(351, 27);
            txtAlias.TabIndex = 13;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(344, 298);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(94, 29);
            btnAceptar.TabIndex = 14;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // FrmInsertNormative
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(739, 397);
            Controls.Add(btnAceptar);
            Controls.Add(txtAlias);
            Controls.Add(label1);
            Controls.Add(cmbNormatives);
            Controls.Add(lblNormatives);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmInsertNormative";
            Text = "Insert a normative";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbNormatives;
        private Label lblNormatives;
        private Label label1;
        private TextBox txtAlias;
        private Button btnAceptar;
    }
}