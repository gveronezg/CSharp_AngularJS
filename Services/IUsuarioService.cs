// Define os namespaces necessários
using MeuPrimeiroProjetoCSharp.Models; // Importa o namespace Models para usar a classe Usuario
using System.Collections.Generic; // Importa o namespace Collections.Generic para usar a interface IEnumerable
using System.Threading.Tasks; // Importa o namespace Threading.Tasks para usar a classe Task

namespace MeuPrimeiroProjetoCSharp.Services // Define o namespace para os serviços da aplicação
{
    // Define a interface IUsuarioService
    public interface IUsuarioService
    {
        // Declara um método assíncrono para obter todos os usuários
        Task<IEnumerable<Usuario>> GetAll();

        // Declara um método assíncrono para obter um usuário pelo ID
        Task<Usuario?> GetById(int id);

        // Declara um método assíncrono para criar um novo usuário
        Task<Usuario> Create(Usuario usuario);

        // Declara um método assíncrono para atualizar um usuário existente
        Task<Usuario?> Update(int id, Usuario usuario);

        // Declara um método assíncrono para excluir um usuário
        Task<bool> Delete(int id);
    }
}
