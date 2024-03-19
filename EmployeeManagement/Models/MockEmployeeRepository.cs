namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
     
        private List<Employee> _employeeList;
        public MockEmployeeRepository() 
        {
            _employeeList = new List<Employee>()
            {
                new Employee() {Id = 1, Name = "Mary", Departement = Dept.HR, Email = "Mary@pragim.com" },
                new Employee() {Id = 2, Name = "John", Departement = Dept.IT, Email = "John@pragim.com" },
                new Employee() {Id = 3, Name = "Sam", Departement = Dept.IT, Email = "Sam@pragim.com" }
            };
        }

        public Employee GetEmployee(int id) 
        {
            return _employeeList.FirstOrDefault(e => e.Id == id);   
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employeeList;
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);
            return employee;
        }

        

        public Employee Delete(int id)
        {
            Employee employee = _employeeList.FirstOrDefault( employee => employee.Id == id);
            if (employee != null)
            {
                _employeeList.Remove(employee);
            }
            return employee;
        }

        public Employee Update(Employee employeeChanges)
        {
            Employee employee = _employeeList.FirstOrDefault(employee => employee.Id == employeeChanges.Id);
            if (employee != null)
            {
                employee.Name = employeeChanges.Name;
                employee.Email = employeeChanges.Email;
                employee.Departement = employeeChanges.Departement;
                
            }
            return employee;

        }
    }
}
