public class Movies
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public required string Director { get; set; }
    public required int ReleaseYear { get; set; }
    public string? ImageUrl { get; set; }
}