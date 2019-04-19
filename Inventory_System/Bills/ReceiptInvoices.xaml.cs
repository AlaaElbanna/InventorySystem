using Final;
using Inventory_System.Adding;
using Inventory_System.Connects;
using Inventory_System.DataBaseLayers;
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

namespace Inventory_System.Bills
{
    /// <summary>
    /// Interaction logic for ReceiptInvoices.xaml
    /// </summary>
    public partial class ReceiptInvoices : Window
    {
        Context context;
        double TotalValues = 0;
        ReceiptInvoice recipt;
        CategoryLayer cat;
        SalesManLayer sales;
        public ReceiptInvoices()
        {
            InitializeComponent();
            cat = new CategoryLayer();
            sales = new SalesManLayer();
            context = new Context();
            CategoryCombo.SelectedValuePath = "ID";
            CategoryCombo.DisplayMemberPath = "Name";
            CategoryCombo.ItemsSource = cat.GetAllCategories().ToList();
            SalesManCombo.SelectedValuePath = "ID";
            SalesManCombo.DisplayMemberPath = "Name";
            SalesManCombo.ItemsSource = sales.GetAllSalesMan().ToList();
            Edit.IsEnabled = false;
            Delete.IsEnabled = false;


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
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        bool CreateObject = false;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int result = 0;

            if (CategoryCombo.SelectedIndex != -1 && ItemCombo.SelectedIndex != -1 && int.TryParse(Quantity.Text, out result) && SalesManCombo.SelectedIndex != -1 && Quantity.Text != "")
            {
                int Item_Id = int.Parse(ItemCombo.SelectedValue.ToString());
                var SelectItem = context.Items.Where(item => item.ID == Item_Id).FirstOrDefault();
                int AvailableQuantity = SelectItem.Quantity;
                if (int.Parse(Quantity.Text) > AvailableQuantity)
                { MessageBox.Show("There aren't This Quantity In Store"); return; }
                if (result < 0)
                {
                    MessageBox.Show("This Quantity is not Valid Should Be Positive Num Only");
                    return;
                }
                else
                {
                    int QuantityValue = int.Parse(Quantity.Text);
                    int Sales_id = int.Parse(SalesManCombo.SelectedValue.ToString());
                    if (CreateObject == false)
                    {
                        recipt = new ReceiptInvoice()
                        {
                            Date = DateTime.Now,
                            salesman = context.salesmans.Where(sales => sales.ID == Sales_id).FirstOrDefault(),
                            ItemInReceiptInvoices = new List<ItemInReceiptInvoice>()
                        };
                        context.ReceiptInvoices.Add(recipt);
                        CreateObject = true;
                    }
                    ItemInReceiptInvoice itemsRecipted = new ItemInReceiptInvoice();

                    itemsRecipted.Item = SelectItem;
                    itemsRecipted.ReceiptInvoice = recipt;
                    itemsRecipted.Quantity = QuantityValue;

                    recipt.ItemInReceiptInvoices.Add(itemsRecipted);
                    SelectItem.ItemInReceiptInvoices.Add(itemsRecipted);
                    SelectItem.Quantity -= int.Parse(Quantity.Text);
                    TotalValues += (int.Parse(Quantity.Text) * SelectItem.BuyPrice);
                    var saller = context.salesmans.Where(sallr => sallr.ID == Sales_id).First();
                   
                    saller.ReceiptInvoices.Add(recipt);

                    context.SaveChanges();
                    Total.Text = TotalValues.ToString();
                    NoOfInvoice.Text = (context.ReceiptInvoices.Where(recip => recip.ID == recipt.ID).Select(re => re.ID).First()).ToString();
                    salesMan.Text = SalesManCombo.Text;
                    this.ListView.Items.Add(new ListViewRecipt { ID = int.Parse(NoOfInvoice.Text), Category = CategoryCombo.Text, Item_Name = ItemCombo.Text, Quantity = int.Parse(Quantity.Text), PriceForPiece = SelectItem.BuyPrice, TotalPrice = double.Parse(Quantity.Text) * SelectItem.BuyPrice });
                    Edit.IsEnabled = true;
                    Delete.IsEnabled = true;
                    SalesManCombo.IsEnabled = false;

                }


            }
            else
            {
                MessageBox.Show("Enter Correct Data");
            }
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int Item_Id = int.Parse(ItemCombo.SelectedValue.ToString());
            var SelectItem = context.Items.Where(item => item.ID == Item_Id).FirstOrDefault();

            int No = int.Parse(NoOfInvoice.Text);
            ReceiptInvoice CurrentEdit = context.ReceiptInvoices.Where(recip => recip.ID == No).FirstOrDefault();
            ItemInReceiptInvoice CurrentEditQuan = context.ItemInReceiptInvoices.Where(recip => recip.ReceiptInvoice_Id == CurrentEdit.ID && recip.Item_Id == Item_Id).FirstOrDefault();
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
            Row.TotalPrice = Row.Quantity*Row.PriceForPiece;
            CategoryCombo.IsEnabled = true;
            ItemCombo.IsEnabled = true;

            ListView.Items.Add(Row);
            context.SaveChanges();

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
            SalesManCombo.IsEnabled = false;
            ListViewRecipt Row = ListView.SelectedItem as ListViewRecipt;
            if (Row == null)
                return;
            CategoryCombo.Text = Row.Category;
            ItemCombo.Text = Row.Item_Name;
            Quantity.Text = Row.Quantity.ToString();
            NoOfInvoice.Text = (context.ReceiptInvoices.Where(recip => recip.ID == Row.ID).Select(re => re.ID).FirstOrDefault()).ToString();


        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ListViewRecipt Row = ListView.SelectedItem as ListViewRecipt;
            
            if (Row == null)
                return;
            Total.Text = SubtractTotal(Row.Quantity, Row.PriceForPiece).ToString();
            ListView.Items.Remove(ListView.SelectedItem);
            var Current = context.ReceiptInvoices.Where(recip => recip.ID == Row.ID).First();
            var CurrentItems = context.ItemInReceiptInvoices.Where(recip => recip.ReceiptInvoice_Id == Row.ID).FirstOrDefault();
            if (CurrentItems == null)
                return;
           
            int Item_Id = int.Parse(ItemCombo.SelectedValue.ToString());
            var SelectItem = context.Items.Where(item => item.ID == Item_Id).FirstOrDefault();
            SelectItem.ItemInReceiptInvoices.Remove(CurrentItems);
            context.ItemInReceiptInvoices.Remove(CurrentItems);
            SelectItem.Quantity += Row.Quantity;

            context.SaveChanges();
            CategoryCombo.IsEnabled = true;
            ItemCombo.IsEnabled = true;

        }

        private void SalesManCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int Sales_id = int.Parse(SalesManCombo.SelectedValue.ToString());

          
        }

        private void Quantity_KeyDown(object sender, KeyEventArgs e)
        {
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
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }

        private void Button_Click_99(object sender, RoutedEventArgs e)
        {
            SalesManCombo.IsEnabled = true;
             CreateObject = false;
            ListView.Items.Clear();
            NoOfInvoice.Text = "";

        }
    }
}
