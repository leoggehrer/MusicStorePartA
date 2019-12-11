using MusicStore.Logic.DataContext;
using System.Collections.Generic;

namespace MusicStore.Logic.Controllers.Persistence
{
	internal partial class AlbumController : MusicStoreController<Entities.Persistence.Album, Contracts.Persistence.IAlbum>
	{
        protected override IEnumerable<Entities.Persistence.Album> Set => MusicStoreContext.Albums;

		public AlbumController(IContext context)
            : base(context)
        {
        }
        public AlbumController(ControllerObject controller)
			: base(controller)
		{
		}
	}
}
