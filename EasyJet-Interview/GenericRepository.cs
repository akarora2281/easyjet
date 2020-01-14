using System;
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
            throw new NotImplementedException();
        }

        public void Delete(I id)
        {

        }
            
        public void Save(T item)
        {

        }
    }
}
