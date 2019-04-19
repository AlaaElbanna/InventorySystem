using Inventory_System.EF_Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.DataBaseLayers
{
    public class CategoryLayer : Base
    {
        public IQueryable<Catogery> GetAllCategories()
        {
            var Categories = context.Catogerys;
            return Categories;
        }
        public IQueryable<Item> GetAllItemsinCategory(int cat_id)
        {
           var query= context.Items.Where(c => c.Cat_Id == cat_id);
            return query;
        }
    }
}
