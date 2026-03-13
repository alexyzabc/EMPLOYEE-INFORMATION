using System;
using System.Collections.Generic;
using EmployeeSystem.Models;
using EmployeeSystem.DL;

namespace EmployeeSystem.BL
{
    public class EmployeeLogic
    {
        private EmployeeData _data;

        public EmployeeLogic(EmployeeData data)
        {
            _data = data;
        }

        public string HireEmployee(string id, string name, string position, string dept)
        {
            if (_data.FindIndex(id) != -1)
                return "ERROR:Employee ID already exists.";

            Employee emp = new Employee
            {
                Id = id,
                Name = name,
                Position = position,
                Department = dept,
                Status = "Active"
            };
            _data.EmployeeList.Add(emp);

            _data.HiringLog.Add($"[HIRED] ID: {id} | Name: {name} | Position: {position} | Dept: {dept} | Date: {DateTime.Now}");

            return $"SUCCESS:Employee {name} successfully hired!";
        }

        public string PromoteEmployee(string id, string newPosition)
        {
            int index = _data.FindIndex(id);
            if (index == -1)
                return "ERROR:Employee not found.";

            string oldPosition = _data.EmployeeList[index].Position;
            _data.EmployeeList[index].Position = newPosition;

            _data.PromotionLog.Add($"[PROMOTED] ID: {id} | Name: {_data.EmployeeList[index].Name} | {oldPosition} -> {newPosition}");

            return $"SUCCESS:{_data.EmployeeList[index].Name} promoted from {oldPosition} to {newPosition}!";
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