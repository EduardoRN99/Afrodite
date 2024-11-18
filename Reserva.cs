using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AfroditeClasses.Models
{
    public class Reserva
    {
        [Key]
        public int IdReserva { get; set; }

        // Data e hora em que a reserva foi feita.
        [Required(ErrorMessage = "A data e hora da reserva são obrigatórias.")]
        public DateTime DataHoraReserva { get; set; }

        // Relacionamento com o Cliente (N:1). Cada reserva é feita por um único cliente.
        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        // Relacionamento com a Agenda (N:1). Cada reserva é associada a um agendamento.
        [ForeignKey("Agenda")]
        public int AgendaId { get; set; }
        public Agenda Agenda { get; set; }

        // Status da reserva (Ex: Confirmada, Cancelada, Pendente)
        [Required(ErrorMessage = "O status da reserva é obrigatório.")]
        public string StatusReserva { get; set; }

        // Construtor
        public Reserva()
        {
            // Inicializar com valores padrão.
            StatusReserva = "Pendente";  // Status inicial
        }
    }
}

