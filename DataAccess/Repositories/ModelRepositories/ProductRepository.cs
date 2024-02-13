using DataAccess.Entities.SpecEntities;
using DataAccess.IRepositories;

namespace DataAccess.Repositories.ModelRepositories;

public class ProductRepository() : BaseRepository<ProductEntity>(@"C:\\Restaurant\\product.json"), IProductRepository;