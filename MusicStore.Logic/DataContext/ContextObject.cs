using MusicStore.Contracts;
using MusicStore.Logic.Entities;
using System.Threading.Tasks;

namespace MusicStore.Logic.DataContext
{
    internal abstract class ContextObject : IContext
    {
        #region Sync-Methods
        public abstract int Count<I, E>()
            where I : IIdentifiable
            where E : IdentityObject, I;
        public abstract E Create<I, E>()
            where I : IIdentifiable
            where E : IdentityObject, I, ICopyable<I>, new();
        public abstract E Insert<I, E>(I entity)
            where I : IIdentifiable
            where E : IdentityObject, I, ICopyable<I>, new();
        public abstract E Update<I, E>(I entity)
            where I : IIdentifiable
            where E : IdentityObject, I, ICopyable<I>, new();
        public abstract E Delete<I, E>(int id)
            where I : IIdentifiable
            where E : IdentityObject, I;
        public abstract void Save();
        #endregion Sync-Methods

        #region Async-Methods
        public abstract Task<int> CountAsync<I, E>()
            where I : IIdentifiable
            where E : IdentityObject, I;
        public abstract Task<E> CreateAsync<I, E>()
            where I : IIdentifiable
            where E : IdentityObject, I, ICopyable<I>, new();
        public abstract Task<E> InsertAsync<I, E>(I entity)
            where I : IIdentifiable
            where E : IdentityObject, ICopyable<I>, I, new();
        public abstract Task<E> UpdateAsync<I, E>(I entity)
            where I : IIdentifiable
            where E : IdentityObject, I, ICopyable<I>, new();
        public abstract Task<E> DeleteAsync<I, E>(int id)
            where I : IIdentifiable
            where E : IdentityObject, I;
        public abstract Task SaveAsync();
        #endregion Async-Methods

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ContextObject()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
