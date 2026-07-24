using System;

namespace StudentAdmissionManagement
{
class Student
{
// Private Data Members (Encapsulation)
private int studentId;
private string studentName;
private int age;
private string course;

// Default Constructor
public Student()
{
studentId = 0;
studentName = "Not Assigned";
age = 0;
course = "Not Selected";
}

// Parameterized Constructor
public Student(int id, string name, int age, string course)
{
this.studentId = id;
this.studentName = name;
this.age = age;
this.course = course;
}

// Public Method to Display Student Details
public void DisplayDetails()
{
Console.WriteLine("\n----- Student Admission Details -----");
Console.WriteLine("Student ID   : " + studentId);
Console.WriteLine("Student Name : " + studentName);
Console.WriteLine("Age          : " + age);
Console.WriteLine("Course       : " + course);
}
}

class Program
{
static void Main(string[] args)
{
Console.WriteLine("=== Student Admission Management System ===");

Console.Write("Enter Student ID: ");
int id = Convert.ToInt32(Console.ReadLine());

Console.Write("Enter Student Name: ");
string name = Console.ReadLine();

Console.Write("Enter Age: ");
int age = Convert.ToInt32(Console.ReadLine());

Console.Write("Enter Course: ");
string course = Console.ReadLine();

// Object Creation
Student student = new Student(id, name, age, course);

// Calling Method
student.DisplayDetails();

Console.WriteLine("\nAdmission Successfully Completed!");
Console.ReadKey();
     }
  }
}
