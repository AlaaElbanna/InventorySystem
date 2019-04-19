using Final;
using Inventory_System.Connects;
using Inventory_System.DataBaseLayers;
using Inventory_System.EF_Classes;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddToSellInvoice.xaml
    /// </summary>
    public partial class AddToPurchaseInvoice : Window
    {
         SupplierLayer supLay;
        CategoryLayer catLay;
        ItemLayer itmLay;
        ItemInPurchaseLayer ItmpurLay;
        PurchaseInvoiceLayer purLayer;
        Base baseLayer;
        public AddToPurchaseInvoice()
        {
            supLay = new SupplierLayer();
            purLayer = new PurchaseInvoiceLayer();
            catLay = new CategoryLayer();
            itmLay = new ItemLayer();
            ItmpurLay = new ItemInPurchaseLayer();
            baseLayer = new Base();
            InitializeComponent();
        }
       

       

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
            NameText.SelectedValuePath = "ID";
            NameText.DisplayMemberPath = "Name";
            NameText.ItemsSource = supLay.GetAllSupplier().ToList();

             CategoryCombo.SelectedValuePath = "ID";
            CategoryCombo.DisplayMemberPath = "Name";
            CategoryCombo.ItemsSource = catLay.GetAllCategories().ToList();

        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
          int Cat_Id = int.Parse(CategoryCombo.SelectedValue.ToString());
          var query = catLay.GetAllItemsinCategory(Cat_Id);
          ItemCombo.SelectedValuePath = "ID";
          ItemCombo.DisplayMemberPath = "name";
          ItemCombo.ItemsSource = query.ToList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int result = 0;
            if (NameText.SelectedIndex!=-1&&CategoryCombo.SelectedIndex!=-1&&Quantity.Text!=""&&int.TryParse(Quantity.Text,out result)==true)
            {
                if (result<0)
                {
                    MessageBox.Show("Enter Positive Num Only");
                    return;
                }
                int item_Id = int.Parse(ItemCombo.SelectedValue.ToString());
                var query = itmLay.GetItem(item_Id);
                int quan = int.Parse(Quantity.Text);
                
               int Sal_Id = int.Parse(NameText.SelectedValue.ToString());
                int inv_Id = int.Parse(NoOfInvoice.Text);
                ItemInPurchaseInvoice itm = ItmpurLay.CreateInvoice(item_Id, inv_Id, quan);
                itmLay.IncreaseQuantity(query, quan);
               
                DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day );
                List1.ItemsSource = null;

                var Items = itmLay.GetItemWithItemsMapping(inv_Id, date);
                    

                 Add.IsEnabled = true;
                List1.ItemsSource = null;
                 List1.ItemsSource = Items.ToList();
                MessageBox.Show("Done");
          
            }
            else
            {

                MessageBox.Show("Pleast Enter All DAta And Quantity Should be number Positive");
            }

        }

        private void NameText_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
        }

        private void NameTex_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        bool InvoiceValue = false;
        private void Get_Click(object sender, RoutedEventArgs e)
        {
            if (NameText.SelectedIndex!=-1&&KindOfInvoice.SelectedIndex!=-1)
            {
                int Sal_Id = int.Parse(NameText.SelectedValue.ToString());
            DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
             ComboBoxItem com = (ComboBoxItem)KindOfInvoice.SelectedItem;
                string value = com.Content.ToString();
                if (value == "Sell")
                    InvoiceValue = true;
                else
                    InvoiceValue = false;

                var query = purLayer.ReturnInvoice(Sal_Id,date,InvoiceValue);
            if (query == null)
            {
                MessageBox.Show("No Invoice With This Data");
                Add.IsEnabled = false;
                return;
            }
                NoOfInvoice.Text = query.ID.ToString();
             var Items = itmLay.GetItemWithItemsMapping(query.ID, date);
                    

            Add.IsEnabled = true;

            List1.ItemsSource = Items.ToList();
            }
            else
            {
                MessageBox.Show("{please Choose Supplier And Kind Of Invoice");
            }
        }

        private void List1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
