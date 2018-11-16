using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Extensions;
using InitDB.Model;

namespace InitDB
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var efDbContext = new EfDbContext())
            {
                var errors = efDbContext.GetValidationErrors();
                //efDbContext.Blogs.Add(new Blog()
                //{
                //    Name = "Harry",
                //    Url = "http://www.qq.com",
                //});
                int id = 1;
                efDbContext.Blogs.Where(x => x.Id == id).ToListAsync();

                ////多对多关系
                //var student = new Student()
                //{
                //    Name = "Ken",
                //    Age = 26,
                //    CreateTime = DateTime.Now,
                //    ModifiedTime = DateTime.Now,
                //    Courses = new List<Course>()
                //    {
                //        new Course()
                //        {
                //            Name = "C#",
                //            MaximumStrength = 12,
                //            CreateTime = DateTime.Now,
                //            ModifiedTime = DateTime.Now,
                //        },
                //        new Course()
                //        {
                //            Name = "Entity Framework",
                //            MaximumStrength = 25,
                //            CreateTime = DateTime.Now,
                //            ModifiedTime = DateTime.Now,
                //        }
                //    },
                //    StudentContact = new StudentContact()
                //    {
                //        ContactNumber = "13800138000"
                //    }
                //};
                //efDbContext.Students.Add(student);

                //var student = new Student()
                //{
                //    Id = 1,
                //    Name = "Harry",
                //    Age = 30
                //};
                //efDbContext.Entry(student).State = EntityState.Unchanged;
                //efDbContext.Entry(student).Property(x => x.Name).IsModified = true;
                //efDbContext.Entry(student).Property(x => x.Age).IsModified = true;

                //使用第三方批量更新
                efDbContext.Students.Where(x => x.Id > 1).Update(x => new Student() {Age = 66});


                efDbContext.SaveChanges();
            }
        }
    }
}
