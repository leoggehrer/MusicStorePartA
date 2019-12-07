using System;
using System.Collections.Generic;
using System.Text;
using MusicStore.Logic.DataContext;

namespace MusicStore.Logic.Controllers.Persistence
{
    abstract class MusicStoreController<E, I> : GenericController<E, I>
        where E : Entities.IdentityObject, I, Contracts.ICopyable<I>, new()
        where I : Contracts.IIdentifiable
    {
        protected IMusicStoreContext MusicStoreContext => (IMusicStoreContext)Context;

        protected MusicStoreController(IContext context)
            : base(context)
        {
        }
        protected MusicStoreController(ControllerObject controller)
            : base(controller)
        {

        }
    }
}
