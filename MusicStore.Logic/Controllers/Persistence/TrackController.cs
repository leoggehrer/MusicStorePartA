using System.Collections.Generic;
using MusicStore.Logic.DataContext;

namespace MusicStore.Logic.Controllers.Persistence
{
	internal partial class TrackController : MusicStoreController<Entities.Persistence.Track, Contracts.Persistence.ITrack>
	{
        protected override IEnumerable<Entities.Persistence.Track> Set => MusicStoreContext.Tracks;

		public TrackController(IContext context)
            : base(context)
        {
        }
        public TrackController(ControllerObject controller)
			: base(controller)
		{
		}
	}
}
