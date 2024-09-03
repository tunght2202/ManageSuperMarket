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
    /// Interaction logic for BillC_Window.xaml
    /// </summary>
    public partial class BillC_Window : Window
    {
        private readonly minimarketdbContext context = new minimarketdbContext();
        public BillC_Window(int id)
        {
            InitializeComponent();
            Load_LvBill(id);
        }

        private void Load_LvBill(int id)
        {
            lvBill.ItemsSource = context.BillCs.Where(x => x.BillId == id).ToList();
        }

        private void Bill_Windown()
        {
            Bill_Window mainWindow = new Bill_Window();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            Bill_Windown();
        }
    }
}
