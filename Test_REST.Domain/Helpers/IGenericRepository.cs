using Test_REST.Domain.Domain;

namespace Test_REST.Infrastructure
{
    public interface IGenericRepository<TEntity> where TEntity : Entity
    { 
        IEnumerable<TEntity> GetAll();
        TEntity GetById(string referenceNumber);
        void Add(TEntity obj);
        TEntity Update(TEntity obj);
        void Delete(string referenceNumber);
    }
}