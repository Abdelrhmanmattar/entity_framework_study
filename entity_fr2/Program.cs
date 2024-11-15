using entity_fr2.DATA;
using entity_fr2.entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace EF009.BasicSetup
{
    class Program
    {
        public static void Main()
        {
            /*using (var item = new AppDBCONTEXT())
            {
                foreach (var row in item.products)
                {
                    Console.WriteLine(row + "..........");
                    Console.WriteLine("loaded at :....." + row.SnapShot.dateTime);
                    Console.WriteLine("version :....." + row.SnapShot.version);

                }
            }*/

            /*var views = new AppDBCONTEXT().orderWithDetailsViews;
            foreach (var view in views)
            {
                Console.WriteLine(view);
            }*/

            var item = new AppDBCONTEXT().Set<OrderBill>()
                .FromSqlInterpolated($"select * from GetOrderBill(2)");
            foreach (var row in item)
            {
                Console.WriteLine(row);
            }

        }
    }
}