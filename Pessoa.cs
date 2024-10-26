using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace AfroditeClasses.Models
{
    public class Pessoa
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [Phone(ErrorMessage = "Telefone inválido.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [MinLength(8, ErrorMessage = "A senha deve ter pelo menos 8 caracteres.")]
        public string SenhaHash { get; private set; }

        public Pessoa(string nome, string telefone, string email, string senha)
        {
            Nome = nome;
            Telefone = telefone;
            Email = email;
            SenhaHash = string.Empty; // Inicializa com uma string vazia
            SetSenha(senha);
        }

        private void SetSenha(string senha)
        {
            if (!ValidarForcaDaSenha(senha))
                throw new ArgumentException("A senha deve ter pelo menos 8 caracteres, com letras e números.");

            SenhaHash = GerarHashSenha(senha);
        }

        public bool ValidarSenha(string senhaDigitada)
        {
            string hashDigitado = GerarHashSenha(senhaDigitada);
            return hashDigitado == SenhaHash;
        }

        public static bool ValidarForcaDaSenha(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha) || senha.Length < 8)
                return false;

            bool contemLetra = false, contemNumero = false;

            foreach (char c in senha)
            {
                if (char.IsLetter(c)) contemLetra = true;
                if (char.IsDigit(c)) contemNumero = true;

                if (contemLetra && contemNumero) return true;
            }

            return false;
        }

        private string GerarHashSenha(string senha)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
                var builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}

