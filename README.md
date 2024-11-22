Employee Management API (C# in .NET Core)
This is the backend API for managing employees, built with C# and .NET Core. The API allows for creating, viewing, updating, deleting employees, and handling employee data with optional photo uploads.

Features
1. Entity Definition
Employee Model: An employee entity is defined with the following properties:
EmployeeId (Guid)
Name (string)
Email (string)
PhoneNumber (string)
HomeAddress (string, optional)
IsDeleted (bool, soft delete flag)
Photo (string, optional, path to the employee photo)
CreateDate (DateTime, date when the employee record was created)
ModifyDate (DateTime, date when the employee record was last modified)
2. API Endpoints
2.1 Create New Employee
Endpoint: POST /api/employees
Accepts input from the frontend via a form and optional file upload (photo).
Validates the data and stores the employee in the database.
2.2 View Employee List
Endpoint: GET /api/employees
Retrieves a list of all stored employees.
2.3 View Employee By ID
Endpoint: GET /api/employees/{id}
Retrieves a specific employee by their unique ID (EmployeeId).
2.4 Update Employee Information
Endpoint: PUT /api/employees/{id}
Updates the details of an existing employee, including their name, email, phone number, and optional photo.
2.5 Soft Delete Employee
Endpoint: DELETE /api/employees/{id}
Soft deletes an employee by marking their record as "IsDeleted". Does not remove the record from the database.
2.6 Check Employee Existence
Endpoint: GET /api/employees/exists/{id}
Checks if an employee exists by their unique ID (EmployeeId).
2.7 Optional Photo Upload
Employees can upload a photo when creating or updating their record. The file is stored in a designated folder on the server, and the relative path to the photo is saved in the employee record.
3. Authentication (Optional)
If authentication is required, you can add JWT token-based authentication or another authentication mechanism to protect sensitive endpoints like creating, updating, or deleting employees.

Setup Instructions
Prerequisites
To set up the project, ensure you have the following installed:

.NET Core SDK (version 7.0 or later)
SQL Server for database operations
