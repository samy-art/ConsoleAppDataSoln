using DataLibraryEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEfDataConsumer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CDataAccess dalEf = new CDataAccess();
            
            dalEf.AddEmployee(new Employee { Eid=120, EName="Rajini", Dept=20 });


            dalEf.DeleteEmployee(101);

            dalEf.ModifyEmployee(new Employee { Eid = 102, EName = "Kamal", Dept = 30 });

            List<Employee> listEmployees = dalEf.GetAllEmployees();
            Console.WriteLine($"{"EmpID",-15}{"EmpName",-15}{"EmpDept",-15}");
            foreach (var emp in listEmployees)
            {
                Console.WriteLine($"{emp.Eid,-15}{emp.EName,-15}{emp.Dept,-15}");
            }
        }
    }
}
