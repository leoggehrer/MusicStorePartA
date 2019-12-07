using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicStore.Logic.DataContext.Ser
{
    internal class SerMusicStoreContext : MusicStoreFileContext
    {
        public SerMusicStoreContext()
        {
        }

        protected override List<T> LoadEntities<T>()
        {
            return LoadFromSer<T>();
        }

        #region Sync-Methods
        public override void Save()
        {
            SaveToSer(Genres);
            SaveToSer(Artists);
            SaveToSer(Albums);
            SaveToSer(Tracks);
        }
        #endregion Sync-Methods

        #region Async-Methods
        public override Task SaveAsync()
        {
            return Task.Run(() =>
            {
                SaveToSer(Genres);
                SaveToSer(Artists);
                SaveToSer(Albums);
                SaveToSer(Tracks);
            });
        }
        #endregion Async-Methods
    }
}
