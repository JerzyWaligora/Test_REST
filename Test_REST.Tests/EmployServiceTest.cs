using Moq;
using Test_REST.Domain.Helpers;
using Test_REST.Domain.Models;
using Test_REST.Domain.Services;
using Test_REST.Tests.Helper;

namespace Test_REST.Tests
{
    [TestClass]
    public class EmployServiceTest
    {
        private readonly EmployeeService _employeeService;
        private readonly Mock<IEmployeeRepository> _employeeRepositoryMock = new Mock<IEmployeeRepository>();
        private readonly EmployeeProvider _employeeProvider;

        public EmployServiceTest()
        {
            _employeeProvider = new EmployeeProvider(_employeeRepositoryMock.Object);
            _employeeService = new EmployeeService(_employeeRepositoryMock.Object, _employeeProvider);
        }

        [TestMethod]
        public void UpdateEmployee_ShouldReturnUpdatedEmployee_WhenEmployeeChangeLastNameAndGender()
        {
            //arrange
            var expectedReferenceNumber = "00000001";
            var current = new Employee(new Domain.ValueObjects.ReferenceNumber("1"), new Domain.ValueObjects.LastName("Nowak"), Domain.ValueObjects.Gender.Male);
            var request = new Employee(new Domain.ValueObjects.ReferenceNumber("1"), new Domain.ValueObjects.LastName("Kowalski"), Domain.ValueObjects.Gender.Female);
            var expected = new Employee(new Domain.ValueObjects.ReferenceNumber("1"), new Domain.ValueObjects.LastName("Kowalski"), Domain.ValueObjects.Gender.Female);

            _employeeRepositoryMock.Setup(x => x.GetById(expectedReferenceNumber)).Returns(current);

            //act
            var actual = _employeeService.UpdateEmployee(request);

            //assert
            Assert.IsTrue(new EmployeeComparer().Equals(expected, actual));
        }
    }
}
