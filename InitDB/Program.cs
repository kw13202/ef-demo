using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                efDbContext.Blogs.Add(new Blog()
                {
                    Name = "Harry",
                    Url = "http://www.qq.com",
                });


                //多对多关系
                var student = new Student()
                {
                    Name = "Ken",
                    Age = 26,
                    CreateTime = DateTime.Now,
                    ModifiedTime = DateTime.Now,
                    Courses = new List<Course>()
                    {
                        new Course()
                        {
                            Name = "C#",
                            MaximumStrength = 12,
                            CreateTime = DateTime.Now,
                            ModifiedTime = DateTime.Now,
                        },
                        new Course()
                        {
                            Name = "Entity Framework",
                            MaximumStrength = 25,
                            CreateTime = DateTime.Now,
                            ModifiedTime = DateTime.Now,
                        }
                    },
                    StudentContact = new StudentContact()
                    {
                        ContactNumber = "13800138000"
                    }
                };
                efDbContext.Students.Add(student);


                efDbContext.SaveChanges();
            }
        }
    }
}
