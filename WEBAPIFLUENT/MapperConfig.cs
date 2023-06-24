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
                cfg.CreateMap<Varient, VarientDTO>()
                .ReverseMap();
                cfg.CreateMap<Board, BoardDTO>().ReverseMap();
                cfg.CreateMap<Rivision, RivisionDTO>().ReverseMap();
                cfg.CreateMap<Identity, IdentityDTO>().ReverseMap();
                cfg.CreateMap<BareBoardDetails,BareBoardDTO>().ReverseMap();
                cfg.CreateMap<AssembledBoardDetails, AssembledBoardDTO>().ReverseMap();
                cfg.CreateMap<Heading, HeadingDTO>().ReverseMap();
                cfg.CreateMap<SubHeading, SubHeadingDTO>().ReverseMap();
                cfg.CreateMap<User, UserDTO>().ReverseMap();
                cfg.CreateMap<PowerUpTest, PowerUpDTO>().ReverseMap();  
                cfg.CreateMap<SubHeadingImages, SubHeadingImagesDTO>().ReverseMap();
                cfg.CreateMap<XLSheet, XLSheetDTO>().ReverseMap();
                cfg.CreateMap<XLTamplate,XLTemplateDTO>().ReverseMap();
                //Any Other Mapping Configuration ....
            });
            //Create an Instance of Mapper and return that Instance
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
