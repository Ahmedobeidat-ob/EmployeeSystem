using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTask.Core.DTO
{
    public class EmployeeDTO
    {
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

       

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; }=false;  

    }
}
