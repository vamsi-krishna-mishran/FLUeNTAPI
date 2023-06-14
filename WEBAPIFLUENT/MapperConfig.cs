using AutoMapper;
using WEBAPIFLUENT.DTOs;
using WEBAPIFLUENT.Models;

namespace WEBAPIFLUENT
{
    public class MapperConfig
    {
        public static Mapper InitializeAutomapper()
        {
            //Provide all the Mapping Configuration
            var config = new MapperConfiguration(cfg =>
            {
                //Configuring Employee and EmployeeDTO
                cfg.CreateMap<Product, ProductDTO>()
                //.ForMember(p => p.Id, act => act.MapFrom(dto => dto.Id))
                //.ForMember(p => p.Description, act => act.MapFrom(dto => dto.Description))
                //.ForMember(p=>p.Name,act=>act.MapFrom(dto=>dto.Name))
                .ReverseMap();
                
                //Any Other Mapping Configuration ....
            });
            //Create an Instance of Mapper and return that Instance
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
