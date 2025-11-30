using System;

public abstract class Discount
{
    public abstract double Apply(double price);
}

public class StudentDiscount : Discount
{
    public override double Apply(double price) => price * 0.9;
}

public class VIPDiscount : Discount
{
    public override double Apply(double price) => price * 0.5;
}

public class DiscountService
{
    public double ApplyDiscount(Discount discount, double price) =>
        discount.Apply(price);
}

class ProgramOCPGood
{
    static void Main()
    {
        var svc = new DiscountService();
        Console.WriteLine(svc.ApplyDiscount(new VIPDiscount(), 100));
    }
}
