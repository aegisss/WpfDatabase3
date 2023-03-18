using System;
using System.Collections.Generic;
using System.Data;
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
using Database.MagazineDataSetTableAdapters;
namespace Database
{
    public partial class MainWindow : Window
    {
        RangTableAdapter adapter = new RangTableAdapter();

        public MainWindow()
        {
            InitializeComponent();
            RangDataGrid.ItemsSource = adapter.GetData();
        }
//Добавление данных в таблицу
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            try { 
            object Rang_code = (RangDataGrid.SelectedItem as DataRowView).Row[0];
            adapter.DeleteRangQuery(Convert.ToInt32(Rang_code));
            RangDataGrid.ItemsSource = adapter.GetData();
            }
            catch
            {
                MessageBox.Show("Невозможно удалить данные");
            }
        }
//Переход в другое окно
        private void GoToNext_Click(object sender, RoutedEventArgs e)
        {
            EmployeeWindow window = new EmployeeWindow();
            window.Show();
            this.Close();
        }
    }
}
