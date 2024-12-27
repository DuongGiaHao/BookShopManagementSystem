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
    public partial class frmOrderDetail : Form
    {
        public frmOrderDetail()
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

        private void btnCustomer_Click(object sender, EventArgs e)
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

        private void btnOrder_Click(object sender, EventArgs e)
        {
            frmOrder frmOder = new frmOrder();
            frmOder.Show();
            this.Hide();
        }

        private void frmOrderDetail_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=MSI\\HAODG;Initial Catalog=Book_Mana;Integrated Security=True";
            string query = "SELECT OrderDetailID, OrderID, BookID, Quantity, Price FROM OrderDetail";

            lvOrderDetail.Items.Clear();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, con);

                try
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["OrderDetailID"].ToString());
                        item.SubItems.Add(reader["OrderID"].ToString());
                        item.SubItems.Add(reader["BookID"].ToString());
                        item.SubItems.Add(reader["Quantity"].ToString());
                        item.SubItems.Add(reader["Price"].ToString());

                        lvOrderDetail.Items.Add(item);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách chi tiết đơn hàng: " + ex.Message);
                }
            }
        }

        private void lvOrderDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvOrderDetail.SelectedItems.Count > 0)
            {
                var selectedItem = lvOrderDetail.SelectedItems[0];

                txtOrderDetailID.Text = selectedItem.SubItems[0].Text;
                txtOrderID.Text = selectedItem.SubItems[1].Text;
                txtBookID.Text = selectedItem.SubItems[2].Text;
                txtQuantity.Text = selectedItem.SubItems[3].Text;
                txtPrice.Text = selectedItem.SubItems[4].Text;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=MSI\\HAODG;Initial Catalog=Book_Mana;Integrated Security=True";
            string query = "INSERT INTO OrderDetail (OrderDetailID, OrderID, BookID, Quantity, Price) VALUES (@OrderDetailID, @OrderID, @BookID, @Quantity, @Price)";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, con);

                command.Parameters.AddWithValue("@OrderDetailID", txtOrderDetailID.Text);
                command.Parameters.AddWithValue("@OrderID", txtOrderID.Text);
                command.Parameters.AddWithValue("@BookID", txtBookID.Text);
                command.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
                command.Parameters.AddWithValue("@Price", txtPrice.Text);

                try
                {
                    con.Open();
                    command.ExecuteNonQuery();

                    ListViewItem item = new ListViewItem(txtOrderDetailID.Text);
                    item.SubItems.Add(txtOrderID.Text);
                    item.SubItems.Add(txtBookID.Text);
                    item.SubItems.Add(txtQuantity.Text);
                    item.SubItems.Add(txtPrice.Text);
                    lvOrderDetail.Items.Add(item);

                    MessageBox.Show("Thêm chi tiết đơn hàng thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm: " + ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvOrderDetail.SelectedItems.Count > 0)
            {
                string connectionString = "Data Source=MSI\\HAODG;Initial Catalog=Book_Mana;Integrated Security=True";
                string query = "DELETE FROM OrderDetail WHERE OrderDetailID = @OrderDetailID";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@OrderDetailID", txtOrderDetailID.Text);

                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();

                        lvOrderDetail.Items.Remove(lvOrderDetail.SelectedItems[0]);
                        MessageBox.Show("Xóa chi tiết đơn hàng thành công!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lvOrderDetail.SelectedItems.Count > 0)
            {
                string connectionString = "Data Source=MSI\\HAODG;Initial Catalog=Book_Mana;Integrated Security=True";
                string query = "UPDATE OrderDetail SET OrderID = @OrderID, BookID = @BookID, Quantity = @Quantity, Price = @Price WHERE OrderDetailID = @OrderDetailID";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, con);

                    command.Parameters.AddWithValue("@OrderDetailID", txtOrderDetailID.Text);
                    command.Parameters.AddWithValue("@OrderID", txtOrderID.Text);
                    command.Parameters.AddWithValue("@BookID", txtBookID.Text);
                    command.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
                    command.Parameters.AddWithValue("@Price", txtPrice.Text);

                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();

                        var selectedItem = lvOrderDetail.SelectedItems[0];

                        selectedItem.SubItems[0].Text = txtOrderDetailID.Text;
                        selectedItem.SubItems[1].Text = txtOrderID.Text;
                        selectedItem.SubItems[2].Text = txtBookID.Text;
                        selectedItem.SubItems[3].Text = txtQuantity.Text;
                        selectedItem.SubItems[4].Text = txtPrice.Text;

                        MessageBox.Show("Cập nhật chi tiết đơn hàng thành công!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=MSI\\HAODG;Initial Catalog=Book_Mana;Integrated Security=True";
            string query = "SELECT OrderDetailID, OrderID, BookID, Quantity, Price FROM OrderDetail WHERE OrderDetailID = @OrderDetailID";

            lvOrderDetail.Items.Clear();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@OrderDetailID", txtOrderDetailID.Text);

                try
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["OrderDetailID"].ToString());
                        item.SubItems.Add(reader["OrderID"].ToString());
                        item.SubItems.Add(reader["BookID"].ToString());
                        item.SubItems.Add(reader["Quantity"].ToString());
                        item.SubItems.Add(reader["Price"].ToString());

                        lvOrderDetail.Items.Add(item);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
                }
            }
        }

        private void btnDasboard_Click(object sender, EventArgs e)
        {
            frmDasboard frm = new frmDasboard();
            frm.Show();
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

