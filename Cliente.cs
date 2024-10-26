using System;
using System.ComponentModel.DataAnnotations;

namespace AfroditeClasses.Models
{
    public class Cliente : Pessoa
    {
        public int IdCliente { get; set; }

        public Cliente(string nome, string telefone, string email, string senha, int idCliente)
            : base(nome, telefone, email, senha)
        {
            IdCliente = idCliente;
        }
    }
}
