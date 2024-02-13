using ApplicationLayer.Models.SpecModels;
using AutoMapper;
using DataAccess.Entities.SpecEntities;

namespace ApplicationLayer.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<VoucherModel, VoucherEntity>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.OrderEntity, opt => opt.MapFrom(src => src.OrderModel));
        CreateMap<VoucherEntity, VoucherModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.OrderModel, opt => opt.MapFrom(src => src.OrderEntity));
        CreateMap<ProductEntity, ProductModel>();
        CreateMap<ProductModel, ProductEntity>();
        CreateMap<TableEntity, TableModel>();
        CreateMap<TableModel, TableEntity>();
        CreateMap<OrderModel, OrderEntity>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.TableEntity, opt => opt.MapFrom(src => src.TableModel))
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.ProductModels));
        CreateMap<OrderEntity, OrderModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.TableModel, opt => opt.MapFrom(src => src.TableEntity))
            .ForMember(dest => dest.ProductModels, opt => opt.MapFrom(src => src.Products));
    }
}