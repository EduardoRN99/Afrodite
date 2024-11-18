using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AfroditeClasses.Models
{
    public class Agenda
    {
        [Key]
        public int IdAgenda { get; set; }

        // Data e hora de início do agendamento.
        [Required(ErrorMessage = "A data e hora de início são obrigatórias.")]
        public DateTime DataHoraInicio { get; set; }

        // Data e hora de término do agendamento.
        [Required(ErrorMessage = "A data e hora de término são obrigatórias.")]
        public DateTime DataHoraFim { get; set; }

        // Relacionamento com o Profissional (N:1). Vários agendamentos podem ser feitos para o mesmo profissional.
        [ForeignKey("Profissional")]
        public int ProfissionalId { get; set; }
        public Profissional Profissional { get; set; }

        // Relacionamento com o Serviço (N:1). Cada agendamento refere-se a um único serviço.
        [ForeignKey("Servico")]
        public int ServicoId { get; set; }
        public Servico Servico { get; set; }

        // Relacionamento com a Reserva (1:N). Um agendamento pode ter várias reservas.
        public ICollection<Reserva> Reservas { get; set; }

        // Construtor
        public Agenda()
        {
            Reservas = new List<Reserva>();
        }
    }
}
