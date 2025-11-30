# SOLID Principles Violations & Fixes (C# Examples)

A GitHub‑ready repository demonstrating **OOP violations of SOLID principles** in C#, including explanations and corrected versions.

---

## 📁 Repository Structure

```
SOLID-Violations/
│
├── README.md
├── SRP/
│   ├── SRP_Violation.cs
│   ├── SRP_Fix.cs
│
├── OCP/
│   ├── OCP_Violation.cs
│   ├── OCP_Fix.cs
│
├── LSP/
│   ├── LSP_Violation.cs
│   ├── LSP_Fix.cs
│
├── ISP/
│   ├── ISP_Violation.cs
│   ├── ISP_Fix.cs
│
└── DIP/
    ├── DIP_Violation.cs
    └── DIP_Fix.cs
```

---

# 1️⃣ Single Responsibility Principle (SRP)

## ❌ Violation (One class doing many jobs)

```csharp
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
```

### 🔍 Issue

This class **has multiple responsibilities**:

* Database
* Email
* Logging

Any change in one area forces modifications in this class.

## ✔️ Fix

```csharp
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
```

---

# 2️⃣ Open/Closed Principle (OCP)

## ❌ Violation

```csharp
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
```

### 🔍 Issue

To add new discount types, we **must modify this class**, violating OCP.

## ✔️ Fix

```csharp
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
```

---

# 3️⃣ Liskov Substitution Principle (LSP)

## ❌ Violation

```csharp
public class Bird
{
    public virtual void Fly() => Console.WriteLine("Flying");
}

public class Ostrich : Bird
{
    public override void Fly() => throw new Exception("Ostrich cannot fly!");
}
```

### 🔍 Issue

Derived class **changes base class behavior** → not substitutable.

## ✔️ Fix

```csharp
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
```

---

# 4️⃣ Interface Segregation Principle (ISP)

## ❌ Violation

```csharp
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
```

### 🔍 Issue

Robot is forced to implement a method it doesn't need.

## ✔️ Fix

```csharp
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
```

---

# 5️⃣ Dependency Inversion Principle (DIP)

## ❌ Violation

```csharp
public class EmailService
{
    public void Send() => Console.WriteLine("Email sent.");
}

public class Notification
{
    private EmailService email = new();

    public void Notify() => email.Send();
}
```

### 🔍 Issue

High-level module depends on **concrete class**, not abstraction.

## ✔️ Fix

```csharp
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
```

---

# ✅ Done!

You can copy this structure directly into a GitHub repo.
If you want, I can also:

* Generate the folder structure as downloadable ZIP
* Add a full README
* Add GitHub‑style documentation
* Add UML diagrams
