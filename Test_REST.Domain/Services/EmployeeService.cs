using Test_REST.Domain.Helpers;
using Test_REST.Domain.Models;
using Test_REST.Domain.ValueObjects;

namespace Test_REST.Domain.Services
{
    public class EmployeeService : IDomainService<Employee>
    {
        private IEmployeeRepository _employeeRepository;
        private EmployeeProvider _employeeProvider;

        public EmployeeService(IEmployeeRepository employeeRepository, EmployeeProvider employeeProvider)
        {
            _employeeRepository = employeeRepository;
            _employeeProvider = employeeProvider;    
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAll();
        }

        public Employee GetEmployee(string referenceNumber)
        {
            return _employeeRepository.GetById(referenceNumber);
        }

        public void AddEmployee(string lastName, Gender gender)
        {
            _employeeProvider.AddEmployee(lastName, gender);    
        }

        public Employee UpdateEmployee(Employee entity)
        {
            ThrowIf.Argument.IsNull(() => entity);

            var employee = _employeeRepository.GetById(entity.ReferenceNumber);

            ThrowIf.Argument.IsNull(() => employee);

            employee.UpdateEmployee(entity);
            _employeeRepository.Update(employee);

            return employee;
        }

        public void DeleteEmployee(string referenceNumber)
        {
            _employeeRepository.Delete(referenceNumber);
        }
    }
}
