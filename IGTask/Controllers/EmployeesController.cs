using AutoMapper;
using IGTask.Core.Data;
using IGTask.Core.DTO;
using IGTask.Core.IService;
using IGTask.Infra.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IGTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesService _service;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeesService service,IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        // GET: api/<EmployeesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _service.GetAllAsync();
            return Ok(employees);
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(Guid id)
        {

            var employee = await _service.GetAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee([FromForm] EmployeeDTO employee, IFormFile? file)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // If CreateDate is not provided, set it to the current UTC time
            if (employee.CreateDate == default)
            {
                employee.CreateDate = DateTime.UtcNow; // Set current UTC time if not provided
            }

            var EMP = _mapper.Map<Employee>(employee);

            // Handle the photo if a file is provided
            if (file != null && file.Length > 0)
            {
                // Define the upload path for the photo
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "employee", fileName);

                // Ensure the directory exists
                var directoryPath = Path.GetDirectoryName(uploadPath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                // Save the uploaded photo to the server
                using (var stream = new FileStream(uploadPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Save the relative file path (not the full server path)
                EMP.Photo = Path.Combine("uploads", "employee", fileName);
            }

            // Add the employee to the database
            var addedEmployee = await _service.AddAsync(EMP);

            return CreatedAtAction(nameof(GetEmployeeById), new { id = addedEmployee.EmployeeId }, addedEmployee);
        }


        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(Guid id, [FromForm] EmployeeDTO employee, IFormFile? file)
        {
            var updatedEmployee = _mapper.Map<Employee>(employee);  // Map DTO to entity

            var existingEmployee = await _service.GetAsync(id);  // Fetch the existing employee from the database
            if (existingEmployee == null)
            {
                return NotFound(); // Return 404 if the employee is not found
            }

          

            try
            {
                // Update employee fields
                existingEmployee.Name = updatedEmployee.Name;
                existingEmployee.Email = updatedEmployee.Email;
                existingEmployee.MobileNumber = updatedEmployee.MobileNumber;
                existingEmployee.HomeAddress = updatedEmployee.HomeAddress;
                existingEmployee.IsDeleted = updatedEmployee.IsDeleted;
                existingEmployee.ModifyDate = DateTime.UtcNow;  // Update ModifyDate to current time

                // Handle photo upload if a new file is provided
                if (file != null)
                {
                    // Generate a unique filename for the uploaded file
                    var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                    var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "employee", fileName);

                    // Ensure the directory exists
                    var directoryPath = Path.GetDirectoryName(uploadPath);
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);  // Create directory if not exists
                    }

                    // Save the uploaded photo to the server
                    using (var stream = new FileStream(uploadPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);  // Asynchronously save the file
                    }

                    // Update the employee photo path
                    existingEmployee.Photo = Path.Combine("uploads", "employee", fileName);  // Store relative path to photo
                }

                // Update the employee in the database
                await _service.UpdateAsync(existingEmployee);

                return NoContent();  // 204 No Content on successful update
            }
            catch (Exception ex)
            {
                // Handle unexpected errors and return 500 Internal Server Error
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }




        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteEmployee(Guid id)
        {
            var employee = await _service.GetAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            if (employee.IsDeleted)
            {
                return BadRequest("Employee is already deleted.");
            }

            await _service.SoftDeleteAsync(id);
            return NoContent();
        }

        [HttpGet("exists/{id}")]
        public async Task<ActionResult<bool>> EmployeeExists(Guid id)
        {
            var exists = await _service.Exists(id);
            return Ok(exists);
        }

    }


}
