using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using EmployeeSystem.Models;

namespace EmployeeSystem.DL
{
    public class EmployeeDatabase
    {
        private string _connectionString =
            "Server=localhost\\SQLEXPRESS;Database=EmployeeDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public void SaveEmployee(Employee emp)
        {
            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            string query = "INSERT INTO Employees (Id, Name, Position, Department, Status) VALUES (@Id, @Name, @Position, @Department, @Status)";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", emp.Id);
            cmd.Parameters.AddWithValue("@Name", emp.Name);
            cmd.Parameters.AddWithValue("@Position", emp.Position);
            cmd.Parameters.AddWithValue("@Department", emp.Department);
            cmd.Parameters.AddWithValue("@Status", emp.Status);
            cmd.ExecuteNonQuery();
        }

        public void UpdateEmployee(Employee emp)
        {
            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            string query = "UPDATE Employees SET Position=@Position, Department=@Department WHERE Id=@Id";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", emp.Id);
            cmd.Parameters.AddWithValue("@Position", emp.Position);
            cmd.Parameters.AddWithValue("@Department", emp.Department);
            cmd.ExecuteNonQuery();
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> list = new List<Employee>();
            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            string query = "SELECT * FROM Employees";
            using SqlCommand cmd = new SqlCommand(query, conn);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Employee
                {
                    Id = reader["Id"].ToString(),
                    Name = reader["Name"].ToString(),
                    Position = reader["Position"].ToString(),
                    Department = reader["Department"].ToString(),
                    Status = reader["Status"].ToString()
                });
            }
            return list;
        }
    }
}