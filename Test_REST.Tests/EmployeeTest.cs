using Moq;
using Test_REST.Domain.Helpers;
using Test_REST.Domain.Models;
using Test_REST.Domain.Services;
using Test_REST.Domain.ValueObjects;
using Test_REST.Tests.Helper;

namespace Test_REST.Tests
{
    [TestClass]
    public class EmployeeTest
    {
        [TestMethod]
        public void EmployeeConstructor_ShouldCreateProperleFields()
        {
            //arrange
            var referenceNumber = new ReferenceNumber("1");
            var lastName = new LastName("Kowalski");
            var gender = Gender.Male;

            //act
            var actual = new Employee(referenceNumber, lastName, gender);

            //assert
            Assert.AreEqual(actual.ReferenceNumber, "00000001");
            Assert.AreEqual(actual.LastName, "Kowalski");
            Assert.AreEqual(actual.Gender, Gender.Male);
        }

        [TestMethod]
        public void EmployeeUpdate_ShouldModifyProperties_WhenEmployeeChangeLastNameAndGender()
        {
            //arrange
            var actual = new Employee(new ReferenceNumber("1"), new LastName("Kowalski"), Gender.Male);
            var request = new Employee(new ReferenceNumber("1"), new LastName("Kowalska"), Gender.Female);
            var expected = new Employee(new ReferenceNumber("1"), new LastName("Kowalska"), Gender.Female);

            //act
            actual.UpdateEmployee(request);

            //assert
            Assert.IsTrue(new EmployeeComparer().Equals(expected, actual));
        }
    }
}