using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace FitnessTracker_software
{
    public partial class Setgoal : Form
    {
        private OleDbConnection con1;
        public Setgoal()
        {

            InitializeComponent();
            con1 = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|Database.accdb");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                con1.Open();
                OleDbCommand cmd = con1.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Users set current_goal ='" + textBox1.Text + "' where username='" + textBox2.Text + "'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Goal was Successfully set");
                new Activities().Show(); this.Hide();
                con1.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, " Goal not successfully set");
                con1.Close();
            }
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            new Home().Show(); this.Hide();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            new Home().Show(); this.Hide();
        }

        private void Setgoal_Load(object sender, EventArgs e)
        {

        }
    }
}
