using System;
using System.ComponentModel.DataAnnotations;

namespace AfroditeClasses.Models
{
    public class Profissional : Pessoa
    {
        [Key] // Define IdProfissional como chave primária
        public int IdProfissional { get; set; }

        [Required(ErrorMessage = "O tipo de serviço é obrigatório.")]
        public string TipoServico { get; set; }

        [Required(ErrorMessage = "O salário é obrigatório.")]
        [Range(0, double.MaxValue, ErrorMessage = "O salário deve ser um valor positivo.")]
        public double Salario { get; set; }

        // Construtor que inicializa as propriedades do profissional e chama o construtor base de Pessoa
        public Profissional(string nome, string telefone, string email, string senha, int idProfissional, string tipoServico, double salario)
            : base(nome, telefone, email, senha) // Passa os parâmetros para o construtor da classe base (Pessoa)
        {
            IdProfissional = idProfissional;
            TipoServico = tipoServico;
            Salario = salario;
        }

        // Método para gerenciar a agenda do profissional
        public void GerenciarAgenda()
        {
            // Implementação para gerenciar a agenda (a ser implementado conforme a lógica de negócios)
        }
    }
}
