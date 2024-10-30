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
    public partial class Activities : Form
    {
        public Activities()
        {
            InitializeComponent();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            new Walking().Show(); this.Hide();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            new Swimming().Show(); this.Hide();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            new Running().Show(); this.Hide();
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            new Cycling().Show(); this.Hide();
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            new Strength_Training().Show(); this.Hide();
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            new Aerobic().Show(); this.Hide();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            new Setgoal().Show(); this.Hide();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            new Home().Show(); this.Hide();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
