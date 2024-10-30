using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitnessTracker_software
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            new Progress().Show(); this.Hide();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            new Setgoal().Show(); this.Hide();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
