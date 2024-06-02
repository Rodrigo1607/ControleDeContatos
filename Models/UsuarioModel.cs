using ControleDeContatos.Enums;
using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o Nome: ")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o Login: ")]
        public string Login { get; set;}

        [Required(ErrorMessage = "Digite o email: ")]
        [EmailAddress(ErrorMessage = "O email informado está incorreto.")]

        public string Email { get; set;}

        [Required(ErrorMessage = "Digite a senha: ")]
        public string Senha { get; set;}

        [Required(ErrorMessage = "Informe o perfil do Usuário: ")]
        public PerfilEnum? Perfil { get; set; }

        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }

    }
}
