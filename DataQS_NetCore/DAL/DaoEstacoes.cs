using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataQS_NetCore.DML;
using DataQS_NetCore.DAL;
using System.Data.SQLite;
using System.Windows;

namespace DataQS_NetCore.DAL
{
    class DaoEstacoes
    {
        AcessoDados Data;
        public void AddEstation(Estacoes Estacoes)
        {
            Data = new AcessoDados();

            try
            {
                Data.GetConnection();
                using (SQLiteConnection con = new SQLiteConnection(Data.ConnectionString))
                {
                    con.Open();
                    SQLiteCommand command = new SQLiteCommand();

                    string query = @"INSERT INTO Estacoes(Nome,Latitude, Longitude, Altitude, TemperaturaMaxAbs, TemperaturaMinAbs, PrecipitacaoMaxAbs) 
	                                              VALUES (@Nome,@Latitude, @Longitude, @Altitude, @TemperaturaMaxAbs, @TemperaturaMinAbs, @PrecipitacaoMaxAbs)";
                    command.CommandText = query;
                    command.Connection = con;
                    command.Parameters.Add(new SQLiteParameter("Latitude", Estacoes.Latitude));
                    command.Parameters.Add(new SQLiteParameter("Longitude", Estacoes.Longitude));
                    command.Parameters.Add(new SQLiteParameter("Altitude", Estacoes.Altitude));
                    command.Parameters.Add(new SQLiteParameter("TemperaturaMaxAbs", Estacoes.TemperaturaMaxAbs));
                    command.Parameters.Add(new SQLiteParameter("TemperaturaMinAbs", Estacoes.TemperaturaMinAbs));
                    command.Parameters.Add(new SQLiteParameter("PrecipitacaoMaxAbs", Estacoes.PrecipitacaoMaxAbs));
                    command.Parameters.Add(new SQLiteParameter("Nome", Estacoes.Nome));
                    command.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Estação Cadastrada.", "Sucesso!", MessageBoxButton.OK);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Erro", MessageBoxButton.OK);
            }
        }
        public List<Estacoes> SelectStation()
        {
            List<Estacoes> estacoes = new List<Estacoes>();

            Data = new AcessoDados();
            try
            {
                Data.GetConnection();
                using (SQLiteConnection con = new SQLiteConnection(Data.ConnectionString))
                {
                    con.Open();
                    SQLiteCommand command = new SQLiteCommand();

                    string query = @"SELECT * FROM ESTACOES";
                    command.CommandText = query;
                    command.Connection = con;
                    SQLiteDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Estacoes estacao = new Estacoes();
                        estacao.Id = reader.GetInt32("Id");
                        estacao.Altitude = reader.GetDouble("Altitude");
                        estacao.Longitude = reader.GetDouble("Longitude");
                        estacao.Latitude = reader.GetDouble("Latitude");
                        estacao.Nome = reader.GetString("Nome");
                        estacao.PrecipitacaoMaxAbs = reader.GetDouble("PrecipitacaoMaxAbs");
                        estacao.TemperaturaMaxAbs = reader.GetDouble("TemperaturaMaxAbs");
                        estacao.TemperaturaMinAbs = reader.GetDouble("TemperaturaMinAbs");
                        estacoes.Add(estacao);
                    }
                    con.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Erro", MessageBoxButton.OK);
            }
            return estacoes;
        }

    }
}
