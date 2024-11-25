using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/imdbtopten")]
public class IMDBTopTenController : ControllerBase
{
    private readonly AppDbContext _context;

    // static assignment for our GET-endpoint data
    private static List<IMDBTopTenModel> _IMDBTopTen = new List<IMDBTopTenModel>() {
        new IMDBTopTenModel {Id = 1, Title = "The Shawshank Redemption", Director = "Frank Darabont", ReleaseYear = 1994},
        new IMDBTopTenModel {Id = 2, Title = "The Godfather", Director = "Francis Ford Coppola", ReleaseYear = 1972},
        new IMDBTopTenModel {Id = 3, Title = "The Dark Knight", Director = "Christopher Nolan", ReleaseYear = 2008},
        new IMDBTopTenModel {Id = 4, Title = "The Godfather Part II", Director = "Francis Ford Coppola", ReleaseYear = 1974},
        new IMDBTopTenModel {Id = 5, Title = "12 Angry Men", Director = "Sidney Lumet", ReleaseYear = 1957},
        new IMDBTopTenModel {Id = 6, Title = "The Lord Of The Rings: Return Of The King", Director = "Peter Jackson", ReleaseYear = 2003},
        new IMDBTopTenModel {Id = 7, Title = "Schindler's List", Director= "Steven Spielberg", ReleaseYear = 1993},
        new IMDBTopTenModel {Id = 8, Title = "Pulp Fiction", Director = "Quentin Tarantino", ReleaseYear = 1994},
        new IMDBTopTenModel {Id = 9, Title = "The Lord Of The Rings: The Fellowship Of The Ring", Director = "Peter Jackson", ReleaseYear = 2001},
        new IMDBTopTenModel {Id = 10, Title = "The Good, the Bad and the Ugly", Director = "Sergio Leone", ReleaseYear = 1966}
    };

    public IMDBTopTenController(AppDbContext context)
    {
        _context = context;

        if (!_context.IMDBTopTen.Any())
        {
            _context.IMDBTopTen.AddRange(_IMDBTopTen);
            _context.SaveChanges();
        }
    }

    [HttpGet]
    public IEnumerable<IMDBTopTenModel> Get()
    {
        return _context.IMDBTopTen.ToList();
    }
}