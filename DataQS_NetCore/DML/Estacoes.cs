using System;
using System.Collections.Generic;
using System.Text;

namespace DataQS_NetCore.DML
{
    class Estacoes
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Altitude { get; set; }
        public double TemperaturaMaxAbs { get; set; }
        public double TemperaturaMinAbs { get; set; }
        public double PrecipitacaoMaxAbs { get; set; }
        public string Nome { get; set; }

    }
}
