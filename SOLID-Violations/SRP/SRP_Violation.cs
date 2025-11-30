using System;

public class UserService
{
    public void RegisterUser(string name)
    {
        // 1. Save user
        Console.WriteLine("Saving user to database...");

        // 2. Send email
        Console.WriteLine("Sending welcome email...");

        // 3. Log actions
        Console.WriteLine("Logging: User registered.");
    }
}

// Simple demo runner
class ProgramSRPBad
{
    static void Main()
    {
        var s = new UserService();
        s.RegisterUser("Alice");
    }
}
