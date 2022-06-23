using IKBasvuru.COMMON.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IKBasvuru.DATA.Repositories
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter = null);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);

        Task<T> GetAsync(Expression<Func<T, bool>> filter = null);
        Task<T> GetFirstAsync(Expression<Func<T, bool>> filter = null);
        Task<T> GetLastAsync(Expression<Func<T, bool>> filter = null);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void HardDelete(T entity);

        Task AddAsync(T entity);
        Task<T> MasterAddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task HardDeleteAsync(T entity);
    }
}
