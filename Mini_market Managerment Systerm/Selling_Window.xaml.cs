using Mini_market_Managerment_Systerm.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Mini_market_Managerment_Systerm
{
    /// <summary>
    /// Interaction logic for Selling_Window.xaml
    /// </summary>
    /// 

    public partial class Selling_Window : Window
    {
        private Seller seller;
        private readonly minimarketdbContext _context = new minimarketdbContext();

        private List<Product> products = new List<Product>();
        public Selling_Window(Seller seller)
        {
            this.seller = seller;
            InitializeComponent();
            load_name(seller);
            load_lvProduct();
            load_Category();
            load_lvBill();
        }

        private void load_name(Seller seller)
        {
            lbNameSeller.Content = seller.SellerName.ToString();
            DateTime dateTimeNow = DateTime.Now;
            lbDate.Content = dateTimeNow.ToLongDateString();
        }

        private void load_lvProduct()
        {
            lvProduct.ItemsSource = _context.Products.ToList();
        }

        private void load_lvBill()
        {
            lvBill.ItemsSource = _context.Bills.Where(x => x.SellerName.Equals(seller.SellerName)).ToList();
        }
        private void load_Category()
        {
            cbCategory.ItemsSource = _context.Categories.ToList();
            cbCategory.SelectedIndex = -1;
        }

        private void cbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int categoryId = (cbCategory.SelectedItem as Category).CatId;

            lvProduct.ItemsSource = _context.Products.Where(x => x.CatId == categoryId).ToList();

        }

        private void Button_Click_Refresh(object sender, RoutedEventArgs e)
        {
            load_lvProduct();
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

        private void lvProduct_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            Product item = (sender as ListView).SelectedItem as Product;
            if (item != null)
            {
                tbName.Text = item.ProdName.ToString();
                tbPrice.Text = item.ProdPrice.ToString();
                cbCategory.SelectedItem = item.Cat;
            }

        }

        private void Button_Click_AddProduct(object sender, RoutedEventArgs e)
        {
            String nameProduct = tbName.Text.ToString();
            String quantityProductString = tbQuantity.Text.ToString();
            int quantityProduct;
            bool resultParseQuantity = int.TryParse(quantityProductString, out quantityProduct);
            if (!resultParseQuantity)
            {
                MessageBox.Show("Số lượng sản phẩm phải là số", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (quantityProduct < 0)
            {
                MessageBox.Show("Số lượng sản phẩm phải lớn hơn 0", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Product product = _context.Products.FirstOrDefault(x => x.ProdName == nameProduct);

            product.Total = quantityProduct * product.ProdPrice;

            products.Add(product);

            lvBuy.ItemsSource = null;
            lvBuy.ItemsSource = products;

            int total = 0;

            foreach( var item in products )
            {
                    total += item.Total.Value;
            }

            lbTotal.Content = total;
        }

        private void lvBuy_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Product item = (sender as ListView).SelectedItem as Product;
            if (item != null)
            {
                int idProduct = item.ProdId;
                Product product = products.FirstOrDefault(x => x.ProdId == idProduct);
                products.Remove(product);

                lvBuy.ItemsSource = null;
                lvBuy.ItemsSource = products;

                int total = 0;

                foreach (var i in products)
                {
                    total += i.Total.Value;
                }

                lbTotal.Content = total.ToString() + "VND";
            }
        }

        private void Button_Click_AddBuy(object sender, RoutedEventArgs e)
        {
            if(products.Count > 0)
            {
                int billId = 0;
                String sellerName = seller.SellerName.ToString();
                DateTime sellDate = DateTime.Now;
                int total = int.Parse(lbTotal.Content.ToString());

                Bill bill = new Bill();
                bill.BillId = billId;
                bill.SellerName = sellerName;
                bill.BillDate = sellDate;
                bill.TotalAmount = total;

                _context.Bills.Add(bill);
                _context.SaveChanges();


                List<Product> listViewData = new List<Product>();

                foreach (var item in lvBuy.Items)
                {
                    if (item is Product myData)
                    {
                        listViewData.Add(myData);
                    }
                }

                int id = _context.Bills.Max(x => x.BillId);
                foreach (Product item in listViewData)
                {
                    BillC billC = new BillC()
                    {
                        BillCid = 0,
                        BillId = id,
                        ProductName = item.ProdName,
                        ProductPrice = item.ProdPrice,
                        Quantity = item.ProdQty,
                        Total = item.Total
                    };
                    _context.BillCs.Add(billC);
                    _context.SaveChanges();
                }

                load_lvBill();
                products = new List<Product>();
                lvBuy.ItemsSource = products;
                return;
            }
            else
            {
                MessageBox.Show("Số lượng sản phẩm phải lớn hơn 0", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
