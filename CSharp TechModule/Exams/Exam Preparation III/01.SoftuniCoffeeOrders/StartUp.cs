using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SoftuniCoffeeOrders
{
    public class StartUp
    {
        public static void Main()
        {
            long N = long.Parse(Console.ReadLine());
            decimal totalPrice = 0.0m;
            for (int i = 0; i < N; i++)
            {
                decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
                string orderDate = Console.ReadLine();
                long capsulesCount = long.Parse(Console.ReadLine());
                DateTime date = DateTime.ParseExact(orderDate, "d/M/yyyy", CultureInfo.InstalledUICulture);
                var dateSplitted = orderDate.Split('/').ToArray();
                int year = int.Parse(dateSplitted[2]);
                int month = int.Parse(dateSplitted[1]);
                long numberOfDays = DateTime.DaysInMonth(year, month);
                long pricePerMonth = numberOfDays * capsulesCount;
                decimal currentPrice = pricePerMonth * pricePerCapsule;
                Console.WriteLine($"The price for the coffee is: ${currentPrice:F2}");
                totalPrice += currentPrice;
            }
            Console.WriteLine($"Total: ${totalPrice:F2}");
        }
    }
}
