﻿using DataQS_NetCore.DML;
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
namespace DataQS_NetCore.Pages
{
    public partial class Cadastro : UserControl
    {
        public Cadastro()
        {
            InitializeComponent();
            AtualizaEstacoes();

        }

        public void AtualizaEstacoes()
        {
            EstacoesList.Items.Clear();
            DaoEstacoes daoestacoes = new DaoEstacoes();
            List<Estacoes> estacoes = daoestacoes.SelectStation();
            foreach (Estacoes e in estacoes) EstacoesList.Items.Add(e.Nome);
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

        private void EstacoesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
    }
}
