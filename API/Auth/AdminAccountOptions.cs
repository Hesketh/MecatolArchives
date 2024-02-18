namespace Hesketh.MecatolArchives.API.Auth;

public class AdminAccountOptions
{
    public const string SectionName = "Admin";

    public AdminAccount? Account { get; set; } = null;

    public void Validate()
    {
        if (Account == null)
            throw new InvalidOperationException("No admin account details specified");

        if (string.IsNullOrWhiteSpace(Account.Username))
            throw new InvalidOperationException($"Admin account does not have a valid username");

        if (string.IsNullOrEmpty(Account.Username))
            throw new InvalidOperationException($"Admin account does not have a valid password");
    }
}

public sealed class AdminAccount
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}