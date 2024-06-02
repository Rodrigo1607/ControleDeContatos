using ControleDeContatos.Interface;
using ControleDeContatos.Models;
using ControleDeContatos.Repository;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ControleDeContatos.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public LoginController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                 UsuarioModel usuario = _usuarioRepository.BuscarporLogin(loginModel.Login);
                    
                    if(usuario != null)
                    {
                        if(usuario.SenhaValida(loginModel.Senha))
                        {

                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MensagemErro"] = $"Senha incorreta. Tente novamente";

                    }

                    TempData["MensagemErro"] = $"Login e/ ou Senha incorreto(s). Tente novamente";

                }
                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Erro ao logar, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}