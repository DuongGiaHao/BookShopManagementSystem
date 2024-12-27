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
    public partial class frmOrder : Form
    {
        public frmOrder()
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
            frmBook frmBook = new frmBook();
            frmBook.Show();
            this.Hide();
        }

        private void tnCustomer_Click(object sender, EventArgs e)
        {
            frmCustomer frmCustomer = new frmCustomer();
            frmCustomer.Show();
            this.Hide();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            frmEmployee frmEmployee = new frmEmployee();
            frmEmployee.Show();
            this.Hide();
        }

        private void btnOrderDetail_Click(object sender, EventArgs e)
        {
            frmOrderDetail frmOderDetail = new frmOrderDetail();
            frmOderDetail.Show();
            this.Hide();
        }

        private void frmOder_Load(object sender, EventArgs e)
        {
            // Chuỗi kết nối tới cơ sở dữ liệu
            string connectionString = "Data Source=MSI\\HAODG;Initial Catalog=Book_Mana;Integrated Security=True";

            // Câu lệnh SQL để lấy dữ liệu từ bảng Order
            string query = "SELECT OrderID, CustomerID, EmployeeID, OrderDate FROM [Order]";

            // Xóa các mục cũ trong ListView
            lvOrder.Items.Clear();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, con);

                try
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        // Tạo một ListViewItem mới cho từng bản ghi
                        string orderDateStr = reader["OrderDate"].ToString();
                        DateTime orderDate;

                        if (DateTime.TryParse(orderDateStr, out orderDate))
                        {
                            ListViewItem item = new ListViewItem(reader["OrderID"].ToString());
                            item.SubItems.Add(reader["CustomerID"].ToString());
                            item.SubItems.Add(reader["EmployeeID"].ToString());
                            item.SubItems.Add(orderDate.ToString("dd-MM-yyyy"));
                            lvOrder.Items.Add(item);
                        }
                        else
                        {
                            MessageBox.Show("Lỗi định dạng ngày tháng trong dữ liệu!");
                        }
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=MSI\\HAODG;Initial Catalog=Book_Mana;Integrated Security=True";
            string query = "INSERT INTO [Order] (OrderID, CustomerID, EmployeeID, OrderDate) VALUES (@OrderID, @CustomerID, @EmployeeID, @OrderDate)";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, con);

                command.Parameters.AddWithValue("@OrderID", txtOrderID.Text);
                command.Parameters.AddWithValue("@CustomerID", txtCustomerID.Text);
                command.Parameters.AddWithValue("@EmployeeID", txtEmployeeID.Text);

                // Kiểm tra ngày tháng hợp lệ trước khi thêm vào
                DateTime orderDate = dtpOrderDate.Value;

                if (orderDate != null)
                {
                    command.Parameters.AddWithValue("@OrderDate", orderDate);

                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();

                        // Thêm vào ListView
                        ListViewItem item = new ListViewItem(txtOrderID.Text);
                        item.SubItems.Add(txtCustomerID.Text);
                        item.SubItems.Add(txtEmployeeID.Text);
                        item.SubItems.Add(orderDate.ToString("dd-MM-yyyy"));
                        lvOrder.Items.Add(item);

                        MessageBox.Show("Thêm đơn hàng thành công!", "Thông báo");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi thêm đơn hàng: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Ngày tháng không hợp lệ. Vui lòng kiểm tra lại!");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvOrder.SelectedItems.Count > 0)
            {
                var selectedItem = lvOrder.SelectedItems[0];
                string orderID = selectedItem.SubItems[0].Text;

                string connectionString = "Data Source=MSI\\HAODG;Initial Catalog=Book_Mana;Integrated Security=True";
                string query = "DELETE FROM [Order] WHERE OrderID = @OrderID";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@OrderID", orderID);

                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();
                        lvOrder.Items.Remove(selectedItem);

                        MessageBox.Show("Xóa đơn hàng thành công!", "Thông báo");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa đơn hàng: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn đơn hàng cần xóa!");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text;
            string connectionString = "Data Source=MSI\\HAODG;Initial Catalog=Book_Mana;Integrated Security=True";
            string query = "SELECT OrderID, CustomerID, EmployeeID, OrderDate FROM [Order] WHERE OrderID LIKE @SearchText OR CustomerID LIKE @SearchText OR EmployeeID LIKE @SearchText";

            lvOrder.Items.Clear();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                try
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["OrderID"].ToString());
                        item.SubItems.Add(reader["CustomerID"].ToString());
                        item.SubItems.Add(reader["EmployeeID"].ToString());
                        item.SubItems.Add(Convert.ToDateTime(reader["OrderDate"]).ToString("dd-MM-yyyy"));
                        lvOrder.Items.Add(item);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lvOrder.SelectedItems.Count > 0)
            {
                var selectedItem = lvOrder.SelectedItems[0];

                selectedItem.SubItems[0].Text = txtOrderID.Text;
                selectedItem.SubItems[1].Text = txtCustomerID.Text;
                selectedItem.SubItems[2].Text = txtEmployeeID.Text;
                selectedItem.SubItems[3].Text = dtpOrderDate.Value.ToString("dd-MM-yyyy");

                string connectionString = "Data Source=MSI\\HAODG;Initial Catalog=Book_Mana;Integrated Security=True";
                string query = "UPDATE [Order] SET CustomerID = @CustomerID, EmployeeID = @EmployeeID, OrderDate = @OrderDate WHERE OrderID = @OrderID";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, con);

                    command.Parameters.AddWithValue("@OrderID", txtOrderID.Text);
                    command.Parameters.AddWithValue("@CustomerID", txtCustomerID.Text);
                    command.Parameters.AddWithValue("@EmployeeID", txtEmployeeID.Text);
                    command.Parameters.AddWithValue("@OrderDate", dtpOrderDate.Value);

                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();

                        MessageBox.Show("Cập nhật đơn hàng thành công!", "Thông báo");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật đơn hàng: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn đơn hàng để cập nhật!");
            }
        }

        private void lvOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvOrder.SelectedItems.Count > 0)
            {
                var selectedItem = lvOrder.SelectedItems[0];

                txtOrderID.Text = selectedItem.SubItems[0].Text;
                txtCustomerID.Text = selectedItem.SubItems[1].Text;
                txtEmployeeID.Text = selectedItem.SubItems[2].Text;

                string orderDateStr = selectedItem.SubItems[3].Text;

                if (DateTime.TryParseExact(orderDateStr, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime orderDate))
                {
                    dtpOrderDate.Value = orderDate;
                }
                else
                {
                    MessageBox.Show("Lỗi định dạng ngày tháng trong mục đã chọn!");
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