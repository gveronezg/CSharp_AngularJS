using MeuPrimeiroProjetoCSharp.Models; // Importa o namespace Models para usar a classe Usuario
using MeuPrimeiroProjetoCSharp.Data;  // Importa o namespace Data para usar o DbContext
using Microsoft.EntityFrameworkCore; // Importa o namespace EntityFrameworkCore

namespace MeuPrimeiroProjetoCSharp.Services // Define o namespace para os serviços da aplicação
{
    public class UsuarioService : IUsuarioService // Define a classe UsuarioService que implementa a interface IUsuarioService
    {
        private readonly MeuDbContext _context; // Declara um campo privado para armazenar o contexto do banco de dados

        public UsuarioService(MeuDbContext context) // Define o construtor da classe UsuarioService
        {
            _context = context; // Inicializa o contexto do banco de dados
        }

        public async Task<IEnumerable<Usuario>> GetAll() // Define o método assíncrono para obter todos os usuários
        {
            return await _context.Usuarios.ToListAsync(); // Retorna uma lista de todos os usuários do banco de dados
        }

        public async Task<Usuario?> GetById(int id) // Define o método assíncrono para obter um usuário pelo ID
        {
            return await _context.Usuarios.FindAsync(id); // Retorna o usuário com o ID especificado, ou null se não encontrado
        }

        public async Task<Usuario> Create(Usuario usuario) // Define o método assíncrono para criar um novo usuário
        {
            _context.Usuarios.Add(usuario); // Adiciona o usuário ao contexto do banco de dados
            await _context.SaveChangesAsync(); // Salva as mudanças no banco de dados
            return usuario; // Retorna o usuário criado
        }

        public async Task<Usuario?> Update(int id, Usuario usuario) // Define o método assíncrono para atualizar um usuário existente
        {
            var existing = await _context.Usuarios.FindAsync(id); // Busca o usuário existente no banco de dados
            if (existing == null) return null; // Se o usuário não existir, retorna null

            existing.Nome = usuario.Nome; // Atualiza o nome do usuário
            existing.Email = usuario.Email; // Atualiza o email do usuário

            await _context.SaveChangesAsync(); // Salva as mudanças no banco de dados
            return existing; // Retorna o usuário atualizado
        }

        public async Task<bool> Delete(int id) // Define o método assíncrono para excluir um usuário
        {
            var usuario = await _context.Usuarios.FindAsync(id); // Busca o usuário no banco de dados
            if (usuario == null) return false; // Se o usuário não existir, retorna false

            _context.Usuarios.Remove(usuario); // Remove o usuário do contexto do banco de dados
            await _context.SaveChangesAsync(); // Salva as mudanças no banco de dados
            return true; // Retorna true para indicar que o usuário foi excluído com sucesso
        }
    }
}
