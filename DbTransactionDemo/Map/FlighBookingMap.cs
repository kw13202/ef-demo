using DbTransactionDemo.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbTransactionDemo.Map
{
    public class FlighBookingMap : EntityTypeConfiguration<FlighBooking>
    {
        public FlighBookingMap()
        {
            //表名
            ToTable("FlighBookings");

            //主键
            HasKey(x => x.FlightId);

            //字段
            Property(x => x.FlightId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.FlightName).HasMaxLength(50).IsRequired();
            Property(x => x.Number);
            Property(x => x.TravellingDate);

            //索引

            //关系

        }
    }
}
