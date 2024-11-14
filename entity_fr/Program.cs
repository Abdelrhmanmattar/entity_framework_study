using entity_fr.DATA;
using System;

namespace entity_fr
{

    class Program
    {
        static void Main(string[] args)
        {
            using(var data_base = new AppDBContext())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("print all data from employee table");
                Console.ResetColor();
                foreach (var row in data_base.Employees)
                {
                    Console.WriteLine(row);
                    Console.WriteLine("====================================================================================================");
                }
                #region
                //try insert data 
                #endregion
                /* Employee sampleEmployee2 = new Employee
                 {
                     LastName = "kamal",
                     FirstName = "Jane",
                     Title = "Project Manager",
                     ReportsTo = 1, // Reporting to employee with ID 1
                     BirthDate = new DateTime(1985, 3, 22),
                     HireDate = new DateTime(2015, 11, 15),
                     Address = "456 Elm St",
                     City = "Los Angeles",
                     State = "CA",
                     Country = "USA",
                     PostalCode = "90001",
                     Phone = "987-654-3210",
                     Fax = "987-654-3211",
                     Email = "jane.smith@example.com",
                     InverseReportsToNavigation = new List<Employee>() // No direct reports initially
                 };
                 Console.WriteLine(sampleEmployee2);
                 data_base.Set<Employee>().Add(sampleEmployee2);
                 data_base.SaveChanges();
                */
                #region
                //try to delete data 
                #endregion
                /*data_base.Employees.Where(x => x.EmployeeId >= 9).ExecuteDelete();
                Console.WriteLine("delete=========");*/

                #region
                //try to update data
                #endregion
                //data_base.Employees.Where(x => x.EmployeeId == 1)
                //    .ExecuteUpdate(e => e.SetProperty(emp => emp.LastName, "kamal")
                //    );
                //Console.WriteLine("update=========");

                //try join statment
                //select e.EmployeeId , CONCAT(e.FirstName,' ',e.LastName) as emp , CONCAT(m.FirstName,' ',m.LastName) as man
                //from Employee as e left outer join Employee as m
                //on e.ReportsTo = m.EmployeeId;

                #region
                //the next query is inner join
                #endregion
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("print inner join");
                Console.ResetColor();
                var query2 = data_base.Employees.Join(data_base.Employees,
                    e => e.ReportsTo, m => m.EmployeeId
                    , (e, m) => new
                    {
                        e.EmployeeId,
                        emp = e.FirstName + " " + e.LastName,
                        man = m.FirstName + " " + m.LastName,
                    }
                    );
                foreach (var row in query2)
                {
                    Console.WriteLine(row);
                    Console.WriteLine("====================================================================================================");
                }

                #region
                //the next query is left outer join
                #endregion
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("print left outer join");
                Console.ResetColor();
                var query3 = data_base.Employees.GroupJoin(
                    data_base.Employees,
                    e => e.ReportsTo,
                    m => m.EmployeeId,
                    (e, managers) => new { Employee = e, Managers = managers.DefaultIfEmpty() }
                  ).
                  SelectMany
                  (
                        x => x.Managers,
                        (x, m) => new
                        {
                            EmployeeId = x.Employee.EmployeeId,
                            emp = x.Employee.FirstName + " " + x.Employee.LastName,
                            man = m != null ? m.FirstName + " " + m.LastName : null
                        }
                  );
                foreach (var row in query3)
                {
                    Console.WriteLine(row);
                    Console.WriteLine("====================================================================================================");
                }


                #region
                //try to order by id
                #endregion
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("print order by id");
                Console.ResetColor();
                var query = data_base.Employees.OrderByDescending(x => x.EmployeeId);
                foreach (var row in query)
                {
                    Console.WriteLine(row);
                    Console.WriteLine("====================================================================================================");
                }

                #region
                //TRY AGGREGATE FUNCTION
                #endregion
                /*
                 * this will return max value of() so it will return max id but not row
                 */
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("print max id");
                Console.ResetColor();
                var query4 = data_base.Employees.Max(x => x.EmployeeId);
                Console.WriteLine(query4);
                Console.WriteLine("====================================================================================================");

                /*
                 *MaxBy() 
                 * will return row but this command didn't avaiable in sql server 
                 * so we must use AsEnumerable() to convert the data to list in memory
                 * disadvantage of this command that it will return all data from database to memory
                 * will cost performance and memory
                 */
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("print max row");
                    Console.ResetColor();
                var query5 = data_base.Employees.AsEnumerable().MaxBy(x => x.EmployeeId);
                Console.WriteLine(query5);
                Console.WriteLine("====================================================================================================");

                /*
                 * alternative way to get max row
                 */
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("print max row alternative way");
                Console.ResetColor();
                var max_id = data_base.Employees.Max(x => x.EmployeeId); // get max id
                var row_ = data_base.Employees.Select(x => x).Where(x => x.EmployeeId == max_id);
                foreach (var row in row_)
                {
                    Console.WriteLine(row);
                    Console.WriteLine("====================================================================================================");
                }




            }


        }
    }

}
