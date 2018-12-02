using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbTransactionDemo
{
    public class HotelFlightConfiguration : DbConfiguration
    {
        public HotelFlightConfiguration()
        {
            SetDatabaseInitializer(new DropCreateDatabaseIfModelChanges<HotelDbContext>());
            SetDatabaseInitializer(new DropCreateDatabaseIfModelChanges<FlightDbContext>());
        }
    }
}
