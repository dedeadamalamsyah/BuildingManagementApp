# Building Management System - Technical Test

A robust Visitor Management System built with **Clean Architecture** principles, featuring automated registration control based on holiday schedules and Role-Based Access Control (RBAC).

## 🚀 Tech Stack

- **Framework:** .NET 10 (ASP.NET Core MVC)
- **Database:** SQLite with Entity Framework Core
- **Security:** ASP.NET Core Identity (RBAC)
- **Architecture:** Clean Architecture (Domain, Application, Infrastructure, Web)
- **Testing:** xUnit with Moq

## ✨ Key Features

- **Smart Visitor Registration:** Automated approval system with real-time holiday validation.
- **Holiday Management:** Full CRUD for admins to manage building holidays.
- **Admin Dashboard:** Centralized view of all visitors with **LINQ-powered Date Range Filtering**.
- **Role-Based Security:** Administrative areas are protected and only accessible by authorized Admin accounts.
- **Responsive UI:** Built with Bootstrap for a seamless experience on all devices.

## 🏗️ Architecture Overview

This project follows **Clean Architecture** to ensure high maintainability and testability:

- **Domain:** Core entities and interfaces (POCOs).
- **Application:** Business logic, DTOs, and Service implementations.
- **Infrastructure:** Data persistence (DbContext) and external concerns.
- **Web:** UI, Controllers, and Identity configurations.

## 🛠️ Getting Started

1. **Clone the repository:**
   ```bash
   git clone https://github.com/dedeadamalamsyah/BuildingManagementApp
   ```

2. **Update Database:**
   ```bash
   dotnet ef database update --project BuildingApp.Infrastructure --startup-project BuildingApp.Web
   ```

3. **Run the Application:**
   ```bash
   dotnet run --project BuildingApp.Web
   ```

## 🔐 Admin Credentials (Seeded)

The system automatically seeds an admin account for testing:

- **Email:** `admin@lievee.com`
- **Password:** `Admin123!`

---

Developed as part of the Technical Test for PT Lievee Ciptatama Indonesia.
