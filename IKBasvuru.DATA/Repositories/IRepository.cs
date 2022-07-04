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

        int Add(T entity);
        int Update(T entity);
        int Delete(T entity);
        int HardDelete(T entity);

        Task<int> AddAsync(T entity);
        Task<T> MasterAddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
        Task<int> HardDeleteAsync(T entity);
    }
}
