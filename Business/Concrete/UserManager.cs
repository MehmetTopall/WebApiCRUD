using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager:IService<User>
    {
        private IRepository<User> userRepo;
        public UserManager()
        {
            userRepo = new Repository<User>();
        }

        public User Create(User p)
        {
            return userRepo.Create(p);
        }

        public void Delete(int id)
        {
            userRepo.Delete(id);
        }

        public List<User> GetAll()
        {
            return userRepo.GetAll();
        }

        public User GetById(int id)
        {
            return userRepo.GetById(id);
        }

        public User Update(User p)
        {
            return userRepo.Update(p);
        }
    }
}
