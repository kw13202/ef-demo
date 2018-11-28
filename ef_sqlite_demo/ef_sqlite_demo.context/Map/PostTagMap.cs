using ef_sqlite_demo.model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ef_sqlite_demo.context.Map
{
    public class PostTagMap : IEntityTypeConfiguration<PostTag>
    {
        public void Configure(EntityTypeBuilder<PostTag> builder)
        {
            //表名
            builder.ToTable("PostTag");

            //主键
            builder.HasKey(x => new { x.PostId, x.TagId });

            //字段

            //索引

            //关系
        }
    }
}
