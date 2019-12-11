namespace MusicStore.Contracts.Persistence
{
    /// <summary>
    /// This interface defines properties of a genre.
    /// </summary>
	public interface IGenre : IIdentifiable
    {
        /// <summary>
        /// Gets or sets the name of this instance.
        /// </summary>
        string Name { get; set; }
    }
}
