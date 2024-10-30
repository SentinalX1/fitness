using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;

namespace FitnessTracker_software
{
    class LogIn_Class
    {
       
            private OleDbConnection connection;

            public LogIn_Class(string connectionString)
            {
                connection = new OleDbConnection(connectionString);
            }

            public bool AuthenticateUser(string userID, string username, string password)
            {
           
            try
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Users WHERE userID = ? AND username  = ? AND password = ?";
                OleDbCommand cmd = new OleDbCommand(query, connection);
                cmd.Parameters.AddWithValue("?", userID);
                cmd.Parameters.AddWithValue("?", username);
                cmd.Parameters.AddWithValue("?", password);

                int result = (int)cmd.ExecuteScalar();

                return result > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            
            }
          
                finally
                {
                    connection.Close();
                }
            }
        }
    }


