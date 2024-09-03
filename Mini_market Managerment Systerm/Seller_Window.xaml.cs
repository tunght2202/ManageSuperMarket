using Microsoft.EntityFrameworkCore;
using Mini_market_Managerment_Systerm.Models;
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

namespace Mini_market_Managerment_Systerm
{
    /// <summary>
    /// Interaction logic for Seller_Window.xaml
    /// </summary>
    public partial class Seller_Window : Window
    {
        private readonly minimarketdbContext context = new minimarketdbContext();
        public Seller_Window()
        {
            InitializeComponent();
            Load_lvSeller();
        }


        private void Load_lvSeller()
        {
            lvSeller.ItemsSource = context.Sellers.Include(x => x.User).ToList();
        }



        private void Button_Click_Logout(object sender, RoutedEventArgs e)
        {
            MainWindow();
        }
        private void MainWindow()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click_Seller(object sender, RoutedEventArgs e)
        {
            Seller_Windown();
        }

        private void Seller_Windown()
        {
            Seller_Window mainWindow = new Seller_Window();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click_Category(object sender, RoutedEventArgs e)
        {
            Category_Windown();
        }

        private void Category_Windown()
        {
            Category_Windown mainWindow = new Category_Windown();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click_Product(object sender, RoutedEventArgs e)
        {
            Product_Windown();
        }

        private void Product_Windown()
        {
            Product_Windown mainWindow = new Product_Windown();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click_Bill(object sender, RoutedEventArgs e)
        {
            Bill_Windown();
        }

        private void Bill_Windown()
        {
            Bill_Window mainWindow = new Bill_Window();
            mainWindow.Show();
            this.Close();
        }

        private void lvSeller_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Seller item = (sender as ListView).SelectedItem as Seller;
            if (item != null)
            {
                tbId.Text = item.SellerId.ToString();
                tbName.Text = item.SellerName.ToString();
                tbAge.Text = item.SellerAge.ToString();
                tbPhone.Text = item.SellerPhone.ToString();
                tbUserName.Text = item.User.UserName.ToString();
                tbPass.Text = item.User.UserPass.ToString();
            }
        }




      
        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(tbId.Text.ToString());
                String name = tbName.Text.ToString();
                String phone = tbPhone.Text.ToString();
                String userName = tbUserName.Text.ToString();
                String pass = tbPass.Text.ToString();
                String ageString = tbAge.Text.ToString();
                int age;
                bool ageBool = int.TryParse(ageString, out age);
                if (name.Trim() == "")
                {
                    MessageBox.Show("Không được để trống tên", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (!IsValidPhoneNumber(phone))
                {
                    MessageBox.Show("Hãy nhập đúng số điện thoại", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (!ageBool || age < 16 || age > 100)
                {
                    MessageBox.Show("Hãy nhập đúng tuổi", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (userName.Trim() == "")
                {
                    MessageBox.Show("Không được để trống User Name", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (pass.Trim() == "")
                {
                    MessageBox.Show("Không được để trống mật khẩu ", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                Seller seller = context.Sellers.Include(x=>x.User).FirstOrDefault(x => x.SellerId == id);
                if (seller != null)
                {

                    seller.SellerName = name;
                    seller.SellerPhone = phone;
                    seller.SellerAge = age;
                    if (seller.User != null)
                    {
                        seller.User.UserName = userName;
                        seller.User.UserPass = pass;
                    }
                    context.Users.Update(seller.User);
                    context.Sellers.Update(seller);
                    context.SaveChanges();
                    Load_lvSeller();
                    MessageBox.Show("Update Seller Successfull", "Update Seller");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Seller fales", "Update seller");
            }
        }

        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            // Mẫu biểu thức chính quy cho số điện thoại di động Việt Nam
            string pattern = @"^0[3|5|7|8|9]\d{8}$";

            // Tạo đối tượng Regex với mẫu
            Regex regex = new Regex(pattern);

            // Kiểm tra số điện thoại với mẫu
            return regex.IsMatch(phoneNumber);
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = 0;
                String name = tbName.Text.ToString();
                String phone = tbPhone.Text.ToString();
                String userName = tbUserName.Text.ToString();
                String pass = tbPass.Text.ToString();
                String ageString = tbAge.Text.ToString();
                int age;
                bool ageBool = int.TryParse(ageString, out age);
                if (name.Trim() == "")
                {
                    MessageBox.Show("Không được để trống tên", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (!IsValidPhoneNumber(phone))
                {
                    MessageBox.Show("Hãy nhập đúng số điện thoại", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (!ageBool || age < 16 || age > 100)
                {
                    MessageBox.Show("Hãy nhập đúng tuổi", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (userName.Trim() == "")
                {
                    MessageBox.Show("Không được để trống User Name", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (pass.Trim() == "")
                {
                    MessageBox.Show("Không được để trống mật khẩu ", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                User user = context.Users.FirstOrDefault(x => x.UserName.Equals(userName));
                if (user != null)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại ", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                

                User user1 = new User()
                {
                    UserId = 0,
                    UserName = userName,
                    UserPass = pass,
                    RoleId = 2
                };
                context.Users.Add(user1);
                context.SaveChanges();

                User u = context.Users.FirstOrDefault(x => x.UserName.Equals(userName));
                Seller seller = new Seller()
                {
                    SellerId = 0,
                    SellerName = name,
                    SellerAge = age,
                    SellerPhone = phone,
                    UserId = u.UserId
                };
                context.Sellers.Add(seller);
                context.SaveChanges();
                Load_lvSeller();
                MessageBox.Show("Add Seller Successfull", "Add Seller");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Add Seller fales", "Add seller");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(tbId.Text.ToString() == null)
                {
                    MessageBox.Show("Hãy chọn một Seller ", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                
                    int id = int.Parse(tbId.Text.ToString());
                    Seller seller = context.Sellers.FirstOrDefault(x => x.SellerId == id);

                User user = context.Users.FirstOrDefault(x => x.UserId == seller.UserId);
                context.Users.Remove(user);

                context.Sellers.Remove(seller);
                    context.SaveChanges();


                    Load_lvSeller();
                    MessageBox.Show("Delete Seller Successfull", "Delete Seller");
                
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete Seller fales", "Delete seller");
            }
        }
    }
}
