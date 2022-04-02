using DataAccessInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DbContext myContext;
        private readonly DbSet<User> users;

        public UsersRepository(DbContext context)
        {
            this.myContext = context;
            this.users = context.Set<User>();
        }

        public IEnumerable<User> GetUsers()
        {
            return this.users;
        }

        public IEnumerable<User> GetUsers(Predicate<User> filter)
        {
            throw new NotImplementedException();
        }

        public void InsertUser(User user)
        {
            users.Add(user);
            myContext.SaveChanges();
        }

        public User GetUserById(int id)
        {
            List<User> users = this.users.ToList();
            foreach (User item in users)
            {
                if (item.Id.Equals(id))
                {
                    return item;
                }
            }
            return null;
        }

        public void DeleteUser(int id)
        {
            User userToDelete = GetUserById(id);
            if (userToDelete is null)
            {
                throw new Exception("No existe en la bd este user master");
            }
            else
            {
                myContext.Entry(userToDelete).State = EntityState.Deleted;
                users.Remove(userToDelete);
                myContext.SaveChanges();
            }
        }

        public void UpdateUser(User user, String password)
        {
            User userFound = GetUserById(user.Id);
            if (userFound is null)
            {
                throw new Exception("No existe este user en la bd");
            }
            else
            {
                userFound.Name = user.Name;
                userFound.Password = password;
                myContext.Entry(userFound).State = EntityState.Modified;
                myContext.SaveChanges();
            }
        }

    }
}
