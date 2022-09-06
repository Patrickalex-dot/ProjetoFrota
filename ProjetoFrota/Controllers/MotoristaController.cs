using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFrota.Models;
using ProjetoFrota.Repositorys;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoFrota.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class MotoristaController : ControllerBase
    {
        private readonly MotoristaRepository _motoristaRepository = new MotoristaRepository();
        public IActionResult GetAll()
        {
            return Ok(new JsonResult(new
            {
                sucesso = true,

            }));
        }

        [HttpPost]
        public IActionResult Salvar (ViewModelSalvar.SalvarMotoristaViewModel motorista)
        {
            if (motorista == null)
                return Ok("Nenhum dado do motorista foi informado");
            if (motorista.Nome == null)
                return Ok("Nome do motorista não informado");
            if (motorista.Endereco == null)
                return Ok("Endereco do motorista não informado");
            if (motorista.Cpf == null)
                return Ok("Cpf do motorista não informado");

            _motoristaRepository.Salvar(motorista);
            return Ok("Motorista adicionado com sucesso");

        }
        [HttpGet]
        public IActionResult BuscarTodos()
        {
            var Motoristas = _motoristaRepository.BuscarTodos();
            if (Motoristas == null || !Motoristas.Any())
                return NotFound(new { mesage = $"Lista Vazia." });
            return Ok(Motoristas);
        }
        [HttpPut]
        public IActionResult Atualizar(ViewModelAtualizar.AtualizarMotoristaViewModel atualizarMotorista)
        {
            
            if (atualizarMotorista.Cpf == null)
                return Ok("Cpf do motorista não foi informado");
            var mEncontrado = _motoristaRepository.BuscarPorCpf(atualizarMotorista.Cpf);

            if (mEncontrado == null)
                return Ok("não há nenhum registro com esse nome");
            

            return Ok(mEncontrado);
        }
        [HttpDelete]
        public IActionResult Deletar(MotoristaModel deletarMotorista)
        {
            

            if (deletarMotorista.Nome == null)
                return Ok("Nome do motorista não foi informado");
            
            var motorista = motoristas.FirstOrDefault(m => m.Nome == deletarMotorista.Nome);

            if (motorista == null)
                return Ok("Não há nenhum registro com esse nome");
            motoristas.Remove(motorista);
            return Ok("Removido com sucesso");
        }
    }
}
