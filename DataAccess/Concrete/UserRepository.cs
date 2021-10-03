using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class UserRepository : IUserRepository
    {
        public User CreateUser(User user)
        {
            using (var webapiDbContext = new WebApiDbContext())
            {
                webapiDbContext.Users.Add(user);
                webapiDbContext.SaveChanges();
                return user;
            }
        }

        public void DeleteUser(int id)
        {
            using (var webapiDbContext = new WebApiDbContext())
            {
                var deletedUser = GetUserById(id);
                webapiDbContext.Users.Remove(deletedUser);
                webapiDbContext.SaveChanges();
            }
        }

        public List<User> GetAllUsers()
        {
            using (var webapiDbContext = new WebApiDbContext())
            {
                return webapiDbContext.Users.ToList();
            }
        }

        public User GetUserById(int id)
        {
            using (var webapiDbContext = new WebApiDbContext())
            {
                return webapiDbContext.Users.Find(id);
            }
        }

        public User UpdateUser(User user)
        {
            using (var webapiDbContext = new WebApiDbContext())
            {
                webapiDbContext.Users.Update(user);
                webapiDbContext.SaveChanges();
                return user;
            }
        }
    }
}
