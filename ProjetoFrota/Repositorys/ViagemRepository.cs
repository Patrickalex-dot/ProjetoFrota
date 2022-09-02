using consoleFrota;
using ProjetoFrota.Models;
using System.Data.SqlClient;

namespace ProjetoFrota.Repositorys
{
    public class ViagemRepository
    {
        private readonly string Conexao = @"Data Source=ITELABD14\SQLEXPRESS;Initial Catalog=ProjetoFrota;Integrated Security=True;";

        public bool Salvar(ViewModelSalvar.SalvarViagemViewModel salvarViagem)
        {
            try
            {
                var query = "@INSERT INTO Viagem (CidadePartida,CidadeDestino,Token,IdMotorista,IdCaminhao) VALUES (@cidadePartida,@cidadeDestino,@Token,@idMotorista,@idCaminhao)";
                using (var sql = new SqlConnection(Conexao))
                {

                }
                    
                    
                    
            }
        }
          
        
    }
}
