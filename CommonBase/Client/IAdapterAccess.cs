using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Client
{
    public interface IAdapterAccess<T> : IDisposable
    {
        #region Sync-Methods
        int Count();
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Create();
        T Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        #endregion Sync-Methods

        #region Async-Methods
        Task<int> CountAsync();
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync();
        Task<T> InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        #endregion Async-Methods
    }
}
