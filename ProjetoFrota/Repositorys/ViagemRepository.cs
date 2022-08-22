using consoleFrota;

namespace ProjetoFrota.Repositorys
{
    public class ViagemRepository
    {
        public int id { get; set; }
        public string CidadePartida { get; set; }
        public string CidadeDestino { get; set; }
        public Caminhao Caminhao { get; set; }
        public Motorista Motorista { get; set; }
    }
}
