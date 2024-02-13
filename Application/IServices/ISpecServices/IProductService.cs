using ApplicationLayer.Models.SpecModels;

namespace ApplicationLayer.IServices.ISpecServices;

public interface IProductService : IBaseService<ProductModel>
{
    public ProductModel NewProduct(ProductModel productModel);
}