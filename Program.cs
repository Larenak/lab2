using System;
using System.IO;
using System.Text;

namespace ConsoleApp;

internal static class Program
{
    private static void Main()
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Лабораторная работа №2. Вариант 3.");
        Console.WriteLine("Все данные вводятся с клавиатуры.");

        try
        {
            RunMenu();
        }
        catch (EndOfStreamException)
        {
            Console.WriteLine();
            Console.WriteLine("Ввод завершён. До свидания!");
        }
    }

    private static int ReadChoice()
    {
        while (true)
        {
            Console.Write("Ваш выбор: ");
            string input = Console.ReadLine();

            if (input == null)
            {
                throw new EndOfStreamException();
            }

            if (int.TryParse(input, out int choice)
                && choice >= 0 && choice <= 7)
            {
                return choice;
            }

            Console.WriteLine("Введите целое число от 0 до 7.");
        }
    }

    private static void RunMenu()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Выберите задачу:");
            Console.WriteLine("1 - Задание 1.3. Имена");
            Console.WriteLine(
                "2 - Задание 2.2. Человек с именем");
            Console.WriteLine(
                "3 - Задание 2.3. Человек с родителем");
            Console.WriteLine("4 - Задание 3.3. Города");
            Console.WriteLine("5 - Задание 4.5. Создаём имена");
            Console.WriteLine(
                "6 - Задание 4.6. Создаём человека");
            Console.WriteLine("7 - Задание 5.2. Кот мяукает");
            Console.WriteLine("0 - Выход");
            int choice = ReadChoice();
            Console.WriteLine();

            switch (choice)
            {
                case 0:
                    Console.WriteLine("До свидания!");
                    return;
                case 1:
                    RunNames();
                    break;
                case 2:
                    RunPeopleWithNames();
                    break;
                case 3:
                    RunPeopleWithFathers();
                    break;
                case 4:
                    RunCities();
                    break;
                case 5:
                    RunNameConstructors();
                    break;
                case 6:
                    RunPersonConstructors();
                    break;
                case 7:
                    RunCat();
                    break;
            }
        }
    }

    // Задание 1.3.
    private static void RunNames()
    {
        Console.WriteLine("Задание 1.3. Имена");
        Console.WriteLine(
            "Введите имена Клеопатры, Пушкина и Маяковского.");
        var names = new PersonName[3];

        for (var i = 0; i < names.Length; i++)
        {
            Console.WriteLine($"Имя №{i + 1}:");
            names[i] = PersonName.Read();
        }

        Console.WriteLine("Результат:");

        foreach (PersonName name in names)
        {
            Console.WriteLine(name);
        }
    }

    // Задание 2.2.
    private static void RunPeopleWithNames()
    {
        Console.WriteLine("Задание 2.2. Человек с именем");
        Console.WriteLine(
            "Введите Клеопатру (152), Пушкина (167),");
        Console.WriteLine("Маяковского (189).");
        var people = new Person[3];

        for (var i = 0; i < people.Length; i++)
        {
            Console.WriteLine($"Человек №{i + 1}:");
            PersonName name = PersonName.Read();
            int height = Person.ReadHeight();
            people[i] = new Person(name, height);
        }

        Console.WriteLine("Результат:");

        foreach (Person person in people)
        {
            Console.WriteLine(person);
        }
    }

    // Задание 2.3.
    private static void RunPeopleWithFathers()
    {
        Console.WriteLine("Задание 2.3. Человек с родителем");
        Console.WriteLine("Введите Чудова Ивана, Чудова Петра,");
        Console.WriteLine("Бориса без фамилии и отчества.");
        Console.WriteLine("Первый человек - отец второго,");
        Console.WriteLine("второй - отец третьего.");
        var people = new Person[3];

        for (var i = 0; i < people.Length; i++)
        {
            Console.WriteLine($"Человек №{i + 1}:");
            PersonName name = PersonName.Read();
            int height = Person.ReadHeight();
            Person father = null;

            if (i > 0)
            {
                father = people[i - 1];
            }

            people[i] = new Person(name, height, father);
        }

        Console.WriteLine("Результат:");

        foreach (Person person in people)
        {
            Console.WriteLine(person);
        }
    }

    // Задание 3.3.
    private static void RunCities()
    {
        Console.WriteLine("Задание 3.3. Города");
        Console.WriteLine(
            "Введите названия городов A, B, C, D, E, F.");
        var cities = new City[6];

        for (var i = 0; i < cities.Length; i++)
        {
            string name = City.ReadName(
                $"Название города {(char)('A' + i)}");
            cities[i] = new City(name);
        }

        Console.WriteLine(
            "Введите стоимости дорог с рисунка 2.");
        Console.WriteLine(
            "Стрелка показывает направление пути.");
        cities[0].ReadRoute(cities[1], true);
        cities[0].ReadRoute(cities[5], false);
        cities[5].ReadRoute(cities[1], false);
        cities[1].ReadRoute(cities[2], true);
        cities[2].ReadRoute(cities[3], true);
        cities[3].ReadRoute(cities[4], false);
        cities[4].ReadRoute(cities[5], true);
        cities[0].ReadRoute(cities[3], true);
        Console.WriteLine("Результат:");

        foreach (City city in cities)
        {
            Console.WriteLine(city);
        }
    }

    // Задание 4.5.
    private static void RunNameConstructors()
    {
        Console.WriteLine("Задание 4.5. Создаём имена");
        Console.WriteLine("Введите данные четырёх имён.");
        Console.WriteLine("1. Клеопатра: только личное имя.");
        string firstName = PersonName.ReadPart(
            "Личное имя", false);
        var first = new PersonName(firstName);
        Console.WriteLine("2. Пушкин Александр Сергеевич.");
        firstName = PersonName.ReadPart(
            "Личное имя", false);
        string lastName = PersonName.ReadPart(
            "Фамилия", false);
        string patronymic = PersonName.ReadPart(
            "Отчество", false);
        var second = new PersonName(
            firstName, lastName, patronymic);
        Console.WriteLine("3. Маяковский Владимир.");
        firstName = PersonName.ReadPart(
            "Личное имя", false);
        lastName = PersonName.ReadPart("Фамилия", false);
        var third = new PersonName(firstName, lastName);
        Console.WriteLine("4. Христофор, фамилия Бонифатьевич.");
        firstName = PersonName.ReadPart(
            "Личное имя", false);
        lastName = PersonName.ReadPart("Фамилия", false);
        var fourth = new PersonName(firstName, lastName);
        Console.WriteLine("Результат:");
        Console.WriteLine(first);
        Console.WriteLine(second);
        Console.WriteLine(third);
        Console.WriteLine(fourth);
    }

    // Задание 4.6.
    private static void RunPersonConstructors()
    {
        Console.WriteLine("Задание 4.6. Создаём человека");
        Console.WriteLine(
            "1. Лев, рост 170. Имя задаётся строкой.");
        string firstName = PersonName.ReadPart(
            "Личное имя", false);
        int height = Person.ReadHeight();
        var first = new Person(firstName, height);
        Console.WriteLine(
            "2. Пушкин Сергей, рост 168. Отец - Лев.");
        Console.WriteLine("Имя задаётся объектом PersonName.");
        PersonName name = PersonName.Read();
        height = Person.ReadHeight();
        var second = new Person(name, height, first);
        Console.WriteLine(
            "3. Александр, рост 167. Отец - Сергей.");
        Console.WriteLine("Имя задаётся строкой.");
        firstName = PersonName.ReadPart(
            "Личное имя", false);
        height = Person.ReadHeight();
        var third = new Person(firstName, height, second);
        Console.WriteLine("Результат:");
        Console.WriteLine(first);
        Console.WriteLine(second);
        Console.WriteLine(third);
        Console.WriteLine(
            "Четвёртый способ: объект имени без отца.");
        var withoutFather = new Person(
            new PersonName(firstName), height);
        Console.WriteLine(withoutFather);
    }

    // Задание 5.2.
    private static void RunCat()
    {
        Console.WriteLine("Задание 5.2. Кот мяукает");
        Console.WriteLine(
            "Введите имя Барсик и число повторений 3.");
        string name = Cat.ReadName();
        int count = Cat.ReadCount();
        var cat = new Cat(name);
        Console.WriteLine("Результат:");
        Console.WriteLine(cat);
        cat.Meow();
        cat.Meow(count);
    }
}
