namespace BookOfNuffle.WebAPI.Auth;

public class AdminAccountOptions
{
    public const string SectionName = "Admin";

    public AdminAccount[] Accounts { get; set; } = Array.Empty<AdminAccount>();

    public void Validate()
    {
        if (Accounts.Length == 0)
            throw new InvalidOperationException("No admin account details specified");

        if (Accounts.Any(x =>
                Accounts.Count(y => y.Username.Equals(x.Username, StringComparison.InvariantCultureIgnoreCase)) > 1))
            throw new InvalidOperationException("Duplicate username specified");

        for (var index = 0; index < Accounts.Length; index++)
        {
            var adminAccount = Accounts[index];
            if (string.IsNullOrWhiteSpace(adminAccount.Username))
                throw new InvalidOperationException($"Admin account at index {index} does not have a valid username");

            if (string.IsNullOrEmpty(adminAccount.Username))
                throw new InvalidOperationException($"Admin account at index {index} does not have a valid password");
        }
    }
}

public class AdminAccount
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}