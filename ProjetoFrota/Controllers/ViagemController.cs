using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFrota.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoFrota.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ViagemController : ControllerBase
    {
        public static string GerarToken()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }

        public readonly static List<ViagemModel> viagens = new List<ViagemModel>();

        [HttpPost]
        public IActionResult Salvar (ViagemModel viagem)
        {
            if (viagem == null)
                return Ok("Nenhum dado informado");
            if (viagem.Caminhao == null)
                return Ok("Camninhão não registrado");
            if (viagem.Motorista == null)
                return Ok("Motorista não registrado");
            if (viagem.CidadePartida == null)
                return Ok("Cidade de partida não registrada");
            if (viagem.CidadeDestino == null)
                return Ok("Cidade de destino não registrada");

            viagem.Token = GerarToken();

            viagens.Add(viagem);
            return Ok("Viagem adicionada com sucesso");
        }
        [HttpGet]
        public IActionResult BuscarTodos()
        {
            if (viagens == null || !viagens.Any())
                return NotFound(new { mensage = $"Lista vazia" });
            return Ok(viagens);

        }
        [HttpPut]
        public IActionResult Atualizar(ViagemModel atualizarViagem)
        {
            if (atualizarViagem == null)
                return NoContent();
            if (atualizarViagem.Caminhao == null)
                return Ok("Caminhão não foi informado");
            if (atualizarViagem.Motorista == null)
                return Ok("Motorista não foi informado");
            if (atualizarViagem.CidadePartida == null)
                return Ok("Cidade de partida não foi informada");
            if (atualizarViagem.CidadeDestino == null)
                return Ok("Cidade de destino não foi informada");

            var vEncontrada = viagens.FirstOrDefault(v => v.Token == atualizarViagem.Token);

            if (vEncontrada == null)
                return Ok("Nenhuma viagem corresponde a esse token");

            vEncontrada.Caminhao = atualizarViagem.Caminhao;
            vEncontrada.Motorista = atualizarViagem.Motorista;
            vEncontrada.CidadePartida = atualizarViagem.CidadePartida;
            vEncontrada.CidadeDestino = atualizarViagem.CidadePartida;

            return Ok(vEncontrada);

            

        }
        [HttpDelete]
        public IActionResult Deletar(ViagemModel deletarViagem)
        {
            if (deletarViagem.Token == null)
                return Ok("Nenhum registro de token encontrado");
            var vEncontrada = viagens.FirstOrDefault(v => v.Token == deletarViagem.Token);
            if (vEncontrada == null)
                return Ok("Não há nenhum registro correspondente a esse Token");

            viagens.Remove(vEncontrada);
            return Ok("Removido com sucesso");
            

            
        }
    }
}
