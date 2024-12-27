using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BookShopManagementSystem
{
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmLOGIN frmLOGIN = new frmLOGIN();
            frmLOGIN.Show();
            this.Hide();

        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            frmBook frmBOOK = new frmBook();
            frmBOOK.Show(); 
            this.Hide();    
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
           frmEmployee frmEmployee = new frmEmployee();
            frmEmployee.Show();
            this.Hide();
        }

        private void btnOder_Click(object sender, EventArgs e)
        {
            frmOrder frmOder = new frmOrder();    
            frmOder.Show();
            this.Hide();
        }

        private void btnOderDetail_Click(object sender, EventArgs e)
        {
            frmOrderDetail frmOderDetail = new frmOrderDetail();
            frmOderDetail.Show();
            this.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=MSI\\HAODG;Initial Catalog=Book_Mana;Integrated Security=True";
            string query = "INSERT INTO Customer (CustomerID, CustomerName, Phone, Address) VALUES (@CustomerID, @CustomerName, @Phone, @Address)";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, con);

                command.Parameters.AddWithValue("@CustomerID", txtCustomerID.Text);
                command.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                command.Parameters.AddWithValue("@Phone", txtPhone.Text);
                command.Parameters.AddWithValue("@Address", txtAddress.Text);

                try
                {
                    con.Open();
                    command.ExecuteNonQuery();

                    ListViewItem newItem = new ListViewItem(txtCustomerID.Text);
                    newItem.SubItems.Add(txtCustomerName.Text);
                    newItem.SubItems.Add(txtPhone.Text);
                    newItem.SubItems.Add(txtAddress.Text);
                    lvCustomers.Items.Add(newItem);

                    MessageBox.Show("Thêm khách hàng thành công!", "Thông báo");

                    txtCustomerID.Clear();
                    txtCustomerName.Clear();
                    txtPhone.Clear();
                    txtAddress.Clear();
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm khách hàng: " + ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvCustomers.SelectedItems.Count > 0)
            {
                var selectedItem = lvCustomers.SelectedItems[0];
                string customerID = selectedItem.SubItems[0].Text;

                string connectionString = "Data Source=MSI\\HAODG;Initial Catalog=Book_Mana;Integrated Security=True";
                string query = "DELETE FROM Customer WHERE CustomerID = @CustomerID";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@CustomerID", customerID);

                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();
                        lvCustomers.Items.Remove(selectedItem);
                        MessageBox.Show("Xóa khách hàng thành công!", "Thông báo");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa khách hàng: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lvCustomers.SelectedItems.Count > 0)
            {
                var selectedItem = lvCustomers.SelectedItems[0];

                selectedItem.SubItems[0].Text = txtCustomerID.Text;
                selectedItem.SubItems[1].Text = txtCustomerName.Text;
                selectedItem.SubItems[2].Text = txtPhone.Text;
                selectedItem.SubItems[3].Text = txtAddress.Text;

                string connectionString = "Data Source=MSI\\HAODG;Initial Catalog=Book_Mana;Integrated Security=True";
                string query = "UPDATE Customer SET CustomerName = @CustomerName, Phone = @Phone, Address = @Address WHERE CustomerID = @CustomerID";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, con);

                    command.Parameters.AddWithValue("@CustomerID", txtCustomerID.Text);
                    command.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                    command.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    command.Parameters.AddWithValue("@Address", txtAddress.Text);

                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Cập nhật khách hàng thành công!", "Thông báo");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật khách hàng: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng để cập nhật!");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchKeyword = txtSearch.Text.Trim();
            string connectionString = "Data Source=MSI\\HAODG;Initial Catalog=Book_Mana;Integrated Security=True";
            string query = "SELECT * FROM Customer WHERE CustomerName LIKE @SearchKeyword";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@SearchKeyword", "%" + searchKeyword + "%");

                try
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    lvCustomers.Items.Clear();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["CustomerID"].ToString());
                        item.SubItems.Add(reader["CustomerName"].ToString());
                        item.SubItems.Add(reader["Phone"].ToString());
                        item.SubItems.Add(reader["Address"].ToString());
                        lvCustomers.Items.Add(item);
                    }

                    reader.Close();
                    if (lvCustomers.Items.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy kết quả phù hợp!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
                }
            }
        }

        private void lvCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvCustomers.SelectedItems.Count > 0)
            {
                // Lấy mục được chọn
                var selectedItem = lvCustomers.SelectedItems[0];
                // Hiển thị dữ liệu lên các TextBox
                txtCustomerID.Text = selectedItem.SubItems[0].Text;
                txtCustomerName.Text = selectedItem.SubItems[1].Text;
                txtPhone.Text = selectedItem.SubItems[2].Text;
                txtAddress.Text = selectedItem.SubItems[3].Text;
               
            }
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            string query = "SELECT CustomerID, CustomerName, Phone, Address FROM Customer";

            // Xóa các mục cũ trong ListView
            lvCustomers.Items.Clear();

            // Chuỗi kết nối tới cơ sở dữ liệu
            string connectionString = "Data Source=MSI\\HAODG;Initial Catalog=Book_Mana;Integrated Security=True";

            SqlConnection con = new SqlConnection(connectionString);
            {
                SqlCommand command = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        // Tạo một ListViewItem mới
                        ListViewItem item = new ListViewItem(reader["CustomerID"].ToString());
                        item.SubItems.Add(reader["CustomerName"].ToString());
                        item.SubItems.Add(reader["Phone"].ToString());
                        item.SubItems.Add(reader["Address"].ToString());
                    

                        // Thêm item vào ListView
                        lvCustomers.Items.Add(item);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void btnDasboard_Click(object sender, EventArgs e)
        {
            frmDasboard frmDasboard = new frmDasboard();
            frmDasboard.Show();
            this.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // Display a confirmation dialog
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit?",
                "Exit Confirmation",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            // Check the result of the dialog
            if (result == DialogResult.OK)
            {
                Application.Exit(); // Close the application
            }
        }
    }
}   
