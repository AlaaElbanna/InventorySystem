using Inventory_System;
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

namespace Final
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
      Context c;
        public Login()
        {
            InitializeComponent();
            c = new Context();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (admin.IsChecked == true)
            {
                var password2 = c.Accounts.Where(u => u.username == username.Text && u.type == true).Select(u => u.password).FirstOrDefault();


                if (password2 == password.Password)
                {
                    Welcome1 wel = new Welcome1(0);
                    wel.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong Username or Password");
                }
            }
            else
            {
                var password2 = c.Accounts.Where(u => u.username == username.Text && u.type == false).Select(u => u.password).FirstOrDefault();


                if (password2 == password.Password)
                {
                    Welcome1 wel = new Welcome1(1);
                    wel.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong Username or Password");
                }
            }
            }
        }
    }

