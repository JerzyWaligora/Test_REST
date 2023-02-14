using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_REST.Domain.Models;
using Test_REST.Infrastructure;

namespace Test_REST.Domain.Helpers
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {

    }
}
