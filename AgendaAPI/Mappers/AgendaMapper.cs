using AgendaAPI.DTOs;
using AgendaAPI.Models;
using AutoMapper;

namespace AgendaAPI.Mappers
{
    public class AgendaMapper : Profile
	{
		public AgendaMapper()
		{
			CreateMap<Contato, ContatoDTO>();
			CreateMap<ContatoDTO, Contato>();
		}
	}
}

