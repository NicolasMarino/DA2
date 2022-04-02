using Domain;
using System;
using System.Collections.Generic;

namespace DataAccessInterface
{
    public interface IUsersRepository
    {
        IEnumerable<User> GetUsers(Predicate<User> filter);
        IEnumerable<User> GetUsers();
        void InsertUser(User user);
        User GetUserById(int id);
        void DeleteUser(int id);
        void UpdateUser(User user, String password);
    }
}
