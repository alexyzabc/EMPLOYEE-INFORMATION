using System;
using EmployeeSystem.Models;
using EmployeeSystem.DL;
using EmployeeSystem.BL;

namespace EmployeeSystem.UI
{
    internal class Program
    {
        static EmployeeData _data = new EmployeeData();
        static EmployeeLogic _logic = new EmployeeLogic(_data);

        static void Main(string[] args)
        {
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
                    case "1": HireEmployee(); break;
                    case "2": PromoteEmployee(); break;
                    case "3": TransferEmployee(); break;
                    case "4": ViewAllEmployees(); break;
                    case "5": Console.WriteLine("Feature coming soon."); break;
                    case "6": Console.WriteLine("Feature coming soon."); break;
                    case "0":
                        running = false;
                        Console.WriteLine("Exiting system...");
                        break;
                    default: Console.WriteLine("Invalid choice."); break;
                }
            }
        }

        static void ShowOptions(string[] options)
        {
            for (int i = 0; i < options.Length; i++)
                Console.WriteLine($"[{i + 1}] {options[i]}");
            Console.Write("Enter the number of your option: ");
        }

        static void HireEmployee()
        {
            Console.WriteLine("\nHIRE NEW EMPLOYEE:");
            Console.Write("Employee ID: "); string id = Console.ReadLine();
            Console.Write("Name: "); string name = Console.ReadLine();
            Console.Write("Position: "); string position = Console.ReadLine();
            Console.Write("Department: "); string dept = Console.ReadLine();

            string result = _logic.HireEmployee(id, name, position, dept);
            Console.WriteLine(result);
        }

        static void PromoteEmployee()
        {
            Console.WriteLine("\nPROMOTE EMPLOYEE:");
            Console.Write("Enter Employee ID: "); string id = Console.ReadLine();
            Console.Write("Enter New Position: "); string newPos = Console.ReadLine();

            string result = _logic.PromoteEmployee(id, newPos);
            Console.WriteLine(result);
        }

        static void TransferEmployee()
        {
            Console.WriteLine("\nTRANSFER EMPLOYEE:");
            Console.Write("Enter Employee ID: "); string id = Console.ReadLine();
            Console.Write("Enter New Department: "); string dept = Console.ReadLine();

            string result = _logic.TransferEmployee(id, dept);
            Console.WriteLine(result);
        }

        static void ViewAllEmployees()
        {
            Console.WriteLine("\nALL EMPLOYEES:");

            if (_data.EmployeeList.Count == 0)
            {
                Console.WriteLine("No employees found.");
                return;
            }

            foreach (var emp in _data.EmployeeList)
            {
                Console.WriteLine($"ID: {emp.Id} | Name: {emp.Name} | Position: {emp.Position} | Dept: {emp.Department} | Status: {emp.Status}");
            }
            Console.WriteLine();
        }
    }
}