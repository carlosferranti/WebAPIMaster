using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIMaster.Models;
using WebAPIMaster.Repositories.Interfaces;

namespace WebAPIMaster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios()
        {
            List<UsuarioModel> usuarios = await _usuarioRepository.BuscarTodosUsuarios();

            if (usuarios.Count == 0)
                return NotFound("Nenhum usuário encontrado.");

            return Ok(usuarios);
        }          
        
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> BuscarPorId(int id)
        {
            if (!int.TryParse(id.ToString(), out int parsedId))
                return BadRequest("O ID fornecido não é válido.");

            UsuarioModel usuario = await _usuarioRepository.BuscarPorId(parsedId);

            if (usuario == null)
                return NotFound("O usuário não foi encontrado.");

            return Ok(usuario);
        }
      
        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuarioModel)
        {
            if (usuarioModel == null)
                return BadRequest("O modelo de usuário não pode ser nulo.");

            if (string.IsNullOrEmpty(usuarioModel.Nome) || string.IsNullOrEmpty(usuarioModel.Email))
                return BadRequest("Nome e Email são campos obrigatórios.");

            UsuarioModel usuario = await _usuarioRepository.Adicionar(usuarioModel);

            if (usuario == null)
                return BadRequest("Falha ao cadastrar o usuário.");

            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody] UsuarioModel usuarioModel, int id)
        {
            if (!int.TryParse(id.ToString(), out int parsedId))
                return BadRequest("O ID fornecido não é um válido.");

            usuarioModel.Id = parsedId;
            UsuarioModel usuario = await _usuarioRepository.Atualizar(usuarioModel, parsedId);

            if (usuario == null)
                return NotFound("O registro não foi encontrado.");

            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> Apagar(int id)
        {
            bool apagado;

            if (!int.TryParse(id.ToString(), out int parsedId))
                return BadRequest("O ID fornecido não é válido.");

            apagado = await _usuarioRepository.Apagar(parsedId);

            if (!apagado)
                return NotFound("O registro não foi encontrado.");

            return Ok(apagado);
        }
    }
}
