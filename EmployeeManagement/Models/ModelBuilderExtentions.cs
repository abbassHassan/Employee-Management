using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Models
{
    public static class ModelBuilderExtentions
    {
        public static void seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Name = "Mary",
                    Email = "Mary@gmail.com",
                    Departement = Dept.IT
                },
                new Employee
                {
                    Id = 2,
                    Name = "John",
                    Email = "John@gmail.com",
                    Departement = Dept.HR
                }

                );
        }
    }
}
