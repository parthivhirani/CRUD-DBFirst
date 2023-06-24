using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstApproach
{
    internal class StoreProcedures
    {
        static void Main(string[] args)
        {
            using(var contx = new SampleDBEntities3())
            {
                foreach(var x in contx.addTwoNumbers(3, 4))
                {
                    Console.WriteLine(x);   
                }
                //var result = (string)contx.addTwoNumbers(3, 4);
                //Console.WriteLine();

                //var result = contx.getGetEmployee();    
                //foreach(var x in result)
                //{
                //    Console.WriteLine(x.Name);
                //}
                

                Console.ReadKey();
            }
        }
    }
}
