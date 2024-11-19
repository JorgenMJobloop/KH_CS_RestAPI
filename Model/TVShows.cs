public class TVShows
{
    /// <summary>
    /// Our TVShow endpoint model, that contain the following fields
    /// int Id
    /// string Title
    /// string Creators
    /// int ReleaseYear
    /// int NumberOfSeasons
    /// </summary>
    public required int Id { get; set; }
    public required string Title { get; set; }
    public required string Creators { get; set; }
    public required int ReleaseYear { get; set; }
    public required int NumberOfSeasons { get; set; }
}