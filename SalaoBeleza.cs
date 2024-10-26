using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        public bool EditarProfissional(int idProfissional, Profissional profissionalAtualizado)
        {
            var profissional = Profissionais.Find(p => p.IdProfissional == idProfissional);
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

        public List<Profissional> ListarProfissionais()
        {
            return Profissionais;
        }

        public bool AdicionarServico(Servico servico)
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
            servico.TempoDaServico = servicoAtualizado.TempoDaServico;
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

