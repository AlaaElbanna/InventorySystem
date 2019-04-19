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
using System.Text.RegularExpressions;
using Inventory_System.Connects;
using Final;

namespace Inventory_System.Adding
{
    /// <summary>
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        Context c;
        public AddUser()
        {
            InitializeComponent();
            type.Items.Add("Admin");
            type.Items.Add("User");
            c = new Context();
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
        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text == "" || Phone.Text == "" || Address.Text == ""
                || username.Text == "" || password.Text == "" || type.SelectedIndex == -1)
            {
                MessageBox.Show("Please Fill The Missing Data");
            }
            else
            {
                if (Phone.Text.Length < 11 || Phone.Text.Length > 11)
                    MessageBox.Show("Please Enter Phone Number with 11 digit");
                else if(Regex.IsMatch(password.Text , @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$") == false)
                {
                    MessageBox.Show("Password Must at least 8 Captial and Small characters and digit ");
                }
                else
                {
                    User user = new User();
                    user.name = Name.Text;
                    user.address = Address.Text;
                    user.phone = Phone.Text;
                    var exist = c.Accounts.Where(u => u.username == username.Text).Select(u=>u.username).FirstOrDefault();
                    var exist2 = c.Users.Where(u => u.phone == Phone.Text).Select(u => u.phone).FirstOrDefault();

                    if (exist == username.Text)
                    {
                        MessageBox.Show("Username is already exsit Enter another one");
                        
                    }
                    else if(exist2 == Phone.Text)
                    {
                        MessageBox.Show("This User Is Already Sign Up Please Login Instead");
                    }
                    else
                    {
                        c.Users.Add(user);
                        c.SaveChanges();
                        var id = c.Users.Where(u => u.name == Name.Text).Select(u => u.ID).FirstOrDefault();
                        Account acc = new Account();
                        acc.ID = id;
                        acc.username = username.Text;
                        acc.password = password.Text;
                        if (type.SelectedIndex == 0)
                            acc.type = true;
                        else
                            acc.type = false;
                        c.Accounts.Add(acc);
                        c.SaveChanges();
                        MessageBox.Show("Add Sucessful");
                    }
                }
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}  
