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
    public partial class frmBook : Form
    {
        public frmBook()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmLOGIN frmLOGIN = new frmLOGIN();
            frmLOGIN.Show();
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

            string query = "INSERT INTO Book (BookID, BookTitle, Category, Quantity, Price) VALUES (@BookID, @BookTitle, @Category, @Quantity, @Price)";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, con);

                command.Parameters.AddWithValue("@BookID", txtBookID.Text);
                command.Parameters.AddWithValue("@BookTitle", txtBookTitle.Text);
                command.Parameters.AddWithValue("@Category" ,cmbCategory.SelectedItem.ToString());
                command.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
                command.Parameters.AddWithValue("@Price", txtPrice.Text);

                try
                {
                    con.Open();
                    command.ExecuteNonQuery();

                    // Thêm vào ListView
                    ListViewItem newItem = new ListViewItem(txtBookID.Text);
                    newItem.SubItems.Add(txtBookTitle.Text);
                    newItem.SubItems.Add(cmbCategory.SelectedItem.ToString());
                    newItem.SubItems.Add(txtQuantity.Text);
                    newItem.SubItems.Add(txtPrice.Text);
                    lvBook.Items.Add(newItem);

                    MessageBox.Show("Thêm sách thành công!", "Thông báo");

                    txtBookID.Clear();
                    txtBookTitle.Clear();
                    cmbCategory.SelectedIndex = -1;
                    txtQuantity.Clear();
                    txtPrice.Clear();
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm sách: " + ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvBook.SelectedItems.Count > 0)
            {
                var selectedItem = lvBook.SelectedItems[0];
                string bookID = selectedItem.SubItems[0].Text;

                string connectionString = "Data Source=MSI\\HAODG;Initial Catalog=Book_Mana;Integrated Security=True";
                string query = "DELETE FROM Book WHERE BookID = @BookID";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@BookID", bookID);

                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();
                        lvBook.Items.Remove(selectedItem);
                        MessageBox.Show("Xóa sách thành công!", "Thông báo");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa sách: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sách cần xóa!");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lvBook.SelectedItems.Count > 0)
            {
                var selectedItem = lvBook.SelectedItems[0];

                selectedItem.SubItems[0].Text = txtBookID.Text;
                selectedItem.SubItems[1].Text = txtBookTitle.Text;
                selectedItem.SubItems[2].Text = cmbCategory.SelectedItem.ToString();
                selectedItem.SubItems[3].Text = txtQuantity.Text;
                selectedItem.SubItems[4].Text = txtPrice.Text;

                string connectionString = "Data Source=MSI\\HAODG;Initial Catalog=Book_Mana;Integrated Security=True";
                string query = "UPDATE Book SET BookTitle = @BookTitle, Category = @Category, Quantity = @Quantity, Price = @Price WHERE BookID = @BookID";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, con);

                    command.Parameters.AddWithValue("@BookID", txtBookID.Text);
                    command.Parameters.AddWithValue("@BookTitle", txtBookTitle.Text);
                    command.Parameters.AddWithValue("@Category", cmbCategory.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
                    command.Parameters.AddWithValue("@Price", txtPrice.Text);

                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Cập nhật sách thành công!", "Thông báo");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật sách: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sách để cập nhật!");
            }
        }

     

        private void frmBook_Load(object sender, EventArgs e)
        {
            // Câu lệnh SQL để lấy dữ liệu
            string query = "SELECT BookID, BookTitle, Category, Quantity, Price FROM Book";

            // Xóa các mục cũ trong ListView
            lvBook.Items.Clear();

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
                        ListViewItem item = new ListViewItem(reader["BookID"].ToString());
                        item.SubItems.Add(reader["BookTitle"].ToString());
                        item.SubItems.Add(reader["Category"].ToString());
                        item.SubItems.Add(reader["Quantity"].ToString());
                        item.SubItems.Add(reader["Price"].ToString());


                        // Thêm item vào ListView
                        lvBook.Items.Add(item);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void lvBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvBook.SelectedItems.Count > 0)
            {
                // Lấy mục được chọn
                var selectedItem = lvBook.SelectedItems[0];             
                // Hiển thị dữ liệu lên các TextBox
                txtBookID.Text = selectedItem.SubItems[0].Text;
                txtBookTitle.Text = selectedItem.SubItems[1].Text;
                cmbCategory.SelectedItem = selectedItem.SubItems[2].Text;
                txtQuantity.Text = selectedItem.SubItems[3].Text;
                txtPrice.Text = selectedItem.SubItems[4].Text;
            }
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            string searchKeyword = txtSearch.Text.Trim();
            string connectionString = "Data Source=MSI\\HAODG;Initial Catalog=Book_Mana;Integrated Security=True";

            string query = "SELECT BookID, BookTitle, Category, Quantity, Price FROM Book WHERE BookTitle LIKE @SearchKeyword";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@SearchKeyword", "%" + searchKeyword + "%");

                try
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    lvBook.Items.Clear();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["BookID"].ToString());
                        item.SubItems.Add(reader["BookTitle"].ToString());
                        item.SubItems.Add(reader["Category"].ToString());
                        item.SubItems.Add(reader["Quantity"].ToString());
                        item.SubItems.Add(reader["Price"].ToString());
                        lvBook.Items.Add(item);
                    }

                    reader.Close();
                    if (lvBook.Items.Count == 0)
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

        private void btnDasbord_Click(object sender, EventArgs e)
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
