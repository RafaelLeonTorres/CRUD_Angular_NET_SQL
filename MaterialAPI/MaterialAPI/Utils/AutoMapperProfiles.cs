using AutoMapper;
using MaterialAPI.DTOs;
using MaterialAPI.Models;

namespace MaterialAPI.Utils
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap();
        }

        private void CreateMap()
        {
            CreateMap<Material, MaterialReadDTO>();
            CreateMap<MaterialCreateDTO, Material>();
        }
    }
}
