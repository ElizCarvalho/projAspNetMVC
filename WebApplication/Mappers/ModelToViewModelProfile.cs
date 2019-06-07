using AutoMapper;
using WebApplication.Models;

namespace WebApplication.Mappers
{
	public class ModelToViewModelProfile : Profile
	{
		protected override void Configure()
		{
			Mapper.CreateMap<Pessoa, PessoaViewModel>();
		}
	}
}