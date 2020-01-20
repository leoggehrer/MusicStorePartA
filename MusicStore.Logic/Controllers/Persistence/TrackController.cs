//@DomainCode
//MdStart
using System.Collections.Generic;
using MusicStore.Logic.DataContext;

namespace MusicStore.Logic.Controllers.Persistence
{
    /// <summary>
    /// This class implements the specified controller for the entity 'Track'.
    /// </summary>
    internal partial class TrackController : MusicStoreController<Contracts.Persistence.ITrack, Entities.Persistence.Track>
    {
        protected override IEnumerable<Entities.Persistence.Track> Set => MusicStoreContext.Tracks;

        /// <summary>
        /// This constructor creates an instance and takes over the context assigned to it.
        /// </summary>
        /// <param name="context">Context assigned to the controller.</param>
        public TrackController(IContext context)
            : base(context)
        {
        }
        /// <summary>
        /// This constructor creates an instance and takes over the context of another controller.
        /// </summary>
        /// <param name="controller">The controller object from which the context is taken.</param>
        public TrackController(ControllerObject controller)
            : base(controller)
        {
        }
    }
}
//MdEnd