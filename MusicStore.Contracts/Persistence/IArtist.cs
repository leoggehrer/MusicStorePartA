namespace MusicStore.Contracts.Persistence
{
	public interface IArtist : IIdentifiable
    {
        string Name { get; set; }
    }
}
