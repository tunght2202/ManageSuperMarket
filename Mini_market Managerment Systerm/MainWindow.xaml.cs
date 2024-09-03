using Mini_market_Managerment_Systerm.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mini_market_Managerment_Systerm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly minimarketdbContext _context = new minimarketdbContext();
        public List<string> listName;
        public MainWindow()
        {
            InitializeComponent();
            LoginForm_load();
        }

        //
        private void LoginForm_load()
        {
            cbRole.ItemsSource = _context.Roles.ToList();
            cbRole.SelectedIndex = 0;
        }

        private void Button_Click_Login(object sender, RoutedEventArgs e)
        {
            User user = ValidateAccountLogin();
            if (user == null) return;

            MessageBox.Show("Bạn đã đăng nhập thành công", "Chúc mừng", MessageBoxButton.OK, MessageBoxImage.Information);

            if (user.RoleId == 1)
            {
                Admin_Window();
            }
            else
            {
                Seller seller = _context.Sellers.FirstOrDefault(x => x.UserId == user.UserId);
                Selling_Window(seller);
            }
        }

        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private User ValidateAccountLogin()
        {
            string userName = tbUserName.Text;
            string password = tbPassWord.Password;
            int role = (cbRole.SelectedItem as Role).RoleId;

            if (userName.Trim() == "")
            {
                MessageBox.Show("Bạn cần nhập Tài Khoản", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                tbUserName.Focus();
                return null;
            }
            if (password.Trim() == "")
            {
                MessageBox.Show("Bạn cần nhập Mật Khẩu", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                tbPassWord.Focus();
                return null;
            }

            User user = _context.Users.FirstOrDefault(x => x.UserName.Equals(userName) && x.UserPass.Equals(password) && x.RoleId == role);
            if (user == null)
            {
                MessageBox.Show("Tài Khoản, Mật Khẩu hoặc Role không chính xác vui lòng thử lại", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Error);
                tbUserName.Focus();
                return null;
            }
            return user;
        }

        private void Selling_Window(Seller seller)
        {
            Selling_Window mainWindow = new Selling_Window(seller);
            mainWindow.Show();
            this.Close();
        }
        private void Admin_Window()
        {
            Bill_Window mainWindow = new Bill_Window();
            mainWindow.Show();
            this.Close();
        }

    }
}