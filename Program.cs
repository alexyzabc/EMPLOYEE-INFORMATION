using System.Collections;
using System.Data;

namespace EMPLOYEE_INFORMATION
{
    internal class Program
    {
       
            static string[] empID = new string[100];
            static string[] empName = new string[100];
            static string[] empPosition = new string[100];
            static string[] empDept = new string[100];
            static string[] empStatus = new string[100];
            static int empCount = 0;

            static ArrayList hiringLog = new ArrayList();
            static ArrayList promotionLog = new ArrayList();
            static ArrayList movementLog = new ArrayList();
        static void Main(string[] args)
        {
            bool running = true;
            string[] employeeName = { "Juan Dela Cruz", "Maria lacsinto", "Macy Lhou Rodico", "Ken Darwin", "Hudson AFK" };
          
            string[] employeeNumber = { "EMP001", "EMP002", "EMP003", "EMP004", "EMP005" };
            string[] employeePosition = { "Software Engineer", "Data Analyst", "Network Admin", "Professor", "Web Developer" };
            string[] empDepartment = { " IT", "IT", "IT", "Education", "IT" };
            Console.WriteLine("==============================");
            Console.WriteLine("EMPLOYEE MANAGEMENT SYSTEM");
            Console.WriteLine("==============================");

            while (running)
            {
                Console.WriteLine("\n---MAIN MENU---");
                Console.WriteLine("1. Hire New Employee: ");
                Console.WriteLine("2. Promote Employee: ");
                Console.WriteLine("3. Transfer/Movement: ");
                Console.WriteLine("4. View All Employees: ");
                Console.WriteLine("5. Search Employee: ");
                Console.WriteLine("6. Exit");
                Console.Write("\nEnter your Choice: ");

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
                        SearchEmployee();
                        break;
                    case "0":
                        Console.WriteLine("\nExiting the system. Goodbye!");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }

        }

        static void HireEmployee()
        {
            Console.WriteLine("---HIRE NEW EMPLOYEE---");
            if (empCount >= 100)
            {
                Console.WriteLine("Employee list is full!");
                return;
            }
            Console.Write("Enter Employee ID: ");
            string ID = Console.ReadLine();
             if (FindEmployeeIndex(id) != -1)
            {
                Console.WriteLine("Employee ID already exists. Please try again.");
            } 
            {
                }
            }
        }
    }
}
