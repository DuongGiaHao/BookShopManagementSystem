using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BookShopManagementSystem
{
    public partial class frmLOGIN : Form
    {
        public frmLOGIN()
        {
            InitializeComponent();
        }
       
        private SqlConnection ConnectToDatabase()
        {
            string connectionString = "Data Source=MSI\\HAODG;Initial Catalog=ManageProduct;Integrated Security=True";
            return new SqlConnection(connectionString);
        }

        // Hàm kiểm tra đăng nhập
        private bool CheckLogin(string username, string password)
        {
            using (SqlConnection conn = ConnectToDatabase())
            {
                conn.Open();
                string query = "SELECT * FROM [UserName] WHERE name = @Name AND pass = @Pass";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", username);
                cmd.Parameters.AddWithValue("@Pass", password);

                SqlDataReader reader = cmd.ExecuteReader();
                return reader.HasRows;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPass.Text;

            if (CheckLogin(username, password))
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Mở form frmMain khi đăng nhập thành công
                frmDasboard frmDasboard = new frmDasboard();
                frmDasboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Display a confirmation dialog
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check the user's choice
            if (result == DialogResult.Yes)
            {
                // Exit the application
                Application.Exit();
            }
        }
    }
    
}
