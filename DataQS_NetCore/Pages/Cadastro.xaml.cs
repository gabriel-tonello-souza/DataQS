using DataQS_NetCore.DML;
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
using DataQS_NetCore.DAL;
using System.Linq;

namespace DataQS_NetCore.Pages
{
    public partial class Cadastro : UserControl
    {
        static List<Estacoes> estacoes;
        public Cadastro()
        {
            InitializeComponent();
            AtualizaEstacoes();

        }

        public void AtualizaEstacoes()
        {
            EstacoesList.Items.Clear();
            DaoEstacoes daoestacoes = new DaoEstacoes();

            estacoes = daoestacoes.SelectStation();
            this.EstacoesList.SelectedValuePath = "Key";
            this.EstacoesList.DisplayMemberPath = "Value";
            foreach (Estacoes e in estacoes)
            {
                EstacoesList.Items.Add(new KeyValuePair<int, string>(e.Id, e.Nome));
            }
        }

        private void Salvar_Click(object sender, RoutedEventArgs e)
        {
            Estacoes estacoes = new Estacoes();
            estacoes.Nome = Nome.Text;
            estacoes.Latitude = Convert.ToDouble( Latitude.Text);
            estacoes.Longitude = Convert.ToDouble(Longitude.Text);
            estacoes.Altitude = Convert.ToDouble(Altitude.Text);
            estacoes.PrecipitacaoMaxAbs = Convert.ToDouble(PrecipitacaoMaxAbs.Text);
            estacoes.TemperaturaMaxAbs = Convert.ToDouble(TemperaturaMaxAbs.Text);
            estacoes.TemperaturaMinAbs = Convert.ToDouble(TemperaturaMinAbs.Text);
            DaoEstacoes daoestacoes = new DaoEstacoes();
            daoestacoes.AddEstation(estacoes);

            AtualizaEstacoes();
            Nome.Text = "";
            Latitude.Text = "";
            Longitude.Text = "";
            Altitude.Text = "";
            PrecipitacaoMaxAbs.Text = "";
            TemperaturaMaxAbs.Text = "";
            TemperaturaMinAbs.Text = "";

        }

        private void EstacoesList_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            int key = ((KeyValuePair<int, string>)EstacoesList.SelectedItem).Key;

            var estacao = estacoes.Select(x => x).Where(x => x.Id == key ).ToList();

            Nome.Text = estacao[0].Nome.ToString();
            Latitude.Text = estacao[0].Latitude.ToString();
            Longitude.Text = estacao[0].Longitude.ToString();
            Altitude.Text = estacao[0].Altitude.ToString();
            PrecipitacaoMaxAbs.Text = estacao[0].PrecipitacaoMaxAbs.ToString();
            TemperaturaMaxAbs.Text = estacao[0].TemperaturaMaxAbs.ToString();
            TemperaturaMinAbs.Text = estacao[0].TemperaturaMinAbs.ToString();
        }
    }
}
