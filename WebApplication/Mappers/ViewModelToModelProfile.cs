using AutoMapper;
using WebApplication.Models;

namespace WebApplication.Mappers
{
	public class ViewModelToModelProfile : Profile
	{
		protected override void Configure()
		{
			Mapper.CreateMap<PessoaViewModel, Pessoa>();
		}
	}
}