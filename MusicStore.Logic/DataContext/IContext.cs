//@BaseCode
//MdStart
using System;
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

        E Insert<I, E>(E entity)
            where I : IIdentifiable
            where E : IdentityObject, ICopyable<I>, I, new();

        E Update<I, E>(E entity)
            where I : IIdentifiable
            where E : IdentityObject, ICopyable<I>, I, new();

        E Delete<I, E>(int id)
            where I : IIdentifiable
            where E : IdentityObject, I;

        void Save();
        #endregion Sync-Methods
    }
}
//MdEnd