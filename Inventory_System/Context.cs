using Inventory_System.EF_Classes;
using System;
using System.Data.Entity;
using System.Linq;
namespace Inventory_System
{
   
    public class Context : DbContext
    {
        // Your context has been configured to use a 'Context' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Inventory_System.Context' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Context' 
        // connection string in the application configuration file.
        public Context()
                 : base("Data Source=.;Initial Catalog=StoreSystem;Integrated Security=True;MultipleActiveResultSets=true")
        {

        }
        public virtual DbSet<Catogery> Catogerys { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<purchaseInvoice> purchaseInvoices { get; set; }
        public virtual DbSet<ItemInPurchaseInvoice> ItemInPurchaseInvoices { get; set; }
        public virtual DbSet<ItemInReceiptInvoice> ItemInReceiptInvoices { get; set; }
        public virtual DbSet<ItemInSalesInvoice> ItemInSalesInvoices { get; set; }
        public virtual DbSet<ReceiptInvoice> ReceiptInvoices { get; set; }
        public virtual DbSet<SalesInvoice> SalesInvoices { get; set; }
        public virtual DbSet<salesman> salesmans { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<User> Users { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}