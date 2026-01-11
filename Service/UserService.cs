public class UserService
{
    public User? CurrentUser { get; private set; }

    // TEMP storage (later → database)
    private readonly List<User> users = new();

    public bool IsLoggedIn => CurrentUser != null;

    public bool Signup(string name, string email, string password)
    {
        if (users.Any(u => u.Email == email))
            return false;

        users.Add(new User
        {
            Name = name,
            Email = email,
            Password = password
        });

        return true;
    }

    public bool Login(string email, string password)
    {
        var user = users.FirstOrDefault(
            u => u.Email == email && u.Password == password
        );

        if (user == null)
            return false;

        CurrentUser = user;
        return true;
    }

    public void Logout()
    {
        CurrentUser = null;
    }
}
