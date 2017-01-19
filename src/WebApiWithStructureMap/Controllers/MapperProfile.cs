using AutoMapper;
using Core = WebApiWithStructureMap.Models.Core;
using Dto = WebApiWithStructureMap.Models.Dto;

namespace WebApiWithStructureMap.Controllers
{
    public class MapperProfile :
        Profile
    {
        public MapperProfile()
        {
            CreateMap<Core.MyObject, Dto.MyObjectDto>();
            CreateMap<Core.MyObject, Dto.MyObjectUpdateDto>();
            CreateMap<Dto.MyObjectInsertDto, Core.MyObject>();
            CreateMap<Dto.MyObjectUpdateDto, Core.MyObject>();
        }
    }
}