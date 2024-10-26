using System;
using System.ComponentModel.DataAnnotations;

namespace AfroditeClasses.Models
{
    public class Profissional : Pessoa
    {
        public int IdProfissional { get; set; }

        [Required(ErrorMessage = "O tipo de serviço é obrigatório.")]
        public string TipoServico { get; set; }

        [Required(ErrorMessage = "O salário é obrigatório.")]
        [Range(0, double.MaxValue, ErrorMessage = "O salário deve ser um valor positivo.")]
        public double  Salario { get; set; }

        public Profissional(string nome, string telefone, string email, string senha, int idProfissional, string tipoServico, double salario)
            : base(nome, telefone, email, senha)
        {
            IdProfissional = idProfissional;
            TipoServico = tipoServico;
            Salario = salario;
        }

        public void GerenciarAgenda()
        {
            
        }
    }
}
