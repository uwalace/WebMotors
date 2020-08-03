using AutoMapper;
using WebMotors.Application.Dto;
using WebMotors.Domain.Entities;

namespace WebMotors.Application.AutoMapper
{
	public class MappingAnuncio : Profile
	{
		public MappingAnuncio()
		{
			CreateMap<Anuncio, AnuncioDto>()
				.ForMember(dest => dest.ID, from => from.MapFrom(x => x.ID))
				.ForMember(dest => dest.Marca, from => from.MapFrom(x => x.Marca))
				.ForMember(dest => dest.Modelo, from => from.MapFrom(x => x.Modelo))				
				.ForMember(dest => dest.Versao, from => from.MapFrom(x => x.Versao))
				.ForMember(dest => dest.Ano, from => from.MapFrom(x => x.Ano))
				.ForMember(dest => dest.Quilometragem, from => from.MapFrom(x => x.Quilometragem))
				.ForMember(dest => dest.Observacao, from => from.MapFrom(x => x.Observacao));

			CreateMap<AnuncioDto, Anuncio>()
				.ForMember(dest => dest.ID, from => from.MapFrom(x => x.ID))
				.ForMember(dest => dest.Marca, from => from.MapFrom(x => x.Marca))
				.ForMember(dest => dest.Modelo, from => from.MapFrom(x => x.Modelo))
				.ForMember(dest => dest.Versao, from => from.MapFrom(x => x.Versao))
				.ForMember(dest => dest.Ano, from => from.MapFrom(x => x.Ano))
				.ForMember(dest => dest.Quilometragem, from => from.MapFrom(x => x.Quilometragem))
				.ForMember(dest => dest.Observacao, from => from.MapFrom(x => x.Observacao));

		}
	}
}
