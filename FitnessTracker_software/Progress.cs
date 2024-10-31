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
    public partial class Progress : Form
    {
        private OleDbConnection con1;
        public Progress()
        {
           
        InitializeComponent();
        con1 = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Fitness.accdb");
    }

        private void Button5_Click(object sender, EventArgs e)
        {
            new Home().Show(); this.Hide();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            new Home().Show(); this.Hide();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                con1.Open();
                OleDbCommand cmd = con1.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Users WHERE username = '" + textBox1.Text + "'";
                DataTable dt = new DataTable();
                OleDbDataAdapter dp = new OleDbDataAdapter(cmd);
                dp.Fill(dt);
                dataGridView1.DataSource = dt;
                con1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Connection is not successful");
                con1.Close();
            }

        }
    }
}
