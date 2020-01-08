//@DomainCode
//MdStart
namespace MusicStore.Contracts.Persistence
{
    /// <summary>
    /// Defines all public properties of an album.
    /// </summary>
    public interface IAlbum : IIdentifiable, ICopyable<IAlbum>
    {
        /// <summary>
        /// Gets or sets the reference id from an artist.
        /// </summary>
        int ArtistId { get; set; }
        /// <summary>
        /// Gets or sets the title of this instance.
        /// </summary>
        string Title { get; set; }
    }
}
//MdEnd