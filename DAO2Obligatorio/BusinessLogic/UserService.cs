using DataAccessInterface;
using Domain;
using IBusinessLogic;
using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class UserService : IUserService
    {
        private readonly IUsersRepository userManagment;
        
        public UserService(IUsersRepository userManagment)
        {
            this.userManagment = userManagment;
        }

        public void DeleteUser(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("El identificador debe ser mayor que 0.");
            }
            userManagment.DeleteUser(id);
        }

        public IEnumerable<User> GetUsers(User movie = null)
        {
            return userManagment.GetUsers();
        }

        public User InsertUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentException("Debe enviar la pelicula.");
            }
            
            userManagment.InsertUser(user);
            return user;
        }

        public User UpdateUser(User user, String password)
        {
            if (user == null)
            {
                throw new ArgumentException("Debe enviar el usuario.");
            }

            userManagment.UpdateUser(user, password);
            return user;
        }

    }
}
