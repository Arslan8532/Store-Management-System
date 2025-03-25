namespace Store
{
    partial class order
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
            this.label_exit = new System.Windows.Forms.Label();
            this.productnameandpricedataGridViewprd = new System.Windows.Forms.DataGridView();
            this.billdataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewproductorder = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Productname = new System.Windows.Forms.TextBox();
            this.prprice = new System.Windows.Forms.TextBox();
            this.prodquantitiy = new System.Windows.Forms.TextBox();
            this.categorycomboBox_category = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button_print = new System.Windows.Forms.Button();
            this.button_addbill = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label_amount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_seller = new System.Windows.Forms.Label();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProdQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProdId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProdPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label_date = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.productnameandpricedataGridViewprd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.billdataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewproductorder)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_exit
            // 
            this.label_exit.AutoSize = true;
            this.label_exit.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_exit.ForeColor = System.Drawing.Color.Goldenrod;
            this.label_exit.Location = new System.Drawing.Point(1022, -69);
            this.label_exit.Name = "label_exit";
            this.label_exit.Size = new System.Drawing.Size(30, 32);
            this.label_exit.TabIndex = 37;
            this.label_exit.Text = "X";
            // 
            // productnameandpricedataGridViewprd
            // 
            this.productnameandpricedataGridViewprd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productnameandpricedataGridViewprd.Location = new System.Drawing.Point(15, 344);
            this.productnameandpricedataGridViewprd.Name = "productnameandpricedataGridViewprd";
            this.productnameandpricedataGridViewprd.Size = new System.Drawing.Size(476, 213);
            this.productnameandpricedataGridViewprd.TabIndex = 29;
            this.productnameandpricedataGridViewprd.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.productnameandpricedataGridViewprd_CellContentClick);
            // 
            // billdataGridView2
            // 
            this.billdataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.billdataGridView2.Location = new System.Drawing.Point(519, 344);
            this.billdataGridView2.Name = "billdataGridView2";
            this.billdataGridView2.Size = new System.Drawing.Size(607, 213);
            this.billdataGridView2.TabIndex = 28;
            this.billdataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.billdataGridView2_CellContentClick);
            // 
            // dataGridViewproductorder
            // 
            this.dataGridViewproductorder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewproductorder.Location = new System.Drawing.Point(519, 50);
            this.dataGridViewproductorder.Name = "dataGridViewproductorder";
            this.dataGridViewproductorder.Size = new System.Drawing.Size(607, 200);
            this.dataGridViewproductorder.TabIndex = 27;
            this.dataGridViewproductorder.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewproductorder_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Goldenrod;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.productnameandpricedataGridViewprd);
            this.panel1.Controls.Add(this.billdataGridView2);
            this.panel1.Controls.Add(this.dataGridViewproductorder);
            this.panel1.Controls.Add(this.Productname);
            this.panel1.Controls.Add(this.prprice);
            this.panel1.Controls.Add(this.prodquantitiy);
            this.panel1.Controls.Add(this.categorycomboBox_category);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.button_print);
            this.panel1.Controls.Add(this.button_addbill);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label_amount);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label_seller);
            this.panel1.Controls.Add(this.label_date);
            this.panel1.Location = new System.Drawing.Point(0, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1175, 684);
            this.panel1.TabIndex = 36;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Font = new System.Drawing.Font("Sitka Display", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(520, 290);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 47);
            this.label1.TabIndex = 30;
            this.label1.Text = "Bill Detail";
            // 
            // Productname
            // 
            this.Productname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Productname.Location = new System.Drawing.Point(115, 69);
            this.Productname.Name = "Productname";
            this.Productname.Size = new System.Drawing.Size(179, 26);
            this.Productname.TabIndex = 25;
            this.Productname.TextChanged += new System.EventHandler(this.Productname_TextChanged);
            // 
            // prprice
            // 
            this.prprice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prprice.Location = new System.Drawing.Point(115, 111);
            this.prprice.Name = "prprice";
            this.prprice.Size = new System.Drawing.Size(179, 26);
            this.prprice.TabIndex = 24;
            this.prprice.TextChanged += new System.EventHandler(this.prprice_TextChanged);
            // 
            // prodquantitiy
            // 
            this.prodquantitiy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prodquantitiy.Location = new System.Drawing.Point(115, 152);
            this.prodquantitiy.Name = "prodquantitiy";
            this.prodquantitiy.Size = new System.Drawing.Size(179, 26);
            this.prodquantitiy.TabIndex = 23;
            this.prodquantitiy.TextChanged += new System.EventHandler(this.prodquantitiy_TextChanged);
            // 
            // categorycomboBox_category
            // 
            this.categorycomboBox_category.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.categorycomboBox_category.Cursor = System.Windows.Forms.Cursors.Hand;
            this.categorycomboBox_category.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.categorycomboBox_category.Font = new System.Drawing.Font("Sitka Display", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categorycomboBox_category.FormattingEnabled = true;
            this.categorycomboBox_category.Location = new System.Drawing.Point(148, 290);
            this.categorycomboBox_category.Margin = new System.Windows.Forms.Padding(10);
            this.categorycomboBox_category.Name = "categorycomboBox_category";
            this.categorycomboBox_category.Size = new System.Drawing.Size(192, 36);
            this.categorycomboBox_category.TabIndex = 17;
            this.categorycomboBox_category.SelectedIndexChanged += new System.EventHandler(this.categorycomboBox_category_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label6.Font = new System.Drawing.Font("Sitka Display", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(520, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 47);
            this.label6.TabIndex = 15;
            this.label6.Text = "SELLING";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // button_print
            // 
            this.button_print.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button_print.FlatAppearance.BorderSize = 0;
            this.button_print.Font = new System.Drawing.Font("Sitka Small", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_print.ForeColor = System.Drawing.Color.Black;
            this.button_print.Location = new System.Drawing.Point(1038, 563);
            this.button_print.Name = "button_print";
            this.button_print.Size = new System.Drawing.Size(88, 52);
            this.button_print.TabIndex = 11;
            this.button_print.Text = "Print";
            this.button_print.UseVisualStyleBackColor = false;
            this.button_print.Click += new System.EventHandler(this.button_print_Click);
            // 
            // button_addbill
            // 
            this.button_addbill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button_addbill.FlatAppearance.BorderSize = 0;
            this.button_addbill.Font = new System.Drawing.Font("Sitka Display", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_addbill.ForeColor = System.Drawing.Color.Black;
            this.button_addbill.Location = new System.Drawing.Point(208, 194);
            this.button_addbill.Name = "button_addbill";
            this.button_addbill.Size = new System.Drawing.Size(86, 39);
            this.button_addbill.TabIndex = 11;
            this.button_addbill.Text = "Add";
            this.button_addbill.UseVisualStyleBackColor = false;
            this.button_addbill.Click += new System.EventHandler(this.button_addbill_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Sitka Display", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(31, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 28);
            this.label4.TabIndex = 6;
            this.label4.Text = "Price";
            // 
            // label_amount
            // 
            this.label_amount.AutoSize = true;
            this.label_amount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label_amount.Font = new System.Drawing.Font("Sitka Display", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_amount.ForeColor = System.Drawing.Color.White;
            this.label_amount.Location = new System.Drawing.Point(952, 253);
            this.label_amount.Name = "label_amount";
            this.label_amount.Size = new System.Drawing.Size(43, 28);
            this.label_amount.TabIndex = 4;
            this.label_amount.Text = "Rs :";
            this.label_amount.Click += new System.EventHandler(this.label_amount_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sitka Display", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(10, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 28);
            this.label3.TabIndex = 4;
            this.label3.Text = "Quantity";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sitka Display", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(31, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // label_seller
            // 
            this.label_seller.AutoSize = true;
            this.label_seller.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label_seller.Font = new System.Drawing.Font("Sitka Display", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_seller.ForeColor = System.Drawing.Color.White;
            this.label_seller.Location = new System.Drawing.Point(120, 4);
            this.label_seller.Name = "label_seller";
            this.label_seller.Size = new System.Drawing.Size(157, 42);
            this.label_seller.TabIndex = 0;
            this.label_seller.Text = "SellerName";
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            // 
            // ProdQty
            // 
            this.ProdQty.HeaderText = "ProdQty";
            this.ProdQty.Name = "ProdQty";
            // 
            // ProdId
            // 
            this.ProdId.HeaderText = "ProdId";
            this.ProdId.Name = "ProdId";
            // 
            // ProdName
            // 
            this.ProdName.HeaderText = "ProdName";
            this.ProdName.Name = "ProdName";
            // 
            // ProdPrice
            // 
            this.ProdPrice.HeaderText = "ProdPrice";
            this.ProdPrice.Name = "ProdPrice";
            // 
            // label_date
            // 
            this.label_date.AutoSize = true;
            this.label_date.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label_date.Font = new System.Drawing.Font("Sitka Display", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_date.ForeColor = System.Drawing.Color.White;
            this.label_date.Location = new System.Drawing.Point(950, 9);
            this.label_date.Name = "label_date";
            this.label_date.Size = new System.Drawing.Size(83, 39);
            this.label_date.TabIndex = 0;
            this.label_date.Text = "Date: ";
            this.label_date.Click += new System.EventHandler(this.label_date_Click);
            // 
            // order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 656);
            this.Controls.Add(this.label_exit);
            this.Controls.Add(this.panel1);
            this.Name = "order";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "order";
            this.Load += new System.EventHandler(this.order_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productnameandpricedataGridViewprd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.billdataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewproductorder)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_exit;
        private System.Windows.Forms.DataGridView productnameandpricedataGridViewprd;
        private System.Windows.Forms.DataGridView billdataGridView2;
        private System.Windows.Forms.DataGridView dataGridViewproductorder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox Productname;
        private System.Windows.Forms.TextBox prprice;
        private System.Windows.Forms.TextBox prodquantitiy;
        private System.Windows.Forms.ComboBox categorycomboBox_category;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_print;
        private System.Windows.Forms.Button button_addbill;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_amount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_seller;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_date;
    }
}