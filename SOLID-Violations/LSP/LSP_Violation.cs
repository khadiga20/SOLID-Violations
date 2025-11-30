using System;

public class Bird
{
    public virtual void Fly() => Console.WriteLine("Flying");
}

public class Ostrich : Bird
{
    public override void Fly() => throw new Exception("Ostrich cannot fly!");
}

class ProgramLSPBad
{
    static void Main()
    {
        Bird b = new Ostrich();
        b.Fly(); // exception at runtime
    }
}
