﻿
using ProjetoFrota.Models;

namespace ProjetoFrota.ViewModelSalvar
{
    public class SalvarViagemViewModel
    {
        public int id { get; set; }
        public string CidadePartida { get; set; }
        public string CidadeDestino { get; set; }
        public CaminhaoModel Caminhao { get; set; }
        public MotoristaModel Motorista { get; set; }
    }
}
