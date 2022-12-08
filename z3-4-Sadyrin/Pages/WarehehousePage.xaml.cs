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

namespace z3_4_Sadyrin.Pages
{
    /// <summary>
    /// Логика взаимодействия для WarehehousePage.xaml
    /// </summary>
    public partial class WarehehousePage : Page
    {
        public WarehehousePage()
        {
            InitializeComponent();
            DGridWarehouse.ItemsSource = Entities.GetContext().Warehouse.ToList(); 
        }

        private void btnWarehouse_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnStroyMaterial_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddPage(null));
        }

        private void BtnDobav_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Page_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridWarehouse.ItemsSource = Entities.GetContext().Warehouse.ToList();
            }
        }
    }
}
