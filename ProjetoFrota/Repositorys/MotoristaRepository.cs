﻿using Dapper;
using ProjetoFrota.Dto_s;
using ProjetoFrota.ViewModelSalvar;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ProjetoFrota.Repositorys
{
    public class MotoristaRepository
    {
        private readonly string Conexao = @"Data Source=ITELABD14\SQLEXPRESS;Initial Catalog=ProjetoFrota;Integrated Security=True;";

        public bool Salvar (SalvarMotoristaViewModel salvarMotorista)
        {
            try
            {
                var query = @"INSERT INTO Motorista 
                            (Nome,Endereco, Cpf)
                            VALUES (@nome,@endereco,@cpf) ";
                using (var sql = new SqlConnection(Conexao))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@Nome", salvarMotorista.Nome);
                    command.Parameters.AddWithValue("@endereco", salvarMotorista.Endereco);
                    command.Parameters.AddWithValue("@cpf", salvarMotorista.Cpf);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                Console.WriteLine("Motorista cadastrado com sucesso");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro:" + ex.Message);
                return false;
            }
        }
        public MotoristaDto BuscarPorCpf (string cpf)
        {
            MotoristaDto MotoristasEncontrados;
            try
            {
                var query = "@SELECT MotoristaId,Nome,Cpf,Endereco FROM Motorista WHERE Cpf = @cpf";
                using (var connection = new SqlConnection(Conexao))
                {
                    var parametros = new
                    {
                        cpf
                    };
                    MotoristasEncontrados = connection.Query<MotoristaDto>(query, parametros).FirstOrDefault();
                }
                return MotoristasEncontrados;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }
            
            

        }
        public List<MotoristaDto> BuscarTodos()
        {
            List<MotoristaDto> MotoristaEncontrado;
            try
            {
                var query = @"SELECT MotoristaId,Nome,Endereco,Cpf FROM Motorista";
                using (var connection = new SqlConnection(Conexao))
                {
                    MotoristaEncontrado = connection.Query<MotoristaDto>(query).ToList();
                }
                return MotoristaEncontrado;
            }
            catch (Exception execao)
            {
                Console.WriteLine("Erro:" + execao.Message);
                return null;
            }
        }
        public void Atualizar(ViewModelAtualizar.AtualizarMotoristaViewModel motorista)
        {
            try
            {
                var query = "@UPDATE Motorista SET Nome = @nome, Cpf = @cpf, Endereco = @endereco WHERE Cpf = @cpf";
                using (var sql = new SqlConnection(Conexao))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@cpf", motorista.Cpf);
                    command.Parameters.AddWithValue("@nome", motorista.Nome);
                    command.Parameters.AddWithValue("@endereco", motorista.Endereco);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }



            }
            catch(Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }

        }
        public void Deletar(string Cpf)
        {
            try
            {
                var query = "DELETE FROM Motorista WHERE Cpf = @cpf";
                using (var sql = new SqlConnection(Conexao))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@cpf", Cpf);
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
