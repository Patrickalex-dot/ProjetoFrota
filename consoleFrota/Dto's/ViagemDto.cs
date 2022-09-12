using System;
using System.Collections.Generic;
using System.Text;

namespace consoleFrota.Dto_s
{
    internal class ViagemDto
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string CidadePartida { get; set; }
        public string CidadeDestino { get; set; }
        public CaminhaoModel Caminhao { get; set; }
        public MotoristaModel Motorista { get; set; }
    }
}
