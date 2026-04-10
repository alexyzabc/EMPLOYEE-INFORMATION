using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using EmployeeSystem.Models;

namespace EmployeeSystem.DL
{
    public class EmployeeData
    {
        private string _jsonFilePath;

        public List<Employee> EmployeeList = new List<Employee>();
        public List<string> HiringLog = new List<string>();
        public List<string> PromotionLog = new List<string>();
        public List<string> MovementLog = new List<string>();

        public EmployeeData()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string dataFolder = Path.GetFullPath(Path.Combine(basePath, "..\\..\\..\\..\\EMPLOYEE INFORMATION\\Data"));
            Directory.CreateDirectory(dataFolder);
            _jsonFilePath = Path.Combine(dataFolder, "employees.json");

            if (!File.Exists(_jsonFilePath))
                File.WriteAllText(_jsonFilePath, "[]");

            LoadFromJson();
        }

        public void LoadFromJson()
        {
            string json = File.ReadAllText(_jsonFilePath);
            EmployeeList = JsonSerializer.Deserialize<List<Employee>>(json) ?? new List<Employee>();
        }

        public void SaveToJson()
        {
            string json = JsonSerializer.Serialize(EmployeeList, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_jsonFilePath, json);
        }

        public int FindIndex(string id)
        {
            for (int i = 0; i < EmployeeList.Count; i++)
            {
                if (EmployeeList[i].Id == id)
                    return i;
            }
            return -1;
        }
    }
}