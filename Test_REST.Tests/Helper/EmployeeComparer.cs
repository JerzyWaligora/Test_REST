using Test_REST.Domain.Models;

namespace Test_REST.Tests.Helper
{
    public class EmployeeComparer : IEqualityComparer<Employee>
        {
            public bool Equals(Employee x, Employee y)
            {
                if (x == null && y == null)
                {
                    return true;
                }

                if (x == null || y == null)
                {
                    return false;
                }

                return (x.LastName == y.LastName) && (x.Gender == y.Gender) && (x.Gender == y.Gender) && (x.ReferenceNumber == y.ReferenceNumber);
            }

            public int GetHashCode(Employee obj)
            {
                throw new NotImplementedException();
            }
        }
    
}
