//@DomainCode
//MdStart
using System.Collections.Generic;

namespace MusicStore.Logic.DataContext.Ser
{
    internal partial class SerMusicStoreContext : MusicStoreFileContext
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
    }
}
//MdEnd