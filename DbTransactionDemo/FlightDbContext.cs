using DbTransactionDemo.Map;
using DbTransactionDemo.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbTransactionDemo
{
    [DbConfigurationType(typeof(HotelFlightConfiguration))]
    public class FlightDbContext : DbContext
    {
        public FlightDbContext() : base("name=flightConnection")
        {

        }

        public DbSet<FlighBooking> FlighBookings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FlighBookingMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
