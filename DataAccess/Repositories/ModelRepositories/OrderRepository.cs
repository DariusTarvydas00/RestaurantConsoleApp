using DataAccess.Entities.SpecEntities;
using DataAccess.IRepositories;

namespace DataAccess.Repositories.ModelRepositories;

public class OrderRepository() : BaseRepository<OrderEntity>(@"C:\\Restaurant\\order.json"), IOrderRepository;