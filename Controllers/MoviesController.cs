using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/movies")]

public class MoviesController : ControllerBase
{
    // created the default data on our GET endpoint
    private static List<Movies> movies = new List<Movies> {
        new Movies {Id = 1, Title = "The Shawshank Redemption", Director = "Frank Darabont", ReleaseYear = 1994},
        new Movies {Id = 2, Title = "The Godfather", Director = "Francis Ford Coppola", ReleaseYear = 1972},
        new Movies {Id = 3, Title = "Schindlers List", Director = "Steven Spielberg", ReleaseYear = 1993},
        new Movies {Id = 4, Title = "Pulp Fiction", Director = "Quentin Tarantino", ReleaseYear = 1994},
        new Movies {Id = 5, Title = "The Good, The Bad and The Ugly", Director = "Sergio Leone", ReleaseYear = 1966},
        new Movies {Id = 6, Title = "Fight Club", Director = "David Fincher", ReleaseYear = 1999}
    };

    // create the GET endpoint
    [HttpGet]
    public IEnumerable<Movies> Get()
    {
        return movies;
    }
    // create the POST endpoint
    [HttpPost]
    public IActionResult Post([FromBody] Movies _movies)
    {
        if (movies == null)
        {
            return BadRequest("Client error occured!");
        }
        movies.Add(_movies);
        return CreatedAtAction(nameof(Post), new { id = _movies.Id, Title = _movies.Title, Director = _movies.Director, ReleaseYear = _movies.ReleaseYear }, _movies);
    }
}