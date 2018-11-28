using ef_sqlite_demo.model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ef_sqlite_demo.context.Map
{
    public class TagMap : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            //表名
            builder.ToTable("Tags");

            //主键
            builder.HasKey(x => x.Id);

            //字段
            builder.Property(x => x.Id);
            builder.Property(x => x.TagName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.CreateTime);

            //索引

            //关系
            builder.HasMany(x => x.PostTags).WithOne(x => x.Tag).HasForeignKey(x => x.TagId);
        }
    }
}
