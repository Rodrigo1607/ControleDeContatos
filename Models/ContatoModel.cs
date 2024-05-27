using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class ContatoModel
    {
        public int ID { get; set; }

        [Required (ErrorMessage ="Digite o Nome: ")]
        public string Nome { get; set; }

        [Required (ErrorMessage ="Digite o email: ")]
        [EmailAddress(ErrorMessage = "O email informado está incorreto.")]
        public string Email { get; set; }

        [Required (ErrorMessage ="Digite o Celular: ")]
        [Phone(ErrorMessage = "O celular informado está incorreto.")]
        public string Celular { get; set; }

       


}
}
