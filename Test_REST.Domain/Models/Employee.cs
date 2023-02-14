using Test_REST.Domain.Domain;
using Test_REST.Domain.Helpers;
using Test_REST.Domain.ValueObjects;

namespace Test_REST.Domain.Models
{
    public class Employee : Entity
    {
        public Employee(ReferenceNumber referenceNumber, LastName lastName, Gender gender) : base(referenceNumber)
        {
            ThrowIf.Argument.IsNull(() => lastName);

            LastName = lastName.Value;
            Gender = gender;
        }

        public virtual string LastName { get;  set; }
        public virtual Gender Gender { get; protected set; }

        public void UpdateEmployee(Employee employee)
        {
            ThrowIf.Argument.IsNull(() => employee);

            this.ReferenceNumber = employee.ReferenceNumber;
            this.LastName = employee.LastName;
            this.Gender = employee.Gender;
        }
    }
}