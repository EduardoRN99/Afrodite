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
            SetSenha(senha); // Define a senha e valida a força dela
        }

        private void SetSenha(string senha)  // Método privado SetSenha para validar e definir a senha da pessoa
        {
            if (!ValidarForcaDaSenha(senha)) 
                throw new ArgumentException("A senha deve ter pelo menos 8 caracteres, com letras e números."); // Valida a força da senha e lança uma exceção se não atender aos requisitos

            SenhaHash = GerarHashSenha(senha);  // Gera o hash da senha e armazena em SenhaHash
        }

        public bool ValidarSenha(string senhaDigitada) // Método para validar se uma senha digitada corresponde ao hash da senha armazenada
        {
            string hashDigitado = GerarHashSenha(senhaDigitada);
            return hashDigitado == SenhaHash; // Retorna true se os hashes coincidirem
        }

        public static bool ValidarForcaDaSenha(string senha) // Método estático para validar a força da senha (deve conter letras e números e ter no mínimo 8 caracteres)
        {
            if (string.IsNullOrWhiteSpace(senha) || senha.Length < 8)
                return false; // Retorna false se a senha for nula, vazia ou tiver menos de 8 caracteres

            bool contemLetra = false, contemNumero = false;  // Variáveis para verificar se a senha contém pelo menos uma letra e um número

            foreach (char c in senha)
            {
                if (char.IsLetter(c)) contemLetra = true;
                if (char.IsDigit(c)) contemNumero = true; // Percorre cada caractere da senha e define as variáveis contemLetra e contemNumero

                if (contemLetra && contemNumero) return true; // Se encontrar pelo menos uma letra e um número, retorna true
            }

            return false;
        }

        private string GerarHashSenha(string senha)
        {
            using (var sha256 = SHA256.Create()) // Usa SHA256 para criar o hash
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha)); // Converte a senha em um array de bytes e calcula o hash

                var builder = new StringBuilder();// Constrói uma string hexadecimal do hash
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2")); // Cada byte é convertido em um par hexadecimal
                }
                return builder.ToString(); // Retorna a string final do hash
            }
        }
    }
}
