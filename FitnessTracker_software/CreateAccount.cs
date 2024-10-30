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
    public partial class CreateAccount : Form
    {
        public OleDbConnection con1;
        public CreateAccount()
        {
            InitializeComponent();
            con1 = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|Database.accdb");
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            // Get user input from textboxes or other controls
            string UserID = textBox1.Text;
            string username = textBox2.Text;
            string password = textBox3.Text;


            try
            {
                con1.Open();
                using (OleDbCommand cmd = con1.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO [Users] ([UserID], [Username], [Password]) VALUES (@UserID, @Username, @Password)";
                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Account created successfully");
                    new Home().Show();
                    this.Hide();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating user: " + ex.Message);
            }
            finally
            {
                con1.Close();

            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
