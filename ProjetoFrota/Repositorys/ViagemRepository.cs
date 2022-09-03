using consoleFrota;
using Dapper;
using ProjetoFrota.Dto_s;
using ProjetoFrota.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

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

                Console.WriteLine("Viagem cadastrada com sucesso!");
                return true;
                    
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return false;
            }
        }
        public List<ViagemDto> BuscarPorToken(string token)
        {
            List<ViagemDto> ViagensEncontradas;
            try
            {
                var query = @"SELECT CidadePartida,CidadeDestino,Token,IdMotorista,IdCaminhao FROM Viagem WHERE Token = @token";
                using (var connection = new SqlConnection(Conexao))
                {
                    var parametro = new
                    {
                        token
                    };
                    ViagensEncontradas = connection.Query<ViagemDto>(query, parametro).ToList();
                }
                return ViagensEncontradas;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }
        }
        public void Atualizar (ViewModelAtualizar.AtualizarViagemViewModel Viagem, string Token)
        {
            try
            {
                var query = @"UPDATE Viagem SET CidadePartida = @cidadePartida, CidadeDestino = @cidadeDestino, Token = @token, IdMotorista = @idMotorista, IdCaminhao = @idCaminhao ";
                using (var sql = new SqlConnection(Conexao))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@cidadePartida", Viagem.CidadePartida);
                    command.Parameters.AddWithValue("@cidadeDestino", Viagem.CidadeDestino);
                    command.Parameters.AddWithValue("@token", Viagem.Token);
                    command.Parameters.AddWithValue("@idMotorista", Viagem.Motorista.Id);
                    command.Parameters.AddWithValue("@idCaminhao", Viagem.Caminhao.Id);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }
        public void Deletar (string Token)
        {
            try
            {
                var query = "DELETE FROM Viagem WHERE Token = @token";
                using (var sql = new SqlConnection(Conexao))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@token", Token);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }
          
        
    }
}
