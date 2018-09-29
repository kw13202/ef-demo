using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitDB
{
    public class CustomKeyConvention : Convention
    {
        public CustomKeyConvention()
        {
            Properties().Where(x => x.Name == "Id").Configure(x => x.IsKey());
        }
    }
}
