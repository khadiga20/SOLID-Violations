using System;

public interface IMessageService
{
    void Send();
}

public class EmailService : IMessageService
{
    public void Send() => Console.WriteLine("Email sent.");
}

public class SMSService : IMessageService
{
    public void Send() => Console.WriteLine("SMS sent.");
}

public class Notification
{
    private readonly IMessageService messageService;

    public Notification(IMessageService msg)
    {
        messageService = msg;
    }

    public void Notify() => messageService.Send();
}

class ProgramDIPGood
{
    static void Main()
    {
        var n = new Notification(new EmailService());
        n.Notify();
    }
}
