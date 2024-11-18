using System;
using MySqlConnector;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AfroditeClasses.Models
{
    public class Avaliacao
    {
        [Key]
        public int IdAvaliacao { get; set; }

        [Range(1, 5, ErrorMessage = "A nota deve ser entre 1 e 5.")]
        public int Nota { get; set; }

        [StringLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres.")]
        public string Descricao { get; set; }

        // Relacionamento com Cliente (N:1)
        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        // Relacionamento com Profissional (N:1)
        [ForeignKey("Profissional")]
        public int ProfissionalId { get; set; }
        public Profissional Profissional { get; set; }

        // Relacionamento com Servico (N:1)
        [ForeignKey("Servico")]
        public int ServicoId { get; set; }
        public Servico Servico { get; set; }
    }
}
