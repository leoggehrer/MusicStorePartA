//@DomainCode
//MdStart
using MusicStore.Logic.DataContext;

namespace MusicStore.Logic.Controllers.Persistence
{
    /// <summary>
    /// This class is the specification of a generic controller to a project controller.
    /// </summary>
    internal abstract partial class MusicStoreController<I, E> : GenericController<I, E>
       where I : Contracts.IIdentifiable
       where E : Entities.IdentityObject, I, Contracts.ICopyable<I>, new()
    {
        protected IMusicStoreContext MusicStoreContext => (IMusicStoreContext)Context;

        /// <summary>
        /// This constructor creates an instance and takes over the context assigned to it.
        /// </summary>
        /// <param name="context">Context assigned to the controller.</param>
        protected MusicStoreController(IContext context)
            : base(context)
        {
        }
        /// <summary>
        /// This constructor creates an instance and takes over the context of another controller.
        /// </summary>
        /// <param name="controller">The controller object from which the context is taken.</param>
        protected MusicStoreController(ControllerObject controller)
            : base(controller)
        {

        }
    }
}
//MdEnd