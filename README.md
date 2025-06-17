# 🖥️ Inventory Management System - ASP.NET Core MVC

This is a web-based **Inventory Management System** built with **ASP.NET Core MVC** and **SQL Server**. It allows users to manage items efficiently through a user-friendly interface and provides full CRUD functionality along with categorized listings and image handling.

---

## 🚀 Features

- 🧩 Built using **ASP.NET Core MVC** and **Entity Framework Core**.
- 📷 Upload and preview item images before saving.
- 🗂 Categorize items by **Operating System**, **Item Type**, and **Category**.
- ✅ Server-side and client-side form validation.
- 🎨 Clean UI using **Bootstrap 5**.
- 🌐 Localization support using resource files.
- 🔐 Admin role detection based on email via `AdminSettings`.

---

## 📂 Project Structure

```
📁 Controllers/
📁 Models/
📁 Views/
📁 wwwroot/
📁 Migrations/
📁 Resources/
📁 Database/
```

---

## 🛠️ Getting Started

### 🧑‍💻 Setup Instructions

1. **Clone the repository**:

   ```bash
   git clone https://github.com/your-username/your-repo-name.git
   ```

2. **Set up the database connection**:

   Open the file `LapShopContext.cs` and update the connection string inside the `OnConfiguring` method to match your local SQL Server configuration:

   ```csharp
   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
       if (!optionsBuilder.IsConfigured)
       {
           optionsBuilder.UseSqlServer("Server=.;Database=LapShop;Trusted_Connection=True;");
       }
   }
   ```

3. **Import the database**:

   Use the SQL file `myproject_db.sql` inside the `Database/` folder to create the tables and seed data using SQL Server Management Studio (SSMS).

4. **Run the project**:

   Press `F5` or click the **Run** button in Visual Studio.

---

## 🔐 Admin Settings

You can define admin emails in the `appsettings.json` file under `AdminSettings`:

```json
"AdminSettings": {
  "AdminEmails": [
    "admin@gmail.com"
  ]
}
```

Anyone logging in with one of these emails will be granted administrative privileges.

---

## 🌐 Language Support

The application supports localization via `.resx` resource files, allowing you to easily adapt the UI for different languages.

---

## 🧪 Test Admin Login

You can log in using the following test credentials to simulate admin access:

```
Email: admin@gmail.com
Password: Admin@12345
```

---

## 📄 License

This project is open-source and available under the [MIT License](LICENSE).

