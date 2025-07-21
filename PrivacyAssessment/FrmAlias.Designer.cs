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
            SuspendLayout();
            // 
            // lblAlias
            // 
            lblAlias.AutoSize = true;
            lblAlias.Location = new Point(125, 81);
            lblAlias.Name = "lblAlias";
            lblAlias.Size = new Size(44, 20);
            lblAlias.TabIndex = 0;
            lblAlias.Text = "Alias:";
            // 
            // txtAlias
            // 
            txtAlias.Location = new Point(209, 74);
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
            // FrmAlias
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(659, 264);
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
    }
}