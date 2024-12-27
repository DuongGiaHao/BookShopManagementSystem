namespace BookShopManagementSystem
{
    partial class frmOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnDasboard = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnOder = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnOderDetail = new System.Windows.Forms.Button();
            this.btnEmployee = new System.Windows.Forms.Button();
            this.tnCustomer = new System.Windows.Forms.Button();
            this.btnBook = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.txtEmployeeID = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lvOrder = new System.Windows.Forms.ListView();
            this.oderid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.customerid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.employeeid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.oderdate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Maroon;
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.btnDasboard);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnOder);
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.btnOderDetail);
            this.panel1.Controls.Add(this.btnEmployee);
            this.panel1.Controls.Add(this.tnCustomer);
            this.panel1.Controls.Add(this.btnBook);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(184, 670);
            this.panel1.TabIndex = 2;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::BookShopManagementSystem.Properties.Resources.Screenshot_2024_12_27_152606;
            this.pictureBox3.Location = new System.Drawing.Point(22, 13);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(136, 90);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // btnDasboard
            // 
            this.btnDasboard.BackColor = System.Drawing.Color.Maroon;
            this.btnDasboard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDasboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDasboard.ForeColor = System.Drawing.Color.White;
            this.btnDasboard.Location = new System.Drawing.Point(3, 130);
            this.btnDasboard.Name = "btnDasboard";
            this.btnDasboard.Size = new System.Drawing.Size(181, 29);
            this.btnDasboard.TabIndex = 6;
            this.btnDasboard.Text = "Dasboard";
            this.btnDasboard.UseVisualStyleBackColor = false;
            this.btnDasboard.Click += new System.EventHandler(this.btnDasboard_Click);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(181, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(881, 100);
            this.panel2.TabIndex = 1;
            // 
            // btnOder
            // 
            this.btnOder.BackColor = System.Drawing.Color.Maroon;
            this.btnOder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnOder.ForeColor = System.Drawing.Color.White;
            this.btnOder.Location = new System.Drawing.Point(0, 354);
            this.btnOder.Name = "btnOder";
            this.btnOder.Size = new System.Drawing.Size(181, 29);
            this.btnOder.TabIndex = 5;
            this.btnOder.Text = "Order";
            this.btnOder.UseVisualStyleBackColor = false;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Maroon;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(0, 503);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(181, 29);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnOderDetail
            // 
            this.btnOderDetail.BackColor = System.Drawing.Color.Maroon;
            this.btnOderDetail.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOderDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnOderDetail.ForeColor = System.Drawing.Color.White;
            this.btnOderDetail.Location = new System.Drawing.Point(3, 416);
            this.btnOderDetail.Name = "btnOderDetail";
            this.btnOderDetail.Size = new System.Drawing.Size(181, 29);
            this.btnOderDetail.TabIndex = 3;
            this.btnOderDetail.Text = "OrderDetail";
            this.btnOderDetail.UseVisualStyleBackColor = false;
            this.btnOderDetail.Click += new System.EventHandler(this.btnOrderDetail_Click);
            // 
            // btnEmployee
            // 
            this.btnEmployee.BackColor = System.Drawing.Color.Maroon;
            this.btnEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnEmployee.ForeColor = System.Drawing.Color.White;
            this.btnEmployee.Location = new System.Drawing.Point(0, 299);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(181, 29);
            this.btnEmployee.TabIndex = 2;
            this.btnEmployee.Text = "Employee";
            this.btnEmployee.UseVisualStyleBackColor = false;
            this.btnEmployee.Click += new System.EventHandler(this.btnEmployee_Click);
            // 
            // tnCustomer
            // 
            this.tnCustomer.BackColor = System.Drawing.Color.Maroon;
            this.tnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.tnCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tnCustomer.ForeColor = System.Drawing.Color.White;
            this.tnCustomer.Location = new System.Drawing.Point(0, 242);
            this.tnCustomer.Name = "tnCustomer";
            this.tnCustomer.Size = new System.Drawing.Size(181, 29);
            this.tnCustomer.TabIndex = 1;
            this.tnCustomer.Text = "Customer";
            this.tnCustomer.UseVisualStyleBackColor = false;
            this.tnCustomer.Click += new System.EventHandler(this.tnCustomer_Click);
            // 
            // btnBook
            // 
            this.btnBook.BackColor = System.Drawing.Color.Maroon;
            this.btnBook.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnBook.ForeColor = System.Drawing.Color.White;
            this.btnBook.Location = new System.Drawing.Point(3, 188);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(181, 29);
            this.btnBook.TabIndex = 0;
            this.btnBook.Text = "Books";
            this.btnBook.UseVisualStyleBackColor = false;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnClose);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(184, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(875, 100);
            this.panel3.TabIndex = 5;
            // 
            // btnClose
            // 
            this.btnClose.Image = global::BookShopManagementSystem.Properties.Resources.error_icon;
            this.btnClose.Location = new System.Drawing.Point(814, -1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(60, 49);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnClose.TabIndex = 3;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(275, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(327, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Book Shop Management System";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.dtpOrderDate);
            this.panel4.Controls.Add(this.txtEmployeeID);
            this.panel4.Controls.Add(this.txtSearch);
            this.panel4.Controls.Add(this.btnSearch);
            this.panel4.Controls.Add(this.lvOrder);
            this.panel4.Controls.Add(this.btnAdd);
            this.panel4.Controls.Add(this.btnDelete);
            this.panel4.Controls.Add(this.btnUpdate);
            this.panel4.Controls.Add(this.txtCustomerID);
            this.panel4.Controls.Add(this.txtOrderID);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(190, 130);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(869, 537);
            this.panel4.TabIndex = 6;
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.Location = new System.Drawing.Point(628, 64);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Size = new System.Drawing.Size(228, 22);
            this.dtpOrderDate.TabIndex = 20;
            // 
            // txtEmployeeID
            // 
            this.txtEmployeeID.Location = new System.Drawing.Point(404, 62);
            this.txtEmployeeID.Name = "txtEmployeeID";
            this.txtEmployeeID.Size = new System.Drawing.Size(161, 22);
            this.txtEmployeeID.TabIndex = 19;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(273, 192);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(391, 22);
            this.txtSearch.TabIndex = 18;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Maroon;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(678, 188);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 29);
            this.btnSearch.TabIndex = 15;
            this.btnSearch.Text = "Sereach";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lvOrder
            // 
            this.lvOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.oderid,
            this.customerid,
            this.employeeid,
            this.oderdate});
            this.lvOrder.HideSelection = false;
            this.lvOrder.Location = new System.Drawing.Point(3, 223);
            this.lvOrder.Name = "lvOrder";
            this.lvOrder.Size = new System.Drawing.Size(861, 309);
            this.lvOrder.TabIndex = 14;
            this.lvOrder.UseCompatibleStateImageBehavior = false;
            this.lvOrder.View = System.Windows.Forms.View.Details;
            this.lvOrder.SelectedIndexChanged += new System.EventHandler(this.lvOrder_SelectedIndexChanged);
            // 
            // oderid
            // 
            this.oderid.Text = "OderID";
            this.oderid.Width = 150;
            // 
            // customerid
            // 
            this.customerid.Text = "CustomerID";
            this.customerid.Width = 150;
            // 
            // employeeid
            // 
            this.employeeid.Text = "EmployeeID";
            this.employeeid.Width = 150;
            // 
            // oderdate
            // 
            this.oderdate.Text = "OderDate";
            this.oderdate.Width = 200;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Maroon;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(247, 111);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 29);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "Add ";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Maroon;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(343, 111);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 29);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Maroon;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(451, 111);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 29);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Location = new System.Drawing.Point(197, 62);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(146, 22);
            this.txtCustomerID.TabIndex = 9;
            // 
            // txtOrderID
            // 
            this.txtOrderID.Location = new System.Drawing.Point(16, 62);
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.Size = new System.Drawing.Size(126, 22);
            this.txtOrderID.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.Location = new System.Drawing.Point(624, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "OderDate";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(12, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "OrderID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(400, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "EmployeeID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(193, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "CustomerID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(203, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Oder Information";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.Location = new System.Drawing.Point(182, 194);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 20);
            this.label8.TabIndex = 24;
            this.label8.Text = "OrderID";
            // 
            // frmOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1059, 670);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmOder";
            this.Load += new System.EventHandler(this.frmOder_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDasboard;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnOder;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnOderDetail;
        private System.Windows.Forms.Button btnEmployee;
        private System.Windows.Forms.Button tnCustomer;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListView lvOrder;
        private System.Windows.Forms.ColumnHeader oderid;
        private System.Windows.Forms.ColumnHeader customerid;
        private System.Windows.Forms.ColumnHeader employeeid;
        private System.Windows.Forms.ColumnHeader oderdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.TextBox txtOrderID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmployeeID;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label8;
    }
}