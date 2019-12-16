//MdStart
namespace MusicStore.Contracts.Persistence
{
    /// <summary>
    /// This interface defines properties of an album.
    /// </summary>
	public interface IAlbum : IIdentifiable
    {
        /// <summary>
        /// Gets or sets the reference id from artist.
        /// </summary>
        int ArtistId { get; set; }
        /// <summary>
        /// Gets or sets the title of this instance.
        /// </summary>
        string Title { get; set; }
    }
}
//MdEnd