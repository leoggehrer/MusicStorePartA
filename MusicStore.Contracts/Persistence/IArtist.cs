//@DomainCode
//MdStart
namespace MusicStore.Contracts.Persistence
{
    /// <summary>
    /// Defines all properties of an artist.
    /// </summary>
	public interface IArtist : IIdentifiable, ICopyable<IArtist>
    {
        /// <summary>
        /// Gets or sets the name of this instance.
        /// </summary>
        string Name { get; set; }
    }
}
//MdEnd
