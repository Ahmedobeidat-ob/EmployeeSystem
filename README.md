Employee Management API (C# in .NET Core)
This is the backend API for managing employees, built using C# and .NET Core. The API includes functionality for creating, updating, retrieving, and deleting employee records. Additionally, it supports uploading and updating employee photos.

Features
1. Employee Entity
The Employee entity includes the following properties:

EmployeeId: Unique identifier (Guid)
Name: Employee's full name
Email: Employee's email address
MobileNumber: Employee's contact number
HomeAddress: (Optional) Employee's home address
IsDeleted: Soft delete flag (boolean)
Photo: (Optional) Path to employee's photo
CreateDate: Date the employee record was created
ModifyDate: Date the employee record was last modified
2. API Endpoints
2.1 Get All Employees
Endpoint: GET /api/employees
Retrieves a list of all employees in the system.
Response: 200 OK with a list of employees.
2.2 Get Employee by ID
Endpoint: GET /api/employees/{id}
Retrieves a specific employee by their unique EmployeeId.
Response: 200 OK with the employee details or 404 Not Found if the employee is not found.
2.3 Create New Employee
Endpoint: POST /api/employees
Creates a new employee record. Supports form data including optional photo upload.
Request Body: Employee data in EmployeeDTO format.
File Upload: Optionally upload a photo using IFormFile.
Response: 201 Created with the created employee details and location header.
2.4 Update Employee
Endpoint: PUT /api/employees/{id}
Updates an existing employee's details. Supports updating the employee's name, email, phone number, address, and photo.
Request Body: Updated employee data in EmployeeDTO format.
File Upload: Optionally upload a new photo using IFormFile.
Response: 204 No Content on success or 404 Not Found if the employee does not exist.
2.5 Soft Delete Employee
Endpoint: DELETE /api/employees/{id}
Soft deletes an employee record by setting the IsDeleted flag.
Response: 204 No Content on success or 404 Not Found if the employee does not exist.
2.6 Check if Employee Exists
Endpoint: GET /api/employees/exists/{id}
Checks if an employee exists by their unique EmployeeId.
Response: 200 OK with true or false.
3. Photo Upload
For employee photo uploads:

A unique file name is generated for each uploaded photo.
The photo is saved in the wwwroot/uploads/employee/ directory on the server.
The relative file path is saved in the Photo field of the employee record.
