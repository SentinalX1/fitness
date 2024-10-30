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
using System.IO;

namespace FitnessTracker_software
{
    public partial class LogIn : Form
    {
        private LogIn_Class LogIn_Class;
        public LogIn()
        {
            InitializeComponent();
            try
            {
                string dbPath = Path.Combine(Application.StartupPath, "Fitness.accdb");

                if (!File.Exists(dbPath))
                {
                    MessageBox.Show($"Database not found at: {dbPath}\nPlease ensure the database file is in the correct location.",
                        "Database Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                LogIn_Class = new LogIn_Class(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Fitness.accdb");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing database connection: {ex.Message}",
                    "Connection Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new CreateAccount().Show(); 
            this.Hide();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (LogIn_Class == null)
                {
                    MessageBox.Show("Database connection not initialized properly.",
                        "Connection Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                if (LogIn_Class.AuthenticateUser(textBox1.Text, textBox2.Text, textBox3.Text))
                {
                    MessageBox.Show("Login was successful");
                    new Home().Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("User Login failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during login: {ex.Message}",
                    "Login Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
