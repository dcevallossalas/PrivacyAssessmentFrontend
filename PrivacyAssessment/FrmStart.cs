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
    public partial class FrmStart : Form
    {
        private System.Windows.Forms.Timer mainTimer;

        public FrmStart()
        {
            InitializeComponent();
        }

        private void FrmStart_Load(object sender, EventArgs e)
        {
            mainTimer = new System.Windows.Forms.Timer();
            mainTimer.Interval = 5000;
            mainTimer.Tick += tickTimer;
            mainTimer.Start();
        }

        private void tickTimer(object sender, EventArgs e)
        {
            mainTimer.Stop();
            mainTimer.Dispose();
            this.Close();
        }
    }
}