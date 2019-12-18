//@BaseCode
//MdStart
namespace MusicStore.Contracts.Persistence
{
    /// <summary>
    /// Defines all properties of a genre.
    /// </summary>
	public interface IGenre : IIdentifiable, ICopyable<IGenre>
    {
        /// <summary>
        /// Gets or sets the name of this instance.
        /// </summary>
        string Name { get; set; }
    }
}
//MdEnd
