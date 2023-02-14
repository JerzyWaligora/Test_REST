using Test_REST.Domain.Helpers;
using Test_REST.Domain.Models;
using Test_REST.Domain.ValueObjects;

namespace Test_REST.Domain.Services
{
    public class EmployeeProvider
    {
        private IEmployeeRepository _employeeRepository;
        private readonly Queue<EmployeeDto> _entityQueue = new Queue<EmployeeDto>();
        private bool _lockAddEntity;

        public EmployeeProvider(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void AddEmployee(string lastName, Gender gender)
        {
            _entityQueue.Enqueue(new EmployeeDto(new LastName(lastName), gender));

            while (_lockAddEntity)
            {
                Thread.Sleep(10);
            }

            _lockAddEntity = true;

            var maxReferenceNumber = 1;
            var employees = _employeeRepository.GetAll();
           
            if (employees.Any())
                maxReferenceNumber = employees.Max(e => Convert.ToInt32(e.ReferenceNumber)) + 1;

            var employeeDto = _entityQueue.Dequeue();
            var employee = new Employee(new ReferenceNumber(maxReferenceNumber.ToString()), new LastName(employeeDto.LastName), employeeDto.Gender);

            _employeeRepository.Add(employee);

            _lockAddEntity = false;
        }

    }
}
