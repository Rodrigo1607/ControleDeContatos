using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ControleDeContatos.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Digite o Login: ")]

        public string Login {  get; set; }

        [Required(ErrorMessage = "Digite a Senha: ")]

        public string Senha { get; set; }
    }
}
