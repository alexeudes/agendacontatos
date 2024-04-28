using AgendaAPI.Models;

namespace AgendaAPI.Data.Repositories.Interfaces
{
    public interface IAgendaRepository
    {
        Task<IEnumerable<Contato>> GetAll();
        Task<IEnumerable<Contato>> GetByName(string nome);
        Task<bool> Create(Contato contato);
        Task<bool> Update(Contato contato);
        Task<bool> Delete(Contato contato);
        Task<Contato> GetById(int id);
    }
}

