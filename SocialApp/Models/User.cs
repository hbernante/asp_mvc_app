namespace SocialApp.Models;

public class User
{
    public int Id { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public required string Email { get; set; }

    public required string Password { get; set; }

    public string? ProfilePicture { get; set; }

    public string? Bio { get; set; }

    public string? Website { get; set; }

    public string? Hobbies { get; set; }

    public string? Location { get; set; }
}
