using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Logon
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AppContext db;
        public MainWindow()
        {
            InitializeComponent();

            db = new AppContext();
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            string login = authLoginBox.Text.Trim();
            string password = authPassBox.Password.Trim();
            
        }
        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            string login = regLoginBox.Text.Trim();
            string password = regPassBox.Password.Trim();
            string passwordCheck = regPassCheckBox.Password.Trim();
            string bday = pickedDataBox.Text.Trim();
            if(login?.Length < 3)
            {
                regLoginBox.ToolTip = "Login must contain 3 or more characters";
                regLoginBox.Background = Brushes.Red;
            }
            
            else if (password?.Length < 3)
            {
                regPassBox.ToolTip = "Password must contain 3 or more characters";
                regPassBox.Background = Brushes.Red;
            }

            else if (bday?.Length < 8)
            {
                regPassBox.ToolTip = "Password must contain 3 or more characters";
                regPassBox.Background = Brushes.Red;
            }

            else if (passwordCheck != password)
            {
                regPassCheckBox.ToolTip = "Passwords are not the same";
                regPassCheckBox.Background = Brushes.Red;
            }
            else
            {
                regLoginBox.ToolTip = "Login is entered correctly";
                regLoginBox.Background = Brushes.White;

                regPassBox.ToolTip = "Password is entered correctly";
                regPassBox.Background = Brushes.White;

                regPassBox.ToolTip = "Passwords are entered correctly";
                regPassCheckBox.Background = Brushes.White;

                User user = new User(login, password);

                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        private void BrowseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            if (openFileDialog.ShowDialog() == true)
            {
                BitmapImage bitmap = new BitmapImage(new Uri(openFileDialog.FileName));
                avatar.Source = bitmap;
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void DatePicker_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
