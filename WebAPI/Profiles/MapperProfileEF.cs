using ApplicationCore.Models;
using AutoMapper;
using ProjectManagerApi.Dto;

namespace ProjectManagerApi.Profiles
{
    public class MapperProfileEF : Profile
    {
        public MapperProfileEF()
        {
            CreateMap<RegisterDto, User>();
            CreateMap<ProjectDto, Project>();
            CreateMap<ProjectUpdateDto, Project>();
            CreateMap<Project, ProjectGetDto>()
                .ForMember(dest => dest.Languages, opt => opt.MapFrom(src => src.Languages.Select(x => x.LanguageId).ToList()))
                .ForMember(dest => dest.Technologies, opt => opt.MapFrom(src => src.Technologies.Select(x => x.TechId).ToList()));

            CreateMap<Language, LanguageDto>();
            CreateMap<LanguageDto, Language>();
            CreateMap<AddLanguageDto, Language>();
            CreateMap<Language,AddLanguageDto>();

            CreateMap<Tech,TechDto>();
            CreateMap<TechDto, Tech>();
            CreateMap<AddTechDto, Tech>();
            CreateMap<Tech,AddTechDto>();

            CreateMap<User, UserGetDto>();

        }
    }
}
