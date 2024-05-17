using System;
using System.Collections.Generic;

public interface IUchit
{
    void uchit();
}

public class Person
{
    public string Name {get; set;}
    public int Age {get; set;}
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
    public virtual void inf()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}");
    }
}
public class Professor : Person, IUchit
{
    public string Sub {get; set;}
    public Professor(string name, int age, string sub) : base(name, age)
    {
        Sub = sub;
    }

    public void uchit()
    {
        Console.WriteLine($"{Name} prepodaet {Sub}.");
    }

    public override void inf()
    {
        base.inf();
        Console.WriteLine($"Predmet: {Sub}");
    }
}

public class Student : Person
{
    public List<string> Predmeti {get; set;}

    public Student(string name, int age) : base(name, age)
    {
        Predmeti = new List<string>();
    }

    public void zapis(string predm)
    {
        Predmeti.Add(predm);
        Console.WriteLine($"{Name} zapisalsya na {predm}.");
    }

    public override void inf()
    {
        base.inf();
        Console.WriteLine($"Predmeti: {string.Join(", ", Predmeti)}"); 
    }
}

class Program
{
    static void Main()
    {
        Professor professor = new Professor("Ryan Gosling", 38, "Video editing");
        Student student = new Student("Pavel", 17);

        professor.uchit();
        professor.inf();

        student.zapis("Video Editing Basics");
        student.zapis("Working whith sound in Video");
        student.inf();
    }
}