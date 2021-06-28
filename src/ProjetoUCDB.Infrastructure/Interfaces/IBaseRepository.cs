using System.Threading.Tasks;
using ProjetoUCDB.Core.Entities;
using System.Collections.Generic;

namespace ProjetoUCDB.Infrastructure.Interfaces
{
    public interface IBaseRepository<T> where T : Base
    {
        Task<T> Create(T obj);
        Task<T> Update(T obj);
        Task Remove(long id);
        Task<T> Get(long id);
        Task<List<T>> Get();
    }
}
