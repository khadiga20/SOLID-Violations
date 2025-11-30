using System;

public class EmailService
{
    public void Send() => Console.WriteLine("Email sent.");
}

public class Notification
{
    private EmailService email = new();

    public void Notify() => email.Send();
}

class ProgramDIPBad
{
    static void Main()
    {
        var n = new Notification();
        n.Notify();
    }
}
