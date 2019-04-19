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
    /// Interaction logic for AddToSpecialInvoice.xaml
    /// </summary>
    public partial class AddToSpecialInvoice : Window
    {
        SalesManLayer salLay;
        CategoryLayer catLay;
        ItemLayer itmLay;
        ItemInReceiptInvoiceLayer ItmrecLay;
        ReceiptInvoiceLayer recLayer;
        Base baseLayer;
        public AddToSpecialInvoice()
        {
            salLay = new SalesManLayer();
            recLayer = new ReceiptInvoiceLayer();
            catLay = new CategoryLayer();
            itmLay = new ItemLayer();
            ItmrecLay = new ItemInReceiptInvoiceLayer();
            baseLayer = new Base();
            InitializeComponent();
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
            var Customers = salLay.GetAllSalesMan();
            NameText.SelectedValuePath = "ID";
            NameText.DisplayMemberPath = "Name";
            NameText.ItemsSource = Customers.ToList();

            var categories = catLay.GetAllCategories(); ;
            CategoryCombo.SelectedValuePath = "ID";
            CategoryCombo.DisplayMemberPath = "Name";
            CategoryCombo.ItemsSource = categories.ToList();

        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
          int Cat_Id = int.Parse(CategoryCombo.SelectedValue.ToString());
            var query = catLay.GetAllItemsinCategory(Cat_Id); 
          ItemCombo.SelectedValuePath = "ID";
          ItemCombo.DisplayMemberPath = "name";
          ItemCombo.ItemsSource = query.ToList();

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
            AddUser add = new AddUser();
            add.Show();
            this.Close();

        }

        private void Button_Click_20(object sender, RoutedEventArgs e)
        {
            AddCustomer add = new AddCustomer();
            add.Show();
            this.Close();

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
             int result = 0;
           
             if (NameText.SelectedIndex!=-1&&CategoryCombo.SelectedIndex!=-1&&Quantity.Text!=""&&int.TryParse(Quantity.Text,out result)==true)
             {
                 if (result < 0)
                 {
                     MessageBox.Show("Enter Positive Num Only");
                     return;
                 }
                int item_Id = int.Parse(ItemCombo.SelectedValue.ToString());
                var query = itmLay.GetItem(item_Id);
                int quan = int.Parse(Quantity.Text);
                if (query.Quantity < quan)
                {
                    MessageBox.Show("This Quantity isn't Available in The Store");
                    return;
                }
               int Sal_Id = int.Parse(NameText.SelectedValue.ToString());
                int inv_Id = int.Parse(NoOfInvoice.Text);
                ItmrecLay.CreateInvoice(item_Id,inv_Id,quan);
                itmLay.DecreaseQuantity(query, quan);
               
                DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                List1.ItemsSource = null;
                var Items = itmLay.GetRecItemWithItemsMapping(inv_Id, date);

                 Add.IsEnabled = true;

                 List1.ItemsSource = Items.ToList();
      
          
            }
             else
             {

                 MessageBox.Show("Pleast Enter All DAta And Quantity Should be number Positive");
             }
        }

        private void NameText_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int Sal_Id = int.Parse(NameText.SelectedValue.ToString());
            DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            var query = recLayer.GetInvoice(Sal_Id, date);
            if (query == null)
            {
                MessageBox.Show("No Invoice With This Data");
                Add.IsEnabled = false;
                return;
            }
            NoOfInvoice.Text = query.ID.ToString();
            var Items = itmLay.GetRecItemWithItemsMapping(query.ID, date);
            Add.IsEnabled = true;
            
            List1.ItemsSource = Items.ToList();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
