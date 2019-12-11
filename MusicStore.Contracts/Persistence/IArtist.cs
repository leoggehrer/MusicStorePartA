namespace MusicStore.Contracts.Persistence
{
    /// <summary>
    /// This interface defines properties of an artist.
    /// </summary>
	public interface IArtist : IIdentifiable
    {
        /// <summary>
        /// Gets or sets the name of this instance.
        /// </summary>
        string Name { get; set; }
    }
}
