using System;

public interface IWork
{
    void Work();
}

public interface IEat
{
    void Eat();
}

public class Human : IWork, IEat
{
    public void Work() => Console.WriteLine("Human working");
    public void Eat() => Console.WriteLine("Human eating");
}

public class Robot : IWork
{
    public void Work() => Console.WriteLine("Robot working");
}

class ProgramISPGood
{
    static void Main()
    {
        IWork r = new Robot();
        r.Work();
    }
}
