public class MockUsers
{
    public required int Id { get; set; }
    public required string Username { get; set; }
    /// <summary>
    /// @@@@@ 
    /// Remember to hash this before pushing it to database
    /// @@@@@
    /// </summary>
    public required string Password { get; set; }

}