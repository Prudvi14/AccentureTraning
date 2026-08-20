namespace Githubdemo.Data
{
    public class EmployeeRepository : IEmployee
    {
    private readonly EmployeeDbContext _context;

    public EmployeeRepository() : this(new EmployeeDbContext())
    {
    }

    public EmployeeRepository(EmployeeDbContext context)
    {
        _context = context;
    }

        public void AddEmployee(Employee employee)
        {
        if (_context.Employees.Any(e => e.Id == employee.Id))
            {
                throw new InvalidOperationException($"Employee with Id {employee.Id} already exists.");
            }

        _context.Employees.Add(employee);
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
        return _context.Employees;
        }

        public Employee? GetEmployeeById(int id)
        {
        return _context.Employees.FirstOrDefault(e => e.Id == id);
        }

        public bool UpdateEmployee(Employee employee)
        {
        var existingEmployee = _context.Employees.FirstOrDefault(e => e.Id == employee.Id);
            if (existingEmployee is null)
            {
                return false;
            }

            existingEmployee.Name = employee.Name;
            existingEmployee.Salary = employee.Salary;
            return true;
        }

        public bool DeleteEmployee(int id)
        {
        var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (employee is null)
            {
                return false;
            }

        _context.Employees.Remove(employee);
            return true;
        }
    }
}
