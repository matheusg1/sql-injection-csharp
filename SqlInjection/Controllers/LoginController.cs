using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SqlInjection.Interface;
using SqlInjection.Models;

namespace SqlInjection.Controllers
{
    [ApiController]
    [Route("login/")]
    public class LoginController : Controller
    {
        IConfiguration _config;
        ILoginService _loginService;

        public LoginController(IConfiguration config, ILoginService loginService)
        {
            _config = config;
            _loginService = loginService;
        }

        [HttpPost]
        [Route("loginComPrepared")]
        public IActionResult LoginComPrepared(Usuario usuario)
        {
            var resposta = _loginService.LoginComPrepared(_config, usuario);
            if (resposta.GetType() == typeof(Usuario))
            {
                return Ok("Logado com sucesso");
            }
            return StatusCode(StatusCodes.Status404NotFound, "Erro ao logar");
        }

        [HttpPost]
        [Route("loginSemPrepared")]
        public IActionResult LoginSemPrepared(Usuario usuario)
        {
            var resposta = _loginService.LoginSemPrepared(_config, usuario);
            if (resposta.GetType() == typeof(Usuario))
            {
                return Ok("Logado com sucesso");
            }
            return StatusCode(StatusCodes.Status404NotFound, "Erro ao logar");
        }
    }
}
