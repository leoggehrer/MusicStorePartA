//@DomainCode
//MdStart
using MusicStore.Logic.DataContext;
using System.Collections.Generic;

namespace MusicStore.Logic.Controllers.Persistence
{
    /// <summary>
    /// This class implements the specified controller for the entity 'Album'.
    /// </summary>
    internal partial class AlbumController : MusicStoreController<Entities.Persistence.Album, Contracts.Persistence.IAlbum>
    {
        protected override IEnumerable<Entities.Persistence.Album> Set => MusicStoreContext.Albums;

        /// <summary>
        /// This constructor creates an instance and takes over the context assigned to it.
        /// </summary>
        /// <param name="context">Context assigned to the controller.</param>
        public AlbumController(IContext context)
            : base(context)
        {
        }
        /// <summary>
        /// This constructor creates an instance and takes over the context of another controller.
        /// </summary>
        /// <param name="controller">The controller object from which the context is taken.</param>
        public AlbumController(ControllerObject controller)
            : base(controller)
        {
        }
    }
}
//MdEnd