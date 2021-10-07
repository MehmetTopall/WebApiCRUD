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
    public class CategoryManager : IService<Category>
    {
        private IRepository<Category> categoryRepo;
        public CategoryManager()
        {
            categoryRepo = new Repository<Category>();
        }
        public Category Create(Category p)
        {
            return categoryRepo.Create(p);
        }

        public void Delete(int id)
        {
            categoryRepo.Delete(id);
        }

        public List<Category> GetAll()
        {
            return categoryRepo.GetAll();
        }

        public Category GetById(int id)
        {
            return categoryRepo.GetById(id);
        }

        public Category Updated(Category p)
        {
            return categoryRepo.Updated(p);
        }
    }
}
