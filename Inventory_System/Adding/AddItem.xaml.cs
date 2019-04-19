using Final;
using Inventory_System.Connects;
using Inventory_System.EF_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Inventory_System.Adding
{

    /// <summary>
    /// Interaction logic for AddItem.xaml
    /// </summary>
    public partial class AddItem : Window
    {
        Context context = new Context();
        List<LvInvoice> listoflvitems = new List<LvInvoice>();
        purchaseInvoice pi;

        public AddItem()
        {
            context.SaveChanges();
            pi = new purchaseInvoice();
            InitializeComponent();
            var cats = context.Catogerys;
            cmbitems.Items.Clear();
            foreach (Catogery item in cats)
            {
                cmbcats.DisplayMemberPath = "Name";
                cmbcats.SelectedValuePath = "ID";
                cmbcats.Items.Add(item);
            }
            var suppliers = context.Suppliers;
            foreach (var item in suppliers)
            {
                cmbsuppliers.DisplayMemberPath = "Name";
                cmbsuppliers.SelectedValuePath = "ID";
                cmbsuppliers.Items.Add(item);
            }
            LVitems.Items.Clear();




        }



        private void cmbcats_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Catogery cat = (Catogery)cmbcats.SelectedItem;
            txtItemName.IsEnabled = true;
            //int x = cat.ID;
            if (cat != null)
            {
                cmbitems.Items.Clear();
                var items = context.Items.Where(i => i.catogery.ID == cat.ID);
                foreach (Item x in items)
                {
                    cmbitems.DisplayMemberPath = "name";
                    cmbitems.SelectedValuePath = "ID";
                    cmbitems.Items.Add(x);
                }
            }

        }
        bool FirstClick = false;
        private void btnadditem_Click(object sender, RoutedEventArgs e)
        {


            int qty, sellprice, buyprice;
            bool tryqty = int.TryParse(txtQty.Text, out qty);
            bool trysellprice = int.TryParse(txtsellprice.Text, out sellprice);
            bool trybuyprice = int.TryParse(txtBuyPrice.Text, out buyprice);
            //bool xx = int.Parse(txtsellprice.Text) > int.Parse(txtBuyPrice.Text);
            if (LVitems.Items.Count == 0 && cmbitems.Items.Count > 0 && txtQty.Text != "" && tryqty && sellprice > buyprice && qty > 0&& trysellprice&& trybuyprice)
            {
                cmbsuppliers.IsEnabled = false;
                Item items = (Item)cmbitems.SelectedItem;
                Item current_item = context.Items.Where(c => c.ID == items.ID).First();
                current_item.Quantity += int.Parse(txtQty.Text);
                current_item.SellPrice = int.Parse(txtsellprice.Text);
                current_item.BuyPrice = int.Parse(txtBuyPrice.Text);
                Supplier selected_supplier = (Supplier)cmbsuppliers.SelectedItem;

                if (FirstClick == false)
                {
                    pi = new purchaseInvoice();
                    pi.Date = DateTime.Now;
                    //  pi.Quantity = int.Parse(txtQty.Text);
                    pi.Supplier = selected_supplier;
                    pi.Supplier = (Supplier)cmbsuppliers.SelectedItem;
                    pi.KindOfInvoice = true;
                    pi.TotalPrice = int.Parse(txtQty.Text) * int.Parse(current_item.BuyPrice.ToString());
                    context.purchaseInvoices.Add(pi);
                    FirstClick = true;

                }
                selected_supplier.purchaseInvoices.Add(pi);
                ItemInPurchaseInvoice iip = new ItemInPurchaseInvoice();
                //  iip.Item = ;
                iip.Item_Id = current_item.ID;
                iip.purchaseInvoice_Id = pi.ID;
                iip.purchaseInvoice = pi;
                iip.Quantity = int.Parse(txtQty.Text);
                ////////////////
                context.ItemInPurchaseInvoices.Add(iip);


                context.SaveChanges();
                MessageBox.Show("your items succesfuly");
            }

            else if (LVitems.Items.Count >= 1)
            {
                cmbsuppliers.IsEnabled = false;
                foreach (var item in listoflvitems)
                {
                    //   Context c = new Context();
                    Supplier selected_supplier = (Supplier)cmbsuppliers.SelectedItem;
                    Item current_item = context.Items.Where(cc => cc.ID == item.ID).First();
                    //   Item current_item = context.Items.Where(c => c.ID == item.ID).First();
                    if (FirstClick == false)
                    {
                        pi = new purchaseInvoice();
                        pi.Date = DateTime.Now;
                        //  pi.Quantity = int.Parse(txtQty.Text);
                        pi.KindOfInvoice = true;
                        pi.Supplier = selected_supplier;
                        pi.Supplier = (Supplier)cmbsuppliers.SelectedItem;
                        //  pi.TotalPrice = int.Parse(txtQty.Text) * int.Parse(current_item.BuyPrice.ToString());
                        context.purchaseInvoices.Add(pi);
                        FirstClick = true;

                    }
                    //purchaseInvoice pi = new purchaseInvoice();
                    pi.Date = DateTime.Now;
                    // pi.Quantity = item.Quantity;
                    //  Supplier selected_supplier =item.SupplierID;
                    pi.Supplier = item.Supplier;
                    pi.KindOfInvoice = true;
                    pi.Supplier = item.Supplier; //(Supplier)cmbsuppliers.SelectedItem;
                    pi.TotalPrice = item.Quantity * int.Parse(current_item.BuyPrice.ToString());
                    // selected_supplier.purchaseInvoices.Add(pi);

                    ItemInPurchaseInvoice iip = new ItemInPurchaseInvoice();
                    //item.item.ItemInPurchaseInvoices = new List<ItemInPurchaseInvoice>();
                    //  iip.Item = ;
                    iip.Item_Id = current_item.ID;
                    iip.purchaseInvoice_Id = pi.ID;
                    iip.purchaseInvoice = pi;
                    iip.Quantity = item.Quantity;
                    current_item.Quantity += item.Quantity;
                    current_item.SellPrice = item.SellPrice;
                    current_item.BuyPrice = item.BuyPrice;
                    item.Supplier.purchaseInvoices.Add(pi);
                    //item.item
                    context.ItemInPurchaseInvoices.Add(iip);
                    //context.Suppliers.Add();
                    context.SaveChanges();

                }
                MessageBox.Show("your list of items added succesfuly");
                LVitems.Items.Clear();
                listoflvitems.Clear();
            }
            else
            {
                MessageBox.Show("Plz check that:\n 1-you choosed an item \n" +
                    " 2-you choosed a supplier \n " +
                    "3- sell price bigger than buy price and bigger than zero ");
            }

        }

        private void btnaddtolist_Click(object sender, RoutedEventArgs e)
        {
            //cmbsuppliers.IsEnabled = false;
            int qty, sellprice, buyprice;
            //  bool xx = int.Parse(txtsellprice.Text) > int.Parse(txtBuyPrice.Text);

            bool tryqty = int.TryParse(txtQty.Text, out qty);
            bool trysellprice = int.TryParse(txtsellprice.Text, out sellprice);
            bool trybuyprice = int.TryParse(txtBuyPrice.Text, out buyprice);
            if (cmbitems.Items.Count > 0 && txtQty.Text != "" && tryqty && sellprice > buyprice && qty > 0)
            {

                cmbsuppliers.IsEnabled = false;
                Item cmbbox_item = (Item)cmbitems.SelectedItem;

                var items = context.Items.Where(i => i.ID == cmbbox_item.ID).FirstOrDefault();

                LvInvoice lvinvoice = new LvInvoice();
                lvinvoice.Cat_Id = items.Cat_Id;
                lvinvoice.ID = items.ID;
                lvinvoice.name = items.name;
                Supplier cmbsuplier = (Supplier)cmbsuppliers.SelectedItem;
                lvinvoice.Supplier = context.Suppliers.Where(s => s.ID == cmbsuplier.ID).FirstOrDefault();
                lvinvoice.Quantity = int.Parse(txtQty.Text);
                lvinvoice.SellPrice = double.Parse(txtsellprice.Text);
                lvinvoice.BuyPrice = double.Parse(txtBuyPrice.Text);
                lvinvoice.item = items;

                LVitems.Items.Add(lvinvoice);

                listoflvitems.Add(lvinvoice);


                txtQty.Text = null;


            }
            else
            {
                MessageBox.Show("Plz check that:\n 1-you choosed an item \n" +
                    " 2-you choosed a supplier \n " +
                    "3- sell price bigger than buy price and bigger than zero ");
            }

        }

        private void LVitems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnedit_Click(object sender, RoutedEventArgs e)
        {
            //  LVitems.SelectedItems.Remove(lvinvoice);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // var x = 0;
            LVitems.SelectedItems.Remove(LVitems.SelectedItem);
        }
          private void Button_Click10(object sender, RoutedEventArgs e)
        {
            AddCategory add = new AddCategory();
            add.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddItem add = new AddItem();
            add.Show();
            this.Close();

        }



        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Billls bill = new Billls();
            bill.Show();
            this.Close();

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            AddSalesMan add = new AddSalesMan();
            add.Show();
            this.Close();

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            AddSupplier add = new AddSupplier();
            add.Show();
            this.Close();

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Reportss report = new Reportss();
            report.Show();
            this.Close();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();

        }

        private void Button_Click_20(object sender, RoutedEventArgs e)
        {
            AddCustomer add = new AddCustomer();
            add.Show();
            this.Close();

        }


        private void rdnew_Clicked(object sender, RoutedEventArgs e)
        {
            cmbitems.Visibility = (Visibility)1;
            // cmbsuppliers.Visibility= (Visibility)0;

            // txtsellprice.Visibility = (Visibility)0;
            //txtBuyPrice.Visibility= (Visibility)0;
            txtItemName.Visibility = (Visibility)0;
            btnadditem.Visibility = (Visibility)1;
            btnaddtolist.Visibility = (Visibility)1;
            btnAddnewItem.Visibility = (Visibility)0;
            txtQty.Visibility = (Visibility)1;
        }

        private void rdbitemexist_Click(object sender, RoutedEventArgs e)
        {
            cmbitems.Visibility = (Visibility)0;
            // cmbsuppliers.Visibility = (Visibility)0;

            // txtsellprice.Visibility= (Visibility)1;
            //  txtBuyPrice.Visibility = (Visibility)1;
            txtItemName.Visibility = (Visibility)1;
            btnAddnewItem.Visibility = (Visibility)1;
            btnaddtolist.Visibility = (Visibility)0;
            btnadditem.Visibility = (Visibility)0;
            txtQty.Visibility = (Visibility)0;
        }



        private void btnAddItem_Click_1(object sender, RoutedEventArgs e)
        {
            int sellprice, buyprice;
            //  bool xx = int.Parse(txtsellprice.Text) > int.Parse(txtBuyPrice.Text);

            //*bool tryqty = int.TryParse(txtQty.Text, out qty);
            bool trysellprice = int.TryParse(txtsellprice.Text, out sellprice);
            bool trybuyprice = int.TryParse(txtBuyPrice.Text, out buyprice);

            // bool x = int.Parse(txtsellprice.Text) > int.Parse(txtBuyPrice.Text);
            if (txtItemName.Text != "" && sellprice > buyprice)
            {
                Item new_item = new Item();
                new_item.name = txtItemName.Text;
                new_item.Quantity = 0;//int.Parse( txtQty.Text);
                new_item.SellPrice = int.Parse(txtsellprice.Text);
                new_item.BuyPrice = int.Parse(txtBuyPrice.Text);
                Catogery cat = (Catogery)cmbcats.SelectedItem;
                new_item.Cat_Id = cat.ID;
                context.Items.Add(new_item);
                context.SaveChanges();
                MessageBox.Show("item added ");
                cmbcats.SelectedIndex = -1;
                cmbitems.Items.Clear();
            }
            else
            {
                MessageBox.Show("plz make sure about item name \n and sell price should be bigger than buy price ");
            }
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            FirstClick = false;
            cmbsuppliers.IsEnabled = true;
            LVitems.Items.Clear();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

    [NotMapped]
    public class LvInvoice
    {
        public int Cat_Id { get; set; }
        public int ID{ get; set; }
        public string name { get; set; }
        public Supplier Supplier { get; set; }
        public int Quantity { get; set; }
        public double SellPrice { get; set; }
        public double BuyPrice { get; set; }
        public Item item { get; set; }
    }
}

