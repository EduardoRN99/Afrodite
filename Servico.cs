using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AfroditeClasses.Models
{
    public class Servico
    {
        [Key]
        public int IdServico { get; set; }

        [Required(ErrorMessage = "O nome do serviço é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do serviço deve ter no máximo 100 caracteres.")]
        public string NomeDoServico { get; set; }

        [Required(ErrorMessage = "A categoria do serviço é obrigatória.")]
        [StringLength(50, ErrorMessage = "A categoria do serviço deve ter no máximo 50 caracteres.")]
        public string CategoriaServico { get; set; }

        [Required(ErrorMessage = "O preço do serviço é obrigatório.")]
        [Range(0, 10000, ErrorMessage = "O preço do serviço deve ser entre 0 e 10.000.")]
        public decimal PrecoDoServico { get; set; }

        [StringLength(500, ErrorMessage = "A descrição do serviço deve ter no máximo 500 caracteres.")]
        public string DescricaoServico { get; set; }

        [Required(ErrorMessage = "O tempo do serviço é obrigatório.")]
        public TimeSpan TempoDeServico { get; set; }  // Alterado para TimeSpan, que é mais apropriado para duração

        // Relacionamento com Profissional (1:N)
        public ICollection<Profissional> Profissionais { get; set; }

        public Servico()
        {
            Profissionais = new List<Profissional>();
        }

        // Métodos de serviço (CRUD)
        public void CadastrarServico()
        {
            // Implementação do método para cadastrar o serviço
        }

        public void RemoverServico()
        {
            // Implementação do método para remover o serviço
        }

        public void EditarServico()
        {
            // Implementação do método para editar o serviço
        }
    }
}


