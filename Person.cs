using System;
using System.IO;

namespace ConsoleApp;

// Задание 2.2.
/*
public class Person
{
    private PersonName _name;
    private int _height;

    public PersonName Name
    {
        get
        {
            return _name;
        }
        set
        {
            ArgumentNullException.ThrowIfNull(value);
            _name = value;
        }
    }

    public int Height
    {
        get
        {
            return _height;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    "Рост должен быть положительным.");
            }

            _height = value;
        }
    }

    public Person(PersonName name, int height)
    {
        Name = name;
        Height = height;
    }

    public static int ReadHeight()
    {
        while (true)
        {
            Console.Write("Рост в сантиметрах: ");
            string input = Console.ReadLine();

            if (input == null)
            {
                throw new EndOfStreamException();
            }

            if (int.TryParse(input, out int height)
                && height > 0)
            {
                return height;
            }

            Console.WriteLine(
                "Введите целое число от 1 до 2147483647.");
        }
    }

    public override string ToString()
    {
        return $"{Name}, рост: {Height}";
    }
}
*/

// Задание 2.3.
/*
public class Person
{
    private PersonName _name;
    private int _height;

    private readonly Person _father;

    public Person Father
    {
        get
        {
            return _father;
        }
    }

    public PersonName Name
    {
        get
        {
            return _name;
        }
        set
        {
            ArgumentNullException.ThrowIfNull(value);
            _name = value;
        }
    }

    public int Height
    {
        get
        {
            return _height;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    "Рост должен быть положительным.");
            }

            _height = value;
        }
    }

    public Person(PersonName name, int height)
        : this(name, height, null)
    {
    }

    public Person(PersonName name, int height, Person father)
    {
        Name = name;
        Height = height;
        _father = father;
        CompleteName();
    }

    public static int ReadHeight()
    {
        while (true)
        {
            Console.Write("Рост в сантиметрах: ");
            string input = Console.ReadLine();

            if (input == null)
            {
                throw new EndOfStreamException();
            }

            if (int.TryParse(input, out int height)
                && height > 0)
            {
                return height;
            }

            Console.WriteLine(
                "Введите целое число от 1 до 2147483647.");
        }
    }

    private void CompleteName()
    {
        if (Father == null)
        {
            return;
        }

        Father.CompleteName();

        if (Name.LastName.Length == 0)
        {
            Name.LastName = Father.Name.LastName;
        }

        if (Name.Patronymic.Length == 0
            && Father.Name.FirstName.Length > 0)
        {
            Name.Patronymic = Father.Name.FirstName + "ович";
        }
    }

    public override string ToString()
    {
        CompleteName();
        return $"{Name}, рост: {Height}";
    }
}
*/

// Задание 4.6.
public class Person
{
    private PersonName _name;
    private int _height;

    private readonly Person _father;

    public Person Father
    {
        get
        {
            return _father;
        }
    }

    public PersonName Name
    {
        get
        {
            return _name;
        }
        set
        {
            ArgumentNullException.ThrowIfNull(value);
            _name = value;
        }
    }

    public int Height
    {
        get
        {
            return _height;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    "Рост должен быть положительным.");
            }

            _height = value;
        }
    }

    public Person(PersonName name, int height)
        : this(name, height, null)
    {
    }

    public Person(PersonName name, int height, Person father)
    {
        Name = name;
        Height = height;
        _father = father;
        CompleteName();
    }

    public Person(string firstName, int height)
        : this(new PersonName(firstName), height, null)
    {
    }

    public Person(string firstName, int height, Person father)
        : this(new PersonName(firstName), height, father)
    {
    }

    public static int ReadHeight()
    {
        while (true)
        {
            Console.Write("Рост в сантиметрах: ");
            string input = Console.ReadLine();

            if (input == null)
            {
                throw new EndOfStreamException();
            }

            if (int.TryParse(input, out int height)
                && height > 0)
            {
                return height;
            }

            Console.WriteLine(
                "Введите целое число от 1 до 2147483647.");
        }
    }

    private void CompleteName()
    {
        if (Father == null)
        {
            return;
        }

        Father.CompleteName();

        if (Name.LastName.Length == 0)
        {
            Name.LastName = Father.Name.LastName;
        }

        if (Name.Patronymic.Length == 0
            && Father.Name.FirstName.Length > 0)
        {
            Name.Patronymic = Father.Name.FirstName + "ович";
        }
    }

    public override string ToString()
    {
        CompleteName();
        return $"{Name}, {Height}";
    }
}
