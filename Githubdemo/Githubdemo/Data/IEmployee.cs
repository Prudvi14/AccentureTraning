namespace Githubdemo.Data
{
    public interface IEmployee
    {
        void AddEmployee(Employee employee);
        IEnumerable<Employee> GetAllEmployees();
        Employee? GetEmployeeById(int id);
        bool UpdateEmployee(Employee employee);
        bool DeleteEmployee(int id);

    }
}
