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
       
        private readonly CaminhaoRepository _caminhaoRepository = new CaminhaoRepository();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(new JsonResult(new
            {
                sucesso = true,
                
            }));
        }

        [HttpPost]
        public IActionResult Salvar (ViewModelSalvar.SalvarCaminhaoViewModel caminhao)
        {
            if (caminhao == null)
                return Ok("Nenhum dado do caminhão foi informado");
            if (caminhao.Modelo == null)
                return Ok("Modelo do caminhao não informado");
            if (caminhao.Placa == null)
                return Ok("Placa do caminhão não informada");

            _caminhaoRepository.Salvar(caminhao);
            return Ok("Caminhão adicionado com sucesso ");
        }
        [HttpGet]
        public IActionResult BuscarTodos()
        {
            var caminhoes = _caminhaoRepository.BuscarTodos();
            if (caminhoes == null || !caminhoes.Any())
            
                return NotFound(new { mensage = $"Lista vazia." });
            return Ok(caminhoes);
            


        }
        [HttpPut]
        public IActionResult Atualizar(AtualizarCaminhaoViewModel atualizarCaminhao)
        {
            
            
            if (atualizarCaminhao.Placa == null)
                return Ok("Nenhuma placa foi informada ");

            var cEncontrado = _caminhaoRepository.BuscarPorPlaca(atualizarCaminhao.Placa);

            if (cEncontrado == null)
                return NotFound("Não há nenhum registro com essa placa.");

            cEncontrado.Modelo = atualizarCaminhao.Modelo;
            cEncontrado.Placa = atualizarCaminhao.Placa;

            return Ok(cEncontrado);

        }
        [HttpDelete]
        public IActionResult Deletar(ViewModelDeletar.DeletarCaminhaoViewModel deletarCaminhao)
        {
            if (deletarCaminhao.Placa == null)
                return Ok("Nenhuma placa foi informada");
            var cEncontrado = _caminhaoRepository.BuscarPorPlaca(deletarCaminhao.Placa);

            if (cEncontrado == null)
                return Ok("Não há registro com essa placa.");

            _caminhaoRepository.Deletar(cEncontrado.Placa);
                return Ok("Removido com sucesso!");

            
        }
    }
}
