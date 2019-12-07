using System;
using System.Threading.Tasks;
using MusicStore.Contracts;
using MusicStore.Logic.Entities;

namespace MusicStore.Logic.DataContext
{
    internal partial interface IContext : IDisposable
    {
        #region Sync-Methods
        int Count<I, E>()
            where I : IIdentifiable
            where E : IdentityObject, I;

        E Create<I, E>()
            where I : IIdentifiable
            where E : IdentityObject, ICopyable<I>, I, new();

        E Insert<I, E>(I entity)
            where I : IIdentifiable
            where E : IdentityObject, ICopyable<I>, I, new();

        E Update<I, E>(I entity)
            where I : IIdentifiable
            where E : IdentityObject, ICopyable<I>, I, new();

        E Delete<I, E>(int id)
            where I : IIdentifiable
            where E : IdentityObject, I;

        void Save();
        #endregion Sync-Methods

        #region Async-Methods
        Task<int> CountAsync<I, E>()
            where I : IIdentifiable
            where E : IdentityObject, I;

        Task<E> CreateAsync<I, E>()
            where I : IIdentifiable
            where E : IdentityObject, ICopyable<I>, I, new();

        Task<E> InsertAsync<I, E>(I entity)
            where I : IIdentifiable
            where E : IdentityObject, ICopyable<I>, I, new();

        Task<E> UpdateAsync<I, E>(I entity)
            where I : IIdentifiable
            where E : IdentityObject, ICopyable<I>, I, new();

        Task<E> DeleteAsync<I, E>(int id)
            where I : IIdentifiable
            where E : IdentityObject, I;

        Task SaveAsync();
        #endregion Async-Methods
    }
}