using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
        public class Employee
        {
            public int Id { get; set; }
            [Required]
            [MaxLength(50)]
            public string Name { get; set; }
            [Required]
            [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid Email Format")]
            public string Email { get; set; }
            [Required]
            public Dept? Departement { get; set; }
            public string? PhotoPath { get; set; }

        }
}
