using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIMaster.Models;
using WebAPIMaster.Repositories.Interfaces;

namespace WebAPIMaster.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaController(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TarefaModel>>> BuscarTodasTarefas()
        {
            List<TarefaModel> tarefas = await _tarefaRepository.BuscarTodasTarefas();

            if (tarefas.Count == 0)
                return NotFound("Nenhuma tarefa encontrada.");

            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaModel>> BuscarPorId(int id)
        {
            if (!int.TryParse(id.ToString(), out int parsedId))
                return BadRequest("O ID fornecido não é válido.");

            TarefaModel tarefa = await _tarefaRepository.BuscarPorId(parsedId);

            if (tarefa == null)
                return NotFound("A tarefa não foi encontrada.");

            return Ok(tarefa);
        }

        [HttpPost]
        public async Task<ActionResult<TarefaModel>> Cadastrar([FromBody] TarefaModel tarefaModel)
        {
            if (tarefaModel == null)
                return BadRequest("O modelo de tarefa não pode ser nulo.");

            if (string.IsNullOrEmpty(tarefaModel.Nome) || string.IsNullOrEmpty(tarefaModel.Descricao))
                return BadRequest("Nome e Descrição são campos obrigatórios.");

            TarefaModel tarefa = await _tarefaRepository.Adicionar(tarefaModel);

            if (tarefa == null)
                return BadRequest("Falha ao cadastrar a tarefa.");

            return Ok(tarefa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TarefaModel>> Atualizar([FromBody] TarefaModel tarefaModel, int id)
        {
            if (!int.TryParse(id.ToString(), out int parsedId))
                return BadRequest("O ID fornecido não é um válido.");

            tarefaModel.Id = parsedId;
            TarefaModel tarefa = await _tarefaRepository.Atualizar(tarefaModel, parsedId);

            if (tarefa == null)
                return NotFound("O registro não foi encontrado.");

            return Ok(tarefa);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TarefaModel>> Apagar(int id)
        {
            bool apagado;

            if (!int.TryParse(id.ToString(), out int parsedId))
                return BadRequest("O ID fornecido não é válido.");

            apagado = await _tarefaRepository.Apagar(parsedId);

            if (!apagado)
                return NotFound("O registro não foi encontrado.");

            return Ok(apagado);
        }
    }
}
