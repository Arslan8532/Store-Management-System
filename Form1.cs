using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store
{
    public partial class Form1 : Form
    {
      

        public Form1()
        {
            InitializeComponent();


        }

        private void usernametextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void PasswordtextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Retrieve username and password (trim spaces and ignore case)
            string username = usernametextBox.Text.Trim().ToLower();
            string password = PasswordtextBox.Text.Trim();

            // Validate input fields
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both Username and Password!", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if username and password match "afzal"
            if (username == "afzal" && password == "afzal")
            {
                MessageBox.Show("Welcome, Afzal!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Open Category.cs Form and close login form properly
                Category categoryForm = new Category();
                categoryForm.Show();
                this.Hide();
            }
            else
            {
                // Show error message if login fails
                MessageBox.Show("Invalid Username or Password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Clear password field for security
                PasswordtextBox.Clear();
                PasswordtextBox.Focus();
            }
        }


       

        private void Form1_Load(object sender, EventArgs e)
        {
            // 🎨 Login Button (Modern Design)
            button1.FlatStyle = FlatStyle.Flat;
            button1.BackColor = Color.Teal; // Background Color
            button1.ForeColor = Color.White; // Text Color
            button1.Font = new Font("Segoe UI", 12, FontStyle.Bold); // Modern Font
            button1.FlatAppearance.BorderSize = 0; // No Border
            button1.Cursor = Cursors.Hand; // Hand Cursor on Hover

            // 🎨 Clear Button (Modern Design)
            button2.FlatStyle = FlatStyle.Flat;
            button2.BackColor = Color.DarkRed;
            button2.ForeColor = Color.White;
            button2.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            button2.FlatAppearance.BorderSize = 0;
            button2.Cursor = Cursors.Hand;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Gradient start aur end colors
            Color startColor = Color.Teal;       // Left side color
            Color endColor = Color.DarkSalmon;   // Right side color

            // Gradient Brush create karein
            using (LinearGradientBrush brush = new LinearGradientBrush(panel1.ClientRectangle, startColor, endColor, LinearGradientMode.Horizontal))
            {
                e.Graphics.FillRectangle(brush, panel1.ClientRectangle);
            }
        }


        // Clear button functionality
        private void button2_Click(object sender, EventArgs e)
        {
            // Clear textboxes
            usernametextBox.Clear();
            PasswordtextBox.Clear();

            // Set focus back to username textbox
            usernametextBox.Focus();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            int borderRadius = 25; // Smooth & rounded corners
            int diameter = borderRadius * 2;

            // Enable High-Quality Graphics
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Define Rounded Panel Path
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(0, 0, diameter, diameter, 180, 90);
            path.AddArc(panel2.Width - diameter, 0, diameter, diameter, 270, 90);
            path.AddArc(panel2.Width - diameter, panel2.Height - diameter, diameter, diameter, 0, 90);
            path.AddArc(0, panel2.Height - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            panel2.Region = new Region(path);

            // 🎨 **Modern & Soft Gradient Effect**
            Color startColor = Color.FromArgb(255, 77, 165, 242);  // Light Sky Blue
            Color middleColor = Color.FromArgb(255, 32, 102, 174); // Medium Electric Blue
            Color endColor = Color.FromArgb(255, 12, 58, 130);     // Deep Royal Blue

            using (LinearGradientBrush gradientBrush = new LinearGradientBrush(
                panel2.ClientRectangle, startColor, endColor, LinearGradientMode.Vertical))
            {
                ColorBlend colorBlend = new ColorBlend();
                colorBlend.Colors = new Color[] { startColor, middleColor, endColor };
                colorBlend.Positions = new float[] { 0f, 0.5f, 1f };

                gradientBrush.InterpolationColors = colorBlend;
                e.Graphics.FillPath(gradientBrush, path);
            }

            // ✨ **Soft Neon Glow Border**
            using (Pen borderPen = new Pen(Color.FromArgb(120, 255, 255, 255), 3)) // Soft White Glow
            {
                e.Graphics.DrawPath(borderPen, path);
            }

            // 💡 **Subtle Inner Shadow for 3D Look**
            using (Pen innerShadowPen = new Pen(Color.FromArgb(40, 0, 0, 0), 2)) // Dark Shadow
            {
                e.Graphics.DrawArc(innerShadowPen, 2, 2, diameter - 4, diameter - 4, 180, 90);
                e.Graphics.DrawArc(innerShadowPen, panel2.Width - diameter + 2, 2, diameter - 4, diameter - 4, 270, 90);
                e.Graphics.DrawArc(innerShadowPen, panel2.Width - diameter + 2, panel2.Height - diameter + 2, diameter - 4, diameter - 4, 0, 90);
                e.Graphics.DrawArc(innerShadowPen, 2, panel2.Height - diameter + 2, diameter - 4, diameter - 4, 90, 90);
            }
        }




        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Handle forget password manually
            string username = usernametextBox.Text.Trim().ToLower();

            // Check if username is entered
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter your Username to reset the password!", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if username matches "afzal"
            if (username == "afzal")
            {
                // Display the password manually
                MessageBox.Show("Your password is: afzal", "Password Recovery", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Show error message if username is incorrect
                MessageBox.Show("Username not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Close the application
            Application.Exit();
        }
    }
}
