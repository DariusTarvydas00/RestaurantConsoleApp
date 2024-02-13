using ApplicationLayer.IServices.ISpecServices;
using ApplicationLayer.Models.SpecModels;
using AutoMapper;
using DataAccess.Entities.SpecEntities;
using DataAccess.IRepositories;

namespace ApplicationLayer.Services.ModelServices;

public class VoucherService(IBaseRepository<VoucherEntity?> repository, IMapper mapper)
    : BaseService<VoucherEntity, VoucherModel>(repository, mapper), IVoucherService;