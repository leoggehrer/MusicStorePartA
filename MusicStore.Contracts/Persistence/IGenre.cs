namespace MusicStore.Contracts.Persistence
{
	public interface IGenre : IIdentifiable
    {
        string Name { get; set; }
    }
}
