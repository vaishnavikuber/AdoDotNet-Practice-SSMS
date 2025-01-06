using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Data.SqlClient;

namespace EmployeePayRollAdo.Net
{
    internal class EmployeeRepository
    {

        public static string connString = @"Data Source=LAPTOP-THKBRF74\SQLEXPRESS;Initial Catalog=EmployeeDB;Integrated Security=True;TrustServerCertificate=True";

        SqlConnection connection= new SqlConnection(connString);

        public bool AddEmployee(EmployeeModel employee)
        {
            using (connection)
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                cmd.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", employee.Email);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                connection.Open();
                var result = cmd.ExecuteNonQuery();
                if (result != 0)
                {
                    Console.WriteLine("Data added successfuly");
                    return true;
                }
                Console.WriteLine("Failed to add data");
                return false;
            }
        }

        public void GetAllEmployee()
        {
            EmployeeModel employee = new EmployeeModel();
            using (connection)
            {
                string query = "select * from EmployeePayRoll";
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        employee.EmployeeId=reader.GetInt32(0);
                        employee.EmployeeName=reader.GetString(1);  
                        employee.PhoneNumber=reader.GetString(2);
                        employee.Email=reader.GetString(3);
                        employee.Department=reader.GetString(4);
                        employee.Salary = reader.GetInt32(5);
                        Console.WriteLine("{0},{1},{2},{3},{4},{5}", employee.EmployeeId, employee.EmployeeName, employee.PhoneNumber, employee.Email, employee.Department, employee.Salary);
                    }
                }
                else
                {
                    Console.WriteLine("No Data found in table");
                }
            }
        }

        public bool UpdateEmployee(EmployeeModel employee)
        {
            SqlCommand command = new SqlCommand("spUpdateEmployee", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Department", employee.Department);
            command.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
            connection.Open();
            var result=command.ExecuteNonQuery();
            if(result != 0)
            {
                Console.WriteLine("Data Updated successfully");
                return true;
            }
            Console.WriteLine("Failed to update data");
            return false;
        }

        public bool DeleteEmployee(int employeeId)
        {
            EmployeeModel model= new EmployeeModel() { EmployeeId= employeeId };
            SqlCommand command = new SqlCommand("spDeleteEmployee", connection);
            command.CommandType= CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@EmployeeId", model.EmployeeId);
            connection.Open();
            var result = command.ExecuteNonQuery();
            if (result!=0)
            {
                Console.WriteLine("Data Deleted");
                return true;
            }
            return false;
        }

    }
}
