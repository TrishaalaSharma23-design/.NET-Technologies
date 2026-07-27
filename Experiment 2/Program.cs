/* Design Employee Payroll System using Inheritance, Interface &amp; Polymorphism */

using System;

interface IPayroll
{
    void CalculateSalary();
}

class Employee
{
    public int Id;
    public string Name;
    public double Salary;

    public void GetData()
    {
        Console.Write("Enter Employee ID: ");
        Id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Employee Name: ");
        Name = Console.ReadLine();

        Console.Write("Enter Basic Salary: ");
        Salary = Convert.ToDouble(Console.ReadLine());
    }

    public void ShowData()
    {
        Console.WriteLine("\nID: " + Id);
        Console.WriteLine("Name: " + Name);
    }
}

class Manager : Employee, IPayroll
{
    public void CalculateSalary()
    {
        ShowData();
        Console.WriteLine("Role: Manager");
        Console.WriteLine("Total Salary: " + (Salary + 5000));
    }
}

class Developer : Employee, IPayroll
{
    public void CalculateSalary()
    {
        ShowData();
        Console.WriteLine("Role: Developer");
        Console.WriteLine("Total Salary: " + (Salary + 3000));
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("1. Manager");
        Console.WriteLine("2. Developer");
        Console.Write("Choose Employee Type: ");
        int choice = Convert.ToInt32(Console.ReadLine());

        if (choice == 1)
        {
            Manager m = new Manager();
            m.GetData();
            m.CalculateSalary();
        }
        else
        {
            Developer d = new Developer();
            d.GetData();
            d.CalculateSalary();
        }

        Console.ReadLine();
    }
}
