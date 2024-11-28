public class TestModel
{
    public required int Id { get; set; }
    public required string MockUsername { get; set; }
    /// <summary>
    /// @@@@@ 
    /// Remember to hash this before pushing it to database
    /// @@@@@
    /// </summary>
    public required string MockPassword { get; set; }
    /// <summary>
    /// Test for a number of different escape characters
    /// </summary>
    public char[]? EscapeCharacters { get; set; }
}