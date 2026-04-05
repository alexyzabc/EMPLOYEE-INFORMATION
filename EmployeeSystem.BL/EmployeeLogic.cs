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
                return "Error: Employee ID already exists.";

            Employee emp = new Employee
            {
                Id = id,
                Name = name,
                Position = position,
                Department = department,
                Status = "Active"
            };
            _data.EmployeeList.Add(emp);
            _data.SaveToJson();
            _db.SaveEmployee(emp);  

            return $"Success: Employee {name} successfully hired!";
        }

        public string PromoteEmployee(string id, string newPosition)
        {
            int index = _data.FindIndex(id);
            if (index == -1)
                return "Error: Employee not found.";

            _data.EmployeeList[index].Position = newPosition;
            _data.SaveToJson();
            _db.UpdateEmployee(_data.EmployeeList[index]);  

            return $"Success: Employee {_data.EmployeeList[index].Name} promoted to {newPosition}!";
        }

        public string TransferEmployee(string id, string newDepartment)
        {
            int index = _data.FindIndex(id);
            if (index == -1)
                return "Error: Employee not found.";

            _data.EmployeeList[index].Department = newDepartment;
            _data.SaveToJson();
            _db.UpdateEmployee(_data.EmployeeList[index]); 
            return $"Success: Employee {_data.EmployeeList[index].Name} transferred to {newDepartment}!";
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