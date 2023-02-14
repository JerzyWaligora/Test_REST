using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Test_REST.Domain.Helpers;
using Test_REST.Domain.Models;
using Test_REST.Domain.Services;
using Test_REST.Domain.ValueObjects;

namespace Test_REST.Tests
{
    [TestClass]
    public class ReferenceNumberTest
    {
       
        [TestMethod]
        public void ReferenceNumberConstructor_ShouldCreateProperleValue_WhenHappyPath()
        {
            //arrange
            var referenceNumberValue = "1";
            var expectedReferenceNumber = "00000001";

            //act
            var actual = new ReferenceNumber(referenceNumberValue);

            //assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(actual.Value, expectedReferenceNumber);
        }

        [TestMethod]
        public void ReferenceNumberConstructor_ShouldReturnArgumentException_WhenTooLongInitValue()
        {
            //arrange
            var referenceNumberValue = "123456789";
            var expectedReferenceNumber = "00000001";

            //act
            TestDelegate act = () => new ReferenceNumber(referenceNumberValue);

            //assert
            NUnit.Framework.Assert.Throws<ArgumentException>(act);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow("ABC")]
        public void ReferenceNumberConstructor_ShouldReturnInvalidCastException_WhenReferenceNumberEmptyOrIsNotNumeric(string value)
        {
            //arrange
            var referenceNumberValue = value;
            var expectedReferenceNumber = "00000001";

            //act
            TestDelegate act = () => new ReferenceNumber(referenceNumberValue);

            //assert
            NUnit.Framework.Assert.Throws<InvalidCastException>(act);
        }
    }
}