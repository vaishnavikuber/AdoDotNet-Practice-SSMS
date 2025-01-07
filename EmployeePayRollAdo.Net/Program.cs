using System;

namespace EmployeePayRollAdo.Net
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------Employee PayRoll----------");
            EmployeeModel model = new EmployeeModel();
            EmployeeRepository repository = new EmployeeRepository();
            //EmployeeInput();
            
            //repository.GetAllEmployee();

            //EmployeeUpdate();
            //EmployeeDelete();
            //repository.GetAllEmployee();




            CustomerRepository customerRepo = new CustomerRepository();
            // customerRepo.AddCustomer();
            //customerRepo.UpdateCustomer();
            customerRepo.DeleteCustomer();






        }

        public static void EmployeeInput()
        {
            EmployeeRepository repository = new EmployeeRepository();
            EmployeeModel model = new EmployeeModel();
            Console.WriteLine("Enter Employee Name:");
            model.EmployeeName = Console.ReadLine();
            Console.WriteLine("Enter Phone number:");
            model.PhoneNumber = Console.ReadLine();
            Console.WriteLine("Enter Email:");
            model.Email = Console.ReadLine();
            Console.WriteLine("Enter Department:");
            model.Department = Console.ReadLine();
            Console.WriteLine("Enter Salary:");
            model.Salary = int.Parse(Console.ReadLine());
            repository.AddEmployee(model);
            
        }

        public static void EmployeeUpdate()
        {
            EmployeeRepository repository = new EmployeeRepository();
            EmployeeModel model = new EmployeeModel();
            Console.WriteLine("Enter Employee Id to update:");
            model.EmployeeId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Department to update");
            model.Department= Console.ReadLine();
            repository.UpdateEmployee(model);
        }

        public static void EmployeeDelete()
        {
            EmployeeRepository repository = new EmployeeRepository();
            
            Console.WriteLine("Enter Employee Id to delete:");
            int employeeId = int.Parse(Console.ReadLine());
          
            repository.DeleteEmployee(employeeId);
        }
    }
}
