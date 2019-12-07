namespace MusicStore.Contracts.Persistence
{
	public interface ITrack : IIdentifiable
    {
        int AlbumId { get; set; }
        int GenreId { get; set; }
        string Title { get; set; }
		string Composer { get; set; }
        long Milliseconds { get; set; }
        long Bytes { get; set; }
        double UnitPrice { get; set; }
    }
}
