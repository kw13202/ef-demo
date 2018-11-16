using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using InitDB.Model;

namespace InitDB.Map
{
    public class SQLProfilerMap : EntityTypeConfiguration<SQLProfiler>
    {
        public SQLProfilerMap()
        {
            //表名
            ToTable("SQLProfilers");

            //主键
            HasKey(x => x.Id);

            //字段
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Query).IsRequired().HasColumnType("VARCHAR");
            Property(x => x.Parameters);
            Property(x => x.CommandType).HasColumnType("VARCHAR");
            Property(x => x.TotalSeconds);
            Property(x => x.Exception).HasColumnType("VARCHAR");
            Property(x => x.InnerException).HasColumnType("VARCHAR");
            Property(x => x.RequestId);
            Property(x => x.FileName);
            Property(x => x.CreateDate);
            Property(x => x.Active);

            //索引

            //关系
        }
    }
}
