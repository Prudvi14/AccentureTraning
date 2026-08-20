using Githubdemo.Data;
using Xunit;

namespace Githubdemo.Tests
{
    public class EmployeeRepositoryTests
    {
        [Fact]
        public void AddEmployee_ShouldAddEmployee()
        {
            var context = new EmployeeDbContext();
            var repository = new EmployeeRepository(context);
            var employee = new Employee { Id = 1, Name = "John", Salary = 50000 };

            repository.AddEmployee(employee);

            Assert.Single(context.Employees);
            Assert.Equal("John", context.Employees[0].Name);
        }

        [Fact]
        public void AddEmployee_WithDuplicateId_ShouldThrowInvalidOperationException()
        {
            var context = new EmployeeDbContext();
            var repository = new EmployeeRepository(context);
            repository.AddEmployee(new Employee { Id = 1, Name = "John", Salary = 50000 });

            Assert.Throws<InvalidOperationException>(() =>
                repository.AddEmployee(new Employee { Id = 1, Name = "Jane", Salary = 60000 }));
        }

        [Fact]
        public void GetAllEmployees_ShouldReturnAllEmployees()
        {
            var context = new EmployeeDbContext();
            var repository = new EmployeeRepository(context);
            repository.AddEmployee(new Employee { Id = 1, Name = "John", Salary = 50000 });
            repository.AddEmployee(new Employee { Id = 2, Name = "Jane", Salary = 60000 });

            var employees = repository.GetAllEmployees();

            Assert.Equal(2, employees.Count());
        }

        [Fact]
        public void GetEmployeeById_WhenEmployeeExists_ShouldReturnEmployee()
        {
            var context = new EmployeeDbContext();
            var repository = new EmployeeRepository(context);
            repository.AddEmployee(new Employee { Id = 1, Name = "John", Salary = 50000 });

            var employee = repository.GetEmployeeById(1);

            Assert.NotNull(employee);
            Assert.Equal("John", employee.Name);
        }

        [Fact]
        public void GetEmployeeById_WhenEmployeeDoesNotExist_ShouldReturnNull()
        {
            var context = new EmployeeDbContext();
            var repository = new EmployeeRepository(context);

            var employee = repository.GetEmployeeById(999);

            Assert.Null(employee);
        }

        [Fact]
        public void UpdateEmployee_WhenEmployeeExists_ShouldUpdateAndReturnTrue()
        {
            var context = new EmployeeDbContext();
            var repository = new EmployeeRepository(context);
            repository.AddEmployee(new Employee { Id = 1, Name = "John", Salary = 50000 });

            var result = repository.UpdateEmployee(new Employee { Id = 1, Name = "John Updated", Salary = 70000 });

            Assert.True(result);
            var updated = repository.GetEmployeeById(1);
            Assert.NotNull(updated);
            Assert.Equal("John Updated", updated.Name);
            Assert.Equal(70000, updated.Salary);
        }

        [Fact]
        public void UpdateEmployee_WhenEmployeeDoesNotExist_ShouldReturnFalse()
        {
            var context = new EmployeeDbContext();
            var repository = new EmployeeRepository(context);

            var result = repository.UpdateEmployee(new Employee { Id = 100, Name = "Unknown", Salary = 10000 });

            Assert.False(result);
        }

        [Fact]
        public void DeleteEmployee_WhenEmployeeExists_ShouldRemoveAndReturnTrue()
        {
            var context = new EmployeeDbContext();
            var repository = new EmployeeRepository(context);
            repository.AddEmployee(new Employee { Id = 1, Name = "John", Salary = 50000 });

            var result = repository.DeleteEmployee(1);

            Assert.True(result);
            Assert.Empty(repository.GetAllEmployees());
        }

        [Fact]
        public void DeleteEmployee_WhenEmployeeDoesNotExist_ShouldReturnFalse()
        {
            var context = new EmployeeDbContext();
            var repository = new EmployeeRepository(context);

            var result = repository.DeleteEmployee(999);

            Assert.False(result);
        }
    }
}
