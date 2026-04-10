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
                    "Update Employee",
                    "Delete Employee",
                    "View History",
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
                        TransferEmployee();
                        break;
                    case "4":
                        ViewAllEmployees();
                        break;
                    case "5":
                        UpdateEmployee();
                        break;
                    case "6":
                        DeleteEmployee();
                        break;
                    case "7":
                        ViewHistory();
                        break;
                    case "8":
                        SearchEmployee();
                        break;
                    case "0":
                        running = false;
                        Console.WriteLine("Exiting system...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        static void ShowOptions(string[] options)
        {
            for (int x = 0; x < options.Length; x++)
            {
                Console.WriteLine($"[{x + 1}] {options[x]}");
            }
            Console.Write("Enter the number of your option: ");
        }

        static void HireEmployee()
        {
            Console.WriteLine("\nHIRE NEW EMPLOYEE: Enter the necessary information.");
            Console.Write("Employee ID: "); string id = Console.ReadLine();
            Console.Write("Name: "); string name = Console.ReadLine();
            Console.Write("Position: "); string position = Console.ReadLine();
            Console.Write("Department: "); string dept = Console.ReadLine();

            string result = _logic.HireEmployee(id, name, position, dept);
            if (result != "") Console.WriteLine(result);
        }

        static void PromoteEmployee()
        {
            Console.WriteLine("\nPROMOTE EMPLOYEE:");
            Console.Write("Enter Employee ID: "); string id = Console.ReadLine();

            int index = _logic.GetIndex(id);
            if (index == -1)
            {
                Console.WriteLine("Employee not found.");
                return;
            }

            Console.WriteLine($"Employee Found   : {_data.EmployeeList[index].Name}");
            Console.WriteLine($"Current Position : {_data.EmployeeList[index].Position}");
            Console.Write("Enter New Position: "); string newPos = Console.ReadLine();

            string result = _logic.PromoteEmployee(id, newPos);
            if (result != "") Console.WriteLine(result);
        }

        static void TransferEmployee()
        {
            Console.WriteLine("\nTRANSFER / MOVEMENT:");
            Console.Write("Enter Employee ID: "); string id = Console.ReadLine();

            int index = _logic.GetIndex(id);
            if (index == -1)
            {
                Console.WriteLine("Employee not found.");
                return;
            }

            Console.WriteLine($"Employee Found      : {_data.EmployeeList[index].Name}");
            Console.WriteLine($"Current Department  : {_data.EmployeeList[index].Department}");
            Console.Write("Enter New Department: "); string dept = Console.ReadLine();

            string result = _logic.TransferEmployee(id, dept);
            if (result != "") Console.WriteLine(result);
        }

        static void ViewAllEmployees()
        {
            Console.WriteLine("\nHere are the list of employees..");

            if (_data.EmployeeList.Count == 0)
            {
                Console.WriteLine("No employees found.");
                return;
            }

            for (int i = 0; i < _data.EmployeeList.Count; i++)
            {
                Console.WriteLine($"ID: {_data.EmployeeList[i].Id} | Name: {_data.EmployeeList[i].Name} | Position: {_data.EmployeeList[i].Position} | Dept: {_data.EmployeeList[i].Department} | Status: {_data.EmployeeList[i].Status}");
            }
        }

        static void UpdateEmployee()
        {
            Console.WriteLine("\nUPDATE EMPLOYEE:");
            Console.Write("Enter Employee ID: "); string id = Console.ReadLine();

            int index = _logic.GetIndex(id);
            if (index == -1)
            {
                Console.WriteLine("Employee not found.");
                return;
            }

            Console.WriteLine($"Employee Found   : {_data.EmployeeList[index].Name}");
            Console.Write("Enter New Name: "); string newName = Console.ReadLine();
            Console.Write("Enter New Position: "); string newPos = Console.ReadLine();
            Console.Write("Enter New Department: "); string newDept = Console.ReadLine();

            string result = _logic.UpdateEmployee(id, newName, newPos, newDept);
            if (result != "") Console.WriteLine(result);
        }

        static void DeleteEmployee()
        {
            Console.WriteLine("\nDELETE EMPLOYEE:");
            Console.Write("Enter Employee ID: "); string id = Console.ReadLine();

            int index = _logic.GetIndex(id);
            if (index == -1)
            {
                Console.WriteLine("Employee not found.");
                return;
            }

            Console.WriteLine($"Employee Found: {_data.EmployeeList[index].Name}");
            Console.Write("Are you sure you want to delete? y/n: ");
            string confirm = Console.ReadLine();

            if (confirm == "y")
            {
                string result = _logic.DeleteEmployee(id);
                if (result != "") Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Delete cancelled.");
            }
        }

        static void ViewHistory()
        {
            Console.WriteLine("\nVIEW HISTORY:");
            string[] options = new string[]
            {
                "Hiring History",
                "Promotion History",
                "Transfer / Movement History"
            };
            ShowOptions(options);

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("\nHIRING HISTORY:");
                if (_data.HiringLog.Count == 0)
                    Console.WriteLine("No hiring records yet.");
                else
                    for (int i = 0; i < _data.HiringLog.Count; i++)
                        Console.WriteLine(_data.HiringLog[i]);
            }
            else if (choice == "2")
            {
                Console.WriteLine("\nPROMOTION HISTORY:");
                if (_data.PromotionLog.Count == 0)
                    Console.WriteLine("No promotion records yet.");
                else
                    for (int i = 0; i < _data.PromotionLog.Count; i++)
                        Console.WriteLine(_data.PromotionLog[i]);
            }
            else if (choice == "3")
            {
                Console.WriteLine("\nTRANSFER / MOVEMENT HISTORY:");
                if (_data.MovementLog.Count == 0)
                    Console.WriteLine("No transfer records yet.");
                else
                    for (int i = 0; i < _data.MovementLog.Count; i++)
                        Console.WriteLine(_data.MovementLog[i]);
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }

        static void SearchEmployee()
        {
            Console.WriteLine("\nSEARCH EMPLOYEE:");
            Console.Write("Enter Employee ID or Name: ");
            string keyword = Console.ReadLine().ToLower();

            bool found = false;

            for (int i = 0; i < _data.EmployeeList.Count; i++)
            {
                if (_data.EmployeeList[i].Id.ToLower().Contains(keyword) ||
                    _data.EmployeeList[i].Name.ToLower().Contains(keyword))
                {
                    Console.WriteLine($"ID: {_data.EmployeeList[i].Id} | Name: {_data.EmployeeList[i].Name} | Position: {_data.EmployeeList[i].Position} | Dept: {_data.EmployeeList[i].Department} | Status: {_data.EmployeeList[i].Status}");
                    found = true;
                }
            }

            if (!found)
                Console.WriteLine("No employee found.");
        }
    }
}