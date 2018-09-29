using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InitDB.Model;

namespace InitDB.Map
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            //表名
            ToTable("Customers");

            //主键
            HasKey(x => x.Id);

            //字段
            Property(x => x.Name).HasMaxLength(50).IsRequired();
            Property(x => x.Email).HasMaxLength(50).IsRequired();
            Property(x => x.CreateTime).HasColumnType("DateTime2");
            Property(x => x.ModifiedTime).HasColumnType("DateTime2");

            //索引
            HasIndex(x => new { x.Name, x.Email });

        }
    }
}
