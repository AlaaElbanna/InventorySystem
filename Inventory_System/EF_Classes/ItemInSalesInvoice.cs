using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.EF_Classes
{
    public class ItemInSalesInvoice
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public virtual int Item_Id { get; set; }
        public int Quantity { get; set; }
        public virtual int SalesInvoice_Id { get; set; }

        [ForeignKey("Item_Id")]
        public virtual Item Item { get; set; }
       

        [ForeignKey("SalesInvoice_Id")]
        public virtual SalesInvoice SalesInvoice { get; set; }
  
    }
}
