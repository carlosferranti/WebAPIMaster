﻿using WebAPIMaster.Models;

namespace WebAPIMaster.Repositories.Interfaces
{
    public interface ITarefaRepository
    {

        Task<List<TarefaModel>> BuscarTodasTarefas();
        Task<TarefaModel> BuscarPorId(int id);
        Task<TarefaModel> BuscarPorNome(string nome);
        Task<TarefaModel> Adicionar(TarefaModel tarefa);
        Task<TarefaModel> Atualizar(TarefaModel tarefa, int id);
        Task<bool> Apagar(int id);
    }
}
