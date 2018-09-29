using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InitDB.Model;

namespace InitDB.Map
{
    public class StudentPhotoMap : EntityTypeConfiguration<StudentPhoto>
    {
        public StudentPhotoMap()
        {
            //表名
            ToTable("StudentPhotos");

            //主键
            HasKey(x => x.Id);

            //字段
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.PhotoType);
            Property(x => x.PhotoUrl).HasMaxLength(500).IsRequired();
            Property(x => x.CreateTime);
            Property(x => x.ModifiedTime);

            //索引

            //关系

        }
    }
}
