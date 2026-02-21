using System.Data;

namespace EMPLOYEE_INFORMATION
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==EMPLOYEE INFORMATION (PROMOTION, MOVEMENT, AND HIRING==");
            Console.WriteLine("1. Add Employee(CREATE)");
            Console.WriteLine("2. View Employee(RETRIEVE)");
            Console.WriteLine("3. Update Employee(UPDATE)");
            Console.WriteLine("4. Delete Employee(DELETE)");

            string fname, lname;
            char mInitial;
            int age, employeeId;
            Console.Write("Enter your First Name: ");
            Console.Write("Enter your Last Name: ");
            Console.Write("Enter your age: ");
            Console.Write("Enter your Employee ID: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddEmployee();
                    break;
                case 2:
                    ViewEmployee();
                    break;
                case 3:
                    UpdateEmployee();
                    break;
                case 4:
                    DeleteEmployee();
                    break;
         if (employ ==  )

            }
        }
    }
}
