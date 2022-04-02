using Domain;
using System;
using System.Collections.Generic;

namespace IBusinessLogic
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers(User user = null);
        User InsertUser(User user);
        User UpdateUser(User user, String password);
        void DeleteUser(int id);
    }
}
