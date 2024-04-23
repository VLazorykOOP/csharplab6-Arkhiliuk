using System;

public interface IDisplayable
{
    void Show();
}

public interface INameAge
{
    string Name { get; set; }
    int Age { get; set; }
}

public class Person : INameAge, IDisplayable
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
        Console.WriteLine("Person constructor called.");
    }

    public virtual void Show()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}");
    }

    ~Person()
    {
        Console.WriteLine("Person destructor called.");
    }
}

public class Employee : Person
{
    public string Position { get; set; }

    public Employee(string name, int age, string position)
        : base(name, age)
    {
        Position = position;
        Console.WriteLine("Employee constructor called.");
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Position: {Position}");
    }

    ~Employee()
    {
        Console.WriteLine("Employee destructor called.");
    }
}

public class Worker : Employee
{
    public string Department { get; set; }

    public Worker(string name, int age, string position, string department)
        : base(name, age, position)
    {
        Department = department;
        Console.WriteLine("Worker constructor called.");
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Department: {Department}");
    }

    ~Worker()
    {
        Console.WriteLine("Worker destructor called.");
    }
}

public class Engineer : Employee
{
    public string Field { get; set; }

    public Engineer(string name, int age, string position, string field)
        : base(name, age, position)
    {
        Field = field;
        Console.WriteLine("Engineer constructor called.");
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Field of expertise: {Field}");
    }

    ~Engineer()
    {
        Console.WriteLine("Engineer destructor called.");
    }
}

public interface IFunction
{
    double Calculate(double x);
}

public class Line : IFunction
{
    public double A { get; set; }
    public double B { get; set; }

    public Line(double a, double b)
    {
        A = a;
        B = b;
    }

    public double Calculate(double x)
    {
        return A * x + B;
    }

    public override string ToString()
    {
        return $"Line: y = {A}x + {B}";
    }
}

public class Quadratic : IFunction
{
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }

    public Quadratic(double a, double b, double c)
    {
        A = a;
        B = b;
        C = c;
    }

    public double Calculate(double x)
    {
        return A * x * x + B * x + C;
    }

    public override string ToString()
    {
        return $"Quadratic: y = {A}x^2 + {B}x + {C}";
    }
}

public class Hyperbola : IFunction
{
    public double A { get; set; }
    public double B { get; set; }

    public Hyperbola(double a, double b)
    {
        A = a;
        B = b;
    }

    public double Calculate(double x)
    {
        return A / x + B;
    }

    public override string ToString()
    {
        return $"Hyperbola: y = {A}/x + {B}";
    }
}

class Program
{
    static void Main()
    {
        Person p = new Person("John", 30);
        Worker w = new Worker("Alice", 28, "Manager", "Sales");
        Engineer e = new Engineer("Bob", 35, "Senior Engineer", "Electronics");

        p.Show();
        w.Show();
        e.Show();
        
        IFunction[] functions = new IFunction[]
        {
            new Line(1, 2),
            new Quadratic(1, -2, 1),
            new Hyperbola(4, -1)
        };

        Console.WriteLine("Enter the value of x:");
        double x = Convert.ToDouble(Console.ReadLine());

        foreach (var func in functions)
        {
            Console.WriteLine($"{func} at x = {x}: {func.Calculate(x)}");
        }
    }
}
