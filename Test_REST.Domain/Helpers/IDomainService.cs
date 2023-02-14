using Test_REST.Domain.ValueObjects;

namespace Test_REST.Domain.Helpers
{
    public interface IDomainService<TEntity>
    {
        public IEnumerable<TEntity> GetAllEmployees();

        public TEntity GetEmployee(string referenceNumber);

        void AddEmployee(string lastName, Gender gender);

        TEntity UpdateEmployee(TEntity entity);

        void DeleteEmployee(string referenceNumber);

    }
}
