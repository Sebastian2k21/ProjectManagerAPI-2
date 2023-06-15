using ApplicationCore.Models;
using AutoMapper;
using Infrastructure.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastructure.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Language, LanguageEntity>();
            CreateMap<LanguageEntity, Language>();

            CreateMap<Project, ProjectEntity>();
            CreateMap<ProjectEntity, Project>();

            CreateMap<ProjectStatus, ProjectStatusEntity>();
            CreateMap<ProjectStatusEntity, ProjectStatus>();

            CreateMap<Status, StatusEntity>();
            CreateMap<StatusEntity, Status>();

            CreateMap<Team, TeamEntity>();
            CreateMap<TeamEntity, Team>();

            CreateMap<Tech, TechEntity>();
            CreateMap<TechEntity, Tech>();

            CreateMap<Role, TeamRoleEntity>();
            CreateMap<TeamRoleEntity, Role>();

            CreateMap<User, UserEntity>();
            CreateMap<UserEntity, User>();

            CreateMap<TeamUser, TeamUserEntity>();
            CreateMap<TeamUserEntity, TeamUser>();
        }
    }
}
