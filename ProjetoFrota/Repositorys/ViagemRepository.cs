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
                var query = "@INSERT INTO Viagem (CidadePartida,CidadeDestino,Token,IdMotorista,IdCaminhao) VALUES (@cidadePartida,@cidadeDestino,@token,@idMotorista,@idCaminhao)";
                using (var sql = new SqlConnection(Conexao))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@cidadePartida", salvarViagem.CidadePartida);
                    command.Parameters.AddWithValue("@cidadeDestino", salvarViagem.CidadeDestino);
                    command.Parameters.AddWithValue("@token", salvarViagem.Token);
                    command.Parameters.AddWithValue("@idMotorista", salvarViagem.Motorista);
                    command.Parameters.AddWithValue("@idCaminhao", salvarViagem.Caminhao);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                    
                    
                    
            }
        }
          
        
    }
}
