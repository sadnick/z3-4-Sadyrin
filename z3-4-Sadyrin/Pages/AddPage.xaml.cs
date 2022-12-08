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
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>  

  
    public partial class AddPage : Page        
    {

        private Warehouse _currentWarehouse = new Warehouse();


        public AddPage(Warehouse selectedWarehouse)
        {
            InitializeComponent();

            if (selectedWarehouse != null)
                _currentWarehouse = selectedWarehouse;

            DataContext = _currentWarehouse;
            ComboTypes.ItemsSource = Entities.GetContext().TypeMaterial.ToList();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentWarehouse.Distance))
                errros.AppendLine("Укажите дистанцию");
            if (_currentWarehouse.Address == null)
                errros.AppendLine("Укажите адрес");
            if (_currentWarehouse.TypeMaterial == null)
                errros.AppendLine("Укажите адрес");

            if (errros.Length > 0)
            {
                MessageBox.Show(errros.ToString());
                return;
            }

            if (_currentWarehouse.IDNumberWarehouse == 0)
                Entities.GetContext().Warehouse.Add(_currentWarehouse);

            try
            {
                Entities.GetContext().SaveChanges();
                MessageBox.Show("информация сохранена");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        
        }
    }
}
