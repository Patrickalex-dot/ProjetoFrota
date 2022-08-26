using consoleFrota;
using ProjetoFrota.Models;

namespace ProjetoFrota.ViewModelAtualizar
{
    public class AtualizarViagemViewModel
    {
        public int id { get; set; }
        public string Token { get; set; }
        public string CidadePartida { get; set; }
        public string CidadeDestino { get; set; }
        public CaminhaoModel Caminhao { get; set; }
        public MotoristaModel Motorista { get; set; }
    }
}
