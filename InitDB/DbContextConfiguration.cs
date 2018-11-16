using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitDB
{
    public class DbContextConfiguration : DbConfiguration 
    {
        public DbContextConfiguration()
        {
            DbInterception.Add(new NLogInterceptor());
        }
    }
}
