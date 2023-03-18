using Database.MagazineDataSetTableAdapters;
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
using System.Windows.Shapes;

namespace Database
{
    public partial class EmployeeWindow : Window
    {
        EmployeeTableAdapter adapter1 = new EmployeeTableAdapter();
        public EmployeeWindow()
        {
            InitializeComponent();
            EmployeeDataGrid.ItemsSource = adapter1.GetData();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            object Employee_code = (EmployeeDataGrid.SelectedItem as DataRowView).Row[0];
            adapter1.DeleteEmployeeQuery(Convert.ToInt32(Employee_code));
            EmployeeDataGrid.ItemsSource = adapter1.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

 
    }
}
