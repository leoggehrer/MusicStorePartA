using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicStore.Logic.DataContext;

namespace MusicStore.Logic.Controllers
{
    internal abstract partial class GenericController<E, I> : ControllerObject, IController<I>
        where E : Entities.IdentityObject, I, Contracts.ICopyable<I>, new()
        where I : Contracts.IIdentifiable
    {
        protected abstract IEnumerable<E> Set { get; }

        protected GenericController(IContext context)
            : base(context)
        {

        }
        protected GenericController(ControllerObject controllerObject)
            : base(controllerObject)
        {

        }

        #region Sync-Methods
        public int Count()
        {
            return Context.Count<I, E>();
        }
        public virtual IEnumerable<I> GetAll()
        {
            return Set.Select(i =>
                      {
                          var result = new E();

                          result.CopyProperties(i);
                          return result;
                      });
        }
        public virtual I GetById(int id)
        {
            var result = default(E);
            var item = Set.SingleOrDefault(i => i.Id == id);

            if (item != null)
            {
                result = new E();
                result.CopyProperties(item);
            }
            return result;
        }
        public virtual I Create()
        {
            return new E();
        }

        protected virtual void BeforeInserting(I entity)
        {

        }
        public virtual I Insert(I entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            BeforeInserting(entity);
            var result = Context.Insert<I, E>(entity);
            AfterInserted(result);
            return result;
        }
        protected virtual void AfterInserted(E entity)
        {

        }

        protected virtual void BeforeUpdating(I entity)
        {

        }
        public virtual void Update(I entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            BeforeUpdating(entity);
            var updateEntity = Context.Update<I, E>(entity);

            if (updateEntity != null)
            {
                AfterUpdated(updateEntity);
            }
            else
            {
                throw new Exception("Entity can't find!");
            }
        }
        protected virtual void AfterUpdated(E entity)
        {

        }

        protected virtual void BeforeDeleting(int id)
        {

        }
        public void Delete(int id)
        {
            BeforeDeleting(id);
            var item = Context.Delete<I, E>(id);

            if (item != null)
            {
                AfterDeleted(item);
            }
        }
        protected virtual void AfterDeleted(E entity)
        {

        }

        public void SaveChanges()
        {
            Context.Save();
        }
        #endregion Sync-Methods

        #region Async-Methods
        public Task<int> CountAsync()
        {
            return Context.CountAsync<I, E>();
        }
        public virtual Task<I> GetByIdAsync(int id)
        {
            return Task.Run<I>(() =>
            {
                var result = default(E);
                var item = Set.SingleOrDefault(i => i.Id == id);

                if (item != null)
                {
                    result = new E();
                    result.CopyProperties(item);
                }
                return result;
            });
        }
        public virtual Task<IEnumerable<I>> GetAllAsync()
        {
            return Task.Run<IEnumerable<I>>(() =>
                Set.Select(i =>
                    {
                        var result = new E();

                        result.CopyProperties(i);
                        return result;
                    }));
        }
        public virtual Task<I> CreateAsync()
        {
            return Task.Run<I>(() => new E());
        }

        protected virtual Task BeforeInsertingAsync(I entity)
        {
            return Task.FromResult(0);
        }
        public virtual async Task<I> InsertAsync(I entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await BeforeInsertingAsync(entity);
            var result = await Context.InsertAsync<I, E>(entity);
            await AfterInsertedAsync(result);
            return result;
        }
        protected virtual Task AfterInsertedAsync(E entity)
        {
            return Task.FromResult(0);
        }

        protected virtual Task BeforeUpdatingAsync(I entity)
        {
            return Task.FromResult(0);
        }
        public virtual async Task UpdateAsync(I entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await BeforeUpdatingAsync(entity);
            var updateEntity = await Context.UpdateAsync<I, E>(entity);

            if (updateEntity != null)
            {
                await AfterUpdatedAsync(updateEntity);
            }
            else
            {
                throw new Exception("Entity can't find!");
            }
        }
        protected virtual Task AfterUpdatedAsync(E entity)
        {
            return Task.FromResult(0);
        }

        protected virtual Task BeforeDeletingAsync(int id)
        {
            return Task.FromResult(0);
        }
        public async Task DeleteAsync(int id)
        {
            await BeforeDeletingAsync(id);
            var item = await Context.DeleteAsync<I, E>(id);

            if (item != null)
            {
                await AfterDeletedAsync(item);
            }
        }
        protected virtual Task AfterDeletedAsync(E entity)
        {
            return Task.FromResult(0);
        }

        public Task SaveChangesAsync()
        {
            return Context.SaveAsync();
        }
        #endregion Async-Methods
    }
}
