//@BaseCode
//MdStart
using System.Collections.Generic;
using MusicStore.Logic.Entities.Persistence;

namespace MusicStore.Logic.DataContext
{
    internal partial interface IMusicStoreContext
    {
        IEnumerable<Genre> Genres { get; }
        IEnumerable<Artist> Artists { get; }
        IEnumerable<Album> Albums { get; }
        IEnumerable<Track> Tracks { get; }
    }
}
//MdEnd