using System;
using System.Collections.Generic;
using EmployeeSystem.DL;
using EmployeeSystem.Models;

namespace EmployeeSystem.BL
{
    public class EmployeeLogic
    {
        private EmployeeData _data;
        private EmployeeDatabase _db;

        public EmployeeLogic(EmployeeData data)
        {
            _data = data;
            _db = new EmployeeDatabase();
        }

        public string HireEmployee(string id, string name, string position, string department)
        {
            if (_data.FindIndex(id) != -1)
            {
                Console.WriteLine("Employee ID already exists.");
                return "";
            }

            Employee emp = new Employee();
            emp.Id = id;
            emp.Name = name;
            emp.Position = position;
            emp.Department = department;
            emp.Status = "Active";

            _data.EmployeeList.Add(emp);
            _data.SaveToJson();
            _db.SaveEmployee(emp);

            return $"Employee {name} successfully hired!";
        }

        public string PromoteEmployee(string id, string newPosition)
        {
            int index = _data.FindIndex(id);
            if (index == -1)
            {
                Console.WriteLine("Employee not found.");
                return "";
            }

            _data.EmployeeList[index].Position = newPosition;
            _data.SaveToJson();
            _db.UpdateEmployee(_data.EmployeeList[index]);

            return $"Employee {_data.EmployeeList[index].Name} promoted to {newPosition}!";
        }

        public string TransferEmployee(string id, string newDepartment)
        {
            int index = _data.FindIndex(id);
            if (index == -1)
            {
                Console.WriteLine("Employee not found.");
                return "";
            }

            _data.EmployeeList[index].Department = newDepartment;
            _data.SaveToJson();
            _db.UpdateEmployee(_data.EmployeeList[index]);

            return $"Employee {_data.EmployeeList[index].Name} transferred to {newDepartment}!";
        }

        public string UpdateEmployee(string id, string newName, string newPosition, string newDepartment)
        {
            int index = _data.FindIndex(id);
            if (index == -1)
            {
                Console.WriteLine("Employee not found.");
                return "";
            }

            _data.EmployeeList[index].Name = newName;
            _data.EmployeeList[index].Position = newPosition;
            _data.EmployeeList[index].Department = newDepartment;
            _data.SaveToJson();
            _db.UpdateEmployee(_data.EmployeeList[index]);

            return $"Employee {newName} successfully updated!";
        }

        public string DeleteEmployee(string id)
        {
            int index = _data.FindIndex(id);
            if (index == -1)
            {
                Console.WriteLine("Employee not found.");
                return "";
            }

            string name = _data.EmployeeList[index].Name;
            _data.EmployeeList.RemoveAt(index);
            _data.SaveToJson();
            _db.DeleteEmployee(id);

            return $"Employee {name} successfully deleted!";
        }

        public int GetIndex(string id)
        {
            return _data.FindIndex(id);
        }

        public EmployeeData GetData()
        {
            return _data;
        }
    }
}