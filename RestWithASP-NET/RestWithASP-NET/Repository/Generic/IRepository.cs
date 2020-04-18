using RestWithASP_NET.Model;
using RestWithASP_NET.Model.Base;
using System.Collections.Generic;

namespace RestWithASP_NET.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindById(long id);
        List<T> FindAll();
        T Update(T person);
        void Delete(long id);

        bool Exist(long? id);
    }
}
