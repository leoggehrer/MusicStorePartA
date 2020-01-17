//@DomainCode
//MdStart
using System.Linq;
using MusicStore.Logic.Entities.Persistence;

namespace MusicStore.Logic.DataContext
{
    internal partial interface IMusicStoreContext
    {
        IQueryable<Genre> Genres { get; }
        IQueryable<Artist> Artists { get; }
        IQueryable<Album> Albums { get; }
        IQueryable<Track> Tracks { get; }
    }
}
//MdEnd