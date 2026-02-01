using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrivacyAssessment
{
    /// <summary>
    /// Class FrmView
    /// Form to visualize a text with the results of a previously executed action
    /// </summary>
    public partial class FrmView : Form
    {
        // Constructor
        public FrmView(string text)
        {
            InitializeComponent();
            txtContent.Text = text.Replace("\n", Environment.NewLine).Replace("\\n", Environment.NewLine);
        }

        // Closes the form
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
