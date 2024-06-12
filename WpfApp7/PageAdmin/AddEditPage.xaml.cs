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
using WpfApp7.AppData;

namespace WpfApp7.PageAdmin
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        public Item _currentItem = new Item();
        public AddEditPage(Item selectedItem)
        {
            InitializeComponent();
            if (selectedItem != null)
            {
                _currentItem = selectedItem;
            }
            DataContext = _currentItem;
            
            CmbCategory.ItemsSource = AppConnect.GetContext().ItemCategory.ToList();
            
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.FrameMain.GoBack();
        }

        private void BtnAddItem_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            if (string.IsNullOrEmpty(_currentItem.ItemName))
                error.AppendLine("Укажите наименование предмета!");
            if (_currentItem.ItemParametr2 == null)
                error.AppendLine("Выберите категорию!");

            if(error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }

            if (_currentItem.ItemID == 0)
                AppConnect.GetContext().Item.Add(_currentItem);
            {
                AppConnect.GetContext().SaveChanges();
                MessageBox.Show("Данные добавлены!");
                AppFrame.FrameMain.GoBack();
            }
        }
    }
}
