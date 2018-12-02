using DbTransactionDemo.Map;
using DbTransactionDemo.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbTransactionDemo
{
    public class EfDbContext : DbContext
    {
        public EfDbContext() : base("name=ConnectionString")
        {

        }

        public EfDbContext(DbConnection conn) : base(conn, contextOwnsConnection: false)
        {

        }

        public DbSet<FlighBooking> FlighBookings { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FlighBookingMap());
            modelBuilder.Configurations.Add(new ReservationMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
