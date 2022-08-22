using consoleFrota;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFrota.Repositorys;
using ProjetoFrota.ViewModelAtualizar;
using System.Collections.Generic;

namespace ProjetoFrota.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CaminhaoController : ControllerBase
    {
        public static readonly List<Caminhao> Caminhao = new List<Caminhao>();
        private readonly CaminhaoRepository _caminhaoRepository;

        public CaminhaoController()
        {
            _caminhaoRepository = new CaminhaoRepository();
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastrarCaminhaoViewModel SalvarCaminhaoViewModel)
        {
            if (SalvarCaminhaoViewModel == null)
            {
                return Ok("Dados Não informados");
            }
            if(SalvarCaminhaoViewModel.Modelo == null)
            {
                return Ok ("Modelo não informado");
            }
            if (SalvarCaminhaoViewModel.Placa == null)
            {
                return Ok ("Placa não informada");
            }

            var resultado = _caminhaoRepository.SalvarCaminhao(CadastrarCaminhaoViewModel);
            
            if(resultado) return Ok("Pessoa cadastrada com sucesso");

                
            
        }
    }
}
