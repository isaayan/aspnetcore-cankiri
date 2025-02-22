# Çankırı Promotion Website

This project is a city promotion website developed using **ASP.NET Core MVC**. While users can view various information, individuals with admin privileges can manage the content.

## 📌 Features

### 🏠 Home Page
This section contains basic information about the city, a scrolling slider, and a map showing the city's location.

**Screenshot:**  
![homepage](images/homepage.png)

---

### 👤 User System
This section allows users to register, log in, and access city information after logging in.

- **Login Page**
  Users can log in to access additional features.

  **Screenshot:**  
  ![login](images/login.png)

- **Registration Page**
  New users can register to create an account.

  **Screenshot:**  
  ![register](images/register.png)

- **User Homepage**
  After logging in, users can see personalized content and city details.

  **Screenshot:**  
  ![user-homepage](images/user-homepage.png)

- **District Information**
  Users can explore information about different districts of the city.

  **Screenshot:**  
  ![district](images/district.png)

- **News Page**
  Users can view the latest news about the city.

  **Screenshot:**  
  ![news-page](images/news-page.png)

- **Population Data**
  Users can view demographic and population statistics of the city.

  **Screenshot:**  
  ![population](images/population.png)

- **Touristic Promotion Page**
  Users can explore promotional content about the city's touristic attractions.

  **Screenshot:**  
  ![touristic-promotion-page](images/touristic-promotion-page.png)

---

### 🔧 Admin Panel
The admin panel allows administrators to manage user roles, slider images, and city information.

- **Admin Homepage**
  The homepage for the admin where management options are available.

  **Screenshot:**  
  ![admin-homepage](images/admin-homepage.png)

- **User Role Edit**
  Admins can edit user roles and manage user permissions.

  **Screenshot:**  
  ![user-role-edit](images/user-role-edit.png)

- **Slider Image Edit**
  Admins can manage and edit images in the city’s scrolling slider.

  **Screenshot:**  
  ![slider-image-edit](images/slider-image-edit.png)

- **Touristic Promotion Page (Admin)**
  Admins can add or edit content for the touristic promotion page.

  **Screenshot:**  
  ![touristic-promotion-page-admin](images/touristic-promotion-page-admin.png)

- **Create Touristic Promotion (Admin)**
  Admins can create new entries for the touristic promotion page.

  **Screenshot:**  
  ![create-touristic-promotion-admin](images/create-touristic-promotion-admin.png)

- **Population Data (Admin)**
  Admins can manage population data and statistics.

  **Screenshot:**  
  ![population](images/district-admin.png)

- **District Admin Page**
  Admins can manage district-specific data for the city.

  **Screenshot:**  
  ![district-admin-page](images/district-admin-page.png)

- **Create News (Admin)**
  Admins can create and manage news entries for the city.

  **Screenshot:**  
  ![create-news-admin](images/create-news-admin.png)

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
