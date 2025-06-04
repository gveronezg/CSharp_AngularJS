using MeuPrimeiroProjetoCSharp.Models;
using MeuPrimeiroProjetoCSharp.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MeuPrimeiroProjetoCSharp.Dtos;

namespace MeuPrimeiroProjetoCSharp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuariosController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IEnumerable<UsuarioDto>> Get()
        {
            var usuarios = await _usuarioService.GetAll();
            return _mapper.Map<IEnumerable<UsuarioDto>>(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDto>> Get(int id)
        {
            var usuario = await _usuarioService.GetById(id);
            if (usuario == null) return NotFound();
            return _mapper.Map<UsuarioDto>(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Post(UsuarioCreateDto usuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            var created = await _usuarioService.Create(usuario);
            var usuarioRetorno = _mapper.Map<UsuarioDto>(created);

            return CreatedAtAction(nameof(Get), new { id = usuarioRetorno.Id }, usuarioRetorno);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UsuarioCreateDto usuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            var updated = await _usuarioService.Update(id, usuario);

            if (updated == null) return NotFound();

            var usuarioRetorno = _mapper.Map<UsuarioDto>(updated);
            return Ok(usuarioRetorno);
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
