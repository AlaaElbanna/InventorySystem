using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.EF_Classes
{
    public class Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string name { get; set; }
        public double SellPrice { get; set; }
        public double BuyPrice { get; set; }
        public int Quantity { get; set; }
        public virtual int Cat_Id { get; set; }

        [ForeignKey("Cat_Id")]
        public virtual Catogery catogery { get; set; }
        public virtual ICollection<ItemInPurchaseInvoice> ItemInPurchaseInvoices { get; set; }
        public virtual ICollection<ItemInReceiptInvoice> ItemInReceiptInvoices { get; set; }
        public virtual ICollection<ItemInSalesInvoice> ItemInSalesInvoices { get; set; }
        
 
 
    }
}
