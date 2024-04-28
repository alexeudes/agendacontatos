using AgendaAPI.Data.Repositories.Interfaces;
using AgendaAPI.Models;

namespace AgendaAPI.Data.Repositories
{
    public class AgendaRepository : IAgendaRepository
    {
        private readonly DataContext _context;

        public AgendaRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Contato contato)
        {
            _context.Add(contato);
            return await SaveChangesAsync();
        }

        public async Task<bool> Delete(Contato contato)
        {
            _context.Remove(contato);
            return await SaveChangesAsync();
        }

        public async Task<bool> Update(Contato contato)
        {
            _context.Update(contato);
            return await SaveChangesAsync();
        }

        public async Task<IEnumerable<Contato>> GetAll()
        {
            return _context.Contatos.ToList();
        }

        public async Task<IEnumerable<Contato>> GetByName(string nome)
        {
            return _context.Contatos.Where(c => c.Nome.ToLower().Contains(nome.ToLower()));
        }        

        private async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Contato> GetById(int id)
        {
            return _context.Contatos.Where(c => c.ID == id).FirstOrDefault();
        }
    }
}

