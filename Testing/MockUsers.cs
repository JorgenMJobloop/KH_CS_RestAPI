/// <summary>
/// A test module class, that work as a mockup for a User model and a User table in the database context
/// </summary>
public class MockUsers
{
    /// <summary>
    /// The unique identifier (primary key in context)
    /// </summary>
    public required int Id { get; set; }
    /// <summary>
    /// Plaintext username
    /// </summary>
    public required string Username { get; set; }
    /// <summary>
    /// Input: plaintext password
    /// Output: SHA256 Hash
    /// @@@@@ 
    /// Remember to hash this before pushing it to database
    /// @@@@@
    /// </summary>
    public required string Password { get; set; }

}