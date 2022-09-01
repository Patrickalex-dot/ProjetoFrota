using Dapper;
using ProjetoFrota.Dto_s;
using ProjetoFrota.ViewModelAtualizar;
using ProjetoFrota.ViewModelSalvar;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ProjetoFrota.Repositorys
{
    public class CaminhaoRepository
    {
        private readonly string Conexao = @"Data Source=ITELABD14\SQLEXPRESS;Initial Catalog=ProjetoFrota;Integrated Security=True;";

        public bool Salvar(SalvarCaminhaoViewModel cadastrarCaminhao)
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
        public List<CaminhaoDto> BuscarTodos()
        {
            List<CaminhaoDto> caminhaoEncontrado;
            try
            {
                var query = @"SELECT CaminhaoId,Modelo,Placa FROM Caminhao";
                using (var connection = new SqlConnection(Conexao))
                {
                    caminhaoEncontrado = connection.Query<CaminhaoDto>(query).ToList();
                }
                return caminhaoEncontrado;
            }
            catch (Exception execao)
            {
                Console.WriteLine("Erro:" + execao.Message);
                return null;
            }
        }
        public void Atualizar (AtualizarCaminhaoViewModel caminhao)
        {
            try
            {
                var query = @"UPDATE Caminhao SET Modelo = @modelo, Placa = @placa";
                using (var sql = new SqlConnection(Conexao))
                {
                    SqlCommand command = new SqlCommand(query,sql);
                    command.Parameters.AddWithValue("@modelo", caminhao.Modelo);
                    command.Parameters.AddWithValue("@placa", caminhao.Placa);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception execao)
            {
                Console.WriteLine("Erro" + execao.Message);
            }
        }
        public CaminhaoDto Confirmar(int CaminhaoId)
        {
            var caminhao = new CaminhaoDto();
            try
            {
                var query = "SELECT * FROM Caminhao WHERE CaminhaoId = @caminhaoId";
                using (var  connection = new SqlConnection(Conexao))
                {
                    var parametros = new
                    {
                        CaminhaoId
                    };
                    caminhao = connection.QueryFirstOrDefault<CaminhaoDto>(query, parametros);
                }
            }
            catch (Exception execao)
            {
                Console.WriteLine("Erro: " + execao.Message);
                caminhao = null;
            }
            return caminhao;

        }
        public void Deletar (int Id)
        {
            try
            {
                var query = "DELETE FROM Caminhao WHERE CaminhaoId = @Id";
                using (var sql = new SqlConnection(Conexao))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@Id", Id);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception execao)
            {
                Console.WriteLine("Erro: " + execao.Message);
            }
        }
    }
}
