using EmployeeSystem.BL;
using EmployeeSystem.DL;
using EmployeeSystem.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace EmployeeSystem
{
    internal class Program
    {
        static EmployeeData _data = new EmployeeData();
        static EmployeeLogic _logic;

        static void Main(string[] args)
        {
            _logic = new EmployeeLogic(_data);

            Console.WriteLine("EMPLOYEE INFORMATION SYSTEM");

            bool running = true;

            while (running)
            {
                string[] options = new string[]
                {
                    "Hire New Employee",
                    "Promote Employee",
                    "Transfer / Movement",
                    "View All Employees",
                    "View Employee History",
                    "Search Employee"
                };
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
            Console.Write("Employee ID: "); string id = Console.ReadLine();
            Console.Write("Name: "); string name = Console.ReadLine();
            Console.Write("Position: "); string position = Console.ReadLine();
            Console.Write("Department: "); string dept = Console.ReadLine();

            string result = _logic.HireEmployee(id, name, position, dept);
            Console.WriteLine(result.Split(':')[1]);
        }

        static void PromoteEmployee()
        {
            Console.WriteLine("\nPROMOTE EMPLOYEE:");
            Console.Write("Enter Employee ID: ");
            string id = Console.ReadLine();
            int index = _logic.GetIndex(id);

            if (index == -1) { Console.WriteLine("Employee not found."); return; }

            Console.WriteLine($"Employee Found   : {_data.EmployeeList[index].Name}");
            Console.WriteLine($"Current Position : {_data.EmployeeList[index].Position}");
            Console.Write("Enter New Position: ");
            string newPosition = Console.ReadLine();

            string result = _logic.PromoteEmployee(id, newPosition);
            Console.WriteLine(result.Split(':')[1]);
        }

        static int FindIndex(string id)
        {
            return _logic.GetIndex(id);
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
}
