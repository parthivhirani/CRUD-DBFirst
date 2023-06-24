using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstApproach
{
    internal class Logs
    {
        static void Main(string[] args)
        {
            using(var context = new SampleDBEntities2())
            {
                context.Database.Log = Console.Write;
                var employee = context.EmployeeJs
                    .Where(e=>e.Name =="Hina Sharma")
                    .FirstOrDefault<EmployeeJ>();
                employee.Name = "Hina Tripathi";
                context.SaveChanges();

                Console.ReadLine();
            }
        }
    }
}
