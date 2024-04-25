using System.Data.Entity;
using WebAPIMaster.Data;
using WebAPIMaster.Models;

namespace WebAPIMaster.Repositories.Interfaces
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly TarefasDBContext _dbContext;

        public UsuarioRepository(TarefasDBContext tarefasDBContext)
        {
            _dbContext = tarefasDBContext;
        }
        public async Task<UsuarioModel> BuscarPoId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPoId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário com o ID : {id} não foi encontrado");
            }

            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;

            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return usuarioPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarPoId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário com o ID : {id} não foi encontrado");
            }
            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
