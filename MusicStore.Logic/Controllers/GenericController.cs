//@BaseCode
//MdStart
using System;
using System.Collections.Generic;
using System.Linq;
using CommonBase.Extensions;
using MusicStore.Contracts.Client;
using MusicStore.Logic.DataContext;

namespace MusicStore.Logic.Controllers
{
    /// <inheritdoc cref="IControllerAccess{T}"/>
    /// <summary>
    /// This generic class implements the base properties and operations defined in the interface. 
    /// </summary>
    /// <typeparam name="E">The entity type of element in the controller.</typeparam>
    /// <typeparam name="I">The interface type which implements the entity.</typeparam>
    internal abstract partial class GenericController<E, I> : ControllerObject, IControllerAccess<I>
        where E : Entities.IdentityObject, I, Contracts.ICopyable<I>, new()
        where I : Contracts.IIdentifiable
    {
        protected abstract IEnumerable<E> Set { get; }

        /// <summary>
        /// This constructor creates an instance and takes over the context assigned to it.
        /// </summary>
        /// <param name="context">Context assigned to the controller.</param>
        protected GenericController(IContext context)
            : base(context)
        {

        }
        /// <summary>
        /// This constructor creates an instance and takes over the context of another controller.
        /// </summary>
        /// <param name="controller">The controller object from which the context is taken.</param>
        protected GenericController(ControllerObject controller)
            : base(controller)
        {

        }

        #region Sync-Methods
        /// <inheritdoc />
        public int Count()
        {
            return Context.Count<I, E>();
        }
        /// <inheritdoc />
        public virtual IEnumerable<I> GetAll()
        {
            return Set.Select(i =>
                      {
                          var result = new E();

                          result.CopyProperties(i);
                          return result;
                      });
        }
        /// <inheritdoc />
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
        /// <inheritdoc />
        public virtual I Create()
        {
            return new E();
        }

        protected virtual void BeforeInserting(E entity)
        {

        }
        /// <inheritdoc />
        public virtual I Insert(I entity)
        {
            entity.CheckArgument(nameof(entity));

            var entityModel = new E();

            entityModel.CopyProperties(entity);
            return Insert(entityModel);
        }
        public virtual I Insert(E entity)
        {
            entity.CheckArgument(nameof(entity));

            BeforeInserting(entity);
            var result = Context.Insert<I, E>(entity);
            AfterInserted(result);
            return result;
        }
        protected virtual void AfterInserted(E entity)
        {

        }

        protected virtual void BeforeUpdating(E entity)
        {

        }
        /// <inheritdoc />
        public virtual I Update(I entity)
        {
            entity.CheckArgument(nameof(entity));

            var entityModel = new E();

            entityModel.CopyProperties(entity);
            return Update(entityModel);
        }
        public virtual I Update(E entity)
        {
            entity.CheckArgument(nameof(entity));

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
            return updateEntity;
        }
        protected virtual void AfterUpdated(E entity)
        {

        }

        protected virtual void BeforeDeleting(int id)
        {

        }
        /// <inheritdoc />
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

        protected virtual void BeforeSaveChanges()
        {

        }
        /// <inheritdoc />
        public void SaveChanges()
        {
            BeforeSaveChanges();
            Context.Save();
            AfterSaveChanges();
        }
        protected virtual void AfterSaveChanges()
        {

        }
        #endregion Sync-Methods
    }
}
//MdEnd