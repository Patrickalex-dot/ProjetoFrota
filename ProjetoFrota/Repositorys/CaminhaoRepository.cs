using Dapper;
using ProjetoFrota.Dto_s;
using ProjetoFrota.ViewModelAtualizar;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ProjetoFrota.Repositorys
{
    public class CaminhaoRepository
    {
        private readonly string Conexao = @"Data Source=ITELABD14\SQLEXPRESS;Initial Catalog=ProjetoFrota;Integrated Security=True;";

        public bool Salvar(CadastrarCaminhaoViewModel cadastrarCaminhao)
        {
            try
            {
                var query = @"INSERT INTO Caminhao
                                (Modelo,Placa)
                                VALUES (@Modelo,@Placa)";
                using (var sql = new SqlConnection(Conexao))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@Modelo", cadastrarCaminhao.Modelo);
                    command.Parameters.AddWithValue("@Placa", cadastrarCaminhao.Placa);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                Console.WriteLine("Caminhão cadastrado com sucesso!");
                return true;
            }
            catch (Exception execao)
            {
                Console.WriteLine("Erro: " + execao.Message);
                return false;
            }
            
        }
        public List<CaminhaoDto> BuscarPorPlaca(string placa)
        {
            List<CaminhaoDto> CaminhoesEncontrados;
            try
            {
                var query = @"SELECT CaminhaoId,Modelo,Placa FROM Caminhao
                                WHERE Placa = @Placa";
                using (var connection = new SqlConnection(Conexao))
                {
                    var parametros = new
                    {
                        placa
                    };
                    CaminhoesEncontrados = connection.Query<CaminhaoDto>(query, parametros).ToList();
                }
                return CaminhoesEncontrados;
            }
            catch (Exception execao)
            {
                Console.WriteLine("Erro:" + execao.Message);
                return null;
            }
        }
    }
}
