using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.DataBaseLayers
{
    public class Base
    {
        public Context context;
        public Base ()
        {
            context = new Context();
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
