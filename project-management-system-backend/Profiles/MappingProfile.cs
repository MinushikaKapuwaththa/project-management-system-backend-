using AutoMapper;
using project_management_system_backend.Dtos.ClientDtos;
using project_management_system_backend.Dtos.CompanyDtos;
using project_management_system_backend.Dtos.ProjectDtos;
//using project_management_system_backend.Dtos.TaskDtos;


namespace project_management_system_backend.Profiles

{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.Project, ProjectDto>();
            CreateMap<Models.Project, ProjectForCreationDto>().ReverseMap();
            CreateMap<Models.Project, ProjectForUpdateDto>().ReverseMap();

            CreateMap<Models.Company, CompanyDto>();
            CreateMap<Models.Company, CompanyForCreationDto>().ReverseMap();
            CreateMap<Models.Company, CompanyForUpdateDto>().ReverseMap();

            CreateMap<Models.Client, ClientDto>();
            CreateMap<Models.Client, ClientForCreationDto>().ReverseMap();
            CreateMap<Models.Client, ClientForUpdateDto>().ReverseMap();

            //CreateMap<Models.Task, TasksDto>();
            //CreateMap<Models.Task, TaskForCreationDto>().ReverseMap();



        }
    }
}
