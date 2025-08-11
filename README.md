

# 🚗 Vehicle Rental Management System

A **VB.NET + MySQL** desktop application to automate and streamline the vehicle rental process. This system replaces traditional manual methods with a secure, reliable, and efficient digital solution, enabling better management of vehicles, customers, rentals, and returns.

---

## 📖 Table of Contents

* [Introduction](#introduction)
* [Features](#features)
* [Modules](#modules)
* [System Requirements](#system-requirements)
* [Installation & Setup](#installation--setup)
* [Database Structure](#database-structure)
* [Screenshots](#screenshots)
* [Future Enhancements](#future-enhancements)
* [Contributing](#contributing)
* [License](#license)

---

## 📌 Introduction

The **Vehicle Rental Management System** automates vehicle booking, rental tracking, and return operations. It allows customers to browse and rent available vehicles, while admins can manage vehicle inventories, monitor returns, and track customer details.

**Key Objectives:**

* Reduce manual work and paperwork.
* Improve data accuracy and accessibility.
* Provide quick and secure rental operations.
* Enhance efficiency and customer service.

---

## ✨ Features

### 🔑 User Authentication

* Customer **Registration** & **Login**.
* Admin Login with full privileges.

### 🚘 Vehicle Management

* Add, edit, delete, and view vehicles.
* Filter by type, brand, and availability.

### 📄 Rental Processing

* Rent vehicles with details: vehicle type, brand, registration number, rent & return dates.
* Automatic fee calculation based on rental duration.

### 👤 Customer Management

* Store and retrieve customer details including name, contact info, and driver’s license.

### 🔄 Vehicle Return

* Track returned vehicles and update availability.
* Delay calculation and fine generation.

---

## 🧩 Modules

1. **User Authentication** – Registration/Login for customers and admin access.
2. **Vehicle Details** – Inventory management (Add/Edit/Delete vehicles).
3. **Rental Management** – Renting process with fee calculation and availability updates.
4. **Customer Details** – Stores customer records for admin access.
5. **Return Management** – Handles returns, calculates fines for delays, and updates status.

---

## 💻 System Requirements

### Hardware:

* Processor: Intel Core i3 or higher
* RAM: 4GB minimum
* Storage: 500MB free space

### Software:

* **OS:** Windows 7/8/10/11
* **IDE:** Visual Studio with VB.NET support
* **Database:** MySQL Server
* **Connector:** MySQL Connector/NET

---

## ⚙️ Installation & Setup

### 1. Clone the Repository

```bash
git clone https://github.com/piyushsharma0211/Vehicle-Rental-Management-System.git
```

### 2. Import Database

* Open MySQL.
* Import the provided `.sql` file located in the `/database` folder.

### 3. Configure Database Connection

* Open the project in Visual Studio.
* In the `MY_CONNECTION` class, update the MySQL connection string with your username, password, and database name.

### 4. Run the Application

* Open the `.sln` file in Visual Studio.
* Build and run the project.

---

## 🗄 Database Structure

**Tables:**

* `tbl_accounts` – Stores customer details.
* `car_tbl` – Stores vehicle details.
* `rent_tbl` – Tracks rentals.
* `return_tbl` – Tracks returns and fines.

---

## 📸 Screenshots

*(Add screenshots here from your documentation)*

* **Login Page**
* **Admin Dashboard**
* **Vehicle Inventory**
* **Rental Form**
* **Return Form**

---

## 🚀 Future Enhancements

* Online payment integration.
* Real-time vehicle tracking.
* Web and mobile versions.
* Multi-location branch management.

---

## 🤝 Contributing

Contributions are welcome! Please fork the repository, make changes, and submit a pull request.

---

## 📜 License

This project is licensed under the **MIT License**.

---

