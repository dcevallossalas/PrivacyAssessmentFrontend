namespace PrivacyAssessment
{
    partial class FrmAlias
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
            lblAlias = new Label();
            txtAlias = new TextBox();
            btnAceptar = new Button();
            txtName = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // lblAlias
            // 
            lblAlias.AutoSize = true;
            lblAlias.Location = new Point(136, 120);
            lblAlias.Name = "lblAlias";
            lblAlias.Size = new Size(44, 20);
            lblAlias.TabIndex = 0;
            lblAlias.Text = "Alias:";
            // 
            // txtAlias
            // 
            txtAlias.Location = new Point(220, 113);
            txtAlias.Name = "txtAlias";
            txtAlias.Size = new Size(359, 27);
            txtAlias.TabIndex = 1;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(288, 185);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(94, 29);
            btnAceptar.TabIndex = 2;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(221, 57);
            txtName.Name = "txtName";
            txtName.Size = new Size(358, 27);
            txtName.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(128, 60);
            label2.Name = "label2";
            label2.Size = new Size(52, 20);
            label2.TabIndex = 17;
            label2.Text = "Name:";
            // 
            // FrmAlias
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(659, 264);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(btnAceptar);
            Controls.Add(txtAlias);
            Controls.Add(lblAlias);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmAlias";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Insert a new alias";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAlias;
        private TextBox txtAlias;
        private Button btnAceptar;
        private TextBox txtName;
        private Label label2;
    }
}