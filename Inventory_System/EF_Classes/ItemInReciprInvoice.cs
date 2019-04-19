using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.EF_Classes
{
    public class ItemInReceiptInvoice
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public virtual int Item_Id { get; set; }
        public int Quantity { get; set; }
        public virtual int ReceiptInvoice_Id { get; set; }

        [ForeignKey("Item_Id")]
        public virtual Item Item { get; set; }
 

        [ForeignKey("ReceiptInvoice_Id")]
        public virtual ReceiptInvoice ReceiptInvoice { get; set; }
  
    }
}
