using Final;
using Inventory_System;
using Inventory_System.Adding;
using Inventory_System.Connects;
using Inventory_System.EF_Classes;
using Inventory_System.NotMappedCalsses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Inventory_System.Returnable
{
    public partial class BackFromSupplier : Window
    {
        Context context;
        double TotalValues = 0;
        purchaseInvoice recipt;

        public BackFromSupplier()
        {
            InitializeComponent();
            context = new Context();
            var query = context.Catogerys;
            CategoryCombo.SelectedValuePath = "ID";
            CategoryCombo.DisplayMemberPath = "Name";
            CategoryCombo.ItemsSource = query.ToList();
            var query2 = context.Suppliers;
            SupllierCombo.SelectedValuePath = "ID";
            SupllierCombo.DisplayMemberPath = "Name";
            SupllierCombo.ItemsSource = query2.ToList();
            Edit.IsEnabled = false;
            Delete.IsEnabled = false;
            recipt = new purchaseInvoice();


        }
        public double calculateTotal(int quantity, double price)
        {
            double CurrentValue = quantity * price;
            TotalValues += CurrentValue;
            return TotalValues;
        }
        public double SubtractTotal(int quantity, double price)
        {
            double CurrentValue = quantity * price;
            TotalValues -= CurrentValue;
            return TotalValues;
        }
        private void Button_Click10(object sender, RoutedEventArgs e)
        {
            AddCategory add = new AddCategory();
            add.Show();
            this.Close();
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            AddItem add = new AddItem();
            add.Show();
            this.Close();

        }



        private void Button_Click_30(object sender, RoutedEventArgs e)
        {
            Billls bill = new Billls();
            bill.Show();
            this.Close();

        }

        private void Button_Click_40(object sender, RoutedEventArgs e)
        {
            AddSalesMan add = new AddSalesMan();
            add.Show();
            this.Close();

        }

        private void Button_Click_50(object sender, RoutedEventArgs e)
        {
            AddSupplier add = new AddSupplier();
            add.Show();
            this.Close();

        }

        private void Button_Click_60(object sender, RoutedEventArgs e)
        {
            Reportss report = new Reportss();
            report.Show();
            this.Close();
        }

        private void Button_Click_70(object sender, RoutedEventArgs e)
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
        bool CreatedObject = false;
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (Regex.IsMatch(Quantity.Text, "[^ 0-9]*") || double.Parse(Quantity.Text) <= 0)
            {
                MessageBox.Show("This Quantity is not Valid");
            }

            else if (CategoryCombo.SelectedIndex != -1 && ItemCombo.SelectedIndex != -1 && SupllierCombo.SelectedIndex != -1 && Quantity.Text != "")
            {
                int Item_Id = int.Parse(ItemCombo.SelectedValue.ToString());
                var SelectItem = context.Items.Where(item => item.ID == Item_Id).FirstOrDefault();
                int AvailableQuantity = SelectItem.Quantity;
                if (int.Parse(Quantity.Text) > AvailableQuantity)
                { MessageBox.Show("There aren't This Quantity In Store"); }
                else
                {
                    int QuantityValue = int.Parse(Quantity.Text);
                    int supp_Id = int.Parse(SupllierCombo.SelectedValue.ToString());
                    if (CreatedObject == false)
                    {
                        recipt = new purchaseInvoice()
                        {
                            Date = DateTime.Now,
                            Supplier = context.Suppliers.Where(sup => sup.ID == supp_Id).FirstOrDefault(),
                            ItemInPurchaseInvoices = new List<ItemInPurchaseInvoice>()
                        };
                        CreatedObject = true;
                        context.purchaseInvoices.Add(recipt);

                    }
                    ItemInPurchaseInvoice itemsRecipted = new ItemInPurchaseInvoice();

                    itemsRecipted.Item = SelectItem;
                    itemsRecipted.purchaseInvoice = recipt;
                    itemsRecipted.Quantity = QuantityValue;
                    recipt.ItemInPurchaseInvoices.Add(itemsRecipted);
                    SelectItem.ItemInPurchaseInvoices.Add(itemsRecipted);
                    SelectItem.Quantity -= int.Parse(Quantity.Text);
                    TotalValues += (int.Parse(Quantity.Text) * SelectItem.SellPrice);
                    var suplier = context.Suppliers.Where(sallr => sallr.ID == supp_Id).FirstOrDefault();
                    suplier.purchaseInvoices.Add(recipt);
                    context.SaveChanges();
                    Total.Text = TotalValues.ToString();
                    NoOfInvoice.Text = recipt.ID.ToString();
                    salesMan.Text = SupllierCombo.Text;
                    this.ListView.Items.Add(new ListViewRecipt { ID = int.Parse(NoOfInvoice.Text), Category = CategoryCombo.Text, Item_Name = ItemCombo.Text, Quantity = int.Parse(Quantity.Text), PriceForPiece = SelectItem.SellPrice, TotalPrice = double.Parse(Quantity.Text) * SelectItem.SellPrice });
                    Edit.IsEnabled = true;
                    Delete.IsEnabled = true;
                    SupllierCombo.IsEnabled = false;

                }


            }
            else
            {
                MessageBox.Show("Enter Correct Data");
            }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListView.Items.Count == 0)
            {
                Edit.IsEnabled = false;
                Delete.IsEnabled = false;
                return;
            }
            CategoryCombo.IsEnabled = false;
            ItemCombo.IsEnabled = false;
            SupllierCombo.IsEnabled = false;
            ListViewRecipt Row = ListView.SelectedItem as ListViewRecipt;
            if (Row == null)
                return;
            CategoryCombo.Text = Row.Category;
            ItemCombo.Text = Row.Item_Name;
            Quantity.Text = Row.Quantity.ToString();
            NoOfInvoice.Text = (context.purchaseInvoices.Where(recip => recip.ID == Row.ID).Select(re => re.ID).FirstOrDefault()).ToString();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int Item_Id = int.Parse(ItemCombo.SelectedValue.ToString());
            var SelectItem = context.Items.Where(item => item.ID == Item_Id).FirstOrDefault();

            int No = int.Parse(NoOfInvoice.Text);
            purchaseInvoice CurrentEdit = context.purchaseInvoices.Where(recip => recip.ID == No).FirstOrDefault();
            ItemInPurchaseInvoice CurrentEditQuan = context.ItemInPurchaseInvoices.Where(recip => recip.purchaseInvoice_Id == CurrentEdit.ID && recip.Item_Id == SelectItem.ID).FirstOrDefault();
            if (CurrentEdit == null)
                return;
            SelectItem.Quantity += CurrentEditQuan.Quantity;
            CurrentEditQuan.Quantity = int.Parse(Quantity.Text);
            SelectItem.Quantity -= CurrentEditQuan.Quantity;

            ListViewRecipt Row = ListView.SelectedItem as ListViewRecipt;
            if (Row == null)
                return;
            SubtractTotal(Row.Quantity, Row.PriceForPiece);
            Row.Quantity = int.Parse(Quantity.Text);
            ListView.Items.Remove(ListView.SelectedItem);
            Total.Text = calculateTotal(Row.Quantity, Row.PriceForPiece).ToString();
            CategoryCombo.IsEnabled = true;
            ItemCombo.IsEnabled = true;

            ListView.Items.Add(Row);
            context.SaveChanges();


        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int Item_Id = int.Parse(ItemCombo.SelectedValue.ToString());
            var SelectItem = context.Items.Where(item => item.ID == Item_Id).FirstOrDefault();

            ListViewRecipt Row = ListView.SelectedItem as ListViewRecipt;
            if (Row == null)
                return;
            Total.Text = SubtractTotal(Row.Quantity, Row.PriceForPiece).ToString();

            ListView.Items.Remove(ListView.SelectedItem);
            var Current = context.purchaseInvoices.Where(recip => recip.ID == Row.ID).FirstOrDefault();
            var CurrentItems = context.ItemInPurchaseInvoices.Where(recip => recip.purchaseInvoice_Id == Row.ID && recip.Item_Id == SelectItem.ID).FirstOrDefault();
            if (CurrentItems == null)
                return;
            int sup_id = int.Parse(SupllierCombo.SelectedValue.ToString());

            var suplier = context.Suppliers.Where(sallr => sallr.ID == sup_id).First();
            context.ItemInPurchaseInvoices.Remove(CurrentItems);
            SelectItem.Quantity += Row.Quantity;
            context.SaveChanges();
            CategoryCombo.IsEnabled = true;
            ItemCombo.IsEnabled = true;

        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (CategoryCombo.SelectedIndex == -1)
            {

                return;
            }
            int Cat_id = int.Parse(CategoryCombo.SelectedValue.ToString());
            var query = context.Items.Where(item => item.catogery.ID == Cat_id).ToList();
            ItemCombo.SelectedValuePath = "ID";
            ItemCombo.DisplayMemberPath = "name";
            ItemCombo.ItemsSource = query.ToList();


        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }
    }
}
