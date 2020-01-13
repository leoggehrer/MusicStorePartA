//@DomainCode
//MdStart
using MusicStore.Logic.DataContext;
using System.Collections.Generic;

namespace MusicStore.Logic.Controllers.Persistence
{
    /// <summary>
    /// This class implements the specified controller for the entity 'Artist'.
    /// </summary>
    internal partial class ArtistController : MusicStoreController<Entities.Persistence.Artist, Contracts.Persistence.IArtist>
    {
        protected override IEnumerable<Entities.Persistence.Artist> Set => MusicStoreContext.Artists;

        /// <summary>
        /// This constructor creates an instance and takes over the context assigned to it.
        /// </summary>
        /// <param name="context">Context assigned to the controller.</param>
        public ArtistController(IContext context)
            : base(context)
        {
        }
        /// <summary>
        /// This constructor creates an instance and takes over the context of another controller.
        /// </summary>
        /// <param name="controller">The controller object from which the context is taken.</param>
        public ArtistController(ControllerObject controller)
            : base(controller)
        {
        }
    }
}
//MdEnd