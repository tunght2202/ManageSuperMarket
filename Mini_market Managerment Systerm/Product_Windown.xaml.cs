using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for Product_Windown.xaml
    /// </summary>
    public partial class Product_Windown : Window
    {
        private readonly minimarketdbContext context = new minimarketdbContext();
        public Product_Windown()
        {
            InitializeComponent();
            Load_lvProduct();
            Load_cbCategory();
            Load_cbCategorySearch();
        }

        private void Load_lvProduct()
        {
            lvProduct.ItemsSource = context.Products.ToList();
        }

        private void Load_cbCategory()
        {
            cbCategory.ItemsSource = context.Categories.ToList();
            cbCategory.SelectedIndex = 0;
        }
        private void Load_cbCategorySearch()
        {
            cbCategorySearch.ItemsSource = context.Categories.ToList();
            cbCategorySearch.SelectedIndex = -1;
        }
        private void lvProduct_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Product item = (sender as ListView).SelectedItem as Product;
            if (item != null)
            {
                tbId.Text = item.ProdId.ToString();
                tbName.Text = item.ProdName.ToString();
                tbPrice.Text = item.ProdPrice.ToString();
                cbCategory.SelectedItem = item.Cat;
            }
        }


        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            try
            {
                String name = tbName.Text.ToString();
                int categoryId = (cbCategory.SelectedItem as Category).CatId;
                int price;
                String priceString = tbPrice.Text.ToString();
                bool priceBool = int.TryParse(priceString, out price);
                if (name.Trim() == "")
                {
                    MessageBox.Show("Không được để trống tên", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (!priceBool || price < 0)
                {
                    MessageBox.Show("hãy nhập giá đúng ", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }


                Product oldProduct = context.Products.FirstOrDefault(x => x.ProdName.Equals(name));
                if (oldProduct != null)
                {
                    MessageBox.Show("Product đã tồn tại", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                Product product = new Product()
                {
                    ProdName = name,
                    ProdId = 0,
                    ProdPrice = price,
                    CatId = categoryId

                };

                context.Products.Add(product);
                context.SaveChanges();
                Load_lvProduct();
                MessageBox.Show("Add Product Successfull", "Add Product");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Add Product fales", "Add Product");
            }
        }

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(tbId.Text.ToString());
                String name = tbName.Text.ToString();
                int categoryId = (cbCategory.SelectedItem as Category).CatId;
                int price;
                String priceString = tbPrice.Text.ToString();
                bool priceBool = int.TryParse(priceString, out price);
                if (name.Trim() == "")
                {
                    MessageBox.Show("Không được để trống tên", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (!priceBool)
                {
                    MessageBox.Show("hãy nhập giá đúng ", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }


                Product oldProduct = context.Products.Include(x => x.Cat).FirstOrDefault(x => x.ProdId == id);
                if (oldProduct != null)
                {
                    oldProduct.ProdPrice = price;
                    oldProduct.ProdName = name;
                    oldProduct.CatId = categoryId;

                    context.Products.Update(oldProduct);
                    context.SaveChanges();
                    Load_lvProduct();
                    MessageBox.Show("Update Product Successfull", "Update Product");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Product fales", "Update Product");
            }
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(tbId.Text.ToString());


                Product oldProduct = context.Products.FirstOrDefault(x => x.ProdId == id);
                if (oldProduct == null)
                {
                    MessageBox.Show("Hãy chọn lại sản phẩm", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                context.Products.Remove(oldProduct);
                context.SaveChanges();
                Load_lvProduct();
                MessageBox.Show("Delete Product Successfull", "Delete Product");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete Product fales", "Delete Product");
            }
        }

        private void cbCategorySearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int categoryId = (cbCategorySearch.SelectedItem as Category).CatId;

            lvProduct.ItemsSource = context.Products.Where(x => x.CatId == categoryId).ToList();
        }

        private void Button_Click_Refresh(object sender, RoutedEventArgs e)
        {
            Load_lvProduct();
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
            Product_Windownn();
        }

        private void Product_Windownn()
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


    }
}
