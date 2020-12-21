using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataQS_NetCore.Pages
{
    /// <summary>
    /// Interação lógica para DataGrid.xam
    /// </summary>
    public partial class DataGrid : Page
    {
        public DataGrid(DataTable dt, Variaveis variaveis)
        {
            InitializeComponent();
            DataGridView.ItemsSource = dt.DefaultView;
        }

        public DataTable DataTable(DataTable dt)
        {
            return dt;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Variaveis.CloseWindow();
        }
    }
}
