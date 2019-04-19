using Final;
using Inventory_System.Adding;
using Inventory_System.Connects;
using Inventory_System.DataBaseLayers;
using Inventory_System.EF_Classes;
using Inventory_System.NotMappedCalsses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Inventory_System.Reports
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ItemLayer item;
        List<GetItems> listdata;
        GetItems data;
        public MainWindow()
        {
            InitializeComponent();
            item = new ItemLayer();
            listdata = new List<GetItems>();
            listdata = item.GetItems();


        }

        public void GetDatefromDatabase()
        {



        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShowItem.ItemsSource = null;
            ShowItem.ItemsSource = listdata;
            ItemName.IsEnabled = false; 
            Quantity.IsEnabled = false;
            SellPrice.IsEnabled = false;
            BuyPrice.IsEnabled = false;


        }

        private void ShowItem_Loaded(object sender, RoutedEventArgs e)
        {


        }

        private void ShowItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Category.SelectedItem = data.Category;
            ItemName.IsEnabled = false;
            Quantity.IsEnabled = false;
            SellPrice.IsEnabled = false;
            BuyPrice.IsEnabled = false;


        }

        private void Save_Click_1(object sender, RoutedEventArgs e)
        {

            int result = 0;
            double price = 0;
            if (!int.TryParse(Quantity.Text, out result) && result < 0 &&
                !double.TryParse(SellPrice.Text, out price) && price < 0 &&
                 !double.TryParse(BuyPrice.Text, out price) && price < 0)
            {
                MessageBox.Show("This Quantity is not Valid");
            }

            else
            {
                if (ItemName.Text != "" && Quantity.Text != "" && SellPrice.Text != "" && BuyPrice.Text != "")
                {
                    GetItems Data = new GetItems();

                    Data.Code = data.Code;
                    Data.Name = ItemName.Text;
                    Data.Quantity = Quantity.Text;
                    Data.SellPrice = SellPrice.Text;
                    Data.BuyPrice = BuyPrice.Text;
                    int id = int.Parse(data.Code);
                    int CatID = item.getIDCat(id);
                    item.SaveItem(Data, CatID);
                    ShowItem.ItemsSource = null;
                    ShowItem.ItemsSource = item.GetItems();
                    ItemName.IsEnabled = false;
                    Quantity.IsEnabled = false;
                    SellPrice.IsEnabled = false;
                    BuyPrice.IsEnabled = false;

                    MessageBox.Show("Save Sucess");
                }
                else
                    MessageBox.Show("Complete All Data");
            }

        }


        private void ShowItem_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (ShowItem.SelectedIndex != -1)
            {

                data = (GetItems)ShowItem.SelectedItem;
                ItemName.IsEnabled = true;
                ItemName.Text = data.Name;
                Quantity.IsEnabled = true;
                Quantity.Text = data.Quantity;
                BuyPrice.IsEnabled = true;
                BuyPrice.Text = data.BuyPrice;
                SellPrice.IsEnabled = true;
                SellPrice.Text = data.SellPrice;

                Category.SelectedItem = data.Category;


                foreach (var itemm in item.GetCat())
                {
                    Category.Items.Add(itemm.Name);
                }
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Close();

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
    }


}
