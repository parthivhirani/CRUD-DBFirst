using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstApproach
{
    internal class Program
    {
        static void FetchEmployee()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ID    Name");
            Console.WriteLine("-----------------");
            //Stopwatch sw = Stopwatch.StartNew();
            using (var context = new SampleDBEntities2())
            {
                var employeeList = context.EmployeeJs.ToList();
                foreach (var emps in employeeList)
                {
                    Console.WriteLine($"{emps.Id}  {emps.Name}");
                }
            }
            //sw.Stop();
            //Console.WriteLine($"Time taken: {sw.ElapsedMilliseconds} ms");
            Console.ResetColor();

            //using Native SQL
            //using (var context = new SampleDBEntities2())
            //{
            //    var empList1 = context.EmployeeJs.SqlQuery("select * from EmployeeJ");
            //    foreach (var emps in empList1)
            //    {
            //        Console.WriteLine($"{emps.Id}  {emps.Name}");
            //    }
            //}
        }


        static void AddEmployee()
        {
            using (var context = new SampleDBEntities2())
            {
                EmployeeJ ej = new EmployeeJ();
                Console.Write("Enter ID: ");
                ej.Id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Name: ");
                ej.Name = Console.ReadLine();

                Console.Write("Enter Department: ");
                ej.Department = Console.ReadLine();

                Console.Write("Enter Salary: ");
                ej.Salary = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Gender: ");
                ej.Gender = Console.ReadLine();

                Console.Write("Enter Age: ");
                ej.Age = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter City: ");
                ej.City = Console.ReadLine();

                context.EmployeeJs.Add(ej);
                var status = context.SaveChanges();
                if (status==1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Data added successfully.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("Error in data inserting.");
                    Console.ResetColor();
                }
                
            }
        }

        static void UpdateEmployee()
        {
            Console.Write("Enter ID to be updated: ");
            int id = Convert.ToInt32(Console.ReadLine());


            using(var context = new SampleDBEntities2())
            {
                var updCmd = context.EmployeeJs.Find(id);

                Console.Write("Enter new name: ");
                updCmd.Name = Console.ReadLine();

                var status = context.SaveChanges();
                if(status == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Data updated successfully.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("Error in data updating.");
                    Console.ResetColor();
                }
            }
        }

        static void DeleteEmployee()
        {
            using (var context = new SampleDBEntities2())
            {
                Console.Write("Enter name to be deleted: ");
                string name = Console.ReadLine().ToLower();

                var deleteEmp = context.EmployeeJs.Where(emp => emp.Name.ToLower() == name).FirstOrDefault();

                context.EmployeeJs.Remove(deleteEmp);
                var status = context.SaveChanges();
                if (status == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Data deleted successfully.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("Error in data deleting.");
                    Console.ResetColor();
                }
            }
        }

        

        static void ProcessEmployee()
        {
            Console.WriteLine("-------------------");
            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    FetchEmployee();
                    break;
                case 2:
                    AddEmployee();
                    break;
                case 3:
                    UpdateEmployee();
                    break;
                case 4:
                    DeleteEmployee();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red; 
                    Console.WriteLine("Please enter valid choice.");
                    Console.ResetColor();
                    break;


            }
        }
        static void Main(string[] args)
        {
            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.WriteLine("---------------------------");
            Console.WriteLine("1. Get all Employees");
            Console.WriteLine("2. Add Employee");
            Console.WriteLine("3. Update Employee");
            Console.WriteLine("4. Delete Employee");
            Console.WriteLine("Enter # to exit");
            Console.WriteLine("---------------------------");
            Console.ResetColor();
            while(true)
            {
                try
                {
                    ProcessEmployee();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Thank you");
                    break;
                }
            }
        }
    }
}
