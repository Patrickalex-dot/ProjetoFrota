using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoFrota.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class Caminhao : ControllerBase
    {
        [HttpPost]
        public IActionResult Salvar  (Caminhao caminhao)
        {

        }
    }
}
