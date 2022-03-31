using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreUI.Repositories.Abstract
{
    public interface IGenericRepository<T>
    {
        T GetById(int id);

        List<T> GetAll();

        void Create(T entity);

        void Update(T entity);
        void Delete(T entity);
    }
}