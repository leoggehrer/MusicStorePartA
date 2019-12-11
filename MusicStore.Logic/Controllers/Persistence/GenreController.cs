using System.Collections.Generic;
using MusicStore.Logic.DataContext;

namespace MusicStore.Logic.Controllers.Persistence
{
    internal partial class GenreController : MusicStoreController<Entities.Persistence.Genre, Contracts.Persistence.IGenre>
    {
        protected override IEnumerable<Entities.Persistence.Genre> Set => MusicStoreContext.Genres;

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
