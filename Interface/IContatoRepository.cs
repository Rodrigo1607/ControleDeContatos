﻿using ControleDeContatos.Models;

namespace ControleDeContatos.Interface
{
    public interface IContatoRepository
    {
        ContatoModel ListarPorID(int id);
        List<ContatoModel> BuscarTodos();   
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Atualizar (ContatoModel contato);
        bool Apagar(int id);



    }
}
