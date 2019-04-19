using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.EF_Classes
{
    public class purchaseInvoice
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [NotMapped]
        public double TotalPrice { get; set; }
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
        public bool KindOfInvoice { get; set; }
         public virtual int Supplier_Id { get; set; }

        [ForeignKey("Supplier_Id")]
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<ItemInPurchaseInvoice> ItemInPurchaseInvoices { get; set; }
    }
}
