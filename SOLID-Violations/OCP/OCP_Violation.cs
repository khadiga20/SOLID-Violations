using System;

public class DiscountService
{
    public double GetDiscount(string type, double price)
    {
        if (type == "Normal") return price;
        if (type == "Student") return price * 0.9;
        if (type == "VIP") return price * 0.5;

        return price;
    }
}

class ProgramOCPBad
{
    static void Main()
    {
        var svc = new DiscountService();
        Console.WriteLine(svc.GetDiscount("VIP", 100));
    }
}
