using System.Collections.Generic;

namespace Interface
{
    public interface IRepository<T, IdType>
    {
        IEnumerable<T> Get();

        T GetById(IdType id);

        T Add(T obj);

        T Edit(T obj);

        T Delete(T obj);
    }
}