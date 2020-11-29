using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Text;

namespace DataQS_NetCore.DAL
{
    public class AcessoDados
    {
        public SQLiteConnection Connect;

        public string ConnectionString { get; set; }

        string connection;

        public void GetConnection()
        {
            connection = @"Data Source=Database.db; Version=3";
            ConnectionString = connection;
        }

        //Creating new Database
        public AcessoDados()
        {
            if (!File.Exists("./Database.db"))
            {
                SQLiteConnection.CreateFile("Database.db");
                GetConnection();

                using (SQLiteConnection con = new SQLiteConnection(connection))
                {
                    SQLiteCommand command = new SQLiteCommand();
                    con.Open();
                    command.CommandText = @"CREATE TABLE Estacoes ( ID                INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                                                            Latitude           DECIMAL (18)  NULL,
                                                            Longitude          DECIMAL (18)  NULL,
                                                            Altitude           DECIMAL (18)  NULL,
                                                            TemperaturaMaxAbs  DECIMAL (18)  NULL,
                                                            TemperaturaMinAbs  DECIMAL (18)  NULL,
                                                            PrecipitacaoMaxAbs DECIMAL (18)  NULL,
                                                            Nome               VARCHAR (255) NULL)";
                    command.Connection = con;
                    command.ExecuteNonQuery();

                    con.Close();
                }
            }
            else return;
        }

    }
}
