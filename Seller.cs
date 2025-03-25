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
using System.Drawing.Drawing2D;

namespace Store
{
    public partial class Seller : Form
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Dell\\OneDrive\\Documents\\store.mdf;Integrated Security=True;Connect Timeout=30";

        public Seller()
        {
            InitializeComponent();
            CustomizeDataGridView(); // Customize DataGridView appearance
            LoadSellers(); // Load data into DataGridView when form opens
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                sellerid.Text = row.Cells["SellerId"].Value.ToString();
                Sellername.Text = row.Cells["SellerName"].Value.ToString();
                SellerAge.Text = row.Cells["SellerAge"].Value.ToString();
                SellerPhone.Text = row.Cells["SellerPhone"].Value.ToString();
                SellerPassword.Text = row.Cells["SellerPass"].Value.ToString();
            }
        }

        private void CustomizeDataGridView()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Bold); // Increase header font size
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Regular); // Increase cell font size
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Size = new Size(872, 267);
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Seller (SellerName, SellerAge, SellerPhone, SellerPass) VALUES (@name, @age, @phone, @pass)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", Sellername.Text);
                        cmd.Parameters.AddWithValue("@age", Convert.ToInt32(SellerAge.Text));
                        cmd.Parameters.AddWithValue("@phone", SellerPhone.Text);
                        cmd.Parameters.AddWithValue("@pass", SellerPassword.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Seller Added Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSellers();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(sellerid.Text))
            {
                MessageBox.Show("Please select a seller to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Seller SET SellerName=@name, SellerAge=@age, SellerPhone=@phone, SellerPass=@pass WHERE SellerId=@id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", Convert.ToInt32(sellerid.Text));
                        cmd.Parameters.AddWithValue("@name", Sellername.Text);
                        cmd.Parameters.AddWithValue("@age", Convert.ToInt32(SellerAge.Text));
                        cmd.Parameters.AddWithValue("@phone", SellerPhone.Text);
                        cmd.Parameters.AddWithValue("@pass", SellerPassword.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Seller Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSellers();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(sellerid.Text))
            {
                MessageBox.Show("Please select a seller to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM Seller WHERE SellerId=@id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", Convert.ToInt32(sellerid.Text));
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Seller Deleted Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSellers();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSellers()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Seller";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            sellerid.Text = "";
            Sellername.Text = "";
            SellerAge.Text = "";
            SellerPhone.Text = "";
            SellerPassword.Text = "";
        }

        private void sellerid_TextChanged(object sender, EventArgs e)
        {

        }

        private void Sellername_TextChanged(object sender, EventArgs e)
        {

        }

        private void SellerAge_TextChanged(object sender, EventArgs e)
        {

        }

        private void SellerPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void SellerPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_seller_Click(object sender, EventArgs e)
        {
            // Change button color to indicate it is selected
            button_seller.BackColor = Color.LightBlue;
            button_product.BackColor = SystemColors.Control;
            button_selling.BackColor = SystemColors.Control;

            // Load seller-related data or perform seller-related actions
            LoadSellers();
            Category categoryForm = new Category();

            // Subscribe to the event for category updates
            //categoryForm.CategoryAdded += LoadCategories;

            // Show the Category form
            categoryForm.Show();
        }

        private void button_product_Click(object sender, EventArgs e)
        {
            // Change button color to indicate it is selected
            button_seller.BackColor = SystemColors.Control;
            button_product.BackColor = Color.LightBlue;
            button_selling.BackColor = SystemColors.Control;

            // Open the Product form
            Product productForm = new Product();
            productForm.Show();
        }

        private void button_selling_Click(object sender, EventArgs e)
        {
            // Change button color to indicate it is selected
            button_seller.BackColor = SystemColors.Control;
            button_product.BackColor = SystemColors.Control;
            button_selling.BackColor = Color.LightBlue;

            // Open the Order form
            order orderForm = new order();
            orderForm.ShowDialog();
        }



        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // Enable AntiAliasing for smooth graphics
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Define colors for gradient (similar to panel1 but vertical)
            Color startColor = Color.Teal;        // Top side color
            Color endColor = Color.LightSalmon;    // Bottom side color

            // Create Gradient Brush with Vertical Direction
            using (LinearGradientBrush brush = new LinearGradientBrush(panel2.ClientRectangle, startColor, endColor, LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, panel2.ClientRectangle);
            }

            // Optional: Soft glow border for aesthetic effect
            using (Pen borderPen = new Pen(ControlPaint.Dark(startColor, 0.3f), 3))
            {
                e.Graphics.DrawRectangle(borderPen, new Rectangle(0, 0, panel2.Width - 1, panel2.Height - 1));
            }
        }

        private void label_logout_Click(object sender, EventArgs e)
        {
            // Confirm if the user wants to logout
            var result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Close the current form and show the login form
                this.Close();
                Form1 loginForm = new Form1();
                loginForm.Show();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Enable AntiAliasing for smooth graphics
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Define colors for gradient
            Color startColor = Color.Teal;       // Top side color
            Color endColor = Color.DarkSeaGreen;     // Bottom side color

            // Create Gradient Brush with Vertical Direction
            using (LinearGradientBrush brush = new LinearGradientBrush(panel1.ClientRectangle, startColor, endColor, LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, panel1.ClientRectangle);
            }

            // Optional: Soft glow border for aesthetic effect
            using (Pen borderPen = new Pen(ControlPaint.Dark(startColor, 0.3f), 3))
            {
                e.Graphics.DrawRectangle(borderPen, new Rectangle(0, 0, panel1.Width - 1, panel1.Height - 1));
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}

