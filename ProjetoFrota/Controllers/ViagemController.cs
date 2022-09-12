using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFrota.Models;
using ProjetoFrota.Repositorys;
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

        private readonly ViagemRepository _viagemRepository = new ViagemRepository();

        [HttpPost]
        public IActionResult Salvar (ViewModelSalvar.SalvarViagemViewModel viagem)
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

            _viagemRepository.Salvar(viagem);
            return Ok("Viagem adicionada com sucesso");
        }
        [HttpGet]
        public IActionResult BuscarTodos()
        {
            var Viagem = _viagemRepository.BuscarTodos();
            if (Viagem == null || !Viagem.Any())
                return NotFound(new { mensage = $"Lista vazia" });
            return Ok(Viagem);

        }
        [HttpPut]
        public IActionResult Atualizar(ViewModelAtualizar.AtualizarViagemViewModel atualizarViagem)
        {
            if (atualizarViagem.Token == null)
                return NoContent();
            var vEncontrada = _viagemRepository.BuscarPorToken(atualizarViagem.Token);

            vEncontrada.CidadeDestino = atualizarViagem.CidadeDestino;
            vEncontrada.CidadePartida = atualizarViagem.CidadePartida;
            vEncontrada.Caminhao = atualizarViagem.Caminhao;
            vEncontrada.Motorista = atualizarViagem.Motorista;

            if (vEncontrada == null)
                return Ok("Nenhuma viagem corresponde a esse token");

            

            return Ok(vEncontrada);

            

        }
        [HttpDelete]
        public IActionResult Deletar(ViewModelDeletar.DeletarViagemViewModel deletarViagem)
        {
            if (deletarViagem.Token == null)
                return Ok("Nenhum registro de token encontrado");
            var vEncontrada = _viagemRepository.BuscarPorToken(deletarViagem.Token);
            if (vEncontrada == null)
                return Ok("Não há nenhum registro correspondente a esse Token");

            _viagemRepository.Deletar(vEncontrada.Token);
            return Ok("Removido com sucesso");
            

            
        }
    }
}
