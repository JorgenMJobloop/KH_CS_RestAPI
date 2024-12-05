using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/testing/imagesupport")]

public class ImageSupportController : ControllerBase
{
    private readonly AppDbContext _context;

    public static List<ImageSupport> imageSupport = new List<ImageSupport>() {
        new ImageSupport {Id = 1, ImageUrl = "http://localhost:5045/images/sopranos.png"},
        new ImageSupport {Id = 2, ImageUrl = "http://localhost:5045/images/wire.png"},
        new ImageSupport {Id = 3, ImageUrl = "http://localhost:5045/images/twin_peaks.png"}
    };
    /// <summary>
    /// Part of the test library, used to test static file-serving on the RestAPI
    /// </summary>
    /// <param name="context">Database context</param>
    public ImageSupportController(AppDbContext context)
    {
        _context = context;

        if (!_context.TestImageSupport.Any())
        {
            _context.TestImageSupport.AddRange(imageSupport);
            _context.SaveChanges();
        }
    }



    [HttpGet]
    public IEnumerable<ImageSupport> Get()
    {
        return _context.TestImageSupport.ToList();
    }
}