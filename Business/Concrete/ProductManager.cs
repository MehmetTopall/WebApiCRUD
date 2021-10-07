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
    public class ProductManager : IService<Product>
    {
        private IRepository<Product> productRepo;
        public ProductManager()
        {
            productRepo = new Repository<Product>();
        }
        public Product Create(Product p)
        {
            return productRepo.Create(p);
        }

        public void Delete(int id)
        {
            productRepo.Delete(id);
        }

        public List<Product> GetAll()
        {
            return productRepo.GetAll();
        }

        public Product GetById(int id)
        {
            return productRepo.GetById(id);
        }

        public Product Updated(Product p)
        {
            return productRepo.Updated(p);
        }
    }
}
