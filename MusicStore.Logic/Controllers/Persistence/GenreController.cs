//@DomainCode
//MdStart
using System.Collections.Generic;
using MusicStore.Logic.DataContext;

namespace MusicStore.Logic.Controllers.Persistence
{
    /// <summary>
    /// This class implements the specified controller for the entity 'Genre'.
    /// </summary>
    internal partial class GenreController : MusicStoreController<Contracts.Persistence.IGenre, Entities.Persistence.Genre>
    {
        protected override IEnumerable<Entities.Persistence.Genre> Set => MusicStoreContext.Genres;

        /// <summary>
        /// This constructor creates an instance and takes over the context assigned to it.
        /// </summary>
        /// <param name="context">Context assigned to the controller.</param>
        public GenreController(IContext context)
            : base(context)
        {
        }
        public GenreController(ControllerObject controller)
            : base(controller)
        {
        }
    }
}
//MdEnd