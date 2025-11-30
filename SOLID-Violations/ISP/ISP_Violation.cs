using System;

public interface IWorker
{
    void Work();
    void Eat();
}

public class Robot : IWorker
{
    public void Work() => Console.WriteLine("Robot working");
    public void Eat() => throw new NotImplementedException();
}

class ProgramISPBad
{
    static void Main()
    {
        IWorker r = new Robot();
        r.Work();
    }
}
