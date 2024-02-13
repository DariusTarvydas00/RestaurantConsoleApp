using System.Text.RegularExpressions;
using ApplicationLayer.IServices.ISpecServices;
using ApplicationLayer.Models.SpecModels;
using AutoMapper;
using DataAccess.Entities.SpecEntities;
using DataAccess.IRepositories;

namespace ApplicationLayer.Services.ModelServices;

public class ProductService(IBaseRepository<ProductEntity?> repository, IMapper mapper)
    : BaseService<ProductEntity, ProductModel>(repository, mapper), IProductService
{
    public ProductModel NewProduct(ProductModel productModel)
    {
        if (string.IsNullOrWhiteSpace(productModel.Name) || !new Regex("^[a-zA-Z ]+$").IsMatch(productModel.Name))
        {
            throw new ArgumentException("Invalid Product Name");
        }
        productModel.Name = char.ToUpper(productModel.Name[0]) + productModel.Name[1..];
        if (string.IsNullOrWhiteSpace(productModel.Description) || !new Regex("^[a-zA-Z ]+$").IsMatch(productModel.Description))
        {
            throw new ArgumentException("Invalid Product Description");
        }
        productModel.Description = char.ToUpper(productModel.Description[0]) + productModel.Description[1..];
        if (Math.Round(productModel.Price, 2) <= 0.0d)
        {
            throw new ArgumentException("Product price cannot be negative or equal to 0.");
        }
        return productModel;
    }
}