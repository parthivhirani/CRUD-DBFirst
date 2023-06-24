using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstApproach
{
    internal class RangeAdd
    {
        static void Main(string[] args)
        {
            IList<EmployeeJ> emps = new List<EmployeeJ>()
            {
                new EmployeeJ(){Id= 1013, Name= "Meet", Department= "IT", Salary=30000, Gender="Male", Age=22, City = "Rajkot"},
                new EmployeeJ() { Id = 1014, Name = "Vaidehi", Department= "Development", Salary=100000, Gender="Female", Age=27, City = "Ahmedabad"}
            };

            using (var context = new SampleDBEntities2())
            {
                var empss = context.EmployeeJs.ToList();
                var lastOrDef = empss.LastOrDefault<EmployeeJ>();
                context.EmployeeJs.Remove(lastOrDef);
                context.SaveChanges();

                //context.EmployeeJs.Attach(emps.);

                //var employees = context.EmployeeJs.Where(emp => (emp.Id == 1014 && emp.Id==1012)).ToList();

                //context.Configuration.ValidateOnSaveEnabled = false;
                //context.Entry(emps).State = EntityState.Deleted;
                //context.EmployeeJs.RemoveRange(emps);
                //context.SaveChanges();
                //context.Configuration.ValidateOnSaveEnabled = true;
            }
        }
    }
}
