using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFrota.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoFrota.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class MotoristaController : ControllerBase
    {
        private static readonly List<MotoristaModel> motoristas = new List<MotoristaModel>();

        [HttpPost]
        public IActionResult Salvar (MotoristaModel motorista)
        {
            if (motorista == null)
                return Ok("Nenhum dado do motorista foi informado");
            if (motorista.Nome == null)
                return Ok("Nome do motorista não informado");
            if (motorista.Endereco == null)
                return Ok("Endereco do motorista não informado");
            if (motorista.Cpf == null)
                return Ok("Cpf do motorista não informado");

            motoristas.Add(motorista);
            return Ok("Motorista adicionado com sucesso");

        }
        [HttpGet]
        public IActionResult BuscarTodos()
        {
            if (motoristas == null || !motoristas.Any())
                return NotFound(new { mensage = $"Lista Vazia." });
            return Ok(motoristas);
        }
        [HttpPut]
        public IActionResult Atualizar(MotoristaModel atualizarMotorista)
        {
            if (atualizarMotorista == null)
                return NoContent();

            if (atualizarMotorista.Nome == null)
                return Ok("Nome do motorista não foi informado");
            if (atualizarMotorista.Endereco == null)
                return Ok("Endereco do motorista não foi informado");
            if (atualizarMotorista.Cpf == null)
                return Ok("Cpf do motorista não foi informado");
            var mEncontrado = motoristas.FirstOrDefault(m => m.Nome == atualizarMotorista.Nome);

            if (mEncontrado == null)
                return Ok("não há nenhum registro com esse nome");
            mEncontrado.Nome = atualizarMotorista.Nome;
            mEncontrado.Endereco = atualizarMotorista.Endereco;
            mEncontrado.Cpf = atualizarMotorista.Cpf;

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
