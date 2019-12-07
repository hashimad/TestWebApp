using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebApp.Domain.IRepositories
{
   public interface IRepository<T>
    {
        int Add(T entity);
        bool Update(T entity);
        List<T> GetAll();
        bool Delete(int Id);
    }
}
