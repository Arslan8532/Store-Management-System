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
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using Font = System.Drawing.Font;
using System.Drawing.Drawing2D;

namespace Store
{
    public partial class order : Form
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Dell\\OneDrive\\Documents\\store.mdf;Integrated Security=True;Connect Timeout=30";
        private double totalAmount = 0; // Stores the total amount of the order

        public order()
        {
            InitializeComponent();
            InitializeOrderGrid(); // Initialize order grid with columns
            InitializeProductGrid(); // Initialize product grid with columns
            InitializeBillGrid(); // Initialize bill grid with columns
            LoadCategories();
            LoadProducts(); // Load products when the form starts
            LoadBills();
        }

        // 🟢 Initialize Order Grid (Product Order Table)
        private void InitializeOrderGrid()
        {
            dataGridViewproductorder.ColumnCount = 4;
            dataGridViewproductorder.Columns[0].Name = "Product Name";
            dataGridViewproductorder.Columns[1].Name = "Price";
            dataGridViewproductorder.Columns[2].Name = "Quantity";
            dataGridViewproductorder.Columns[3].Name = "Total Price";

            dataGridViewproductorder.AllowUserToAddRows = false;
            dataGridViewproductorder.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewproductorder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewproductorder.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // 🔹 Modern Theme (Dark Header + Light Rows)
            dataGridViewproductorder.EnableHeadersVisualStyles = false;
            dataGridViewproductorder.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80); // Dark Grayish Blue
            dataGridViewproductorder.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewproductorder.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dataGridViewproductorder.DefaultCellStyle.BackColor = Color.White;
            dataGridViewproductorder.DefaultCellStyle.ForeColor = Color.Black;
            dataGridViewproductorder.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            // 🔹 Alternating Row Colors
            dataGridViewproductorder.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(236, 240, 241); // Light Gray
            dataGridViewproductorder.GridColor = Color.LightGray;

            // 🔹 Full Row Color
            dataGridViewproductorder.CellFormatting += (s, e) =>
            {
                if (e.RowIndex % 2 == 0)
                {
                    e.CellStyle.BackColor = Color.FromArgb(236, 240, 241); // Light Gray
                }
                else
                {
                    e.CellStyle.BackColor = Color.White;
                }
            };
        }

        // 🟢 Initialize Product Grid (Product List Table)
        private void InitializeProductGrid()
        {

            productnameandpricedataGridViewprd.AllowUserToAddRows = false;
            productnameandpricedataGridViewprd.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            productnameandpricedataGridViewprd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            productnameandpricedataGridViewprd.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // 🔹 Modern Theme
            productnameandpricedataGridViewprd.EnableHeadersVisualStyles = false;
            productnameandpricedataGridViewprd.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94); // Dark Blue
            productnameandpricedataGridViewprd.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            productnameandpricedataGridViewprd.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            productnameandpricedataGridViewprd.DefaultCellStyle.BackColor = Color.White;
            productnameandpricedataGridViewprd.DefaultCellStyle.ForeColor = Color.Black;
            productnameandpricedataGridViewprd.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            // 🔹 Alternating Row Colors
            productnameandpricedataGridViewprd.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(236, 240, 241); // Light Gray
            productnameandpricedataGridViewprd.GridColor = Color.LightGray;
        }

        // 🟢 Initialize Bill Grid (Billing History)
        private void InitializeBillGrid()
        {


            billdataGridView2.AllowUserToAddRows = false;
            billdataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            billdataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            billdataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // 🔹 Modern Theme
            billdataGridView2.EnableHeadersVisualStyles = false;
            billdataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185); // Blue
            billdataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            billdataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            billdataGridView2.DefaultCellStyle.BackColor = Color.White;
            billdataGridView2.DefaultCellStyle.ForeColor = Color.Black;
            billdataGridView2.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            // 🔹 Alternating Row Colors
            billdataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(236, 240, 241); // Light Gray
            billdataGridView2.GridColor = Color.LightGray;
        }


        // 🔹 Load categories into combo box
        private void LoadCategories()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT CatId, CatName FROM Category";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                categorycomboBox_category.DisplayMember = "CatName";
                categorycomboBox_category.ValueMember = "CatId";
                categorycomboBox_category.DataSource = dt;
            }
        }

        private void label_date_Click(object sender, EventArgs e)
        {
            label_date.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void Productname_TextChanged(object sender, EventArgs e)
        {
            // Future functionality can go here
        }

        private void prprice_TextChanged(object sender, EventArgs e)
        {
            // Future functionality can go here
        }

        private void prodquantitiy_TextChanged(object sender, EventArgs e)
        {
            // Future functionality can go here
        }

        // 🔹 Filter products by selected category
        private void categorycomboBox_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedCategoryId = Convert.ToInt32(categorycomboBox_category.SelectedValue);
            LoadProducts(selectedCategoryId);
        }

        private void productnameandpricedataGridViewprd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = productnameandpricedataGridViewprd.Rows[e.RowIndex];
                Productname.Text = row.Cells["ProdName"].Value.ToString();
                prprice.Text = row.Cells["ProdPrice"].Value.ToString();
            }
        }

        private void dataGridViewproductorder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dataGridViewproductorder.Rows[e.RowIndex];

                if (MessageBox.Show("Do you want to remove this item?", "Remove Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    double rowTotal = Convert.ToDouble(row.Cells["Total Price"].Value);
                    totalAmount -= rowTotal;
                    label_amount.Text = "Total Amount: " + totalAmount;

                    dataGridViewproductorder.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void label_amount_Click(object sender, EventArgs e)
        {
            // Future functionality can go here
        }

        // 🔹 Add product to the order
        private void button_addbill_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Productname.Text) || string.IsNullOrEmpty(prprice.Text) || string.IsNullOrEmpty(prodquantitiy.Text))
            {
                MessageBox.Show("Please select a product and enter quantity!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int quantity;
            if (!int.TryParse(prodquantitiy.Text, out quantity) || quantity <= 0)
            {
                MessageBox.Show("Invalid quantity!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double price = Convert.ToDouble(prprice.Text);
            double total = price * quantity;
            totalAmount += total;

            dataGridViewproductorder.Rows.Add(Productname.Text, price, quantity, total);
            label_amount.Text = "Total Amount:  " + totalAmount;

            Productname.Text = "";
            prprice.Text = "";
            prodquantitiy.Text = "";
        }

        private void billdataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = billdataGridView2.Rows[e.RowIndex];
                int billId = Convert.ToInt32(row.Cells["BillId"].Value);

                // Fetch bill details
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT ProdName, Quantity, UnitPrice, TotalPrice FROM BillDetails INNER JOIN Product ON BillDetails.ProdId = Product.ProdId WHERE BillId = @billId";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@billId", billId);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Display bill details in a new form or a message box
                    StringBuilder billDetails = new StringBuilder();
                    billDetails.AppendLine($"Bill ID: {billId}");
                    billDetails.AppendLine("Product Name\tQuantity\tUnit Price\tTotal Price");

                    foreach (DataRow detailRow in dt.Rows)
                    {
                        billDetails.AppendLine($"{detailRow["ProdName"]}\t{detailRow["Quantity"]}\t{detailRow["UnitPrice"]}\t{detailRow["TotalPrice"]}");
                    }

                    MessageBox.Show(billDetails.ToString(), "Bill Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }



        // 🔹 Save order and print receipt
        // 🔹 Save order and print receipt
        // 🔹 Save order and print receipt
        // 🔹 Save order and print receipt
        // 🔹 Save order and print receipt
        private void button_print_Click(object sender, EventArgs e)
        {
            if (dataGridViewproductorder.Rows.Count == 0)
            {
                MessageBox.Show("No products added to the order!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int billId = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Set command timeout to 120 seconds
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = conn,
                        Transaction = transaction,
                        CommandTimeout = 120
                    };

                    // Insert into Bill table
                    string billQuery = "INSERT INTO Bill (TotalAmt, SellDate) OUTPUT INSERTED.BillId VALUES (@totalAmt, @sellDate)";
                    cmd.CommandText = billQuery;
                    cmd.Parameters.AddWithValue("@totalAmt", totalAmount);
                    cmd.Parameters.AddWithValue("@sellDate", DateTime.Now);
                    billId = (int)cmd.ExecuteScalar();

                    // Insert into BillDetails and update Product quantity
                    StringBuilder insertDetailsQuery = new StringBuilder();
                    StringBuilder updateProductQuery = new StringBuilder();

                    foreach (DataGridViewRow row in dataGridViewproductorder.Rows)
                    {
                        if (row.Cells[0].Value != null) // Ensure row is not empty
                        {
                            int prodId = GetProductIdByName(row.Cells[0].Value.ToString());
                            int quantityOrdered = Convert.ToInt32(row.Cells[2].Value);
                            double price = Convert.ToDouble(row.Cells[1].Value);
                            double total = Convert.ToDouble(row.Cells[3].Value);

                            // Insert into BillDetails
                            insertDetailsQuery.AppendLine($"INSERT INTO BillDetails (BillId, ProdId, Quantity, UnitPrice, TotalPrice) VALUES ({billId}, {prodId}, {quantityOrdered}, {price}, {total});");

                            // Update Product Quantity
                            updateProductQuery.AppendLine($"UPDATE Product SET ProdQuantity = ProdQuantity - {quantityOrdered} WHERE ProdId = {prodId};");
                        }
                    }

                    // Execute batch insert and update commands
                    cmd.CommandText = insertDetailsQuery.ToString();
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = updateProductQuery.ToString();
                    cmd.ExecuteNonQuery();

                    transaction.Commit();
                    MessageBox.Show("Bill Saved Successfully and Stock Updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error: " + ex.Message, "Transaction Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Generate PDF Invoice
            if (billId > 0)
            {
                GenerateInvoicePDF(billId);
            }

            // Refresh grid views
            LoadProducts();
            LoadBills();
            dataGridViewproductorder.Rows.Clear();
            totalAmount = 0;
            label_amount.Text = "Total Amount: 0.00";
        }


        // 🔹 Function to Generate PDF Invoice
        private void GenerateInvoicePDF(int billId)
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"Invoice_{billId}.pdf");
            Document doc = new Document(PageSize.A4);

            try
            {
                PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                doc.Open();

                // 🔹 Store Name
                iTextSharp.text.Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20);
                Paragraph title = new Paragraph("STORE MANAGEMENT SYSTEM", titleFont)
                {
                    Alignment = Element.ALIGN_CENTER
                };
                doc.Add(title);
                doc.Add(new Paragraph("\n"));

                // 🔹 Invoice Details
                iTextSharp.text.Font normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                doc.Add(new Paragraph($"Invoice No: {billId}", normalFont));
                doc.Add(new Paragraph($"Date: {DateTime.Now.ToString("dd/MM/yyyy")}", normalFont));
                doc.Add(new Paragraph($"Due Date: {DateTime.Now.AddDays(7).ToShortDateString()}", normalFont));
                doc.Add(new Paragraph("\n"));

                // 🔹 Table Header
                PdfPTable table = new PdfPTable(4)
                {
                    WidthPercentage = 100
                };
                table.SetWidths(new float[] { 40f, 20f, 20f, 20f });

                table.AddCell(new PdfPCell(new Phrase("Description", FontFactory.GetFont(FontFactory.HELVETICA_BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });
                table.AddCell(new PdfPCell(new Phrase("Unit Price", FontFactory.GetFont(FontFactory.HELVETICA_BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });
                table.AddCell(new PdfPCell(new Phrase("Qty", FontFactory.GetFont(FontFactory.HELVETICA_BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });
                table.AddCell(new PdfPCell(new Phrase("Total", FontFactory.GetFont(FontFactory.HELVETICA_BOLD))) { HorizontalAlignment = Element.ALIGN_CENTER });

                // 🔹 Add Products from DataGridView
                foreach (DataGridViewRow row in dataGridViewproductorder.Rows)
                {
                    if (row.Cells[0].Value != null) // Ensure row is not empty
                    {
                        table.AddCell(row.Cells[0].Value.ToString()); // Product Name
                        table.AddCell(Convert.ToDouble(row.Cells[1].Value).ToString("F2")); // Unit Price
                        table.AddCell(Convert.ToInt32(row.Cells[2].Value).ToString()); // Quantity
                        table.AddCell(Convert.ToDouble(row.Cells[3].Value).ToString("F2")); // Total Price
                    }
                }

                doc.Add(table);
                doc.Add(new Paragraph("\n"));

                // 🔹 Summary
                doc.Add(new Paragraph($"Subtotal: {totalAmount:F2}", normalFont));
                doc.Add(new Paragraph($"Total: {totalAmount:F2}", titleFont));

                MessageBox.Show($"Invoice generated successfully: {filePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IOException ioEx)
            {
                MessageBox.Show("Error accessing the file. Ensure the file is not open and try again.\n" + ioEx.Message, "File Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while generating the invoice.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                doc.Close();
            }
        }




        // 🔹 Load products into DataGridView
        private void LoadProducts(int categoryId = 0)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT ProdId, ProdName, ProdPrice, ProdQuantity FROM Product";

                if (categoryId > 0)
                    query += " WHERE ProdCat = @categoryId";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                if (categoryId > 0)
                    adapter.SelectCommand.Parameters.AddWithValue("@categoryId", categoryId);

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                productnameandpricedataGridViewprd.DataSource = dt;
            }
        }

        // 🔹 Load bill history
        private void LoadBills()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT BillId, TotalAmt, SellDate FROM Bill";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                billdataGridView2.DataSource = dt;
            }
        }

        private int GetProductIdByName(string productName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT ProdId FROM Product WHERE ProdName = @name";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", productName);
                return (int)cmd.ExecuteScalar();
            }
        }

        private void order_Load(object sender, EventArgs e)
        {
            // Future functionality can go here
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
                e.Graphics.DrawRectangle(borderPen, new System.Drawing.Rectangle(0, 0, panel1.Width - 1, panel1.Height - 1));
            }
        }

     

        private void label6_Click(object sender, EventArgs e)
        {
            // Future functionality can go here
        }

       
        }
    }

