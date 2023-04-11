using System;
using System.Collections.Generic;
using System.Windows;

class Program
{
    static void Main(string[] args)
    {
        // Створення складових
        var geography = new Category("Географiя");
        var europe = new Category("Європа");
        var asia = new Category("Азiя");
        var ukraine = new Category("Україна");

        var europePhysicalGeography = new Lesson("Фiзична географiя Європи", 30);
        var europeanCulture = new Lesson("Культура країн Європи", 15);
        var asianCountries = new Lesson("Країни Азiї", 20);
        var ukrainianHistory = new Lesson("Iсторiя України", 25);
        var ukrainianGeography = new Lesson("Географiя України", 30);

        // Додавання складових до категорій
        europe.AddComponent(europePhysicalGeography);
        europe.AddComponent(europeanCulture);
        asia.AddComponent(asianCountries);
        ukraine.AddComponent(ukrainianHistory);
        ukraine.AddComponent(ukrainianGeography);

        geography.AddComponent(europe);
        geography.AddComponent(asia);
        geography.AddComponent(ukraine);

        // Вивід на екран
        geography.Display(1);
    }
}

abstract class Component
{
    protected string name;

    public Component(string name)
    {
        this.name = name;
    }

    public abstract void Display(int depth);
}

class Category : Component
{
    private List<Component> components = new List<Component>();

    public Category(string name) : base(name)
    {
    }

    public void AddComponent(Component component)
    {
        components.Add(component);
    }

    public override void Display(int depth)
    {
        Console.WriteLine(new string('-', depth) + name);

        foreach (Component component in components)
        {
            component.Display(depth + 2);
        }
    }
}

class Lesson : Component
{
    private int duration;

    public Lesson(string name, int duration) : base(name)
    {
        this.duration = duration;
    }

    public override void Display(int depth)
    {
        Console.WriteLine(new string('-', depth) + name + $" ({duration} годин)");
    }
}
