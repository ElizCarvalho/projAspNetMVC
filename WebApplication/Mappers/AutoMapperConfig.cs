using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Mappers
{
	public class AutoMapperConfig
	{
		public static void RegisterMappings()
		{
			Mapper.Initialize(x =>
			{
				x.AddProfile<ModelToViewModelProfile>(); //add perfl de dominio de model para viewmodel
				x.AddProfile<ViewModelToModelProfile>(); //add perfl de dominio de viewmodel para model
			});
		}
	}
}