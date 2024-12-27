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
    public partial class frmDasboard : Form
    {
        public frmDasboard()
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
            frmBook customer = new frmBook();
            customer.Show();
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
            frmOrder order = new frmOrder();
            order.Show();
            this.Hide();
        }

        private void btnOrderDetail_Click(object sender, EventArgs e)
        {
            frmOrderDetail orderDetail = new frmOrderDetail();
            orderDetail.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmLOGIN frmLOGIN = new frmLOGIN();
            frmLOGIN.Show();
            this.Hide();
        }

        private void frmDasboard_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=MSI\\HAODG;Initial Catalog=Book_Mana;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // Lấy tổng số sản phẩm
                    string queryProducts = "SELECT COUNT(*) FROM Book";
                    SqlCommand cmdProducts = new SqlCommand(queryProducts, con);
                    lblTotalProducts.Text = cmdProducts.ExecuteScalar().ToString();

                    // Lấy tổng số khách hàng
                    string queryCustomers = "SELECT COUNT(*) FROM Customer";
                    SqlCommand cmdCustomers = new SqlCommand(queryCustomers, con);
                    lblTotalCustomers.Text = cmdCustomers.ExecuteScalar().ToString();

                    // Lấy tổng số nhân viên
                    string queryEmployees = "SELECT COUNT(*) FROM Employee";
                    SqlCommand cmdEmployees = new SqlCommand(queryEmployees, con);
                    lblTotalEmployees.Text = cmdEmployees.ExecuteScalar().ToString();

                    // Lấy tổng doanh thu
                    string queryRevenue = "SELECT SUM(Quantity * Price) FROM OrderDetail";
                    SqlCommand cmdRevenue = new SqlCommand(queryRevenue, con);
                    var revenue = cmdRevenue.ExecuteScalar();
                    lblTotalRevenue.Text = revenue != DBNull.Value ? Convert.ToDecimal(revenue).ToString("C") : "0 VNĐ";

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

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
