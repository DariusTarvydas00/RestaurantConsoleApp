using ApplicationLayer.IServices.ISpecServices;
using ApplicationLayer.Mappers;
using ApplicationLayer.Services.ModelServices;
using DataAccess.Entities.SpecEntities;
using DataAccess.IRepositories;
using DataAccess.Repositories.ModelRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleUi;

public class Startup
{
    public IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();
        services.AddAutoMapper(typeof(MappingProfile));
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<ITableService, TableService>();
        services.AddScoped<IVoucherService, VoucherService>();
        services.AddScoped<IBaseRepository<ProductEntity>, ProductRepository>();
        services.AddScoped<IBaseRepository<OrderEntity>, OrderRepository>();
        services.AddScoped<IBaseRepository<TableEntity>, TableRepository>();
        services.AddScoped<IBaseRepository<VoucherEntity>, VoucherRepository>();
        return services.BuildServiceProvider();
    }
}