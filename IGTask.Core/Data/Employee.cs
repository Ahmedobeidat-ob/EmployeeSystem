using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTask.Core.Data
{
    public class Employee
    {
        [Key] 
        public Guid EmployeeId { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(100)] 
        public string Name { get; set; }

        [Required] 
        [EmailAddress] 
        public string Email { get; set; }

        [Required] 
        [Phone]
        public string MobileNumber { get; set; }

        [MaxLength(200)] 
        public string HomeAddress { get; set; }

        [Url] 
        //
        public string Photo { get; set; }
    }
}
