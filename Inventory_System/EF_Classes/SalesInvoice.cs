using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.EF_Classes
{
   public class SalesInvoice
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [NotMapped]
        public double TotalPrice { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }
        public bool KindOfInvoice { get; set; }
        public bool TypeOfPay { get; set; }
        public virtual int Customer_Id { get; set; }

        [ForeignKey("Customer_Id")]
        public virtual Customer Customer { get; set; }
        public virtual int salesman_Id { get; set; }

        [ForeignKey("salesman_Id")]
        public virtual salesman salesman { get; set; }
        public virtual ICollection<ItemInSalesInvoice> ItemInSalesInvoices { get; set; }
    }
}
