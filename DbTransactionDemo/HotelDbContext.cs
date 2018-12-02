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
    public class HotelDbContext : DbContext
    {
        public HotelDbContext() : base("name=reservationConnection")
        {

        }

        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ReservationMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}
