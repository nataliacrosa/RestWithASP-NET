using RestWithASP_NET.Model;
using RestWithASP_NET.Repository.Generic;
using System.Collections.Generic;

namespace RestWithASP_NET.Repository
{
    public interface IPersonRepository: IRepository<Person>
    {
        List<Person> FindByName(string firstName, string lastName);
    }
}
