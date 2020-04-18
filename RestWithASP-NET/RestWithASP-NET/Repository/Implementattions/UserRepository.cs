using System;
using System.Collections.Generic;
using System.Linq;
using RestWithASP_NET.Model;
using RestWithASP_NET.Model.Context;

namespace RestWithASP_NET.Repository.Implementattions
{
    public class UserRepository : IUserRepository
    {
        private readonly MySqlContext _context;

        public UserRepository (MySqlContext context)
        {
            _context = context;
        }

        public User FindByLogin(string login)
        {
            return _context.Users.SingleOrDefault(p => p.Login.Equals(login));
        }
    }
}
