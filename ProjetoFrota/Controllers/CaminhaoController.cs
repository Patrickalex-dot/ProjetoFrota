using consoleFrota;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFrota.Models;
using ProjetoFrota.Repositorys;
using ProjetoFrota.ViewModelAtualizar;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoFrota.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CaminhaoController : ControllerBase
    {
        public readonly static List<CaminhaoModel> caminhoes = new List<CaminhaoModel>();

        [HttpPost]
        public IActionResult Salvar (CaminhaoModel caminhao)
        {
            if (caminhao == null)
                return Ok("Nenhum dado do caminhão foi informado");
            if (caminhao.Modelo == null)
                return Ok("Modelo do caminhao não informado");
            if (caminhao.Placa == null)
                return Ok("Placa do caminhão não informada");

            caminhoes.Add(caminhao);
            return Ok("Caminhão adicionado com sucesso ");
        }
        [HttpGet]
        public IActionResult BuscarTodos()
        {
            if (caminhoes == null || !caminhoes.Any())
            
                return NotFound(new { mensage = $"Lista vazia." });
            return Ok(caminhoes);
            


        }
        [HttpPut]
        public IActionResult Atualizar(CaminhaoModel atualizarCaminhao)
        {
            
            if (atualizarCaminhao.Placa == null)
                return Ok("Nenhuma placa foi informada ");

            var cEncontrado = caminhoes.FirstOrDefault(c => c.Placa == atualizarCaminhao.Placa);

            if (cEncontrado == null)
                return NotFound("Não há nenhum registro com essa placa.");

            cEncontrado.Modelo = atualizarCaminhao.Modelo;
            cEncontrado.Placa = atualizarCaminhao.Placa;

            return Ok(cEncontrado);

        }
        [HttpDelete]
        public IActionResult Deletar(CaminhaoModel deletarCaminhao)
        {
            if (deletarCaminhao.Placa == null)
                return Ok("Nenhuma placa foi informada");
            var cEncontrado = caminhoes.FirstOrDefault(c => c.Placa == deletarCaminhao.Placa);

            if (cEncontrado == null)
                return Ok("Não há registro com essa placa.");

            caminhoes.Remove(cEncontrado);
                return Ok("Removido com sucesso!");

            
        }
    }
}
