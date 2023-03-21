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
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            adapter.UpdateRangQuery(NameTbx.Text, NameTbx1.Text, NameTbx2.Text, (int)(RangDataGrid.SelectedItem as DataRowView).Row[0]);
            RangDataGrid.ItemsSource = adapter.GetData();
        }
//Переход в другое окно
        private void GoToNext_Click(object sender, RoutedEventArgs e)
        {
            EmployeeWindow window = new EmployeeWindow();
            window.Show();
            this.Close();
        }

        private void RangDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                NameTbx.Text = (RangDataGrid.SelectedItem as DataRowView).Row[1].ToString();
                NameTbx1.Text = (RangDataGrid.SelectedItem as DataRowView).Row[2].ToString();
                NameTbx2.Text = (RangDataGrid.SelectedItem as DataRowView).Row[3].ToString();

            }
            catch
            {
                NameTbx.Text = null;
                NameTbx1.Text = null;
                NameTbx2.Text = null;

            }
        }
    }
}
