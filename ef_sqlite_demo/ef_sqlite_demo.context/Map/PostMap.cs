using ef_sqlite_demo.model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ef_sqlite_demo.context.Map
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            //表名
            builder.ToTable("Posts");

            //主键
            builder.HasKey(x => x.Id);

            //字段
            builder.Property(x => x.Id);
            builder.Property(x => x.PostName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.CreateTime);

            //索引

            //关系
            builder.HasMany(x => x.PostTags).WithOne(x => x.Post).HasForeignKey(x => x.PostId);
        }
    }
}
