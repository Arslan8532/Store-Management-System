# 🏪 Store Management System

The **Store Management System** is a **Windows-based desktop application** designed to streamline the management of **products, categories, inventory, and users**.  

This system helps store owners and managers efficiently **track stock levels, manage product categories, and monitor sales**, all while ensuring secure access through **role-based authentication**.

## 🚀 Features
✅ **Product Management** – Add, Edit, Delete, View Products  
✅ **Stock Monitoring** – Track product quantities in real-time  
✅ **Category Management** – Organize products into different categories  
✅ **User Authentication** – Secure login for Admins & Users  
✅ **Modern UI Design** – Smooth animations, rounded panels, and gradients  
✅ **Database Integration** – Uses **SQL Server** for secure data storage  

---

## 🛠️ Technologies Used
- **Programming Language:** C# (.NET Windows Forms)  
- **Database:** Microsoft SQL Server  
- **UI Design:** Custom Graphics using GDI+  
- **Security:** Parameterized SQL Queries (Prevents SQL Injection)  
- **Version Control:** Git & GitHub  

---

## 📂 Database Schema
### 📌 Table: `Products`
| Column Name | Data Type | Constraints |
|------------|----------|-------------|
| `ProdId` | `INT` | Primary Key, Auto Increment |
| `ProdName` | `VARCHAR(255)` | NOT NULL |
| `ProdPrice` | `FLOAT` | NOT NULL |
| `ProdQuantity` | `INT` | NOT NULL |
| `ProdCat` | `VARCHAR(100)` | Foreign Key (Categories) |

### 📌 Table: `Categories`
| Column Name | Data Type | Constraints |
|------------|----------|-------------|
| `CatId` | `INT` | Primary Key, Auto Increment |
| `CatName` | `VARCHAR(100)` | NOT NULL |

### 📌 Table: `Users`
| Column Name | Data Type | Constraints |
|------------|----------|-------------|
| `UserId` | `INT` | Primary Key, Auto Increment |
| `Username` | `VARCHAR(50)` | UNIQUE, NOT NULL |
| `Password` | `VARCHAR(255)` | NOT NULL |
| `Role` | `VARCHAR(50)` | (Admin/User) |

---

## 🎨 UI & Design Features
- **Rounded Corners & Gradient Backgrounds** using `GraphicsPath`  
- **Custom Panel Painting for a Modern Look**  
- **Smooth Transitions & UI Effects using GDI+**  
- **Dynamic Color Adjustments for Better Readability**  

---

## 🚀 Getting Started
### 🔧 Prerequisites
- **Visual Studio** (Latest version recommended)  
- **Microsoft SQL Server**  
- **.NET Framework 4.7+**  

### 📥 Installation
1. **Clone the repository**  
   ```bash
   git clone https://github.com/Arslan8532/Store-Management-System.git



Open the project in Visual Studio

Set up the database

Open SQL Server

Execute the provided database_script.sql

Run the application

🔒 Security Features
Role-Based Authentication (Admins & Users)

Secure Login System with Encrypted Passwords

SQL Injection Prevention using Parameterized Queries

Data Validation for Secure Inputs

🏆 Contributing
Pull requests are welcome! If you want to contribute:

Fork the repo

Create a feature branch (git checkout -b feature-name)

Commit your changes (git commit -m "Added new feature")

Push to the branch (git push origin feature-name)

Create a Pull Request

📜 License
This project is open-source and available under the MIT License.




📩 Contact
For any issues or suggestions, feel free to reach out:
📧 Email: arslan.jameel8532@gamil.com
📌 GitHub: Arslan8532
