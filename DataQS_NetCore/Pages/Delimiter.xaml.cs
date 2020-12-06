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
using System.Windows.Shapes;

namespace DataQS_NetCore.Pages
{
    /// <summary>
    /// Lógica interna para Delimiter.xaml
    /// </summary>
    public partial class Delimiter : Window
    {
        public Delimiter()
        {
            InitializeComponent();
        }
        public string getDelimiter()
        {
            return ",";
        }
    }
}
