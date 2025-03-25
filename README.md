# 🏪 Store Management System

## 📖 Description
The **Store Management System** is a **Windows-based desktop application** developed in **C# (.NET Windows Forms)** with a **Microsoft SQL Server** database. It is designed to help store owners efficiently manage **products, inventory, categories, and users** while ensuring smooth operations with a **user-friendly interface** and **secure authentication**.

With this system, businesses can keep track of **product stock levels, categorize items efficiently, monitor user activities**, and **prevent unauthorized access** with a **role-based authentication system**. 

This application features **modern UI elements, custom graphical effects, and database-driven functionalities**, making it a **reliable and efficient** solution for managing small to medium-sized stores.

---

## 🚀 Features
✅ **Product Management** – Add, Edit, Delete, View Products  
✅ **Stock Monitoring** – Real-time product tracking  
✅ **Category Management** – Organize products into categories  
✅ **User Authentication** – Secure login for Admins & Users  
✅ **Role-Based Access Control** – Different permissions for Admins and Users  
✅ **Modern UI Design** – Smooth animations, rounded panels, and gradients  
✅ **Database Integration** – Uses **SQL Server** for secure data storage  
✅ **Data Validation** – Prevents incorrect entries and ensures accuracy  
✅ **Secure Transactions** – Uses parameterized queries to prevent SQL injection  

---

## 🛠️ Technologies Used
- **Programming Language:** C# (.NET Windows Forms)  
- **Database:** Microsoft SQL Server  
- **UI Design:** Custom Graphics using GDI+  
- **Security:** Parameterized SQL Queries (Prevents SQL Injection)  
- **Version Control:** Git & GitHub  

---

## 🛠️ Database Schema
The **Store Management System** uses a structured relational database with the following tables:

### 📌 `Category`
| Column Name           | Data Type       | Constraints                      |
|----------------------|---------------|---------------------------------|
| `CatId`             | `INT`           | Primary Key, Auto Increment    |
| `CatName`           | `NCHAR(50)`     | NOT NULL                        |
| `CatDes`            | `NCHAR(100)`    | NOT NULL                        |
| `PriceIncreasePercent` | `FLOAT`      | NOT NULL, Default = 0          |

---

### 📌 `Product`
| Column Name  | Data Type   | Constraints                           |
|-------------|------------|--------------------------------------|
| `ProdId`    | `INT`      | Primary Key, Auto Increment         |
| `ProdName`  | `NCHAR(100)` | NOT NULL                            |
| `ProdPrice` | `FLOAT`    | NOT NULL                            |
| `ProdQuantity` | `INT`   | NOT NULL                            |
| `ProdCat`   | `INT`      | Foreign Key → `Category(CatId)`, CASCADE DELETE |

---

### 📌 `Seller`
| Column Name    | Data Type   | Constraints              |
|---------------|------------|-------------------------|
| `SellerId`    | `INT`      | Primary Key, Auto Increment |
| `SellerName`  | `NCHAR(50)` | NOT NULL               |
| `SellerAge`   | `INT`      | NOT NULL               |
| `SellerPhone` | `NCHAR(20)` | NOT NULL               |
| `SellerPass`  | `NCHAR(50)` | NOT NULL               |

---

### 📌 `Bill`
| Column Name  | Data Type   | Constraints                           |
|-------------|------------|--------------------------------------|
| `BillId`    | `INT`      | Primary Key, Auto Increment         |
| `SellerId`  | `INT`      | Foreign Key → `Seller(SellerId)`, SET NULL on delete |
| `SellDate`  | `DATETIME` | Default: `GETDATE()`                |
| `TotalAmt`  | `FLOAT`    | NOT NULL                            |

---

### 📌 `BillDetails`
| Column Name   | Data Type   | Constraints                                   |
|--------------|------------|----------------------------------------------|
| `BillDetailId` | `INT`     | Primary Key, Auto Increment                 |
| `BillId`      | `INT`     | Foreign Key → `Bill(BillId)`, CASCADE DELETE |
| `ProdId`      | `INT`     | Foreign Key → `Product(ProdId)`, CASCADE DELETE |
| `Quantity`    | `INT`     | NOT NULL                                     |
| `UnitPrice`   | `FLOAT`   | NOT NULL                                     |
| `TotalPrice`  | `FLOAT`   | NOT NULL                                     |

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
   git clone https://github.com/your-username/Store-Management-System.git
## 🚀 Getting Started

### 🔧 Prerequisites
- **Visual Studio** (Latest version recommended)  
- **Microsoft SQL Server**  
- **.NET Framework 4.7+**  

### 📥 Installation
1. **Open the project in Visual Studio**  
2. **Set up the database**  
   - Open **SQL Server**  
   - Execute the provided `database_script.sql`  
3. **Run the application**  

---

## 🔒 Security Features
✔️ **Role-Based Authentication** (Admins & Users)  
✔️ **Secure Login System** with Encrypted Passwords  
✔️ **SQL Injection Prevention** using Parameterized Queries  
✔️ **Data Validation** for Secure Inputs  

---

## 🏆 Contributing
Pull requests are welcome! If you want to contribute:  

1. **Fork the repo**  
2. **Create a feature branch**  
   ```bash
   git checkout -b feature-name
## 📩 Contact
For any issues or suggestions, feel free to reach out:

📧 Email: arslan.jameel8532@gmail.com
📌 GitHub: Arslan8532
