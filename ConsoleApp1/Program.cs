using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement
{
    class Program
    {
        static List<Person> people = new List<Person>();

        static void Main(string[] args)
        {
            while (true)
            {
                ShowMenu();
                string choice = Console.ReadLine().Trim();

                switch (choice)
                {
                    case "1":
                        AddEmployee();
                        break;
                    case "2":
                        AddManager();
                        break;
                    case "3":
                        ListPeople();
                        break;
                    case "4":
                        SearchByName();
                        break;
                    case "5":
                        Console.WriteLine("Exiting... Good bye!");
                        return;
                    default:
                        Console.WriteLine("Invalid option, try again.");
                        Pause();
                        break;
                }
            }
        }

        static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("=== Employee Management ===");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Add Manager");
            Console.WriteLine("3. List All People");
            Console.WriteLine("4. Search by Name");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option (1-5): ");
        }

        // قراءة نص غير فارغ
        static string ReadNonEmpty(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine() ?? "";
                if (!string.IsNullOrWhiteSpace(input)) return input.Trim();
                Console.WriteLine("The value cannot be empty. Try again..");
            }
        }

        // قراءة integer مع تحقق
        static int ReadInt(string prompt, int min = int.MinValue, int max = int.MaxValue)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int value) && value >= min && value <= max)
                    return value;
                Console.WriteLine("Enter a valid number. Try again..");
            }
        }

        // قراءة double مع تحقق
        static double ReadDouble(string prompt, double min = double.MinValue, double max = double.MaxValue)
        {
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out double value) && value >= min && value <= max)
                    return value;
                Console.WriteLine("Enter a valid number (may be a decimal). Try again..");
            }
        }

        static void AddEmployee()
        {
            Console.WriteLine("\n--- Add Employee ---");
            string name = ReadNonEmpty("Name: ");
            int age = ReadInt("Age: ", 1, 120);
            double salary = ReadDouble("Salary: ", 0);
            string dept = ReadNonEmpty("Department: ");

            people.Add(new Employee(name, age, salary, dept));
            Console.WriteLine("Employee added successfully.");
            Pause();
        }

        static void AddManager()
        {
            Console.WriteLine("\n--- Add Manager ---");
            string name = ReadNonEmpty("Name: ");
            int age = ReadInt("Age: ", 1, 120);
            double bonus = ReadDouble("Bonus: ", 0);
            int teamSize = ReadInt("Team Size: ", 0);

            people.Add(new Manager(name, age, bonus, teamSize));
            Console.WriteLine("Manager added successfully.");
            Pause();
        }

        static void ListPeople()
        {
            Console.WriteLine("\n--- All People ---");
            if (!people.Any())
            {
                Console.WriteLine("No people added yet.");
            }
            else
            {
                int i = 1;
                foreach (var p in people)
                {
                    Console.Write($"{i++}. ");
                    p.ShowInfo();
                }
            }
            Pause();
        }

        static void SearchByName()
        {
            Console.WriteLine("\n--- Search by Name ---");
            string q = ReadNonEmpty("Enter name to search: ");
            var results = people
                .Where(p => p.Name.IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            if (!results.Any())
            {
                Console.WriteLine("No matches found.");
            }
            else
            {
                Console.WriteLine($"Found {results.Count} result(s):");
                foreach (var r in results) r.ShowInfo();
            }
            Pause();
        }

        static void Pause()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);
        }
    }
}
