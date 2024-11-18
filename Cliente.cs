using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AfroditeClasses.Models
{
    public class Cliente : Pessoa
    {
        [Key]
        public int IdCliente { get; set; }

        // Construtor que inicializa com parâmetros
        public Cliente(string nome, string telefone, string email, string senha)
            : base(nome, telefone, email, senha)
        {
            IdCliente = IdCliente;
        }
    }
}
