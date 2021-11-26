using AutoMapper;
using ProjetoModeloDDD.Domain.DTOs.OutputModels;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Infra.CrossCutting
{
    public class MappingProfile : Profile
    {
        public  MappingProfile()
        {
            CreateMap<PessoaEntity, PessoaOutputModel>().ReverseMap();
        }
    }
}
