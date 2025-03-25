using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using Org.BouncyCastle.Tls;

namespace Store
{
    public partial class Product : Form
    {
        // Connection string for connecting to your database
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Dell\\OneDrive\\Documents\\store.mdf;Integrated Security=True;Connect Timeout=30";

        public Product()
        {
            InitializeComponent();
            CustomizeDataGridViewPro();
            LoadCategories(); // Load categories into comboBox
            LoadProducts();  // Load products into DataGridView
        }
        private void CustomizeDataGridViewPro()
        {
            // 🔷 GridView Background Color
            dataGridViewpro.BackgroundColor = Color.White;
            dataGridViewpro.DefaultCellStyle.BackColor = Color.White;
            dataGridViewpro.DefaultCellStyle.ForeColor = Color.Black;
            dataGridViewpro.DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Regular);

            // 🔹 Alternating Row Colors (Improved Contrast)
            dataGridViewpro.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;  // Light Grayish White
            dataGridViewpro.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSteelBlue;  // Soft Blue Tone

            // 🔷 Header Styling (Dark Blue Background & White Text)
            dataGridViewpro.EnableHeadersVisualStyles = false;
            dataGridViewpro.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dataGridViewpro.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewpro.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold); // ⬅ **Increased Size & Bold**
            dataGridViewpro.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // 🔹 Adjust Row Height & Reduce Spacing
            dataGridViewpro.RowTemplate.Height = 25; // ⬅ Reduced row height for tighter spacing

            // 🔷 Column Borders for Better Visualization
            dataGridViewpro.GridColor = Color.Gray; // ⬅ Softer Grid Lines for readability
            dataGridViewpro.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical; // ⬅ Vertical lines only for cleaner look

            // 🔷 Auto-size columns to fit properly within the grid
            dataGridViewpro.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewpro.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewpro.MultiSelect = false; // Disable multiple row selection
        }

        // Event handlers for TextBox changes (not used here, but required to prevent errors)


        private void proid_TextChanged(object sender, EventArgs e) { }

        private void proname_TextChanged(object sender, EventArgs e) { }

        private void proprice_TextChanged(object sender, EventArgs e) { }

        private void proquanity_TextChanged(object sender, EventArgs e) { }

        // Event handler for category comboBox (not needed for this version)
        private void comboBox_category_SelectedIndexChanged(object sender, EventArgs e) { }

        // Add product to database
        private void button_add_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Product (ProdName, ProdPrice, ProdQuantity, ProdCat) VALUES (@name, @price, @quantity, @catId)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", proname.Text);
                    cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(proprice.Text));
                    cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(proquanity.Text));
                    cmd.Parameters.AddWithValue("@catId", comboBox_category.SelectedValue);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Product Added Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadProducts();
            ClearFields();
        }
       

        // Call this function inside Form_Load



        // Update an existing product in the database
        private void button_update_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(proid.Text))
            {
                MessageBox.Show("Please select a product to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Product SET ProdName=@name, ProdPrice=@price, ProdQuantity=@quantity, ProdCat=@catId WHERE ProdId=@id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(proid.Text));
                    cmd.Parameters.AddWithValue("@name", proname.Text);
                    cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(proprice.Text));
                    cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(proquanity.Text));
                    cmd.Parameters.AddWithValue("@catId", comboBox_category.SelectedValue);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Product Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadProducts();
            ClearFields();
        }

        // Delete a product from the database
        private void button_delete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(proid.Text))
            {
                MessageBox.Show("Please select a product to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Product WHERE ProdId=@id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(proid.Text));
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Product Deleted Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadProducts();
            ClearFields();
        }

        // Search functionality for product (not implemented here)
        private void comboBox_search_SelectedIndexChanged(object sender, EventArgs e) { }

        // Refresh the product list in the DataGridView
        private void button_Refresh_Click(object sender, EventArgs e)
        {
            LoadProducts();
        }

        // Load product data into DataGridView when clicked
        private void dataGridViewpro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Ensure a valid row is clicked
                {
                    DataGridViewRow row = dataGridViewpro.Rows[e.RowIndex];

                    // 🆔 Get Product ID & Name
                    proid.Text = row.Cells["ProdId"].Value?.ToString() ?? "";
                    proname.Text = row.Cells["ProdName"].Value?.ToString() ?? "";

                    // 💲 Get & Validate Price (FLOAT → double)
                    string priceText = row.Cells["ProdPrice"].Value?.ToString();
                    proprice.Text = double.TryParse(priceText, out double price) ? price.ToString("0.00") : "Invalid Price";

                    // 🔢 Get & Validate Quantity (INT)
                    string quantityText = row.Cells["ProdQuantity"].Value?.ToString();
                    proquanity.Text = int.TryParse(quantityText, out int quantity) ? quantity.ToString() : "Invalid Qty";

                    // 🏷️ Handle Category Selection
                    if (row.Cells["ProdCat"].Value != null)
                    {
                        comboBox_category.SelectedValue = row.Cells["ProdCat"].Value;
                    }
                    else
                    {
                        comboBox_category.SelectedIndex = -1; // No category selected
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Load Categories into the comboBox for product selection
        private void LoadCategories()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT CatId, CatName FROM Category";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                comboBox_category.DisplayMember = "CatName";
                comboBox_category.ValueMember = "CatId";
                comboBox_category.DataSource = dt;
            }
        }

        // Load Products into the DataGridView
        private void LoadProducts()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT p.ProdId, p.ProdName, p.ProdPrice, p.ProdQuantity, c.CatName AS ProdCat FROM Product p JOIN Category c ON p.ProdCat = c.CatId";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewpro.DataSource = dt;
            }
        }

        // Clear input fields after performing operations
        private void ClearFields()
        {
            proid.Text = "";
            proname.Text = "";
            proprice.Text = "";
            proquanity.Text = "";
            comboBox_category.SelectedIndex = -1;
        }

        private void button_category_Click(object sender, EventArgs e)
        {
            Category categoryForm = new Category();

            // Subscribe to the event for category updates
            //categoryForm.CategoryAdded += LoadCategories;

            // Show the Category form
            categoryForm.Show();
        }

        private void button_seller_Click(object sender, EventArgs e)
        {
            Seller sellerForm = new Seller();

            // Subscribe to the event if needed (e.g., CategoryUpdated)


            // Show the Seller form
            sellerForm.Show();
        }

        private void button_selling_Click(object sender, EventArgs e)
        {
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

        private void button_product_Click(object sender, EventArgs e)
        {
            // Change button color to indicate it is selected
            button_seller.BackColor = SystemColors.Control;
            button_product.BackColor = Color.LightBlue;
            button_seller.BackColor = SystemColors.Control;

            // Open the Product form
            Product productForm = new Product();
            productForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Change button color to indicate it is selected
            button_seller.BackColor = SystemColors.Control;
            button_product.BackColor = SystemColors.Control;
            button_seller.BackColor = Color.LightBlue;

            // Open the Order form
            order orderForm = new order();
            orderForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Category categoryForm = new Category();

            // Subscribe to the event for category updates
            //categoryForm.CategoryAdded += LoadCategories;

            // Show the Category form
            categoryForm.Show();
        }

        private void label7_Click(object sender, EventArgs e)
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

        private void Product_Load(object sender, EventArgs e)
        { 

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

