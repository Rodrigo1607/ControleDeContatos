using ControleDeContatos.Models;

namespace ControleDeContatos.Interface
{
    public interface IUsuarioRepository
    {
        UsuarioModel BuscarporLogin(string login);
        UsuarioModel ListarPorID(int id);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Atualizar (UsuarioModel usuario);
        bool Apagar(int id);



    }
}
