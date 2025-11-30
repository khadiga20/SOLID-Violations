using System;

public abstract class Bird { }
public abstract class FlyingBird : Bird
{
    public abstract void Fly();
}

public class Sparrow : FlyingBird
{
    public override void Fly() => Console.WriteLine("Sparrow flying");
}

public class Ostrich : Bird
{
    // No Fly() method needed
}

class ProgramLSPGood
{
    static void Main()
    {
        FlyingBird f = new Sparrow();
        f.Fly();
    }
}
