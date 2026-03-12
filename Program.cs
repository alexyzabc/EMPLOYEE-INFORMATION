using System;
using System.Collections.Generic;

internal class Program
{
    static List<string> ids = new List<string>();
    static List<string> names = new List<string>();
    static List<string> positions = new List<string>();
    static List<string> departments = new List<string>();
    static List<string> statuses = new List<string>();

    static List<string> hiringLog = new List<string>();
    static List<string> promotionLog = new List<string>();
    static List<string> movementLog = new List<string>();

    static void Main(string[] args)
    {
        Console.WriteLine("EMPLOYEE INFORMATION SYSTEM");

        bool running = true;

        while (running)
        {
            string[] options = new string[] { "Hire New Employee", "Promote Employee", "Transfer / Movement", "View All Employees", "View Employee History", "Search Employee" };
            ShowOptions(options);
            Console.WriteLine("[0] Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    HireEmployee();
                    break;
                case "2":
                    PromoteEmployee();
                    break;
                case "3":
                    Console.WriteLine("Feature coming soon.");
                    break;
                case "4":
                    Console.WriteLine("Feature coming soon.");
                    break;
                case "5":
                    Console.WriteLine("Feature coming soon.");
                    break;
                case "6":
                    Console.WriteLine("Feature coming soon.");
                    break;
                case "0":
                    Console.WriteLine("Exiting system...");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    static void HireEmployee()
    {
        Console.WriteLine("\nHIRE NEW EMPLOYEE: Enter the necessary information.");

        Console.Write("Employee ID: ");
        string id = Console.ReadLine();

        if (FindIndex(id) != -1)
        {
            Console.WriteLine("Employee ID already exists.");
            return;
        }

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Position: ");
        string position = Console.ReadLine();

        Console.Write("Department: ");
        string dept = Console.ReadLine();

        ids.Add(id);
        names.Add(name);
        positions.Add(position);
        departments.Add(dept);
        statuses.Add("Active");

        hiringLog.Add($"[HIRED] ID: {id} | Name: {name} | Position: {position} | Dept: {dept} | Date: {DateTime.Now}");
        Console.WriteLine($"Employee {name} successfully hired!");
    }

    static void PromoteEmployee()
    {
        Console.WriteLine("\nPROMOTE EMPLOYEE:");
        Console.Write("Enter Employee ID: ");
        string id = Console.ReadLine();

        int index = FindIndex(id);

        if (index == -1)
        {
            Console.WriteLine("Employee not found.");
            return;
        }

        Console.WriteLine($"Employee Found   : {names[index]}");
        Console.WriteLine($"Current Position : {positions[index]}");

        Console.Write("Enter New Position: ");
        string newPosition = Console.ReadLine();

        string oldPosition = positions[index];
        positions[index] = newPosition;

        promotionLog.Add($"[PROMOTED] ID: {id} | Name: {names[index]} | {oldPosition} -> {newPosition}");
        Console.WriteLine($"{names[index]} promoted from {oldPosition} to {newPosition}!");
    }

    static int FindIndex(string id)
    {
        for (int i = 0; i < ids.Count; i++)
        {
            if (ids[i] == id)
                return i;
        }
        return -1;
    }

    static void ShowOptions(string[] options)
    {
        for (int x = 0; x < options.Length; x++)
        {
            Console.WriteLine($"[{x + 1}] {options[x]}");
        }
        Console.Write("Enter the number of your option: ");
    }
}