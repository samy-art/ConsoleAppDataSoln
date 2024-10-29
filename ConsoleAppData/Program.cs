using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppData
{
    internal class Program
    {
        static void MainSelect()
        {
            using (DacWondersEntities dacWondersEntities = new DacWondersEntities())
            {
                var listEmployees = from emp in dacWondersEntities.Employees select emp;

                Console.WriteLine($"{"EmpID",-15}{"EmpName",-15}{"EmpDept",-15}");
                foreach (var emp in listEmployees)
                {
                    Console.WriteLine($"{emp.Eid,-15}{emp.EName,-15}{emp.Dept,-15}");
                }
            }//dacWondersEntities.Dispose();
        }

        static void MainAdd()
        {
            using (DacWondersEntities dacWondersEntities = new DacWondersEntities())
            {
                Employee emp = new Employee { Eid=116,EName="Anil Kumble", Dept=20 };
                dacWondersEntities.Employees.Add( emp );
                dacWondersEntities.SaveChanges();
            }//dacWondersEntities.Dispose();
            MainSelect();
        }

        static void MainUpdate()
        {
            using (DacWondersEntities dacWondersEntities = new DacWondersEntities())
            {
                var empSelected = (from emp in dacWondersEntities.Employees 
                                    where emp.Eid==115 
                                    select emp).First();
                empSelected.EName = "Mohinder Amarnath";
                empSelected.Dept = 30;
                dacWondersEntities.SaveChanges();

            }//dacWondersEntities.Dispose();
            MainSelect();
        }

        static void MainDelete()
        {
            using (DacWondersEntities dacWondersEntities = new DacWondersEntities())
            {
                var empSelected = (from emp in dacWondersEntities.Employees
                                   where emp.Eid == 115
                                   select emp).First();
               dacWondersEntities.Employees.Remove(empSelected);
                dacWondersEntities.SaveChanges();

            }//dacWondersEntities.Dispose();
            MainSelect();
        }
        static void Main(string[] args)
        {
                MainSelect();
        }
    }
}
