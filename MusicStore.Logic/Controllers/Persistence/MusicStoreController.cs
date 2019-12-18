//@BaseCode
//MdStart
using MusicStore.Logic.DataContext;

namespace MusicStore.Logic.Controllers.Persistence
{
    internal abstract partial class MusicStoreController<E, I> : GenericController<E, I>
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
//MdEnd