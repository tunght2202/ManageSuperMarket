using Mini_market_Managerment_Systerm.Models;
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

namespace Mini_market_Managerment_Systerm
{
    /// <summary>
    /// Interaction logic for Bill_Window.xaml
    /// </summary>
    public partial class Bill_Window : Window
    {
        private readonly minimarketdbContext context = new minimarketdbContext();


        public Bill_Window()
        {
            InitializeComponent();
            Load_lvBill();
        }


        private void Load_lvBill()
        {
            List<Bill> list = context.Bills.ToList();
            lvBill.ItemsSource = list;
            int total = 0;
            foreach (var item in list)
            {
                total += item.TotalAmount;
            }

            lbTotal.Content = total;
        }



        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DatePicker datePicker = sender as DatePicker;
            if (datePicker != null && datePicker.SelectedDate.HasValue)
            {
                DateTime selectedDate = datePicker.SelectedDate.Value;

                List<Bill> list = context.Bills.Where(x => x.BillDate.Equals(selectedDate)).ToList();
                lvBill.ItemsSource = list;
                int total = 0;
                foreach (var item in list)
                {
                    total += item.TotalAmount;
                }

                lbTotal.Content = total;
            }
        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            String name = tbName.Text.ToString();

            List<Bill> list = context.Bills.Where(x => x.SellerName.Contains(name)).ToList();
            if(list.Count > 0)
            {
                lvBill.ItemsSource = list;
                int total = 0;
                foreach (var item in list)
                {
                    total += item.TotalAmount;
                }

                lbTotal.Content = total;
            }
            else
            {
                MessageBox.Show("Tên không tồn tại", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            

        }

        private void Button_Click_Refresh(object sender, RoutedEventArgs e)
        {
            Load_lvBill();
        }

        /// Chuyển màn hình


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
            Seller_Window();
        }

        private void Seller_Window()
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

        private void lvBill_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Bill item = (sender as ListView).SelectedItem as Bill;
            if (item != null)
            {
                int idBillC = item.BillId;
                BillC_Window(idBillC);
            }
        }

        private void BillC_Window(int id)
        {
            BillC_Window mainWindow = new BillC_Window(id);
            mainWindow.Show();
            this.Close();
        }
    }
}
