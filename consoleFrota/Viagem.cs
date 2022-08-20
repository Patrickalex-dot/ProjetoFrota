using System;
using System.Collections.Generic;
using System.Text;

namespace consoleFrota
{
    internal class Viagem
    {
        public int id { get; set; }
        public string CidadePartida { get; set; }
        public string CidadeDestino { get; set; }
        public Caminhao Caminhao { get; set; }
        public Motorista Motorista { get; set; }
    }
}
