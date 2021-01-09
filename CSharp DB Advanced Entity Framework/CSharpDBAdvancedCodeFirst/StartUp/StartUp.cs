using System;
using P01_HospitalDatabase.Data;
using P01_HospitalDatabase.Data.Models;
using P01_HospitalDatabase.Initializer;
using P03_SalesDatabase.Data;
using P03_SalesDatabase;
using P03_SalesDatabase.Data.Models;

namespace StartUp
{
    public class StartUp
    {
        public static void Main()
        {
            DbInit.CreateHospitalDatabase();
            DbInit.CreateSalesDatabase();
        }
    }
}
