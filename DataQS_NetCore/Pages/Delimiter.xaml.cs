using System;
using System.Collections.Generic;
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
    /// Interação lógica para Delimiter.xam
    /// </summary>
    public partial class Delimiter : Page
    {
        public Delimiter()
        {
            InitializeComponent();
        }

        public string getDelimiter()
        {
            return ",";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
