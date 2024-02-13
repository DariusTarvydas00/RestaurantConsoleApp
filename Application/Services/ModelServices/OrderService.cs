using ApplicationLayer.IServices.ISpecServices;
using ApplicationLayer.Models.SpecModels;
using AutoMapper;
using DataAccess.Entities.SpecEntities;
using DataAccess.IRepositories;

namespace ApplicationLayer.Services.ModelServices;

public class OrderService(IBaseRepository<OrderEntity?> repository, IMapper mapper)
    : BaseService<OrderEntity, OrderModel>(repository, mapper), IOrderService;