public class ImageSupport
{
    /// <summary>
    /// Required ID for our primary key
    /// </summary>
    public required int Id { get; set; }
    /// <summary>
    /// path to our image-url on the server
    /// </summary>
    public required string ImageUrl { get; set; } // wwwroot/images/someimage
}