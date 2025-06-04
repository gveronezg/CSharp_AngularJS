namespace MeuPrimeiroProjetoCSharp.Dtos
{
    public class UsuarioDto
    {
        public int Id { get; set; } // Id do usuário
        public required string Nome { get; set; } // Nome do usuário
        public required string Email { get; set; } // Email do usuário
    }
}