using AgendaAPI.Mappers;
using AutoMapper;

namespace AgendaAPI.Test.Mapper
{
    public static class Mapper
	{
		public static IMapper MapperHelper()
		{
			var map = new MapperConfiguration(opt =>
			{
				opt.AddProfile(new AgendaMapper());
			});

			var mapper = map.CreateMapper();

			return mapper;
		}
	}
}

