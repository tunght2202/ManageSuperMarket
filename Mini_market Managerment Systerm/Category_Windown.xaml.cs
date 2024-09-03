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
    /// Interaction logic for Category_Windown.xaml
    /// </summary>
    public partial class Category_Windown : Window
    {
        private readonly minimarketdbContext context = new minimarketdbContext();
        public Category_Windown()
        {
            InitializeComponent();
            Load_LvCategory();
        }

        private void Load_LvCategory()
        {
            lvCategory.ItemsSource = context.Categories.ToList();
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
            Category_Windownn();
        }

        private void Category_Windownn()
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

        private void lvCategory_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Category item = (sender as ListView).SelectedItem as Category;
            if (item != null)
            {

                tbId.Text = item.CatId.ToString();
                tbName.Text = item.CatName.ToString();
                tbDescription.Text = item.CatDes.ToString();
            }
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            try
            {
                String name = tbName.Text.ToString();
                String description = tbDescription.Text.ToString();
                if (name.Trim() == "")
                {
                    MessageBox.Show("Không được để trống tên", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }


                if (description.Trim() == "")
                {
                    MessageBox.Show("Không được để trống mô tả", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }


                Category oldCategory = context.Categories.FirstOrDefault(x => x.CatName.Equals(name));
                if (oldCategory != null)
                {
                    MessageBox.Show("Category đã tồn tại", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;

                }

                Category category = new Category()
                {
                    CatId = 0,
                    CatName = name,
                    CatDes = description
            };


            context.Categories.Add(category);
            context.SaveChanges();
            Load_LvCategory();
            MessageBox.Show("Add Category Successfull", "Add Category");

        }
            catch (Exception ex)
            {
                MessageBox.Show("Add Category fales", "Add Category");
            }
}

private void Button_Click_Update(object sender, RoutedEventArgs e)
{
    try
    {
        int id = int.Parse(tbId.Text.ToString());
        String name = tbName.Text.ToString();
        String description = tbDescription.Text.ToString();
        if (name.Trim() == "")
        {
            MessageBox.Show("Không được để trống tên", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }


        if (description.Trim() == "")
        {
            MessageBox.Show("Không được để trống mô tả", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }


        Category category = context.Categories.FirstOrDefault(x => x.CatId == id);
        if (category != null)
        {

            category.CatName = name;
            category.CatDes = description;
            context.Categories.Update(category);
            context.SaveChanges();
            Load_LvCategory();
            MessageBox.Show("Update Category Successfull", "Update Category");
        }

    }
    catch (Exception ex)
    {
        MessageBox.Show("Update Category fales", "Update Category");
    }
}

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(tbId.Text.ToString());

                Category category = context.Categories.FirstOrDefault(x => x.CatId == id);
                if (category != null)
                {


                    context.Categories.Remove(category);
                    context.SaveChanges();
                    Load_LvCategory();
                    MessageBox.Show("Delete Category Successfull", "Delete Category");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete Category fales", "Delete Category");
            }
        }
    }
}
