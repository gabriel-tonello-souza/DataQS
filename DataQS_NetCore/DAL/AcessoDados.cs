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

                //*** Default values ***
                using (SQLiteConnection con = new SQLiteConnection(connection))
                {
                    SQLiteCommand command = new SQLiteCommand();
                    con.Open();
                    command.CommandText = @"INSERT INTO Estacoes (Latitude, Longitude, Altitude, TemperaturaMaxAbs, TemperaturaMinAbs, PrecipitacaoMaxAbs, Nome) VALUES 
                                            (-8.3675    ,-36.4294   ,718    ,35.9   ,11.6   ,108.6  ,'Belo Jardim (BJD) - PE'),
                                            (-15.60083  ,-47.71306  ,1023   ,35.5   ,1.6    ,132.8  ,'Brasília (BRB) - DF'),
                                            (-22.6896   ,-45.0062   ,574    ,37.5   ,1.2    ,117    ,'Cachoeira Paulista (CPA) - SP'),
                                            (-6.4669    ,-37.0847   ,176    ,39.7   ,13.2   ,142.8  ,'Caicó (CAI) - RN'),
                                            (-20.4383   ,-54.5383   ,677    ,39.7   ,-0.9   ,115.1  ,'Campo Grande (CGR) - MS'),
                                            (-15.5553   ,-56.0700   ,185    ,41.1   ,3.3    ,124.6  ,'Cuiabá (CBA) - MT'),
                                            (-22.9486   ,-49.8942   ,446    ,40     ,-1.8   ,271.2  ,'Ourinhos (ORN) - SP'),
                                            (-10.1778   ,-48.3619   ,216    ,40.1   ,11.4   ,120    ,'Palmas (PMA) - TO'),
                                            (-9.0689    ,-40.3197   ,387    ,44.1   ,12.4   ,151.3  ,'Petrolina (PTR) - PE'),
                                            (-11.58166  ,-61.77361  ,252	,41     ,4      ,194    ,'Rolim de Moura (RLM) - RO'),
                                            (-2.5933    ,-44.2122   ,40     ,36     ,13.1   ,210    ,'São Luiz (SLZ) - MA'),
                                            (-7.3817    ,-36.5272   ,486	,34     ,13.2   ,105    ,'São João do Cariri (SCR) - PB'),
                                            (-29.4428	,-53.8231	,489	,39.5	,-2.4	,103.8  ,'São Martinho da Serra (SMS) - RS'),
                                            (-7.827200	,-38.1222	,1123	,33.2	,6.8	,126.8  ,'Triunfo (TRI) - PE'),
                                            (-27.0800	,-52.6144	,700	,37.2	,-4.4	,146.7  ,'Chapecó (CHP) - SC'),
                                            (-25.495444	,-49.331208	,891	,34.8	,-5.4	,104.6  ,'Curitiba (CTB) - PR'),
                                            (-27.6017	,-58.5178	,31     ,38.8	,0.7	,187.1  ,'Florianópolis (FLN) - SC'),
                                            (-26.2525	,-48.8578	,48     ,41.7	,-3	    ,160.4  ,'Joinville (JOI) - SC'),
                                            (-5.8367	,-35.2064	,58	    ,33.8	,10.6	,168.4  ,'Natal (NAT) - RN'),
                                            (-29.0956	,-49.8133	,15	    ,39.3	,-0.1	,112.4  ,'Sombrio (SBR) - SC')
                                            ";
                    command.Connection = con;
                    command.ExecuteNonQuery();

                    con.Close();
                }
            }
            else return;
        }

    }
}
