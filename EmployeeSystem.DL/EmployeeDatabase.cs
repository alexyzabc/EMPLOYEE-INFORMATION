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
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            string query = "INSERT INTO Employees (Id, Name, Position, Department, Status) VALUES (@Id, @Name, @Position, @Department, @Status)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", emp.Id);
            cmd.Parameters.AddWithValue("@Name", emp.Name);
            cmd.Parameters.AddWithValue("@Position", emp.Position);
            cmd.Parameters.AddWithValue("@Department", emp.Department);
            cmd.Parameters.AddWithValue("@Status", emp.Status);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void UpdateEmployee(Employee emp)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            string query = "UPDATE Employees SET Name=@Name, Position=@Position, Department=@Department, Status=@Status WHERE Id=@Id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", emp.Id);
            cmd.Parameters.AddWithValue("@Name", emp.Name);
            cmd.Parameters.AddWithValue("@Position", emp.Position);
            cmd.Parameters.AddWithValue("@Department", emp.Department);
            cmd.Parameters.AddWithValue("@Status", emp.Status);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteEmployee(string id)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            string query = "DELETE FROM Employees WHERE Id=@Id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> list = new List<Employee>();
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            string query = "SELECT * FROM Employees";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Employee emp = new Employee();
                emp.Id = reader["Id"].ToString();
                emp.Name = reader["Name"].ToString();
                emp.Position = reader["Position"].ToString();
                emp.Department = reader["Department"].ToString();
                emp.Status = reader["Status"].ToString();
                list.Add(emp);
            }
            conn.Close();
            return list;
        }
    }
}