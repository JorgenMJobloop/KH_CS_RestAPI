using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/testing/users")]
public class TestController : ControllerBase
{

    private readonly AppDbContext _context;
    // private TestHashPassword testHashPassword;
    // private NonstaticHashPassword nonstaticHashPassword;
    // private List<TestHashPassword> testHashPasswordList;

    private List<MockUsers> testUserTables = new List<MockUsers> {
        new MockUsers {Id = 1, Username = "John Doe", Password = HashPassword.ComputeSHA256Hash("test1234")},
        new MockUsers {Id = 2, Username = "Jane Doe", Password = HashPassword.ComputeSHA256Hash("test12345")},
        new MockUsers {Id = 3, Username = "John Smith", Password = HashPassword.ComputeSHA256Hash("afjkasfjask4123124jksdjfksd")},
        new MockUsers {Id = 4, Username = "Jane Smith", Password = HashPassword.ComputeSHA256Hash("afjkasfjask4123124jksdjfksd")}
    };



    public TestController(AppDbContext context)
    {
        // _nonstaticHashPassword = nonstaticHashPassword;
        // testHashPasswordList = new List<TestHashPassword> { testHash.ID = 1, testHash.Username = "test", testHash.Password = "test1234" };
        _context = context;
        if (!_context.TestModel.Any())
        {
            _context.TestModel.AddRange(testUserTables);
            _context.SaveChanges();
        }
    }



    // [HttpGet("/testhash")]
    // public IEnumerable<TestHashPassword> GetTestHashes()
    // {
    //     return testHashPassword;
    // }

    // simple GET-endpoint using an IEnumerable
    [HttpGet]
    public ActionResult<IEnumerable<MockUsers>> Get()
    {
        return _context.TestModel.ToList();
    }

    [HttpPost]
    public IActionResult Post([FromBody] MockUsers _testModel)
    {
        if (_testModel == null)
        {
            return BadRequest("There was an error appending data to the server!");
        }

        var obj = new MockUsers
        {
            Id = _testModel.Id,
            Username = _testModel.Username,
            Password = HashPassword.ComputeSHA256Hash(_testModel.Password)
        };

        _context.TestModel.Add(obj);
        _context.SaveChanges();
        return CreatedAtAction(nameof(Post), obj);
    }
}