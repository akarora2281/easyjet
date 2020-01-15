using System.Collections.Generic;
using EasyJet.Interview.Interface;

namespace EasyJet.Interview
{
    public class GenericRepository<T, I> : IRepository<T, I> where T : IStoreable<I>
    {
        private List<T> entities;

        public GenericRepository()
        {
            entities = new List<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return entities;
        }

        public T Get(I id)
        {
            return entities.Find(Item => Item.Id.Equals(id));
        }

        public void Delete(I id)
        {
            entities.Remove(Get(id));
        }
            
        public void Save(T item)
        {
            Delete(item.Id);
            entities.Add(item);
        }
    }
}
