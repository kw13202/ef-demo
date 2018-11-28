using ef_sqlite_demo.context;
using ef_sqlite_demo.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ef_sqlite_demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly SqliteContext _context;

        public HomeController(SqliteContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Posts.Include(x => x.PostTags).ThenInclude(pt => pt.Tag).ToListAsync());
        }

        public async Task<IActionResult> Add()
        {
            Random random = new Random();
            var post = new Post()
            {
                PostName = "博客" + random.Next(),
                CreateTime = DateTime.Now,
            };
            post.PostTags.Add(new PostTag()
            {
                PostId = post.Id,
                Tag = new Tag()
                {
                    TagName = "标签" + random.Next(),
                    CreateTime = DateTime.Now,
                }
            });
            post.PostTags.Add(new PostTag()
            {
                PostId = post.Id,
                Tag = new Tag()
                {
                    TagName = "标签" + random.Next(),
                    CreateTime = DateTime.Now,
                }
            });
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            return View();
        }



    }
}
