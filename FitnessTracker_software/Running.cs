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
    public partial class Running : Form
    {
        private const string ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Fitness.accdb";

        public Running()
        {
            InitializeComponent();
        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            // Parse values from textboxes
            if (int.TryParse(textBox1.Text, out int steps) &&
                double.TryParse(textBox2.Text, out double distance) &&
                double.TryParse(textBox3.Text, out double time) &&
                !string.IsNullOrEmpty(textBox4.Text))
            {
                // Calculate calories burned
                double caloriesBurned = CalculateCaloriesBurned(steps, distance, time);

                // Display result in MessageBox
                MessageBox.Show($"Calories Burned: {caloriesBurned}");

                // Insert the result into the Access database
                InsertIntoDatabase(textBox4.Text, caloriesBurned);
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter valid values.");
            }
        }
        private double CalculateCaloriesBurned(int laps, double distance, double time)
        {
            // You can replace this formula with your own for calculating calories burned
            // This is just a placeholder
            double caloriesPerlap = 0.05;
            double caloriesBurned = laps * caloriesPerlap;

            return caloriesBurned;
        }

        private void InsertIntoDatabase(string username, double caloriesBurned)
        {
            {
                using (OleDbConnection connection = new OleDbConnection(ConnectionString))
                {
                    try
                    {
                        connection.Open();

                        // Update existing record in the database using a parameterized query
                        string updateQuery = "UPDATE Users SET current_carrolies_burned= ? WHERE Username = ?";
                        using (OleDbCommand cmd = new OleDbCommand(updateQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("CaloriesBurned", caloriesBurned);
                            cmd.Parameters.AddWithValue("Username", username);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating data in the database: {ex.Message}");
                    }
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            new Activities().Show(); this.Hide();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            new Home().Show(); this.Hide();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
