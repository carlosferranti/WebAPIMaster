using Microsoft.EntityFrameworkCore;
using WebAPIMaster.Data;
using WebAPIMaster.Models;

namespace WebAPIMaster.Repositories.Interfaces
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly UsuariosDBContext _dbContext;

        public TarefaRepository(UsuariosDBContext tarefasDBContext)
        {
            _dbContext = tarefasDBContext;
        }
        public async Task<TarefaModel> BuscarPorId(int id)
        {
            return await _dbContext.Tarefas.FirstOrDefaultAsync(x => x.Id == id);
        }    
        public async Task<TarefaModel?> BuscarPorNome(string nome)
        {
            var tarefa = await _dbContext.Tarefas
                .Where(x => EF.Functions.Like(x.Nome, "%" + nome + "%"))
                .FirstOrDefaultAsync();

            return tarefa; // Este retorno pode ser nulo se nenhuma tarefa for encontrada.
        }
        public async Task<List<TarefaModel>> BuscarTodasTarefas()
        {
            return await _dbContext.Tarefas.ToListAsync();
        }
        public async Task<TarefaModel> Adicionar(TarefaModel tarefa)
        {
            await _dbContext.Tarefas.AddAsync(tarefa);
            await _dbContext.SaveChangesAsync();

            return tarefa;
        }
        public async Task<TarefaModel> Atualizar(TarefaModel tarefa, int id)
        {
            TarefaModel tarefaPorId = await BuscarPorId(id);

            if (tarefaPorId == null)
            {
                throw new Exception($"Tarefa com o ID : {id} não foi encontrado");
            }

            tarefaPorId.Nome = tarefa.Nome;
            tarefaPorId.Descricao = tarefa.Descricao;
            tarefaPorId.Status = tarefa.Status;

            _dbContext.Tarefas.Update(tarefaPorId);
            await _dbContext.SaveChangesAsync();

            return tarefaPorId;
        }
        public async Task<bool> Apagar(int id)
        {
            TarefaModel tarefaPorId = await BuscarPorId(id);

            if (tarefaPorId == null)
            {
                throw new Exception($"Tarefa com o ID : {id} não foi encontrado");
            }
            _dbContext.Tarefas.Remove(tarefaPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
