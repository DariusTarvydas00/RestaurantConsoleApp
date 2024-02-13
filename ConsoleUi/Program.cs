using ApplicationLayer.IServices.ISpecServices;
using ConsoleUi.Controllers.ModelControllers;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleUi;

internal class Program
{
    private static void Main(string[] args)
    {
        var startup = new Startup();
        var serviceProvider = startup.ConfigureServices();
        using var scope = serviceProvider.CreateScope();
        var serviceProviderScope = scope.ServiceProvider;
        var app = new ConsoleApp(
            new ProductController(serviceProviderScope.GetRequiredService<IProductService>()),
            new TableController(serviceProviderScope.GetRequiredService<ITableService>()),
            new OrderController(serviceProviderScope.GetRequiredService<IOrderService>()),
            new VoucherController(serviceProviderScope.GetRequiredService<IVoucherService>())
        );
        app.Run();
    }
}