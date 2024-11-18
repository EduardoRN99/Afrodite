using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AfroditeClasses.Models
{
    public class Notificacao
    {
        [Key]
        public int IdNotificacao { get; set; }

        // Mensagem da notificação.
        [Required(ErrorMessage = "A mensagem da notificação é obrigatória.")]
        [StringLength(500, ErrorMessage = "A mensagem deve ter no máximo 500 caracteres.")]
        public string Mensagem { get; set; }

        // Data e hora em que a notificação foi enviada.
        [Required(ErrorMessage = "A data e hora de envio são obrigatórias.")]
        public DateTime DataHoraEnvio { get; set; }

        // Tipo de notificação (ex: Reserva Confirmada, Agenda Alterada, etc.).
        [Required(ErrorMessage = "O tipo de notificação é obrigatório.")]
        public string TipoNotificacao { get; set; }

        // Relacionamento com o Cliente (N:1). Uma notificação pode ser enviada a um cliente.
        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        // Relacionamento com o Profissional (N:1). Uma notificação pode ser enviada a um profissional.
        [ForeignKey("Profissional")]
        public int ProfissionalId { get; set; }
        public Profissional Profissional { get; set; }

        // Construtor
        public Notificacao()
        {
            DataHoraEnvio = DateTime.Now;
        }
    }
}

