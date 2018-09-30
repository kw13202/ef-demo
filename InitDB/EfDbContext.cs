using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using InitDB.Map;
using InitDB.Migrations;
using InitDB.Model;

namespace InitDB
{
    public class EfDbContext : DbContext
    {
        public EfDbContext() : base("name=ConnectionString")
        {
            //数据库不存在就创建
            //Database.SetInitializer(new CreateDatabaseIfNotExists<EfDbContext>());
            //总是创建无论是否存在
            //Database.SetInitializer(new DropCreateDatabaseAlways<EfDbContext>());
            //数据库模型发生变化则删除重建
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EfDbContext>());

            //自动迁移
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EfDbContext, Configuration>());

            //去除为空检查，生成简单的sql，少了很多判断，有利于查询
            Configuration.UseDatabaseNullSemantics = false;

            Database.Log = Console.WriteLine;
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<BillingDetail> BillingDetails { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //全局
            //modelBuilder.Properties().Where(x => x.Name == "Id").Configure(x => x.IsKey());//有属性Id，则配置为主键
            modelBuilder.Properties<decimal>().Configure(x => x.HasPrecision(10, 2));//decimal类型配置为10位整数，2位小数
            //modelBuilder.Properties<string>().Configure(x => x.HasMaxLength(500));//所有字符串长度设为500
            //modelBuilder.Properties().Where(x => x.Name == "Name").Configure(x => x.HasMaxLength(250));//Name属性的长度为250，这配置会覆盖上面的配置

            //自定义
            //modelBuilder.Conventions.Add<CustomKeyConvention>();
            //modelBuilder.Conventions.AddBefore<IdKeyDiscoveryConvention>(new DateTime2Convention());//在内置发现主键约定之前运行
            //modelBuilder.Conventions.Add(new DateTime2Convention());

            //modelBuilder.Types().Configure(x => x.ToTable(GetTableName(x.ClrType)));
            //modelBuilder.Properties().Where(x => x.GetCustomAttributes(false).OfType<NonUnicode>().Any())
            //    .Configure(x => x.IsUnicode(false));//是否unicode，是则数据库列累死是nvarchar，否则是varchar


            //忽视生成模型
            //modelBuilder.Ignore<Course>();
            //复杂类型
            //modelBuilder.Entity<Order>().ToTable("Orders");
            //modelBuilder.ComplexType<Address>();

            //通过约束区分discriminator
            //modelBuilder.Entity<BillingDetail>().Map<BankAccount>(m => m.Requires("BillingDetailType").HasValue(1))
            //    .Map<CreditCard>(m => m.Requires("BillingDetailType").HasValue(2));//映射到BillingDetailType来区分两者(虽然感觉并没有什么卵用)


            //注册Map
            //modelBuilder.Configurations.Add(new CustomerMap());
            //通过反射注册Map
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => !string.IsNullOrEmpty(t.Namespace))
                .Where(t => t.BaseType != null && t.BaseType.IsGenericType &&
                            t.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }


        }

        private string GetTableName(Type type)
        {
            //把UserClass生成表的时候变为User_Class
            var result = Regex.Replace(type.Name, ".[A-Z]", x => x.Value[0] + "_" + x.Value[1]);
            return result.ToString();
        }



    }
}
