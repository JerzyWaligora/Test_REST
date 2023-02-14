namespace Test_REST.Infrastructure
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(string referenceNumber);
        void Insert(TEntity obj);
        void Update(TEntity obj);
        void Delete(string referenceNumber);

    }
}