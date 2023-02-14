namespace Test_REST.Infrastructure
{
    public class EntityRepository<TEntity> //: IGenericRepository<TEntity> 
    {
        /*
        protected static List<TEntity> entities = new List<TEntity>();


        public void Delete(string referenceNumber)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return entities;
        }

        public TEntity GetById(string referenceNumber)
        {
            return entities.FirstOrDefault(x => x.ReferenceNumber == referenceNumber);
        }

        public void Insert(TEntity item)
        {
            try
            {
                var maxId = entities.Max(x => Convert.ToInt32(x.ReferenceNumber));

                item.ReferenceNumber = (maxId++).ToString();
                entities.Add(item);
            }
            catch (Exception exp)
            {
                //logger.LogError("Error in EntityRepository.Insert", exp);
            }
        }


        public void Update(TEntity item)
        {
            try
            {
                var entity = GetById(item.Id);

               //TODO 

            }
            catch (Exception exp)
            {
                //logger.LogError("Error in EntityRepository.Insert", exp);
            }
        }*/
    }
}