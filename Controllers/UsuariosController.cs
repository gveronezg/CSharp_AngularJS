using MeuPrimeiroProjetoCSharp.Models;
using MeuPrimeiroProjetoCSharp.Services;
using Microsoft.AspNetCore.Mvc;

namespace MeuPrimeiroProjetoCSharp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<IEnumerable<Usuario>> Get()
        {
            return await _usuarioService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> Get(int id)
        {
            var usuario = await _usuarioService.GetById(id);
            if (usuario == null) return NotFound();
            return usuario;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            var created = await _usuarioService.Create(usuario);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Usuario usuario)
        {
            var updated = await _usuarioService.Update(id, usuario);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _usuarioService.Delete(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}