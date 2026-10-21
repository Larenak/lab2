using System;
using System.IO;

namespace ConsoleApp;

// Задание 1.3.
/*
public class PersonName
{
    private string _firstName;
    private string _lastName;
    private string _patronymic;

    public string FirstName
    {
        get
        {
            return _firstName;
        }
        set
        {
            _firstName = NormalizePart(value);
        }
    }

    public string LastName
    {
        get
        {
            return _lastName;
        }
        set
        {
            _lastName = NormalizePart(value);
        }
    }

    public string Patronymic
    {
        get
        {
            return _patronymic;
        }
        set
        {
            _patronymic = NormalizePart(value);
        }
    }

    public PersonName(
        string firstName, string lastName, string patronymic)
    {
        FirstName = firstName;
        LastName = lastName;
        Patronymic = patronymic;
    }

    public static string ReadPart(
        string prompt, bool allowEmpty)
    {
        while (true)
        {
            Console.Write($"{prompt}: ");
            string input = Console.ReadLine();

            if (input == null)
            {
                throw new EndOfStreamException();
            }

            input = input.Trim();

            if (allowEmpty || input.Length > 0)
            {
                return input;
            }

            Console.WriteLine("Поле не должно быть пустым.");
        }
    }

    public static PersonName Read()
    {
        Console.WriteLine(
            "Чтобы пропустить часть имени, нажмите Enter.");
        string firstName = ReadPart("Личное имя", true);
        string lastName = ReadPart("Фамилия", true);
        string patronymic = ReadPart("Отчество", true);
        return new PersonName(firstName, lastName, patronymic);
    }

    private static string NormalizePart(string value)
    {
        if (value == null)
        {
            return string.Empty;
        }

        return value.Trim();
    }

    public override string ToString()
    {
        string result = string.Empty;

        if (LastName.Length > 0)
        {
            result += LastName + " ";
        }

        if (FirstName.Length > 0)
        {
            result += FirstName + " ";
        }

        if (Patronymic.Length > 0)
        {
            result += Patronymic;
        }

        return result.TrimEnd();
    }
}
*/

// Задание 4.5.
public class PersonName
{
    private string _firstName;
    private string _lastName;
    private string _patronymic;

    public string FirstName
    {
        get
        {
            return _firstName;
        }
        set
        {
            _firstName = NormalizePart(value);
        }
    }

    public string LastName
    {
        get
        {
            return _lastName;
        }
        set
        {
            _lastName = NormalizePart(value);
        }
    }

    public string Patronymic
    {
        get
        {
            return _patronymic;
        }
        set
        {
            _patronymic = NormalizePart(value);
        }
    }

    public PersonName(
        string firstName, string lastName, string patronymic)
    {
        FirstName = firstName;
        LastName = lastName;
        Patronymic = patronymic;
    }

    public PersonName(string firstName)
        : this(firstName, string.Empty, string.Empty)
    {
    }

    public PersonName(string firstName, string lastName)
        : this(firstName, lastName, string.Empty)
    {
    }

    public static string ReadPart(
        string prompt, bool allowEmpty)
    {
        while (true)
        {
            Console.Write($"{prompt}: ");
            string input = Console.ReadLine();

            if (input == null)
            {
                throw new EndOfStreamException();
            }

            input = input.Trim();

            if (allowEmpty || input.Length > 0)
            {
                return input;
            }

            Console.WriteLine("Поле не должно быть пустым.");
        }
    }

    public static PersonName Read()
    {
        Console.WriteLine(
            "Чтобы пропустить часть имени, нажмите Enter.");
        string firstName = ReadPart("Личное имя", true);
        string lastName = ReadPart("Фамилия", true);
        string patronymic = ReadPart("Отчество", true);
        return new PersonName(firstName, lastName, patronymic);
    }

    private static string NormalizePart(string value)
    {
        if (value == null)
        {
            return string.Empty;
        }

        return value.Trim();
    }

    public override string ToString()
    {
        string result = string.Empty;

        if (LastName.Length > 0)
        {
            result += LastName + " ";
        }

        if (FirstName.Length > 0)
        {
            result += FirstName + " ";
        }

        if (Patronymic.Length > 0)
        {
            result += Patronymic;
        }

        return result.TrimEnd();
    }
}
