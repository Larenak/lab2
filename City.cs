using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp;

// Задание 3.3.
public class City
{
    private string _name;
    private readonly Dictionary<City, int> _routes;

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
                    "Название города не должно быть пустым.",
                    nameof(value));
            }

            _name = value.Trim();
        }
    }

    public Dictionary<City, int> Routes
    {
        get
        {
            return _routes;
        }
    }

    public City(string name)
    {
        Name = name;
        _routes = new Dictionary<City, int>();
    }

    public static string ReadName(string prompt)
    {
        while (true)
        {
            Console.Write($"{prompt}: ");
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

    public void AddRoute(City destination, int cost)
    {
        ArgumentNullException.ThrowIfNull(destination);

        if (cost < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(cost),
                "Стоимость не должна быть отрицательной.");
        }

        Routes[destination] = cost;
    }

    public void ReadRoute(City destination, bool isTwoWay)
    {
        ArgumentNullException.ThrowIfNull(destination);
        string arrow = "->";

        if (isTwoWay)
        {
            arrow = "<->";
        }

        int cost = ReadCost(
            $"Стоимость {Name} {arrow} {destination.Name}");
        AddRoute(destination, cost);

        if (isTwoWay)
        {
            destination.AddRoute(this, cost);
        }
    }

    private static int ReadCost(string prompt)
    {
        while (true)
        {
            Console.Write($"{prompt}: ");
            string input = Console.ReadLine();

            if (input == null)
            {
                throw new EndOfStreamException();
            }

            if (int.TryParse(input, out int cost)
                && cost >= 0)
            {
                return cost;
            }

            Console.WriteLine(
                "Введите целое число от 0 до 2147483647.");
        }
    }

    public override string ToString()
    {
        var result = new StringBuilder();
        result.Append(Name);
        result.Append(": [");

        var isFirst = true;

        foreach (KeyValuePair<City, int> route in Routes)
        {
            if (!isFirst)
            {
                result.Append(", ");
            }

            result.Append($"{route.Key.Name}:{route.Value}");
            isFirst = false;
        }

        result.Append(']');
        return result.ToString();
    }
}
