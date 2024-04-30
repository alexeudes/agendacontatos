using AgendaAPI.DTOs;

namespace AgendaAPI.Services.Interfaces
{
    public interface IAgendaService
	{
        Task<IEnumerable<ContatoDTO>> GetAll();
        Task<IEnumerable<ContatoDTO>> GetByName(string nome);
        Task<ContatoDTO> GetById(string id);
        Task<bool> Create(ContatoDTO contato);
        Task<bool> Update(ContatoDTO contato);
        Task<bool> Delete(int id);
    }
}

