using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataQS_NetCore.DML;
using DataQS_NetCore.DAL;

namespace DataQS_NetCore.DAL
{
    class DaoEstacoes : AcessoDados
    {
        public long AddEstation(Estacoes Estacoes)
        {
            List<System.Data.SqlClient.SqlParameter> parametros = new List<System.Data.SqlClient.SqlParameter>();
            
            parametros.Add(new System.Data.SqlClient.SqlParameter("Latitude", Estacoes.Latitude));
            parametros.Add(new System.Data.SqlClient.SqlParameter("Longitude", Estacoes.Longitude));
            parametros.Add(new System.Data.SqlClient.SqlParameter("Altitude", Estacoes.Altitude));
            parametros.Add(new System.Data.SqlClient.SqlParameter("TemperaturaMaxAbs", Estacoes.TemperaturaMaxAbs));
            parametros.Add(new System.Data.SqlClient.SqlParameter("TemperaturaMinAbs", Estacoes.TemperaturaMinAbs));
            parametros.Add(new System.Data.SqlClient.SqlParameter("PrecipitacaoMaxAbs", Estacoes.PrecipitacaoMaxAbs));

            DataSet ds = base.Consultar("InsertEstation", parametros);
            long ret = 0;
            if (ds.Tables[0].Rows.Count > 0)
                long.TryParse(ds.Tables[0].Rows[0][0].ToString(), out ret);
            return ret;
        }
    }
}
