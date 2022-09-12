using System;
using System.Collections.Generic;
using System.Text;

namespace consoleFrota.Models
{
    internal class ViagemModel
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string CidadePartida { get; set; }
        public string CidadeDestino { get; set; }
        public CaminhaoModel Caminhao { get; set; }
        public MotoristaModel Motorista { get; set; }
    }
}
