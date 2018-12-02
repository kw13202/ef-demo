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
    public class ReservationMap : EntityTypeConfiguration<Reservation>
    {
        public ReservationMap()
        {
            //表名
            ToTable("Reservations");

            //主键
            HasKey(x => x.BookingId);

            //字段
            Property(x => x.BookingId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasMaxLength(50).IsRequired();
            Property(x => x.BookingDate);

            //索引

            //关系

        }
    }
}
