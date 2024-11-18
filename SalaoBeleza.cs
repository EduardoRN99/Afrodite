using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MySqlConnector;

namespace AfroditeClasses.Models
{
    public class SalaoBeleza
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O endereço é obrigatório.")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "O nome fantasia é obrigatório.")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "O horário de funcionamento é obrigatório.")]
        public DateTime HorarioDeFuncionamento { get; set; }

        public List<Profissional> Profissionais { get; set; }
        public List<Servico> Servicos { get; set; }

        public SalaoBeleza(string endereco, string nomeFantasia, DateTime horarioDeFuncionamento)
        // Construtor que inicializa as propriedades do salão e cria listas vazias para profissionais e serviços
        {
            Endereco = endereco;
            NomeFantasia = nomeFantasia;
            HorarioDeFuncionamento = horarioDeFuncionamento;
            Profissionais = new List<Profissional>();
            Servicos = new List<Servico>();
        }

        public bool AdicionarProfissional(Profissional profissional)
        {
            if (profissional == null || Profissionais.Contains(profissional))
                return false;

            Profissionais.Add(profissional);
            return true;
        }

        public bool EditarProfissional(int idProfissional, Profissional profissionalAtualizado)  // Método para editar as informações de um profissional, localizando-o pelo ID
        {
            var profissional = Profissionais.Find(p => p.IdProfissional == idProfissional); // Busca o profissional com o ID fornecido
            if (profissional == null)
                return false;

            profissional.Nome = profissionalAtualizado.Nome;
            profissional.Telefone = profissionalAtualizado.Telefone;
            profissional.Email = profissionalAtualizado.Email;
            profissional.TipoServico = profissionalAtualizado.TipoServico;
            profissional.Salario = profissionalAtualizado.Salario;
            return true;
        }

        public bool RemoverProfissional(int idProfissional)
        {
            var profissional = Profissionais.Find(p => p.IdProfissional == idProfissional);
            if (profissional == null)
                return false;

            Profissionais.Remove(profissional);
            return true;
        }

        public List<Profissional> ListarProfissionais() // Método para listar todos os profissionais cadastrados no salão
        {
            return Profissionais;
        }

        public bool AdicionarServico(Servico servico) // Método para adicionar um serviço ao salão, verificando se ele não é nulo e se não já está na lista
        {
            if (servico == null || Servicos.Contains(servico))
                return false;

            Servicos.Add(servico);
            return true;
        }

        public bool EditarServico(int idServico, Servico servicoAtualizado)
        {
            var servico = Servicos.Find(s => s.IdServico == idServico);
            if (servico == null)
                return false;

            servico.NomeDoServico = servicoAtualizado.NomeDoServico;
            servico.CategoriaServico = servicoAtualizado.CategoriaServico;
            servico.PrecoDoServico = servicoAtualizado.PrecoDoServico;
            servico.DescricaoServico = servicoAtualizado.DescricaoServico;
            servico.TempoDeServico = servicoAtualizado.TempoDeServico; // Atualiza as propriedades do serviço
            return true; 
        }

        public bool RemoverServico(int idServico)
        {
            var servico = Servicos.Find(s => s.IdServico == idServico);
            if (servico == null)
                return false;

            Servicos.Remove(servico);
            return true;
        }

        public List<Servico> ListarServicos()
        {
            return Servicos;
        }
    }
}

