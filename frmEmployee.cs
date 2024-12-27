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
using System.Windows.Interop;

namespace BookShopManagementSystem
{
    public partial class frmEmployee : Form
    {
        public frmEmployee()
        {
            InitializeComponent();
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            frmBook book = new frmBook();
            book.Show();
            this.Hide();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            frmCustomer customer = new frmCustomer();
            customer.Show();
            this.Hide();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            frmOrder order = new frmOrder();
            order.Show();
            this.Hide();
        }

        private void btnOrderDetail_Click(object sender, EventArgs e)
        {
            frmOrderDetail detail = new frmOrderDetail();
            detail.Show();
            this.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=MSI\\HAODG;Initial Catalog=Book_Mana;Integrated Security=True";
            string query = "INSERT INTO Employee (EmployeeID, EmployeeName, Phone, Email, Address) VALUES (@EmployeeID, @EmployeeName, @Phone, @Email, @Address)";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, con);

                command.Parameters.AddWithValue("@EmployeeID", txtEmployeeID.Text);
                command.Parameters.AddWithValue("@EmployeeName", txtEmployeeName.Text);
                command.Parameters.AddWithValue("@Phone", txtPhone.Text);
                command.Parameters.AddWithValue("@Email", txtEmail.Text);
                command.Parameters.AddWithValue("@Address", txtAddress.Text);

                try
                {
                    con.Open();
                    command.ExecuteNonQuery();

                    // Add to ListView
                    ListViewItem newItem = new ListViewItem(txtEmployeeID.Text);
                    newItem.SubItems.Add(txtEmployeeName.Text);
                    newItem.SubItems.Add(txtPhone.Text);
                    newItem.SubItems.Add(txtEmail.Text);
                    newItem.SubItems.Add(txtAddress.Text);
                    lvEmployees.Items.Add(newItem);

                    MessageBox.Show("Thêm nhân viên thành công!", "Thông báo");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvEmployees.SelectedItems.Count > 0)
            {
                var selectedItem = lvEmployees.SelectedItems[0];
                string employeeID = selectedItem.SubItems[0].Text;

                string connectionString = "Data Source=MSI\\HAODG;Initial Catalog=Book_Mana;Integrated Security=True";
                string query = "DELETE FROM Employee WHERE EmployeeID = @EmployeeID";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@EmployeeID", employeeID);

                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();
                        lvEmployees.Items.Remove(selectedItem);
                        MessageBox.Show("Xóa nhân viên thành công!", "Thông báo");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lvEmployees.SelectedItems.Count > 0)
            {
                var selectedItem = lvEmployees.SelectedItems[0];

                selectedItem.SubItems[0].Text = txtEmployeeID.Text;
                selectedItem.SubItems[1].Text = txtEmployeeName.Text;
                selectedItem.SubItems[2].Text = txtPhone.Text;
                selectedItem.SubItems[3].Text = txtEmail.Text;
                selectedItem.SubItems[4].Text = txtAddress.Text;

                string connectionString = "Data Source=MSI\\HAODG;Initial Catalog=Book_Mana;Integrated Security=True";
                string query = "UPDATE Employee SET EmployeeName = @EmployeeName, Phone = @Phone, Email = @Email, Address = @Address WHERE EmployeeID = @EmployeeID";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, con);

                    command.Parameters.AddWithValue("@EmployeeID", txtEmployeeID.Text);
                    command.Parameters.AddWithValue("@EmployeeName", txtEmployeeName.Text);
                    command.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    command.Parameters.AddWithValue("@Email", txtEmail.Text);
                    command.Parameters.AddWithValue("@Address", txtAddress.Text);

                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Cập nhật nhân viên thành công!", "Thông báo");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật nhân viên: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên để cập nhật!");
            }

        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            string query = "SELECT EmployeeID, EmployeeName, Phone, Email, Address FROM Employee";

            // Xóa các mục cũ trong ListView
            lvEmployees.Items.Clear();

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
                        ListViewItem item = new ListViewItem(reader["EmployeeID"].ToString());
                        item.SubItems.Add(reader["EmployeeName"].ToString());
                        item.SubItems.Add(reader["Phone"].ToString());
                        item.SubItems.Add(reader["Email"].ToString());
                        item.SubItems.Add(reader["Address"].ToString());


                        // Thêm item vào ListView
                        lvEmployees.Items.Add(item);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void lvEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvEmployees.SelectedItems.Count > 0)
            {
                // Lấy mục được chọn
                var selectedItem = lvEmployees.SelectedItems[0];
                // Hiển thị dữ liệu lên các TextBox
                txtEmployeeID.Text = selectedItem.SubItems[0].Text;
                txtEmployeeName.Text = selectedItem.SubItems[1].Text;
                txtPhone.Text = selectedItem.SubItems[2].Text;
                txtEmail.Text = selectedItem.SubItems[3].Text;
                txtAddress.Text = selectedItem.SubItems[4].Text;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmLOGIN frmLOGIN = new frmLOGIN();
            frmLOGIN.Show();
            this.Hide();
        }

        private void btnDasbord_Click(object sender, EventArgs e)
        {
            frmDasboard frmDasboard = new frmDasboard();
            frmDasboard.Show();
            this.Hide();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Chuỗi kết nối
            string connectionString = "Data Source=MSI\\HAODG;Initial Catalog=Book_Mana;Integrated Security=True";

            // Chuỗi SQL tìm kiếm
            string query = "SELECT EmployeeID, EmployeeName, Phone, Email, Address " +
                           "FROM Employee " +
                           "WHERE EmployeeName LIKE @SearchKeyword OR Phone LIKE @SearchKeyword";

            // Xóa danh sách hiện tại trong ListView
            lvEmployees.Items.Clear();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, con);

                // Gán giá trị tham số tìm kiếm
                string searchKeyword = "%" + txtSearchEmployee.Text.Trim() + "%";
                command.Parameters.AddWithValue("@SearchKeyword", searchKeyword);

                try
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // Đọc dữ liệu và hiển thị lên ListView
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["EmployeeID"].ToString());
                        item.SubItems.Add(reader["EmployeeName"].ToString());
                        item.SubItems.Add(reader["Phone"].ToString());
                        item.SubItems.Add(reader["Email"].ToString());
                        item.SubItems.Add(reader["Address"].ToString());

                        lvEmployees.Items.Add(item);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm nhân viên: " + ex.Message);
                }
            }
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
