using RestWithASP_NET.Model;
using System.Collections.Generic;

namespace RestWithASP_NET.Repository
{
    public interface IUserRepository
    {
        User FindByLogin(string login);
    }
}
