using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectsPortifolio.Domain
{
    public interface IRepositoryBase<T>
    {
        Task<List<T>> GetAll();

        Task<T> Add(T entity);

        Task<T> GetById(int? id);

        Task DeleteById(int id);

        Task<T> Update(T entity);
    }
}
