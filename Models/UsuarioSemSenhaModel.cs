﻿using ControleDeContatos.Enums;
using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class UsuarioSemSenhaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o Nome: ")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o Login: ")]
        
        public string Login { get; set;}

        [Required(ErrorMessage = "Digite o email: ")]
        [EmailAddress(ErrorMessage = "O email informado está incorreto.")]

        public string Email { get; set;}

        [Required(ErrorMessage = "Informe o perfil do Usuário: ")]
        public PerfilEnum? Perfil { get; set; }




    }
}
