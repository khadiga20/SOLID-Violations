using System;

public class UserRepository
{
    public void Save(string name) => Console.WriteLine("User saved.");
}

public class EmailService
{
    public void SendWelcome(string name) => Console.WriteLine("Email sent.");
}

public class Logger
{
    public void Log(string msg) => Console.WriteLine(msg);
}

public class UserService
{
    private UserRepository repo = new();
    private EmailService email = new();
    private Logger logger = new();

    public void RegisterUser(string name)
    {
        repo.Save(name);
        email.SendWelcome(name);
        logger.Log("User registered.");
    }
}

class ProgramSRPGood
{
    static void Main()
    {
        var s = new UserService();
        s.RegisterUser("Alice");
    }
}
