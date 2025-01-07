using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Data.SqlClient;

namespace EmployeePayRollAdo.Net
{
    internal class CustomerRepository
    {

        public static string connString = @"Data Source=LAPTOP-THKBRF74\SQLEXPRESS;Initial Catalog=UserDataBase;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection connection= new SqlConnection(connString);

        public bool AddCustomer()
        {
            CustomerModel customer =new CustomerModel();
           
            Console.WriteLine("Enter customer name:");
            customer.CustomerName =Console.ReadLine();
            Console.WriteLine("Enter email id:");
            customer.Email =  Console.ReadLine();
            Console.WriteLine("Enter Phone number");
            customer.PhoneNumber =Console.ReadLine();
            Console.WriteLine("Enter Address:");
            customer.Address = Console.ReadLine();
            Console.WriteLine("Enter Date of birth: yyyy-mm-dd");
            customer.DateOfBirth = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter gender ");
            customer.Gender = Console.ReadLine();

            using (connection)
            {
                SqlCommand command = new SqlCommand("spAddCustomer", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                command.Parameters.AddWithValue("@Email", customer.Email);
                command.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                command.Parameters.AddWithValue("@Address", customer.Address);
                command.Parameters.AddWithValue("@DateOfBirth", customer.DateOfBirth);
                command.Parameters.AddWithValue("@Gender", customer.Gender);
                connection.Open();
                var result = command.ExecuteNonQuery();
                if(result != 0)
                {
                    Console.WriteLine("Data added successfully");
                    return true;
                }
                Console.WriteLine("Failed to add data");
                return false;
            }
        }

        public bool UpdateCustomer()
        {
            CustomerModel customer = new CustomerModel();
            Console.WriteLine("Enter customer id to update");
            customer.CustomerId=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Phone number");
            customer.PhoneNumber = Console.ReadLine();
            Console.WriteLine("Enter Address:");
            customer.Address = Console.ReadLine();

            SqlCommand command = new SqlCommand("spUpdateCustomer", connection);
            command.CommandType= CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
            command.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
            command.Parameters.AddWithValue("@Address", customer.Address);
            connection.Open();
            var result= command.ExecuteNonQuery();
            if(result != 0)
            {
                Console.WriteLine("data updated successfully");
                return true;
            }
            Console.WriteLine("Failed to update data");
            return false;
        }

        public bool DeleteCustomer()
        {
            CustomerModel customer = new CustomerModel();
            Console.WriteLine("Enter customer id to delete");
            customer.CustomerId = int.Parse(Console.ReadLine());
            SqlCommand command = new SqlCommand("spDeleteCustomer", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            command.Parameters.AddWithValue("@CustomerId",customer.CustomerId);
            var result= command.ExecuteNonQuery();
            if(result != 0)
            {
                Console.WriteLine("data deleted");
                return true;
            }
            Console.WriteLine("data not deleted");
            return false;

        }

    }
}
