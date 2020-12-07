using DataQS_NetCore.DAL;
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
using DataQS_NetCore.DML;
using System.Data;
using GenericParsing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace DataQS_NetCore.Pages
{
    /// <summary>
    /// Interação lógica para Variaveis.xam
    /// </summary>
    public partial class Variaveis : UserControl
    {
        public Variaveis()
        {
            InitializeComponent();
            AtualizaEstacoes();
        }
        public void AtualizaEstacoes()
        {
            EstacoesList.Items.Clear();
            DaoEstacoes daoestacoes = new DaoEstacoes();
            List<Estacoes> estacoes = daoestacoes.SelectStation();
            this.EstacoesList.SelectedValuePath = "Key";
            this.EstacoesList.DisplayMemberPath = "Value";
            foreach (Estacoes e in estacoes)
            {
                EstacoesList.Items.Add(new KeyValuePair<int, string>(e.Id, e.Nome));
            }
        }

        private void EstacoesList_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void FileDropStackPanel_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                string file = files[0];

                var delimiter = new Delimiter();
                var del = new Window();
                del.Content = delimiter;
                del.ShowDialog();

                string d = delimiter.getDelimiter();
                DataTable res = ConvertCSVtoDataTable(file, d);

                del.Close();


                var DataGrid = new DataGrid(res);
                var dtView = new Window();
                dtView.Content = DataGrid;
                dtView.ShowDialog();
                dtView.Close();
            }
        }

        public static DataTable ConvertCSVtoDataTable(string strFilePath, string divider)
        {
            StreamReader sr = new StreamReader(strFilePath);
            string[] headers = sr.ReadLine().Split(divider);
            DataTable dt = new DataTable();
            int sizeColumns = headers.Length;
            string[] columnsName = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            int countZAppear = 0;
            for (int i = 0; i <= sizeColumns; i++)
            {
                dt.Columns.Add(columnsName[i - (i / 26) * 26] + (i / 26)); // Caso passe de Z volta para o A e adiciona +1 para não repetir o nome da coluna.
                if (columnsName[i] == "Z") countZAppear++;
            }

            while (!sr.EndOfStream)
            {
                string[] rows = Regex.Split(sr.ReadLine(), divider + "(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
                if (sizeColumns < rows.Length)
                {
                    for (int i = sizeColumns + 1; i <= rows.Length; i++) //adiciona mais colunas se encontrar linhas com colunas excedentes
                    {
                        dt.Columns.Add(columnsName[i - (i / 26) * 26] + (i / 26)); // Caso passe de Z volta para o A e adiciona +1 para não repetir o nome da coluna.
                    }

                    sizeColumns = rows.Length;
                }

                DataRow dr = dt.NewRow();
                for (int i = 0; i < sizeColumns; i++)
                {
                    try
                    {
                        dr[i] = rows[i];

                    }
                    catch
                    {
                        dr[i] = "NULL";
                    }
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}
