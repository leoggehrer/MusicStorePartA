using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicStore.Logic.DataContext.Csv
{
    internal class CsvMusicStoreContext : MusicStoreFileContext
    {
        public CsvMusicStoreContext()
        {
        }

        protected override List<T> LoadEntities<T>()
        {
            return LoadFromCsv<T>();
        }

        #region Sync-Methods
        public override void Save()
        {
            SaveToCsv(Genres);
            SaveToCsv(Artists);
            SaveToCsv(Albums);
            SaveToCsv(Tracks);
        }
        #endregion Sync-Methods

        #region Async-Methods
        public override Task SaveAsync()
        {
            return Task.Run(() =>
            {
                SaveToCsv(Genres);
                SaveToCsv(Artists);
                SaveToCsv(Albums);
                SaveToCsv(Tracks);
            });
        }
        #endregion Async-Methods
    }
}
