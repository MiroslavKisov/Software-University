using P01_HospitalDatabase.Data;
using P03_SalesDatabase.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace StartUp
{
    public class DbInit
    {
        public static void CreateHospitalDatabase()
        {
            using (var Hospital = new HospitalContext())
            {
                Hospital.Database.EnsureCreated();
            }
        }

        public static void CreateSalesDatabase()
        {
            using (var Sales = new SalesContext())
            {
                Sales.Database.EnsureCreated();
            }
        }
    }
}
