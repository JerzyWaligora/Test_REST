using Test_REST.Domain.Domain;
using Test_REST.Domain.Helpers;
using Test_REST.Domain.ValueObjects;

namespace Test_REST.Domain.Models
{
    public class EmployeeDto
    {
        public EmployeeDto(LastName lastName, Gender gender)
        {
            ThrowIf.Argument.IsNull(() => lastName);

            LastName = lastName.Value;
            Gender = gender;
        }

        public string LastName { get; protected set; }
        public Gender Gender { get; protected set; }
    }
}