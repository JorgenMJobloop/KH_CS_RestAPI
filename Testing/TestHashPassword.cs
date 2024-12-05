using System;
/// <summary>
/// Internal test class, that test the HashPassword utility security class, check for collision, and verify that each ID, Username has the correct corresponding hash that we expect!
/// </summary>
public class TestHashPassword
{
    public NonstaticHashPassword nonstaticHashPassword;
    public int ID;
    public string Username;
    public string Password;

    public TestHashPassword(NonstaticHashPassword hash, int id, string username, string password)
    {
        hash = nonstaticHashPassword;
        id = ID;
        username = Username;
        password = Password;

    }

}