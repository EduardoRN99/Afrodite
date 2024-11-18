using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace AfroditeClasses.Models
{
    public class Pessoa
    {
        [Key] // Definindo a chave primária
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

        // A propriedade Salt armazena o valor adicional para aumentar a segurança da senha
        [Required(ErrorMessage = "A senha é obrigatória.")]
        [MinLength(8, ErrorMessage = "A senha deve ter pelo menos 8 caracteres.")]
        public string SenhaHash { get; private set; }

        [NotMapped] // Essa propriedade não será mapeada para o banco de dados
        public string Salt { get; private set; } // Usado internamente para validar a senha de forma segura

        // Construtor que inicializa as propriedades básicas e chama o método SetSenha
        public Pessoa(string nome, string telefone, string email, string senha)
        {
            Nome = nome;
            Telefone = telefone;
            Email = email;
            SenhaHash = string.Empty; // A senha inicia como string vazia
            SetSenha(senha); // Chamando o método para definir a senha e gerar o hash
        }

        // Método para definir a senha, verificando sua força e gerando o hash com o salt
        private void SetSenha(string senha)
        {
            if (!SenhaEhForte(senha))
                throw new ArgumentException("A senha deve ter pelo menos 8 caracteres, com letras e números.");

            Salt = GerarSalt(); // Gerando um salt único para cada senha
            SenhaHash = GerarHashSenha(senha, Salt); // Gerando o hash da senha usando o salt
        }

        // Método para validar se a senha digitada corresponde ao hash armazenado
        public bool ValidarSenha(string senhaDigitada)
        {
            string hashDigitado = GerarHashSenha(senhaDigitada, Salt);
            return hashDigitado == SenhaHash;
        }

        // Método estático que verifica se a senha é forte, contendo letras e números
        public static bool SenhaEhForte(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha) || senha.Length < 8)
                return false; // Senha fraca se for nula ou menor que 8 caracteres

            bool contemLetra = false, contemNumero = false;

            // Verificação se a senha contém pelo menos uma letra e um número
            foreach (char c in senha)
            {
                if (char.IsLetter(c)) contemLetra = true;
                if (char.IsDigit(c)) contemNumero = true;

                // Se encontrar uma letra e um número, a senha é considerada forte
                if (contemLetra && contemNumero) return true;
            }

            return false; // Senha considerada fraca se não atender aos requisitos
        }

        // Método para gerar um salt aleatório
        private string GerarSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        // Método para gerar o hash da senha combinando-a com o salt
        private string GerarHashSenha(string senha, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                // Combinando a senha com o salt antes de gerar o hash
                byte[] senhaComSalt = Encoding.UTF8.GetBytes(senha + salt);
                byte[] hash = sha256.ComputeHash(senhaComSalt); // Calculando o hash

                var builder = new StringBuilder(); // Usando StringBuilder para construir a string do hash
                foreach (var b in hash)
                {
                    builder.Append(b.ToString("x2")); // Convertendo cada byte para hexadecimal
                }
                return builder.ToString(); // Retornando o hash final
            }
        }
    }
}

