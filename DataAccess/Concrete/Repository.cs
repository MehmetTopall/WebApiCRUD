using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        WebApiDbContext c = new WebApiDbContext();
        DbSet<T> _object;

        public Repository()
        {
            _object = c.Set<T>();
        }


        public T Create(T p)
        {
            _object.Add(p);
            c.SaveChanges();
            return p;
        }


        public void Delete(int id)
        {
            var deleted = GetById(id);
            _object.Remove(deleted);
            c.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _object.ToList();
        }

        public T GetById(int id)
        {
            return _object.Find(id);
        }

        public T Updated(T p)
        {
            _object.Update(p);
            c.SaveChanges();
            return p;
            
        }

    }
}
