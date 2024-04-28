using AgendaAPI.DTOs;

namespace AgendaAPI.Services.Interfaces
{
    public interface IAgendaService
	{
        Task<IEnumerable<ContatoDTO>> GetAll();
        Task<IEnumerable<ContatoDTO>> GetByName(string nome);
        Task<bool> Create(ContatoDTO contato);
        Task<bool> Update(ContatoDTO contato);
        Task<Boolean> Delete(int id);
    }
}

