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
    /// Class FrmStart
    /// Displays an initial presentation of the frontend application
    /// </summary>
    public partial class FrmStart : Form
    {
        private System.Windows.Forms.Timer mainTimer;

        // Constructor
        public FrmStart()
        {
            InitializeComponent();
        }

        // Loads a new window with the presentation of the application
        private void FrmStart_Load(object sender, EventArgs e)
        {
            mainTimer = new System.Windows.Forms.Timer();
            mainTimer.Interval = 5000;
            mainTimer.Tick += tickTimer;
            mainTimer.Start();
        }

        // Closes the window when the time expires
        private void tickTimer(object sender, EventArgs e)
        {
            mainTimer.Stop();
            mainTimer.Dispose();
            this.Close();
        }
    }
}