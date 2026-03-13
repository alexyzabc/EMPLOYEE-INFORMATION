using System;
using System.Collections.Generic;
using EmployeeSystem.Models;

namespace EmployeeSystem.DL
{
    public class EmployeeData
    {
        public List<Employee> EmployeeList = new List<Employee>();
        public List<string> HiringLog = new List<string>();
        public List<string> PromotionLog = new List<string>();
        public List<string> MovementLog = new List<string>();

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