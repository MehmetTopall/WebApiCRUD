using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IService<T>
    {
        List<T> GetAll();
        T GetById(int id);
        T Create(T p);
        T Updated(T p);
        void Delete(int id);
    }
}
