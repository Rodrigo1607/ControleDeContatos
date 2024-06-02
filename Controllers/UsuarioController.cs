using ControleDeContatos.Interface;
using ControleDeContatos.Models;
using ControleDeContatos.Repository;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ControleDeContatos.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepository.BuscarTodos();
            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _usuarioRepository.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuario Cadastrado com sucesso.";
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch (Exception erro) 
            {
                TempData["MensagemErro"] = $"Erro ao cadastrar, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");

            }
            
        }

        public IActionResult Editar(int id)
        {

            UsuarioModel usuario = _usuarioRepository.ListarPorID(id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Editar(UsuarioSemSenhaModel usuariosemsenhamodel)
        {
            try
            {

                UsuarioModel usuario = null;
                if (ModelState.IsValid)
                {
                    usuario = new UsuarioModel()
                    {
                        Id = usuariosemsenhamodel.Id,
                        Nome= usuariosemsenhamodel.Nome,
                        Login = usuariosemsenhamodel.Login,
                        Email = usuariosemsenhamodel.Email,
                        Perfil = usuariosemsenhamodel.Perfil                    
                    };
                    usuario = _usuarioRepository.Atualizar(usuario);
                    TempData["MensagemSucesso"] = $"Sucesso ao Editar!";
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Erro ao atualizar, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");

            }

        }

        public IActionResult ApagarConfirmacao(int id)
        {
            UsuarioModel usuario = _usuarioRepository.ListarPorID(id);

            return View(usuario);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _usuarioRepository.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato deletado com sucesso.";

                }
                else
                {
                    TempData["MensagemErro"] = "Erro ao deletar o contato!";

                }
                return RedirectToAction("Index");

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Erro ao Editar o contato, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }


    }



}
