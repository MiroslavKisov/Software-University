using P01_BillsPaymentSystem.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_BillsPaymentSystem
{
    public class DatabaseInit
    {
        public void CreateDatabase(BillsPaymentSystemContext db)
        {
            db.Database.EnsureCreated();
        }

        public void DeleteDatabase(BillsPaymentSystemContext db)
        {
            db.Database.EnsureDeleted();
        }
    }
}
