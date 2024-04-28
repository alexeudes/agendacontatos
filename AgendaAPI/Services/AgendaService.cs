using AgendaAPI.Data.Repositories.Interfaces;
using AgendaAPI.DTOs;
using AgendaAPI.Models;
using AgendaAPI.Services.Interfaces;
using AgendaAPI.Validators;
using AutoMapper;
using FluentValidation;

namespace AgendaAPI.Services
{
    public class AgendaService : IAgendaService
    {
        private readonly IAgendaRepository _agendaRepository;
        private readonly IMapper _mapper;

		public AgendaService(IAgendaRepository agendaRepository, IMapper mapper)
        {
            _agendaRepository = agendaRepository;
            _mapper = mapper;
        }

        public async Task<bool> Create(ContatoDTO contato)
        {
            var contatoMap = _mapper.Map<Contato>(contato);

            var contatoValidator = new ContatoValidator();
            contatoValidator.ValidateAndThrow(contatoMap);

            return await _agendaRepository.Create(contatoMap);
        }

        public async Task<bool> Delete(int id)
        {
            var contato = await _agendaRepository.GetById(id);

            if (contato is null)
                return false;

            return await _agendaRepository.Delete(contato);
        }

        public async Task<IEnumerable<ContatoDTO>> GetAll()
        {
            var contatos = await _agendaRepository.GetAll();
            return contatos.Select(_mapper.Map<ContatoDTO>);
        }

        public async Task<IEnumerable<ContatoDTO>> GetByName(string nome)
        {
            var contatos = await _agendaRepository.GetByName(nome);

            return contatos.Select(_mapper.Map<ContatoDTO>);
        }

        public async Task<bool> Update(ContatoDTO contato)
        {
            var contatoSearched = _agendaRepository.GetById(contato.ID).Result;

            if (contatoSearched is null)
                return false;

            contatoSearched.Nome = contato.Nome ?? contatoSearched.Nome;
            contatoSearched.Telefone = contato.Telefone ?? contatoSearched.Telefone;
            contatoSearched.Email = contato.Email ?? contatoSearched.Email;

            return await _agendaRepository.Update(contatoSearched);
        }
    }
}

