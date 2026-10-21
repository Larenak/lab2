using System;
using System.IO;

namespace ConsoleApp;

// Задание 5.2.
public class Cat
{
    private string _name;

    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(
                    "Имя кота не должно быть пустым.",
                    nameof(value));
            }

            _name = value.Trim();
        }
    }

    public Cat(string name)
    {
        Name = name;
    }

    public static string ReadName()
    {
        while (true)
        {
            Console.Write("Имя кота: ");
            string input = Console.ReadLine();

            if (input == null)
            {
                throw new EndOfStreamException();
            }

            if (!string.IsNullOrWhiteSpace(input))
            {
                return input.Trim();
            }

            Console.WriteLine("Поле не должно быть пустым.");
        }
    }

    public static int ReadCount()
    {
        while (true)
        {
            Console.Write("Число повторений: ");
            string input = Console.ReadLine();

            if (input == null)
            {
                throw new EndOfStreamException();
            }

            if (int.TryParse(input, out int count)
                && count > 0)
            {
                return count;
            }

            Console.WriteLine(
                "Введите целое число от 1 до 2147483647.");
        }
    }

    public void Meow()
    {
        Meow(1);
    }

    public void Meow(int count)
    {
        if (count <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(count),
                "Число повторений должно быть положительным.");
        }

        Console.Write($"{Name}: ");

        for (var i = 0; i < count; i++)
        {
            if (i > 0)
            {
                Console.Write('-');
            }

            Console.Write("мяу");
        }

        Console.WriteLine('!');
    }

    public override string ToString()
    {
        return $"кот: {Name}";
    }
}
