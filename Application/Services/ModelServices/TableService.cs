using ApplicationLayer.IServices.ISpecServices;
using ApplicationLayer.Models.SpecModels;
using AutoMapper;
using DataAccess.Entities.SpecEntities;
using DataAccess.IRepositories;

namespace ApplicationLayer.Services.ModelServices;

public class TableService(IBaseRepository<TableEntity?> repository, IMapper mapper)
    : BaseService<TableEntity, TableModel>(repository, mapper), ITableService;