using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/tvshows")]
public class TVShowsController : ControllerBase
{
    private readonly AppDbContext _context;

    // static assignment of our GET-endpoint data
    private static List<TVShows> _TVShows = new List<TVShows> {
        new TVShows {Id = 1, Title = "The Sopranos", Creators = "David Chase", ReleaseYear = 1999, NumberOfSeasons = 6},
        new TVShows {Id = 2, Title = "Breaking Bad", Creators = "Vince Gilligan", ReleaseYear = 2008, NumberOfSeasons = 5},
        new TVShows {Id = 3, Title = "Game Of Thrones", Creators = "David Benioff & D.B Weiss", ReleaseYear = 2011, NumberOfSeasons = 8},
        new TVShows {Id = 4, Title = "Twin Peaks", Creators = "David Lynch & Mark Frost", ReleaseYear = 1990, NumberOfSeasons = 2},
        new TVShows {Id = 5, Title = "The Wire", Creators = "David Simon", ReleaseYear = 2002, NumberOfSeasons = 5},
        new TVShows {Id = 6, Title = "Arcane", Creators = "Christian Linke and Alex Yee", ReleaseYear = 2021, NumberOfSeasons = 2},
        new TVShows {Id = 7, Title = "Brooklyn 99", Creators = "Dan Goor & Michael Schur", ReleaseYear = 2013, NumberOfSeasons = 8},
        new TVShows {Id = 8, Title = "Hotel Cæsar", Creators = "Peter Emanuel Falck & Christian Wikander", ReleaseYear = 1998, NumberOfSeasons = 34},
        new TVShows {Id = 9, Title = "Neon Genesis Evangelion", Creators = "Hideaki Ano", ReleaseYear = 1995, NumberOfSeasons = 1},
        new TVShows {Id = 10, Title = "Jojo's Bizzare Adventure", Creators = "Hirohiko Araki", ReleaseYear = 2012, NumberOfSeasons = 5},
        new TVShows {Id = 11, Title = "The Walking Dead", Creators = "Frank Darabont", ReleaseYear = 2010, NumberOfSeasons = 11}
    };

    public TVShowsController(AppDbContext context)
    {
        _context = context;

        // add data to our database table for TVShows
        if (!_context.TVShows.Any())
        {
            _context.TVShows.AddRange(_TVShows);
            _context.SaveChanges();
        }
    }

    // defining our GET endpoint and returning out data
    [HttpGet]
    public IEnumerable<TVShows> Get()
    {
        return _context.TVShows.ToList();
    }

    // defining our POST endpoint and having users write data to our model
    [HttpPost]
    public IActionResult Post([FromBody] TVShows tvShows)
    {
        if (tvShows == null)
        {
            return BadRequest("Client side error occured!");
        }
        _context.Add(tvShows);
        _context.SaveChanges();
        return CreatedAtAction(nameof(Post), new { id = tvShows.Id, title = tvShows.Title, creators = tvShows.Creators, releaseYear = tvShows.ReleaseYear, numberOfSeasons = tvShows.NumberOfSeasons }, tvShows);
    }
}