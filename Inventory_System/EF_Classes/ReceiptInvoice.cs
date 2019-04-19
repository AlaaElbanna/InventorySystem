using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.EF_Classes
{
   public class ReceiptInvoice
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [NotMapped]
        public double TotalPrice { get; set; }
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
        public virtual int salesman_Id { get; set; }

        [ForeignKey("salesman_Id")]
        public virtual salesman salesman { get; set; }
        public ICollection<ItemInReceiptInvoice> ItemInReceiptInvoices { get; set; }
        
    }
}
