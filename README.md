# Çankırı Promotion Website

This project is a city promotion website developed using **ASP.NET Core MVC**. While users can view various information, individuals with admin privileges can manage the content.

## 📌 Features

### 🏠 Home Page
- Basic information about the city
- Scrolling slider
- Map showing the city's location

**Screenshot:**  
![Screenshot](screenshots/anasayfa.png)

---

### 👤 User System
- User registration and login
- Access to city information after logging in

**Screenshot:**  
![Login and Registration](screenshots/giris_kayit.png)

---

### 🔧 Admin Panel
- Manage user roles
- Manage slider images
- Add, edit, and delete city information

**Screenshot:**  
![Admin Panel](screenshots/admin_panel.png)

---

## 🛠 Technologies
- **Backend:** ASP.NET Core MVC
- **Frontend:** HTML, CSS, JavaScript, Bootstrap
- **Database:** MySQL

## 🚀 Setup

1. **Clone the Project**
   ```bash
   git clone https://github.com/isaayan/aspnetcore-cankiri.git

2. **Install Dependencies To install the project's dependencies, run the following command**
   ```bash
   dotnet restore
   
3. **Create the Database**
- Open the appsettings.json file and update the database connection information.
- Run the following command to create the database
   ```bash
   dotnet ef database update
   
5. **Run the Project To run the project, use the following command**
   ```bash
   dotnet watch
