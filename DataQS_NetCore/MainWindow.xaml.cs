using DataQS_NetCore.DAL;
using DataQS_NetCore.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace DataQS_NetCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            AcessoDados Data = new AcessoDados();
            Data.GetConnection();

            InitializeComponent();
        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            // Set tooltip visibility

            if (Tg_Btn.IsChecked == true)
            {
                tt_variaveis.Visibility = Visibility.Collapsed;
                tt_register.Visibility = Visibility.Collapsed;
                tt_var4.Visibility = Visibility.Collapsed;
                tt_graficos.Visibility = Visibility.Collapsed;

            }
            else
            {
                tt_variaveis.Visibility = Visibility.Visible;
                tt_register.Visibility = Visibility.Visible;
                tt_var4.Visibility = Visibility.Visible;
                tt_graficos.Visibility = Visibility.Visible;

            }
        }

        private void Tg_Btn_Unchecked(object sender, RoutedEventArgs e)
        {
            MainContent.Opacity = 1;
        }

        private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
        {
            MainContent.Opacity = 0.3;
        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
            DataContext = new VariaveisViewModel();
        }

        private void ListViewItem_Selected_1(object sender, RoutedEventArgs e)
        {
            DataContext = new CadastroViewModel();
        }

        private void ListViewItem_Selected_2(object sender, RoutedEventArgs e)
        {
            DataContext = new GraficosViewModel();
        }
    }

}
